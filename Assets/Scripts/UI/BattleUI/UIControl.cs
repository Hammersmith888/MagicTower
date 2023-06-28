using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using ADs;
using System;

public class UIControl : UI.UIBackbtnClickDispatcher
{
    [SerializeField] private Camera uiCamera;

    [SerializeField] private GameObject pauseGO;
    [SerializeField] private Transform dynamicUIParent;
    [SerializeField] private GameObject textOnStartOfLvl;
    [SerializeField] private Text bossLabel;

    public GameObject panelEasyMod;

    private LivesManager _liveManager;
    [HideInInspector] public bool showDamageView;
    private ObjectsPoolMono<EnemyGoldText> enemyGoldTextPool;
    private ObjectsPoolMono<CoinDoubleHelper> coinDoudleHelperPool;
    private ObjectsPoolMono<DamageView> damageViewPool;

    [SerializeField] GameObject fireWorks;
    public UIBlackPatch BlackScreen;
    List<DataSpawn> listOfHit = new List<DataSpawn>();
    private static int interstitialCounter;
    public static int countRestart = 0;
    public bool x2Power = false;
    public static event Action OnPlayerClick;

    class DataSpawn
    {
        public DamageView.DamageViewData data;
        public int damage;
    }

    private static UIControl current;

    public static UIControl Current
    {
        get
        {
            if (current == null)
            {
                current = FindObjectOfType<UIControl>();
            }

            return current;
        }
    }

    public static Camera UICamera
    {
        get { return current == null ? null : current.uiCamera; }
    }

    private void Awake()
    {
        // uiCamera = Camera.main;
        SetCurrentBackButtonDispatcher(this);
        current = this;
        _liveManager = LivesManager.Instance;
        enemyGoldTextPool =
            new ObjectsPoolMono<EnemyGoldText>(Resources.Load("UI/EnemyGoldTxt") as GameObject, dynamicUIParent, 4);
        coinDoudleHelperPool =
            new ObjectsPoolMono<CoinDoubleHelper>(Resources.Load("UI/CoinDoubleTemplate") as GameObject,
                dynamicUIParent, 4);
        damageViewPool =
            new ObjectsPoolMono<DamageView>(Resources.Load("UI/DamageViewTemplate") as GameObject, dynamicUIParent, 4);
        Time.timeScale = LevelSettings.defaultUsedSpeed;
    }

    private void Start()
    {
        Debug.Log($"======================= GAME ==========================");
        UISettingsPanel.SettingsGame settingsGame =
            PPSerialization.Load(EPrefsKeys.SettingsGame.ToString(), new UISettingsPanel.SettingsGame());
        showDamageView = settingsGame.damageViewOn;
        if (textOnStartOfLvl != null)
        {
            textOnStartOfLvl.SetActive(true);
        }

        ReSetLevelText();

        if (textOnStartOfLvl != null)
        {
            StartCoroutine(Fade(2f, textOnStartOfLvl.GetComponent<CanvasGroup>()));
        }

        if (UIControl.countRestart >= 3)
        {
            StartCoroutine(EasyPanel());
        }
        OnPlayerClick += LevelNext;

    }

    private IEnumerator EasyPanel()
    {
        yield return new WaitForSeconds(0.5f);
        UIControl.countRestart = 0;
        panelEasyMod.SetActive(true);

        UIPauseController.Instance.pauseCalled = true;
        UIPauseController.Instance.Pause();
    }

    public void YesEasy()
    {
        if (!AdsManager.Instance.isAnyVideAdAvailable)
            return;
        AdsManager.ShowVideoAd((bool value) =>
        {
            if (value)
            {
                x2Power = true;
            }
        });
        Continue();
        panelEasyMod.SetActive(false);
    }

    public void NoEasy()
    {
        Continue();
        panelEasyMod.SetActive(false);
    }

    public void HardPause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        UIPauseController.Instance.Continue();
    }

    /// <summary>
    ///positionOnScreen is position in screen coordinates
    /// </summary>
    public static void SpawnEnemyGoldText(Vector3 positionOnScreen, string text)
    {
        if (current != null)
        {
            current.enemyGoldTextPool.GetObjectFromPool()
                .Spawn(current.uiCamera.ScreenToWorldPoint(positionOnScreen), text);
        }
    }

    /// <summary>
    /// positionOnScreen is position in screen coordinates
    /// </summary>
    public static void SpawnCoinDoubleHelper(Vector3 positionOnScreen)
    {
        if (current != null && current.coinDoudleHelperPool != null)
        {
            current.coinDoudleHelperPool.GetObjectFromPool()
                .Spawn(current.uiCamera.ScreenToWorldPoint(positionOnScreen));
        }
    }

    public static void SpawnDamageView(Vector3 pos, int damage, DamageView.DamageViewData damageViewData,
        bool isDeath = false, bool delay = false)
    {
        if (current != null && current.damageViewPool != null && current.showDamageView)
            //current.StartCoroutine(current._Spawn(current.uiCamera.ScreenToWorldPoint(pos), damage, damageViewData, isDeath));
            // current.SpawnDamage(current.uiCamera.ScreenToWorldPoint(pos), damage, damageViewData, isDeath);
            current.damageViewPool.GetObjectFromPool().Spawn(current.uiCamera.ScreenToWorldPoint(pos), damage,
                damageViewData, isDeath, delay);
    }

    public void SpawnDamage(Vector3 pos, int damage, DamageView.DamageViewData damageViewData, bool isDeath = false)
    {
        // Debug.Log("SpawnDamage");
        //current.damageViewPool.GetObjectFromPool().Spawn(current.uiCamera.ScreenToWorldPoint(pos), damage, damageViewData, isDeath);
        //StartCoroutine(_Spawn(current.uiCamera.ScreenToWorldPoint(pos), damage, damageViewData, isDeath));
    }

    IEnumerator _Spawn(Vector3 pos, int damage, DamageView.DamageViewData damageViewData, bool isDeath = false)
    {
        listOfHit.Add(new DataSpawn {damage = damage, data = damageViewData});
        current.damageViewPool.GetObjectFromPool()
            .Spawn(current.uiCamera.ScreenToWorldPoint(pos), damage, damageViewData, isDeath);
        yield return new WaitForEndOfFrame();

    }

    public void Restart()
    {
        UIControl.countRestart++;
        CoinsManager.AddCoinsST(FinishMenu.instance.uiTotal.GetCoins());
        AnalyticsController.Instance.EndProgressionEvent(mainscript.CurrentLvl, 0, false);
        PPSerialization.SaveAllPendingSaves();
        if (_liveManager.canPlay() || UIEditorMenu.EditorWasLoaded)
            //		if( CheckEnergyForStartPlaying() || UIEditorMenu.EditorWasLoaded )
        {
            DecEnergy();
            CloudConnector.Instance = null; // Необходимо только для редактора, в финальной версии убрать
            //SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
            UIBlackPatch.Current.AppearInt(SceneManager.GetActiveScene().buildIndex);
            Continue();
            //FlurryController.instanse.logMyEvent ("LevelRestart");
            if (LevelSettings.Current != null)
            {
                LevelSettings.Current.LogLevelEnd("LevelRestart");
            }
            //AnalyticsController.instanse.LogMyEvent( "LevelRestart", new Dictionary<string, string> { { "level", GameObject.FindObjectOfType<LevelSettings>()._currentLevel.ToString() } } );
        }
        else
        {
            mainscript.ZeroEnergy = true;
            ToMap();
        }

        SoundController.Instanse.StopAllMusic();
    }

    void DecEnergy()
    {
        if (UIEditorMenu.EditorWasLoaded)
            return;

        if (_liveManager.canLooseLife())
        {
            _liveManager.looseOneLife();
        }
    }

    private bool CheckEnergyForStartPlaying()
    {
        return !SaveManager.Energy.Current.IsEmty;
    }

    public void ToLevel(string _levelName)
    {
        Continue();
        //SceneManager.LoadScene(_levelName);
        if (PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0) == 1)
        {
            UIBlackPatch.Current.Appear("Map");
        }
        else
        {
            UIBlackPatch.Current.Appear(_levelName);
        }
    }
    

    public Vector3 GetScreenPosition(Vector3 pos)
    {
        return current.uiCamera.ScreenToWorldPoint(pos);
    }

    public void ToMap()
    {
        AnalyticsController.Instance.EndProgressionEvent(mainscript.CurrentLvl, 0, false);
        Continue();
        SoundController.Instanse.StopAllBackgroundSFX();
        CloudConnector.Instance = null;
        //SceneManager.LoadScene("Map");

        CoinsManager.AddCoinsST(FinishMenu.instance.uiTotal.GetCoins());


        int openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        if (PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0) == 1)
        {
            UIBlackPatch.Current.Appear("Map");
        }
        else
        {
            if (openLevel > 0)
            {
                UIBlackPatch.Current.Appear("Map");
            }
            else
            {
                UIBlackPatch.Current.Appear("Menu");
            }
        }

        DisableLevelAmbient();
        PPSerialization.SaveAllPendingSaves();
        //SceneManager.LoadScene("MainMenu");
    }

    private void DisableLevelAmbient()
    {
        SoundController.Instanse.ambientSFX.Stop();
    }

    public void Exit()
    {
        AnalyticsController.Instance.EndProgressionEvent(mainscript.CurrentLvl, 0, false);
        PPSerialization.SaveAllPendingSaves();
        Continue();
        //SceneManager.LoadScene("MainMenu");
        UIBlackPatch.Current.Appear("MainMenu");
        DisableLevelAmbient();
    }

    public void ToShop(bool nextLevel = false)
    {
        AnalyticsController.Instance.EndProgressionEvent(mainscript.CurrentLvl, 0, false);
        PPSerialization.SaveAllPendingSaves();
        Continue();
        SoundController.Instanse.StopAllBackgroundSFX();
        //Debug.Log($"PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0): {PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0)}");

        // if nextLevel == true then we go to the next level
        if (nextLevel)
        {
            // save current level in memory 
            int nextLevelID = mainscript.CurrentLvl + 1;
            PlayerPrefs.SetString("currentLvl", nextLevelID.ToString());
            UIEditorMenu.loadedFile = nextLevelID.ToString();
            mainscript.CurrentLvl = nextLevelID;

            // load next level
            UIBlackPatch.Current.Appear("Level_1_Tutorial");
        }


        if (PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0) == 1)
        {
            UIBlackPatch.Current.Appear("Map");
        }
        else
        {
            UIBlackPatch.Current.Appear("Shop");
        }

        DisableLevelAmbient();
    }

    public void ToMenuEditor()
    {
        Continue();
        UIBlackPatch.Current.Appear("MenuEditor");
        DisableLevelAmbient();
    }

    bool takeBag = false;

    public void Next()
    {
        AnalyticsController.Instance.LogMyEvent("press_continue",
            new Dictionary<string, string>() {{"CompleteLevel", mainscript.CurrentLvl.ToString()}});

        if (CrownsController.instance.isAward && !takeBag)
        {
            takeBag = true;
            FinishMenu.instance.uiTotal.levelGoldCoinsFlyAnimation.gameObject.SetActive(false);
            FinishMenu.instance.uiTotal.playerHealthCoinsFlyAnimation.gameObject.SetActive(false);
            CrownsController.instance.OpenBagAwardPanel();
            return;
        }
        Debug.LogError("curLevel: "+mainscript.CurrentLvl+"sl: "+ RemoteController.Instance.GetStartLevel()+"rl: "+ RemoteController.Instance.GetRateRound());
        if (mainscript.CurrentLvl >= RemoteController.Instance.GetStartLevel() && !ADs.AdsManager.CheckAdsState())
        {
            if (((mainscript.CurrentLvl - RemoteController.Instance.GetStartLevel())% RemoteController.Instance.GetRateRound() == 0))
            {
                ADs.AdsManager.RequestAndShowInterstitial(onInterstitialComplete: UIBlackPatch.Current.LoadPendingScene);
            }
            LevelStartAction(interstitialCounter != 0);

            interstitialCounter++;
            if (interstitialCounter == RemoteController.Instance.GetRateRound())
            {
                interstitialCounter = 0;
            }
        }
        else
        {
            LevelStartAction();
        }
        bool nextLevel = mainscript.CurrentLvl < 7;
        ToShopFromFirstLevel(nextLevel);
        CrownsController.instance.Save();
        fireWorks.SetActive(false);
        OnPlayerClick?.Invoke();
    }
    private void LevelNext()
    {
        AnalyticsController.Instance.LogMyEvent("LevelNext");
    }

    private void LevelStartAction(bool loadSceneAutomatically = true)
    {
        StartCoroutine(_OpenLevel(loadSceneAutomatically));
    }

    IEnumerator _OpenLevel(bool loadSceneAutomatically = true)
    {
        while (AdsPreview.instance.isShow)
            yield return null;

        DecEnergy();
        SoundController.Instanse.StopAllBackgroundSFX();
        UIBlackPatch.Current.Appear("Level_1_Tutorial",loadSceneAutomatically);
        SoundController.Instanse.PlayMapNextLevelSFX();
    }

    public void TakeBagAward()
    {
        //if(takeBag)
        //{
        //    ToShopFromFirstLevel();
        //    CrownsController.instance.Save();
        //    fireWorks.SetActive(false);
        //    takeBag = true;
        //}
        //else
        //    CrownsController.instance.CloseAwardBag();

        takeBag = true;

        CrownsController.instance.CloseAwardBag();
    }

    public void ToShopFromFirstLevel(bool nextLevel = false)
    {
        CoinsManager.AddCoinsST(FinishMenu.instance.uiTotal.GetCoins());
        ToShop(nextLevel);
        // Eugene show shop staff after levels
        if (CheckIsNeedShowShopStaff())
        {
            ShopUpgradeItemSettings.IsShowStaffPanelWhenShopOpen = true;
        }
    }

    public void ReSetLevelText()
    {
        if (textOnStartOfLvl != null)
            textOnStartOfLvl.GetComponent<Text>().text = textOnStartOfLvl.GetComponent<LocalTextLoc>().CurrentText.Replace("#", (LevelSettings.Current.currentLevel + 1).ToString());
    }

    private IEnumerator Fade(float startFadeDelay, CanvasGroup canvasGroup)
    {
        yield return new WaitForSeconds(startFadeDelay);
        canvasGroup.GetComponent<Outline>().enabled = false;
        while (canvasGroup.alpha > 0)
        {                   //use "< 1" when fading in
            canvasGroup.alpha -= Time.deltaTime;    //fades out over 1 second. change to += to fade in    
            yield return null;
        }
    }

    public void ShowBoss()
    {
        bossLabel.gameObject.SetActive(true);
    }

    // Eugene show shop staff after levels
    private bool CheckIsNeedShowShopStaff()
    {
        bool isShow = false;
        int levNum = LevelSettings.Current.currentLevel;
        switch (levNum)
        {
                case 8:
                case 19:
                case 39:
                case 53:
                    isShow = true;
                    break;
        }
        return isShow;
    }

    public void ToRateApp()
    {
        AnalyticsController.Instance.LogMyEvent("PauseRateUS");
#if UNITY_ANDROID
        //Application.OpenURL("https://play.google.com/store/apps/details?id=com.akpublish.magicsiege");
        Application.OpenURL("market://details?id=com.akpublish.magicsiege");
#elif UNITY_IOS
		Application.OpenURL( "https://itunes.apple.com/us/app/magic-siege-defender-hd/id1369002248" );
#endif
    }
}