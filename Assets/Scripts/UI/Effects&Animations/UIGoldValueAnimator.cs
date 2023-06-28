using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoldValueAnimator : MonoBehaviour
{
    #region VARIABLES
    public Text currentLvl; //Поле отображает текущий уровень 
    public LevelSettings levelSettings; // берем значение для установления maxNumber

    private int minNumber; //Число с которого начинается анимация
    private int maxNumber; //Число которым заканчивается анимация

    [SerializeField]
    private float startCoinsAnimationDelay;

    public Text    text;

    [SerializeField]
    private GameObject VideoAdsButton;
    [SerializeField]
    public Transform HealthbarGroup, CoinsLevelTransform, VIPobj;

    [SerializeField]
    [Header("Coins Fly Animation")]
    private Transform           coinsFlyTargetPosition;
    [SerializeField]
    public UIConsFlyAnimation  levelGoldCoinsFlyAnimation;
    [SerializeField]
    public UIConsFlyAnimation  playerHealthCoinsFlyAnimation;

    public bool initialAnimationComplete;

    public bool hidePanels = false;
    [SerializeField]
    bool defeat = false;
    public Animator _animDefeat, _animDefeat2;

    private bool doubleCoinsPush = false;
    
    #endregion

    void Awake()
    {
        text = transform.GetComponent<Text>();
        text.text = "0";

        //устанавливаем номер текущего уровня
        levelSettings = LevelSettings.Current;
        currentLvl.text = "" + EndlessMode.EndlessModeManager.Current != null ? (levelSettings.currentLevel + 1).ToString() : ""; // можна добавить STAGE или что то

        SoundController.Instanse.PauseGamePlaySFX();
    }

    public void SetGold(int value)
    {
        maxNumber += value;
        text.text = maxNumber.ToString();
        //FinishMenu.instance.videoX2Coins += value;
    }

    public int GetCoins()
    {
        return maxNumber;
    }

    void OnEnable()
    {
        //initialAnimationComplete = true;
        if (VideoAdsButton != null)
        {
            //VideoAdsButton.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
           // StartCoroutine(CheckVideoConnection());
        }
        StartCoroutine(ShowCount());
    }

    private IEnumerator CheckVideoConnection(float checkAfterDelay = 0)
    {
        yield return new WaitForSecondsRealtime(checkAfterDelay / FinishMenu.instance.indexSpeed);
        if (VideoAdsButton == null)
            yield break;
        WWW www = new WWW("https://www.google.com");
        yield return www;
        if (String.IsNullOrEmpty(www.error) && ADs.AdsManager.Instance.isAnyVideAdAvailable)
        {
            VideoAdsButton.SetActive(true);
        }
        //else
        //{
        //    VideoAdsButton.SetActive(false);
        //    StartCoroutine(CheckVideoConnection(1f));
        //}
    }

    private IEnumerator ShowCount()
    {

        if (VIPobj != null)
        {
            VIPobj.gameObject.SetActive(levelSettings.VIPenabled);
        }
        initialAnimationComplete = false;
        yield return new WaitForSecondsRealtime(startCoinsAnimationDelay / FinishMenu.instance.indexSpeed);

        var trCoins = CoinsLevelTransform.parent.parent;
        CoinsLevelTransform.parent.SetParent(transform.parent.parent.parent);
        Text coinsTop = CoinsLevelTransform.GetComponent<Text>();

        int level = mainscript.CurrentLvl - 1;
        level = level < 0 ? 0 : level;  // fix this problem...

        int earngedGoldOnLevelWithoutMultiplicators = int.Parse(coinsTop.text);
        int earnedGold = Mathf.RoundToInt(earngedGoldOnLevelWithoutMultiplicators * levelSettings.goldenMageCoef);
        int healthGold = 0;
        int health = (int)levelSettings.playerController.CurrentHealth;
        if (health < 0)
        {
            health = 0;
        }
        healthGold = Mathf.RoundToInt(health * levelSettings.goldenMageCoef);

        minNumber = 0;
        if (level <= 1 && SaveManager.GameProgress.Current.finishCount[level] < 2)
        {
            minNumber += levelSettings.TutorAddCoins;
        }
        maxNumber = minNumber + earnedGold;
        float steps = 10;
        float addIterationTime = 1f;
        if (levelGoldCoinsFlyAnimation != null && coinsFlyTargetPosition != null)
        {
            if(!defeat)
                levelGoldCoinsFlyAnimation.PlayEffect(FinishMenu.instance.lineCoins[1].targetCoins.position);
            else
                levelGoldCoinsFlyAnimation.PlayEffect(FinishMenu.instance.lineCoinsDefeat[0].targetCoins.position);
        }
        float stepTime = addIterationTime / steps;
        float progress = 0;
        for (int i = 1; i <= steps; i++)
        {
            progress = (i / steps);
            FinishMenu.instance.lineCoins[1].text.text = ((int)(minNumber + earnedGold * progress)).ToString();
            FinishMenu.instance.lineCoinsDefeat[0].text.text = ((int)(minNumber + earnedGold * progress)).ToString();
            coinsTop.text = ((int)(earngedGoldOnLevelWithoutMultiplicators - (1f - progress))).ToString();
            SoundController.Instanse.playAddCoinSFX();
            yield return new WaitForSecondsRealtime(stepTime / FinishMenu.instance.indexSpeed);
        }
        CoinsLevelTransform.parent.SetParent(trCoins);
        coinsTop.text = "0";
        FinishMenu.instance.lineCoins[1].text.text = (maxNumber).ToString();
        FinishMenu.instance.lineCoinsDefeat[0].text.text = (maxNumber).ToString();
        yield return new WaitForSecondsRealtime(0.5f / FinishMenu.instance.indexSpeed);
        FinishMenu.instance.lineCoins[1].panel.GetComponent<Animator>().enabled = true;
        FinishMenu.instance.lineCoinsDefeat[0].panel.GetComponent<Animator>().enabled = true;
        yield return new WaitForSecondsRealtime(0.5f / FinishMenu.instance.indexSpeed);
        text.text = maxNumber.ToString();

        if (healthGold > 0)
        {
            trCoins = HealthbarGroup.parent.parent;
            HealthbarGroup.parent.SetParent(transform);
            minNumber = maxNumber;
            maxNumber = minNumber + healthGold;
            levelSettings.playerController.haveToExchangeHP = true;
            float currentHealth = levelSettings.playerController.CurrentHealth;
            steps = 50f;
            if (playerHealthCoinsFlyAnimation != null && coinsFlyTargetPosition != null)
            {
                playerHealthCoinsFlyAnimation.PlayEffect(FinishMenu.instance.lineCoins[0].targetCoins.position);
            }
            progress = 0;
            stepTime = addIterationTime / steps;
            for (int i = 1; i <= steps; i++)
            {
                //text.text = ((int)(minNumber + (maxNumber - minNumber) * i / steps)).ToString();
                FinishMenu.instance.lineCoins[0].text.text = ((int)(healthGold * i / steps)).ToString();
                levelSettings.playerController.CurrentHealth -= currentHealth / (float)steps;
                SoundController.Instanse.playAddCoinSFX();
                yield return new WaitForSecondsRealtime(stepTime / FinishMenu.instance.indexSpeed);
            }
            levelSettings.playerController.CurrentHealth = 0;
           // text.text = (maxNumber).ToString();
            FinishMenu.instance.lineCoins[0].text.text = (healthGold).ToString();
            yield return new WaitForSecondsRealtime(0.5f / FinishMenu.instance.indexSpeed);
            FinishMenu.instance.lineCoins[0].panel.GetComponent<Animator>().enabled = true;
            yield return new WaitForSecondsRealtime(0.5f / FinishMenu.instance.indexSpeed);
            text.text = (maxNumber).ToString();
        }

        if (levelSettings.VIPenabled && VIPobj != null)
        {
            yield return new WaitForSecondsRealtime(0.3f / FinishMenu.instance.indexSpeed);
            StartCoroutine(ShowVipSignAnim());
            minNumber = maxNumber;
            maxNumber = (int)((float)maxNumber * 1.5f);
            addIterationTime = 1f;
            steps = 50;
            stepTime = addIterationTime / steps;
            progress = 0;
            for (int i = 1; i <= steps; i++)
            {
                progress = i / steps;
                text.text = ((int)(minNumber + (maxNumber - minNumber) * progress)).ToString();
                SoundController.Instanse.playAddCoinSFX();
                yield return new WaitForSecondsRealtime(stepTime / FinishMenu.instance.indexSpeed);
            }
            Debug.Log($"minNumber: {minNumber} , maxNumber: {maxNumber}");
            text.text = (maxNumber).ToString();
        }
        initialAnimationComplete = true;
        if (doubleCoinsPush)
        {
            text.text = (maxNumber).ToString();
        }

        HealthbarGroup.parent.SetParent(transform.parent.transform.parent.transform.parent);

        HealthbarGroup.parent.SetParent(trCoins);
        yield break;
    }

    private IEnumerator ShowVipSignAnim()
    {
        Image VIPimage = VIPobj.GetComponent<Image>();
        float tempTimer = 0.35f;
        float timeStart = Time.unscaledTime;
        float timeElapsed = 0;
        Color color = VIPimage.color;
        while (timeElapsed < tempTimer)
        {
            timeElapsed = Time.unscaledTime - timeStart;
            color.a = timeElapsed / tempTimer;
            VIPimage.color = color;
            yield return null;
        }
    }


    //метод для кнопки x2 coins for video ads
    public void ShowVideoAds()
    {
        //if (Application.internetReachability == NetworkReachability.NotReachable || !CASAdsController.Instance.IsRewardedLoaded())
        //{
        //    FinishMenu.instance.Tips();
        //    return;
        //}

        StopCoroutine(CheckVideoConnection());

        ADs.AdsManager.ShowVideoAd((bool viewResult) =>
        {
            if (viewResult)
            {
                DoubleCoins();
            }
        });
    }

    public void DoubleCoins()
    {
        Debug.Log($"maxNumber: {maxNumber}, x2 finish: {(FinishMenu.instance != null ? FinishMenu.instance.videoX2Coins : 0)}");
        CoinsManager.AddCoinsST(FinishMenu.instance != null ? FinishMenu.instance.videoX2Coins : 0);
        FinishMenu.instance.isWatchedVideo = true;

        foreach (var o in FinishMenu.instance.btnx2Sprites)
            o.gameObject.SetActive(false);

        StartCoroutine(DoubleCoinsAnimation());
    }

    private IEnumerator DoubleCoinsAnimation()
    {
        doubleCoinsPush = true;

        while (!initialAnimationComplete)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }

        minNumber = int.Parse(text.text);
        var max = int.Parse(text.text) * 2;
        float addIterationTime = 1f;
        float steps = 20;
        float progress = 0;
        for (int i = 1; i <= steps; i++)
        {
            progress = i / steps;
            text.text = ((int)(minNumber + (max - minNumber) * progress)).ToString();
            SoundController.Instanse.playAddCoinSFX();
            yield return new WaitForSecondsRealtime((addIterationTime / steps) / FinishMenu.instance.indexSpeed);
        }
        text.text = (max).ToString();
    }

    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
           FinishMenu.instance.UpdateBtnConnection();
        }
    }
}
