
#pragma warning disable CS0649
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIContinueGame : MonoBehaviour
{
    public bool startTimer;

    [SerializeField]
    public GameObject defeatMenu;

    [SerializeField]
    private GameObject ressurectionPoisons;

    [SerializeField]
    private Text timer;

    [SerializeField]
    private Text amountOFRessurection;

    private TimeSpan ts;
    private LevelSettings levelSettings;

    [SerializeField]
    private Sprite SpendResurrection, GetResurrection;

    [SerializeField] private PoisonsManager _currentRessurection;

    private void Awake()
    {
        levelSettings = LevelSettings.Current;
    }

    private bool wasOnceEnabled;
    private bool showingAds;
    bool waitingClick = false;

    private void OnEnable()
    {
        int openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        levelSettings.pauseObj.pauseCalled = true;
        showingAds = false;
        Debug.Log($"PotionManager.GetPotionsNumber(PotionManager.EPotionType.Resurrection) : {PoisonsManager.Get(PotionManager.EPotionType.Resurrection).CurrentPotion }");
        if (PoisonsManager.Get(PotionManager.EPotionType.Resurrection).CurrentPotion == 0)
        {
            bool isAnyGameProgressChanges = false;
            if (SaveManager.GameProgress.Current.freeResurrectionUsedOnLevel == null)
            {
                SaveManager.GameProgress.Current.freeResurrectionUsedOnLevel = new int[1000];
            }
            if (PlayerPrefs.GetInt("VideoViewsLeft0") > 0 && openLevel >= 6 && SaveManager.GameProgress.Current.freeResurrectionUsedOnLevel[levelSettings.currentLevel] == 0)
            {
                if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
                {
                    isAnyGameProgressChanges = true;
                    SaveManager.GameProgress.Current.freeResurrectionUsedOnLevel[levelSettings.currentLevel] = 3;
                    showingAds = true;
                    transform.Find("Continue").GetComponent<Image>().sprite = GetResurrection;
                    transform.Find("Continue").GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {
                transform.Find("Continue").GetComponent<Image>().sprite = SpendResurrection;
                transform.Find("Continue").GetChild(0).gameObject.SetActive(true);
            }
            SaveManager.GameProgress.Current.Save();
        }
        else
        {
            transform.Find("Continue").GetComponent<Image>().sprite = SpendResurrection;
            transform.Find("Continue").GetChild(0).gameObject.SetActive(true);
        }
        ts = new TimeSpan(0, 0, 4);
        timer.text = ts.Seconds.ToString();
        startTimer = true;
        StartCoroutine(StartCountdown());

        SetupAmountOfPoisons(_currentRessurection.CurrentPotion);

        SoundController.Instanse.PauseGamePlaySFX();
        SoundController.Instanse.playTimerContinueSFX();
    }

    public void CallRestoreLogic()
    {
        StartCoroutine(RestoreByPotion());
    }

    private IEnumerator RestoreByPotion()
    {
        waitingClick = true;
        int openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        ts = new TimeSpan(0, 0, 7);
        if (showingAds)
        {
            if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
            {
                ADs.AdsManager.ShowVideoAd((bool result) =>
               {
                   if (result)
                   {
                       SaveManager.GameProgress.Current.freeResurrectionUsedOnLevel[levelSettings.currentLevel] = 2;
                       SaveManager.GameProgress.Current.Save();
                       PlayerPrefs.SetInt("VideoViewsLeft0", PlayerPrefs.GetInt("VideoViewsLeft0") - 1);
                       var obj = PoisonsManager.Get(PotionManager.EPotionType.Resurrection);
                       obj.Save(PotionManager.EPotionType.Resurrection, obj.CurrentPotion + 3);
                       PlayerController.Instance.ContinueGame();
                   }
               });
            }
        }
        else
            PlayerController.Instance.ContinueGame();
        yield break;
    }

    public void continueTimer()
    {
        StopAllCoroutines();
        ts = new TimeSpan(0, 0, 7);
        SetupAmountOfPoisons(_currentRessurection.CurrentPotion);
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (startTimer)
        {
            //if (waitingClick)
            //{
            //    yield return new WaitForSecondsRealtime(0.1f);
            //}
            yield return new WaitForSecondsRealtime(1.0f);
            CountDownTimer();
        }
    }

    private void CountDownTimer()
    {
        ts = ts.Subtract(TimeSpan.FromSeconds(1));

        timer.text = ts.Seconds.ToString();
        if (ts <= new TimeSpan(0))
        {
            startTimer = false;
            ShowDefeat();
        }
    }

    public void ShowDefeat()
    {
        waitingClick = false;
        EnemiesGenerator.Instance.DisableAllEnemies();
        levelSettings.FinalScoreDefeat();
        levelSettings.wonFlag = true;

        PlayerController.Instance.ShowDefeat();
        gameObject.SetActive(false);

        var _infoAnim = GameObject.FindObjectOfType<UIInfoAnimation>();
        if (_infoAnim != null)
        {
            _infoAnim.gameObject.SetActive(false);
        }
        SoundController.Instanse.stopAmbientSFX();
        SoundController.Instanse.PauseGamePlaySFX();
        SoundController.Instanse.PlayDefeatLevelSFX();
        mainscript.level15restart++;
    }

    private void Update()
    {
        Time.timeScale = 0;
    }

    [SerializeField]
    private Text amonText;
    private void SetupAmountOfPoisons(int amount)
    {
        amountOFRessurection.text = amonText.text.Replace("#", amount.ToString());
    }

    //уменшить количесво бутилок воскрешения
    public void ContinueGame(PoisonsManager ressurection)
    {
        levelSettings.pauseObj.pauseCalled = false;
    }

    public void NotEnoughBottles()
    {
        string _buyMore = transform.Find("_buyMoreBottlesText").GetComponent<Text>().text;
        string text = _buyMore;
        amountOFRessurection.text = text;
        ressurectionPoisons.SetActive(true);
        ressurectionPoisons.transform.parent.gameObject.SetActive(true);
        //TODO: if tansaction crashed ShowDefeat()
    }
}
