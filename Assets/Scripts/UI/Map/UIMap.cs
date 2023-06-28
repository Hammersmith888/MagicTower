using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Tutorials;

public class UIMap : UI.UIBackbtnClickDispatcher, UI.IOnbackButtonClickListener
{
    #region VARIABLES
    private const string PRESENT_NAME_FORMAT = "Present_{0}-{1}";
    private const string LEVEL_TO_LOAD = "Level_1_Tutorial";
    private const string MapOpenShownIdPrefsKey = "MapOpenShownId";
    private const string FacebookLoginPromptWasShow = "FacebookLoginOnMapPromptWasShown";

    private const int SHOW_INTERSTITIAL_ON = 3;
    private const float CLOUDS_X_OFFSET = 45f;

    private const int MinLevelToShowFriendsInviteWindow = 15;

    private static int interstitialCounter;

    public Transform LevelsTransform;
    public GameObject CurrentLevelImage;
    public GameObject scrollLock;
    public Transform Clouds;
    [SerializeField]
    private RectTransform Map;
    [SerializeField]
    private ScrollRect mapScrollRect;
    [SerializeField]
    private Transform[] cloudUnits;
    [SerializeField]
    private RectTransform mapObjectsParent;
    [SerializeField]
    private RectTransform canvasRect;

    public UIBlackPatch BlackScreen;
    public int maxLevelNumber = 40;
    private LivesManager _liveManager;

    [SerializeField]
    private GameObject energyControll;
    [SerializeField]
    List<int> levelDisableEffectBoss = new List<int>();

    [SerializeField]
    private UIMapLevelData[] levelsUIData;

    [SerializeField]
    private AnimationCurve scrollToLevelAnimationCurve;


    public static int currentLevel;


    [SerializeField]
    BossProgress bossProgress;


    [SerializeField]
    private Transform _targetBoss;

    [SerializeField]
    bool testEffectToBoss = false;
    [SerializeField]
    int testLevelEffect = 0;

    [SerializeField]
    GameObject prefabMapEffetc;

    #endregion

    public List<GameObject> objsPanels = new List<GameObject>();
    public List<Transform> childPanels = new List<Transform>();

    public UIConsFlyAnimation flyCoins;
    public Transform coinTargetEffect;

    [SerializeField]
    GameObject[] clouds;

    public GameObject btnDailyRewards;

    private int m_OpenLevel = -1;

    //public static GameObject imgRateMage;
    //public GameObject blocker;
    private int OpenLevel
    {
        get
        {
            return m_OpenLevel;
        }

        set
        {
            m_OpenLevel = value;
            InfoLoaderConfig.Instance.maxOpenedLevel = m_OpenLevel;
        }
    }

    public bool isUpdateViewComplete
    {
        get; private set;
    }

    public bool IsNewLevelUnlocked
    {
        get
        {
            OpenLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
            return !PlayerPrefs.HasKey(MapOpenShownIdPrefsKey) || PlayerPrefs.GetInt(MapOpenShownIdPrefsKey) < OpenLevel;
        }
    }

    private Camera mainCamera;
    private Camera getMainCamera
    {
        get
        {
            if (mainCamera == null)
            {
                mainCamera = Helpers.getMainCamera;
            }
            return mainCamera;
        }
    }

    private static UIMap current;
    public static UIMap Current
    {
        get
        {
            if (current == null)
            {
                current = FindObjectOfType<UIMap>();
            }
            return current;
        }
    }


    override protected bool IsBackButtonClicked
    {
        get
        {
            return (BlackScreen.isOuted && base.IsBackButtonClicked && !UI.UIWindowBase.isAnyWindowActive);
        }
    }

#if UNITY_EDITOR
    [SerializeField]
    private bool pickUILevelsData_EDITOR;
    private void OnDrawGizmosSelected()
    {
        if (pickUILevelsData_EDITOR)
        {
            pickUILevelsData_EDITOR = false;
            if (LevelsTransform != null)
            {
                levelsUIData = LevelsTransform.GetComponentsInChildren<UIMapLevelData>();
            }
        }
    }

    public void UpdateLevelUIDataInEditor()
    {
        if (LevelsTransform != null)
        {
            levelsUIData = LevelsTransform.GetComponentsInChildren<UIMapLevelData>();
        }
    }
#endif

    private void Awake()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        //blocker.SetActive(false);
        current = this;
        SetCurrentBackButtonDispatcher(this);
        AddOnBackButtonListener(this);
        mainscript.AutoUnlockPlayerUpgrades();

        for (int i = 0; i < levelsUIData.Length; i++)
        {
            levelsUIData[i].Init((i + 1 > maxLevelNumber ? maxLevelNumber : i + 1), OnLevelButtonClick);
        }
        UIControl.countRestart = 0;

        //imgRateMage = GameObject.FindGameObjectWithTag("ImageMageRate");
        //imgRateMage.SetActive(false);

#if DEBUG_MODE
        Core.DebugGameEventsMono.DebugEvents.AddListenerToEvent(Core.DebugGameEvents.EDebugEvent.MAP_COMPLETE_LVL, CompleteLevelDebug);
#endif
    }

    public void Start()
    {
        Debug.Log($"======================= MAP ==========================");
        StartCoroutine(UnlockInputCoroutine(2));
        try
        {
            SaveManager.GameProgress.Current.Save(true);
        }
        catch (System.Exception e) { Debug.LogError(e.Message); }
        _liveManager = LivesManager.Instance;

        UpdateClouds();

        UpdateView();
        SoundController.Instanse.StopAllBackgroundSFX();
        SoundController.Instanse.PlayMapSFX();

        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 5 && !PlayerPrefs.HasKey("OfferWasShowLevel5"))
        {
            PlayerPrefs.SetInt("OfferWasShowLevel5", 0);
            PlayerPrefs.Save();
            Tutorial.OpenBlock(timer: 2f);
        }
    }

    private IEnumerator UnlockInputCoroutine(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        UnlockInput();
    }

    public void Share()
    {
        ShareController.instance.Share();
    }

    public void UpdateClouds()
    {
        //var boss = false;
        //if (mainscript.CurrentLvl == 15 || mainscript.CurrentLvl == 30 || mainscript.CurrentLvl == 45 || mainscript.CurrentLvl == 70
        //    || mainscript.CurrentLvl == 95)
        //    boss = true;
        int level = 0;
        for (int i = 0; i < SaveManager.GameProgress.Current.finishCount.Length; i++)
        {
            if (SaveManager.GameProgress.Current.finishCount[i] == 0)
            {
                level = i + 1;
                break;
            }
        }
        btnDailyRewards.gameObject.SetActive(SaveManager.GameProgress.Current.tutDailyReward);
        clouds[0].SetActive(level <= 15);
        clouds[1].SetActive(level <= 30);
        clouds[2].SetActive(level <= 45);
        clouds[3].SetActive(level <= 70);
        levelsUIData[29].shadowImageChanger.gameObject.SetActive(level < 31);

        if(level > 15)
            levelsUIData[14].shadowImageChanger.SetColor(Color.gray);
        if (level > 30)
            levelsUIData[29].shadowImageChanger.SetColor(Color.gray);
        if (level > 45)
            levelsUIData[44].shadowImageChanger.SetColor(Color.gray);
        if (level > 70)
            levelsUIData[69].shadowImageChanger.SetColor(Color.gray);
        if (level > 95)
            levelsUIData[94].shadowImageChanger.SetColor(Color.gray);
    }

    public void OnBackButtonClick()
    {
        ToMenu();
    }

    public void ToMenu()
    {
        SoundController.Instanse.StopAllBackgroundSFX();
        if (BlackScreen.IsPlaying)
        {
            return;
        }
        BlackScreen.Appear("Menu");
    }


    private void OnLevelButtonClick(int _levelID)
    {
        PlayerPrefs.SetString("currentLvl", _levelID.ToString());
        UIEditorMenu.loadedFile = _levelID.ToString();
        mainscript.CurrentLvl = _levelID;
        ToLevel(LEVEL_TO_LOAD);
    }

    private string needToLoadLevel;
    private void ToLevel(string _levelName)
    {
        needToLoadLevel = _levelName;
        if (_liveManager.canPlay())
        {
            Debug.Log("mainscript.CurrentLvl: " + mainscript.CurrentLvl);
            //if (mainscript.CurrentLvl >= RemoteController.Instance.GetStartLevel() && !ADs.AdsManager.CheckAdsState())
            //{
            //    if (interstitialCounter == 0)
            //    {
            //        ADs.AdsManager.RequestAndShowInterstitial(onInterstitialComplete: UIBlackPatch.Current.LoadPendingScene);
            //    }
            //    LevelStartAction(interstitialCounter != 0);

            //    interstitialCounter++;
            //    if (interstitialCounter == RemoteController.Instance.GetRateRound())
            //    {
            //        interstitialCounter = 0;
            //    }
            //}
            //else
            //{
                LevelStartAction();
            //}
        }
        else
        {
            energyControll.GetComponent<ShopEnergy>().OpenInfo();
        }

    }

    IEnumerator _OpenLevel(bool loadSceneAutomatically = true)
    {
        while (AdsPreview.instance.isShow)
            yield return null;

        DecEnergy();
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear(needToLoadLevel, loadSceneAutomatically);
        SoundController.Instanse.PlayMapNextLevelSFX();
    }

    private void LevelStartAction(bool loadSceneAutomatically = true)
    {
        StartCoroutine(_OpenLevel(loadSceneAutomatically));
    }

    private void DecEnergy()
    {
        if (UIEditorMenu.EditorWasLoaded)
            return;

        if (_liveManager.canLooseLife())
        {
            _liveManager.looseOneLife();
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackButtonClick();
        }
    }

    public void ToShop()
    {
        //SceneManager.LoadScene("Shop");
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear("Shop");
    }

    public void ToCrossPromo()
    {
    }

#if DEBUG_MODE
    private void CompleteLevelDebug(Core.BaseEventParams eventParams)
    {
        StopAllCoroutines();
        int lastLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        if (lastLevel <= SaveManager.GameProgress.Current.finishCount.Length)
        {
            SaveManager.GameProgress.Current.finishCount[lastLevel] = 1;
            SaveManager.GameProgress.Current.Save();
            UpdateViewForLvl(lastLevel, needShowAnim: false);
        }
    }
#endif

    private bool CheckEnergyForStartPlaying()
    {
        return !SaveManager.Energy.Current.IsEmty;
    }

    public Transform GetLevelTransform(int levelNumber)
    {
        if (levelNumber >= 1 && levelNumber <= maxLevelNumber)
        {
            return levelsUIData[levelNumber - 1].transform;
        }
        return null;
    }

    //#if UNITY_EDITOR
    private int currentLvl = 0;
    //#endif
    void EditorUpdate()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            StopAllCoroutines();
            int lastLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0) - 1;
            if (lastLevel > 0)
            {
                OpenLevel -= 1;
                SaveManager.GameProgress.Current.finishCount[lastLevel] = 0;
                SaveManager.GameProgress.Current.Save();
                UpdateView(needShowAnim: false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            StopAllCoroutines();
            int lastLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
            OpenLevel += 1;
            if (lastLevel <= SaveManager.GameProgress.Current.finishCount.Length)
            {
                for (int i = 0; i <= lastLevel; i++)
                {
                    SaveManager.GameProgress.Current.finishCount[i] += 1;
                }
                SaveManager.GameProgress.Current.Save();
                UpdateViewForLvl(lastLevel, needShowAnim: false);
            }
        }
        if (Input.GetKeyDown(KeyCode.End))
        {
            print(CurrentLevelImage.transform.position.x);
            print(OpenLevel + " / " + levelsUIData[OpenLevel].GetXPosition);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLvl = Mathf.Clamp(--currentLvl, 0, maxLevelNumber - 1);
            SetViewToLevel(currentLvl);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLvl = Mathf.Clamp(++currentLvl, 0, maxLevelNumber - 1);
            SetViewToLevel(currentLvl);
        }
#endif
    }

    override protected void Update()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        EditorUpdate();
        if (BlackScreen.isOuted == true)
            PastUpdateView();

        if (testEffectToBoss)
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject obj = Instantiate(prefabMapEffetc, _targetBoss.position, Quaternion.identity, levelsUIData[testLevelEffect - 1].gameObject.transform) as GameObject;
                obj.transform.localPosition = Vector3.zero;
                var o = obj.GetComponent<EffectUIFly>();
                o.target = _targetBoss;
                o.indexStart = i;
                o.timerToTarget = (i * (0.1f)) + 0.2f;
            }

            testEffectToBoss = false;
        }

        base.Update();
    }

    private bool pastUpdated = false;

    bool isHowEffect()
    {
        var v = 0;

        foreach (var o in objsPanels)
        {
            if (o != null)
            {
                if (o.activeSelf)
                {
                    Debug.Log($"MAP BOSS EFFETC object active: {o.name}");
                    v++;
                }
            }
        }

        foreach (var t in childPanels)
        {
            if (t.childCount > 0)
            {
                Debug.Log($"MAP BOSS EFFETC child: {t.name}");
                v++;
            }
        }

        return v == 0;
    }

    private void PastUpdateView()
    {
        if (pastUpdated)
            return;
        else
            pastUpdated = true;
        var levelNumber = (OpenLevel + 1);
        var levelUIData = levelsUIData[OpenLevel];

        var block = levelUIData.getLockIcon;
        var back_board = levelUIData.getBackBoardObj;
        float delay = 0f;
        //if (shadow != null) 
        //shadow.GetComponent<ImageChanger>().ToggleImage(true, false);
        var present = LevelsTransform.Find(string.Format(PRESENT_NAME_FORMAT, OpenLevel, levelNumber));
        var present_image = present;
        var present_body = present;
        bool isNewLevel = false;

        if (!PlayerPrefs.HasKey(MapOpenShownIdPrefsKey) || PlayerPrefs.GetInt(MapOpenShownIdPrefsKey) < OpenLevel)
        {
            UIMap.Current.btnDailyRewards.SetActive(SaveManager.GameProgress.Current.CompletedLevelsNumber >= 4);

            if (!SaveManager.GameProgress.Current.tutDailyReward && SaveManager.GameProgress.Current.CompletedLevelsNumber >= 4)
            {
                StartCoroutine(StartDailyRewardTutorial());
            }

            if (OpenLevel == 15 || OpenLevel == 6 || OpenLevel == 7 || OpenLevel >= 70)
            {
                if (!TutorialsManager.IsAnyTutorialActive)
                {
                    CallRateLink.Open(OpenLevel);
                }
            }

            if (OpenLevel != 1 && OpenLevel != 4 && OpenLevel != 2 && OpenLevel != 30 && OpenLevel != 45 && OpenLevel != 70)
            {
                if(!CallRateLink.instance.panel.activeSelf && isHowEffect())
                {
                    isNewLevel = true;
                    OpenLevelEffect(OpenLevel);
                    if(bossProgress.canvas != null)
                        bossProgress.canvas.sortingOrder = 1;
                }
            }
            else
                Debug.Log("Level disabled for effect boss");

            PlayerPrefs.SetInt(MapOpenShownIdPrefsKey, OpenLevel);

            if (present != null)
            {
                present_body = present.transform.Find("Present");
                present_image = present.transform.Find("Image");
                present = present.Find("back");

                StartCoroutine(ShowHideSomething(present.gameObject, false, 1f, false, delay));
                StartCoroutine(ScaleIt(present.gameObject, 0f, 1f, delay));
                if (present_image != null)
                {
                    StartCoroutine(ShowHideSomething(present_image.gameObject, false, 1f, false, delay));
                    StartCoroutine(ScaleIt(present_image.gameObject, 0f, 1f, delay));
                }
                if (present_body != null)
                {
                    StartCoroutine(ShowHideSomething(present_body.gameObject, true, 1f, false, delay));
                    StartCoroutine(ScaleIt(present_body.gameObject, 1f, 1f, delay));
                    StartCoroutine(PullPresent(present_body.gameObject, 0.5f, delay + 0.5f));
                    delay += 0f;
                }
            }
            if (levelNumber > 1)
            {
                levelsUIData[OpenLevel - 1].ShowCompletedAndHideOpenedButtons(true, 1f, false, delay);
                delay += 0.5f;
            }

            StartCoroutine(ShowHideSomething(block.gameObject, false, 1f, false, delay));
            StartCoroutine(ShowHideSomething(back_board.gameObject, true, 1f, false, delay));
            if (OpenLevel < 2)
            {
                CurrentLevelImage.transform.position = levelUIData.getArrowAnchorPos + Vector3.up * 50;
                StartCoroutine(ShowHideSomething(CurrentLevelImage.transform.GetChild(0).gameObject, true, 0.75f, false, 0f));
            }
        }
        else
        {
            if (present != null)
            {
                var presentParent = LevelsTransform.Find(string.Format(PRESENT_NAME_FORMAT, OpenLevel, levelNumber));
                present_body = presentParent.Find("Present");
                present_image = presentParent.Find("Image");
                present = present.Find("back");

                StartCoroutine(ShowHideSomething(present.gameObject, false, 0f, false, 0f));
                StartCoroutine(ScaleIt(present.gameObject, 0f, 0f, 0f));
                if (present_image != null)
                {
                    StartCoroutine(ShowHideSomething(present_image.gameObject, false, 0f, false, 0f));
                    StartCoroutine(ScaleIt(present_image.gameObject, 0f, 1f, delay));
                }
                if (present_body != null)
                {
                    StartCoroutine(ShowHideSomething(present_body.gameObject, true, 0f, false, 0f));
                    StartCoroutine(ScaleIt(present_body.gameObject, 1f, 0f, 0f));
                }
            }
            if (levelNumber > 1)
            {
                levelsUIData[OpenLevel - 1].ShowCompletedAndHideOpenedButtons(true, 0f, false, 0f);
            }

            StartCoroutine(ShowHideSomething(block.gameObject, false, 0f, false, 0f));
            StartCoroutine(ShowHideSomething(back_board.gameObject, true, 0f, false, 0f));
            if (OpenLevel < 2)
            {
                CurrentLevelImage.transform.position = levelUIData.getArrowAnchorPos + Vector3.up * 50;
            }
           
        }
        if (isNewLevel)
        {
            SoundController.Instanse.PlayMapUnlockScrollSFX();
            if (bossProgress.gameObject.activeSelf)
            {
                //Debug.Log($"boss particles: {}");
                bossProgress._Start(isNewLevel);
            }
        }
        else
            bossProgress.Upd();
        MapAds.instance.PlayBoss(0, isNewLevel);
    }

    private IEnumerator StartDailyRewardTutorial()
    {
        yield return new WaitForSeconds(0.5f);

        while (TutorialsManager.IsAnyTutorialActive)
            yield return new WaitForSeconds(0.1f);

        TutorialsManager.OnTutorialStart(ETutorialType.DAILY_REWARD);
        Tutorial.Open(target: UIMap.Current.btnDailyRewards, focus: new Transform[] { UIMap.Current.btnDailyRewards.transform }, mirror: true, rotation: new Vector3(0, 0, -62f), offset: new Vector2(55, 70), waiting: 0, keyText: "t_0632");
        SaveManager.GameProgress.Current.tutDailyReward = true;
        SaveManager.GameProgress.Current.Save();
    }

    public void OpenLevelEffect(int level)
    {
        if (level < 1)
            return;

        for (int i = 0; i < 6; i++)
        {
            GameObject obj = Instantiate(prefabMapEffetc, _targetBoss.position, Quaternion.identity, levelsUIData[level - 1].gameObject.transform) as GameObject;
            obj.transform.localPosition = Vector3.zero;
            var o = obj.GetComponent<EffectUIFly>();
            o.target = _targetBoss;
            o.indexStart = i;
            o.timerToTarget = (i * (0.1f)) + 0.2f;
        }
    }


    public void PlayEffectBoss()
    {
        if (bossProgress.gameObject.activeSelf)
        {
            bossProgress.PlayProgress();
            MapAds.instance.PlayBoss(1);
        }
    }

    private void UnlockInput()
    {
        scrollLock.SetActive(false);

        Debug.Log($" --------------- UnlockInput: {PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0)}");
        if (PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0) == 1)
        {
            Instantiate(AnyWindowsLoaderConfig.Instance.GetWindowOfType(AnyWindowsLoaderConfig.WindowType.endgameWindow), scrollLock.transform.parent);
        }
    }

    private void LockInput()
    {
        scrollLock.SetActive(true);
    }

    IEnumerator ShiftCurrentArrow(Vector3 newPos, float delay, bool momental)
    {
        Debug.LogFormat("ShiftCurrentArrow {0} {1}", delay, momental);
        if (!momental)
        {
            yield return new WaitForSeconds(delay);
            StartCoroutine(ShowHideSomething(CurrentLevelImage.transform.GetChild(0).gameObject, false, 0.5f, false, 0f));
            yield return new WaitForSeconds(0.51f);
        }
        CurrentLevelImage.transform.position = newPos;
        if (!momental)
        {
            StartCoroutine(ShowHideSomething(CurrentLevelImage.transform.GetChild(0).gameObject, true, 0.5f, false, 0f));
            //UnlockInput ();
        }
        yield break;
    }

    private float GetMapPositionByLevelX(float levelXPosition)
    {
        //Debug.Log(canvasRect.sizeDelta +"  "+canvasRect.rect);
        float halfScreenWidth = (canvasRect.sizeDelta.x * canvasRect.localScale.x) / 2f;
        float mapObjectsOffset = mapObjectsParent.anchoredPosition.x;
        float offset = halfScreenWidth - mapObjectsOffset;
        //Debug.Log( "Scroll to lvl " + _to_level_id + "  " + targetLvlPosX + " " + Map.position +" offset: "+ offset );
        float mapXPosition = -levelXPosition - offset;
        float mapWidth = Map.sizeDelta.x * Map.lossyScale.x;
        //Debug.Log( mapPos.x+"  "+ (-mapWidth - offset ) + "  " + ( -offset ) );
        mapXPosition = Mathf.Clamp(mapXPosition, -mapWidth - halfScreenWidth, -halfScreenWidth);
        if (mapXPosition < (-mapWidth + halfScreenWidth))
        {
            mapXPosition = -mapWidth + halfScreenWidth;
        }
        return mapXPosition;
    }


    private void ScrollMapToLevel(int _to_level_id, float time = 0)
    {
        //_to_level_id++;
        //if( _to_level_id < 1 )
        //	yield break;
        //_to_level_id = 1;
        Vector3 mapPos = Map.position;
        mapPos.x = GetMapPositionByLevelX(levelsUIData[_to_level_id].GetXPosition);
        Map.position = mapPos;
    }

    public void ScrollToLevel(int level, float time)
    {
        if (time <= 0)
        {
            SetViewToLevel(OpenLevel);
        }
        else
        {
            StartCoroutine(ScrollToLevelAnimation(level, time));
        }
    }

    public void ScrollToCurrentLevel(float time)
    {
        if (time <= 0)
        {
            SetViewToLevel(OpenLevel);
        }
        else
        {
            StartCoroutine(ScrollToLevelAnimation(OpenLevel, time));
        }
    }

    public void SetViewToLevel(int levelIndex, int cloudsAdditionalIndent = 1)
    {
        UpdateFogPos(levelIndex + cloudsAdditionalIndent);
        ScrollMapToLevel(levelIndex);
    }

    public void UpdateView(bool _forward = true, bool scrollToLevel = true, bool needShowAnim = true)
    {
        isUpdateViewComplete = false;
        OpenLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);

        if (OpenLevel >= maxLevelNumber)
        {
            OpenLevel = maxLevelNumber - 1;
        }

        for (int i = 0; i < OpenLevel + 1; i++)
        {
            var gem = LevelsTransform.Find("Gem_" + i + "-" + (i + 1).ToString());
            if (gem != null)// && PlayerPrefs.GetInt("MapGemsSeen", 0) >= OpenLevel)
            {
                gem.gameObject.SetActive(false);
            }
        }
        PlayerPrefs.SetInt("MapGemsSeen", OpenLevel);
        UpdateFogPos(OpenLevel + 1);

        if (scrollToLevel)
        {
            ScrollMapToLevel(OpenLevel);
        }

        for (var i = 0; i < maxLevelNumber; i++)
        {
            var levelNumber = (i + 1);
            var levelUIData = levelsUIData[i];
            var present = LevelsTransform.Find(string.Format(PRESENT_NAME_FORMAT, i, levelNumber));
            var present_image = present;
            var present_body = present;
            if (present != null)
            {
                present_body = present.transform.Find("Present");
                present_image = present.transform.Find("Image");
                present = present.Find("back");
            }

            if (levelUIData.getShadowImageChanger != null)
            {
                levelUIData.getShadowImageChanger.ToggleImage((i <= OpenLevel), true);
            }

            //	Debug.Log(i+" : "+( ( i < openLevel && !needShowAnim ) || ( needShowAnim && i < openLevel - 1 ) ) );
            //Логика доступа к игре на уровне
            levelUIData.ToggleBetweenOpenedOrCompletedState(!((i < OpenLevel && !needShowAnim) || (needShowAnim && i < OpenLevel - 1)));

            //Чуть другая логика для отображения ревардов за прохождение уровня
            if (i < OpenLevel)
            {
                levelUIData.ToggleLevelButtonsState(true);
                if (present != null)
                {
                    StartCoroutine(ShowHideSomething(present.gameObject, false, 0f, false, 0));
                    if (present_image != null)
                    {
                        StartCoroutine(ShowHideSomething(present_image.gameObject, false, 0f, false, 0));
                    }
                    if (present_body != null)
                    {
                        StartCoroutine(ShowHideSomething(present_body.gameObject, true, 0f, false, 0));
                    }
                }
            }
            else
            {
                levelUIData.ToggleLevelButtonsState(i <= OpenLevel);
                if (present != null)
                {
                    StartCoroutine(ShowHideSomething(present.gameObject, true, 0f, false, 0));
                    if (present_image != null)
                    {
                        StartCoroutine(ShowHideSomething(present_image.gameObject, true, 0f, false, 0));
                    }
                    if (present_body != null)
                    {
                        StartCoroutine(ShowHideSomething(present_body.gameObject, false, 0f, false, 0));
                    }
                }
            }

            if (needShowAnim)
            {
                levelUIData.ToggleLockAndBackBoard((i > OpenLevel - 1), i <= OpenLevel - 1);
            }
            else
            {
                levelUIData.ToggleLockAndBackBoard((i > OpenLevel), i <= OpenLevel);
            }
            if (i == OpenLevel && OpenLevel > 1)
            {
                CurrentLevelImage.transform.position = levelUIData.getArrowAnchorPos + Vector3.up * 50;
            }
        }

        if (PlayerPrefs.HasKey(MapOpenShownIdPrefsKey) && PlayerPrefs.GetInt(MapOpenShownIdPrefsKey) >= OpenLevel)
        {
            BlackScreen.isOuted = true;
        }
        isUpdateViewComplete = true;
    }

    /// <summary>
    /// Currently used only for Debug Logic
    /// </summary>
    private void UpdateViewForLvl(int lvlIndex, bool needShowAnim = true)
    {
        if (lvlIndex >= maxLevelNumber)
            lvlIndex = maxLevelNumber - 1;

        OpenLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);

        if (OpenLevel >= maxLevelNumber)
            OpenLevel = maxLevelNumber - 1;

        UpdateFogPos(OpenLevel + 1);
        ScrollMapToLevel(OpenLevel);

        int iterateTo = Mathf.Min(maxLevelNumber, lvlIndex + 2);

        for (var i = lvlIndex; i < iterateTo; i++)
        {
            var levelNumber = (i + 1);
            var levelUIData = levelsUIData[i];
            var present = LevelsTransform.Find(string.Format(PRESENT_NAME_FORMAT, i, levelNumber));
            var present_image = present;
            var present_body = present;
            if (present != null)
            {
                present_body = present.transform.Find("Present");
                present_image = present.transform.Find("Image");
                present = present.Find("back");
            }

            if (levelUIData.getShadowImageChanger != null)
            {
                levelUIData.getShadowImageChanger.ToggleImage((i <= OpenLevel), true);
            }
            //shadow.GetComponent<ImageChanger>().ToggleImage(((i < openLevel - 1 && !needShowAnim) || (needShowAnim && i < openLevel)), true);

            //Логика доступа к игре на уровне
            if ((i < OpenLevel && !needShowAnim) || (needShowAnim && i < OpenLevel - 1))
            {
                levelUIData.ToggleBetweenOpenedOrCompletedState(false);
            }
            else
            {
                levelUIData.ToggleBetweenOpenedOrCompletedState(true);
            }

            //Чуть другая логика для отображения ревардов за прохождение уровня
            if ((i < OpenLevel && !needShowAnim) || (needShowAnim && i < OpenLevel))
            {
                levelUIData.ToggleLevelButtonsState(true);
                if (present != null)
                {
                    StartCoroutine(ShowHideSomething(present.gameObject, false, 0f, false, 0));
                    if (present_image != null)
                    {
                        StartCoroutine(ShowHideSomething(present_image.gameObject, false, 0f, false, 0));
                    }
                    if (present_body != null)
                    {
                        StartCoroutine(ShowHideSomething(present_body.gameObject, true, 0f, false, 0));
                    }
                }
            }
            else
            {
                levelUIData.ToggleLevelButtonsState(i <= OpenLevel);
                if (present != null)
                {
                    StartCoroutine(ShowHideSomething(present.gameObject, true, 0f, false, 0));
                    if (present_image != null)
                    {
                        StartCoroutine(ShowHideSomething(present_image.gameObject, true, 0f, false, 0));
                    }
                    if (present_body != null)
                    {
                        StartCoroutine(ShowHideSomething(present_body.gameObject, false, 0f, false, 0));
                    }
                }
            }

            if (needShowAnim)
            {
                levelUIData.ToggleLockAndBackBoard((i > OpenLevel - 1), i <= OpenLevel - 1);
            }
            else
            {
                levelUIData.ToggleLockAndBackBoard((i > OpenLevel), i <= OpenLevel);
            }
            if (i == OpenLevel && OpenLevel > 1)
            {
                CurrentLevelImage.transform.position = levelUIData.getArrowAnchorPos + Vector3.up * 50;
            }
        }

        if (PlayerPrefs.HasKey(MapOpenShownIdPrefsKey) && PlayerPrefs.GetInt(MapOpenShownIdPrefsKey) >= OpenLevel)
        {
            BlackScreen.isOuted = true;
       
        }
    }

    private void UpdateFogPos(int _to_level_id)
    {
        if (_to_level_id >= maxLevelNumber)
            _to_level_id = maxLevelNumber - 1;

        Vector3 cloudsPos = Clouds.position;
        if (_to_level_id != 0)
        {
            float clouds_pos_new_x = levelsUIData[_to_level_id].GetXPosition;
            if (_to_level_id >= maxLevelNumber - 1)
            {
                clouds_pos_new_x -= 63f;
            }
            cloudsPos = new Vector3(clouds_pos_new_x + CLOUDS_X_OFFSET, cloudsPos.y, cloudsPos.z);
            Clouds.position = cloudsPos;
        }
        //float xMax = 11850;//8953 для 30 уровней ---  11850 для 40 уровней
        //if( cloudsPos.x > xMax )
        //{
        //	Clouds.position = new Vector3( xMax, cloudsPos.y, cloudsPos.z );
        //}
    }

    private IEnumerator ShowHideSomething(GameObject _obj, bool _on, float _time, bool _momental, float delay)
    {
        yield return new WaitForSeconds(delay);
        _obj.SetActive(true);
        Image _image = _obj.GetComponent<Image>();
        _image.enabled = true;
        float _timer = _time + 0.00001f;
        _image.color = _on ? new Color(1f, 1f, 1f, 0f) : new Color(1f, 1f, 1f, 1f);
        if (!_momental)
        {
            while (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                _image.color = _on ? new Color(1f, 1f, 1f, 1f - _timer) : new Color(1f, 1f, 1f, _timer);
                yield return null;
            }
        }
        else
        {
            _image.color = _on ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 1f, 1f, 0f);
        }
        _image.enabled = _on;
        yield break;
    }

    private IEnumerator ScaleIt(GameObject _obj, float _scale, float _time, float delay)
    {
        yield return new WaitForSeconds(delay);
        Transform _object = _obj.transform;
        if (_time > 0f)
        {
            float _timer = _time;
            while (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                float newScale = _object.localScale.x;
                if (_scale > 0f)
                    newScale = (_time - _timer) / _time;
                else
                    newScale = _timer / _time;
                _object.localScale = new Vector3(newScale, newScale, 1f);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
        else
            _object.localScale = new Vector3(_scale, _scale, 1f);
        yield break;
    }

    private IEnumerator PullPresent(GameObject _obj, float _time, float _delay)
    {
        LockInput();
        yield return new WaitForSeconds(_delay);
        float yShift = 50f;

        RectTransform objRect = _obj.GetComponent<RectTransform>();
        Vector3 objPosition = objRect.position;

        float startY = objPosition.y;
        float _timer = _time / 2f;
        Vector3 newPos = new Vector3(objPosition.x, objPosition.y + yShift, objPosition.z);
        for (float i = 1f; i > 0.85f; i -= 0.01f)
        {
            float _speed = (1f - i) * yShift / 10 + 0.01f;
            objPosition = Vector3.Lerp(objPosition, newPos, _speed);
            objRect.position = objPosition;
            yield return new WaitForSeconds(0.01f * _time / 2f);
            if (objPosition.y > startY + yShift)
            {
                break;
            }
        }
        _timer = _time / 2f;
        startY = objPosition.y;
        newPos = new Vector3(objPosition.x, objPosition.y - yShift, objPosition.z);
        for (float i = 1f; i > 0f; i -= 0.01f)
        {
            float _speed = (1f - i) * yShift / 100 + 0.001f;
            objPosition = Vector3.Lerp(objPosition, newPos, _speed);
            objRect.position = objPosition;
            yield return new WaitForSeconds(0.01f * _time / 2f);
            if (objPosition.y < startY - yShift)
            {
                break;
            }
        }
        UnlockInput();
        yield break;
    }

    private IEnumerator ScrollToLevelAnimation(int level, float animationTime)
    {
        level = Mathf.Clamp(level, 0, levelsUIData.Length - 1);
        float targetLevelX = levelsUIData[level + 1].GetXPosition;

        Vector3 cloudsStartPositon = Clouds.position;
        Vector3 cloudsTargetPosition = cloudsStartPositon;
        cloudsTargetPosition.x = targetLevelX + CLOUDS_X_OFFSET;

        targetLevelX = levelsUIData[level].GetXPosition;
        Vector3 mapStartPosition = Map.position;
        Vector3 mapEndPosition = mapStartPosition;
        mapEndPosition.x = GetMapPositionByLevelX(targetLevelX);

        float timeElapsed = 0;
        float animProgress = 0;

        while (timeElapsed < animationTime)
        {
            timeElapsed += Time.deltaTime;
            animProgress = scrollToLevelAnimationCurve.Evaluate(timeElapsed / animationTime);

            Clouds.position = Vector3.Lerp(cloudsStartPositon, cloudsTargetPosition, animProgress);
            Map.position = Vector3.Lerp(mapStartPosition, mapEndPosition, animProgress);
            yield return null;
        }

    }

    //public static void ReloadOnMap()
    //{
    //	if (SceneManager.GetActiveScene ().name == "Map") {
    //		SceneManager.LoadScene ("Map");
    //	}
    //}

    public void CheatOpenOneMoreLevel()
    {
        currentLvl = Mathf.Clamp(++currentLvl, 0, maxLevelNumber - 1);
        ScrollMapToLevel(currentLvl);
    }

}