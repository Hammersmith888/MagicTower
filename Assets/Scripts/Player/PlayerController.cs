
#pragma warning disable CS0649
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ADs;

public class PlayerController : MonoBehaviour
{
    const string MAGE_TEXTURE_PATH_FORMAT = "MageTextures/{0}";
    public static readonly float DEFAULT_HEALTH_VALUE = 200f;
    #region VARIABLES
    private ObfuscatedFloat maxHealth;

    public RectTransform healthBarRect;
    public Image barBlood;
    public Text healthTextValue;
    public Mana mana;
    [SerializeField]
    private WallController wallController;
    public GameObject finalMenu; // Финальное меню
    private GameObject defeatMenu; // Меню поражения
    public GameObject tutorialObject, SemiDarkBack; // Меню поражения

    private int maxHealthValue = 150; // max ширина прогресс бара здоровья

    private float currentHealth;
    private float lastHealth;
    private Color healthStartColor;
    [HideInInspector]
    public bool haveToExchangeHP;

    private LevelSettings levelSettings;
    private MyGSFU GoogleLoadedData;
    public GameObject Dragon;

    [SerializeField]
    private string[] mageTexturesNames;
    private List<Texture> MageTextures;
    [SerializeField]
    private GameObject MageToChange;
    [SerializeField]
    private GameObject StaffToChange;

    public MagesTest mageSkins;

    [Space(10)]
    [SerializeField]
    private Transform m_mageReplicaAnchor;
    
    public GameObject[] m_mageRendererObjects;
    [HideInInspector]
    public float baseHealthRegen = 0f;
    #endregion

    [SerializeField] Animator _animEffect;

    public static int win = -1;


    [SerializeField]
    SkinnedMeshRenderer meshEffect;
    [SerializeField]
    float timeEffect = 1;

    bool effectPlay = false;

    [SerializeField]
    bool editroEffectPlay = false;
    public bool isHealthUse;

    [SerializeField] private PoisonsManager _ressurection;

    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }

    public static Transform MageReplicaAnchor
    {
        get
        {
            return Instance == null ? null : Instance.m_mageReplicaAnchor;
        }
    }

    public static GameObject[] MageRenderObjectsForReplica
    {
        get
        {
            return Instance == null ? null : Instance.m_mageRendererObjects;
        }
    }

    public static Vector3 Position
    {
        get; private set;
    }

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (levelSettings.wonFlag && !haveToExchangeHP)
            {
                return;
            }
            lastHealth = currentHealth;
            currentHealth = value;
            float _maxHealth = maxHealth;
          
            if (currentHealth > _maxHealth)
            {
                currentHealth = _maxHealth;
            }
            healthBarRect.sizeDelta = new Vector2(Mathf.Clamp(maxHealthValue / _maxHealth * currentHealth, 0, maxHealthValue), healthBarRect.sizeDelta.y);

            if (currentHealth < lastHealth)
            {
                isHealthUse = true;
            }

            if (healthTextValue != null)
            {
                int showHealth = (int)currentHealth;
                if (showHealth < 0)
                {
                    showHealth = 0;
                }
                healthTextValue.text = "" + showHealth + " / " + ((int)_maxHealth).ToString();
              
            }
            if (haveToExchangeHP)
            {
                return;
            }
            if (currentHealth < _maxHealth * 0.5f)
            {
                wallController.PartiallyBroken();
            }
            if (currentHealth < _maxHealth * 0.3f && tutorialObject != null)
            {
                //tutorialObject.GetComponent<Tutorials.Tutorial_1>().ShowMessage_7();
                Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.LOW_HEALTH);

            }

            if (currentHealth < _maxHealth * 0.2f)
            {
                PotionManager.Current.AutoUsePotion(PotionManager.EPotionType.Health);
            }

            if (currentHealth <= 0)
            {
                wallController.FullBroken();
                PreDeath();
            }
        }
    }

    public GameObject WallObject
    {
        get
        {
            return wallController.gameObject;
        }
    }

    private void ResizeHealthBarUI()
    {
        if (DEFAULT_HEALTH_VALUE < maxHealth)
        {
            RectTransform backUI = healthBarRect.transform.parent.GetComponent<RectTransform>();
            float defaultBackWidth = backUI.rect.width;
            float defaultBarWidth = healthBarRect.rect.width;
            float maxWidth = 150;
            //float xShift =  maxWidther * (health - defaultHealth) / defaultHealth;
            float xShift = maxWidth * (maxHealth / 10f) / DEFAULT_HEALTH_VALUE;
            maxHealthValue += (int)xShift;
            backUI.offsetMax = new Vector2(backUI.offsetMax.x + xShift, backUI.offsetMax.y);
            healthBarRect.offsetMax = new Vector2(healthBarRect.offsetMax.x + xShift, healthBarRect.offsetMax.y);
            RectTransform HealthTextRect = healthTextValue.GetComponent<RectTransform>();
            //HealthTextRect.anchoredPosition = new Vector2 (HealthTextRect.anchoredPosition.x + xShift/4f, HealthTextRect.anchoredPosition.y);
        }
    }

    [SerializeField]
    private bool usualMage;

    private void Start()
    {
        _instance = this;
        Position = transform.position;
        if (maxHealth == null)
        {
            maxHealth = new ObfuscatedFloat(DEFAULT_HEALTH_VALUE);
            currentHealth = DEFAULT_HEALTH_VALUE;
        }

        healthStartColor = healthBarRect.GetComponent<Image>().color;

        // Доступ к меню Defeat
        defeatMenu = finalMenu.transform.GetChild(3).gameObject;
        levelSettings = LevelSettings.Current;
        GoogleLoadedData = MyGSFU.current;

        //LoadMageView();
        Core.BattleEventsMono.BattleEvents.AddListenerToEvent(Core.EBattleEvent.POTION_USE, OnPotionUse);
        StartCoroutine(HealthRegen());

        //var t = Debug.unityLogger;
        //t.logEnabled = true;
        //StartCoroutine(Test());
    }
    //private IEnumerator Test()
    //{
    //    while (gameObject.activeSelf)
    //    {
    //        yield return new WaitForSecondsRealtime(1f);
    //        Debug.LogError(PoisonsManager.Get(PotionManager.EPotionType.Resurrection).CurrentPotion);
    //    }
    //}

    public void EffectHealth(bool value)
    {
        if (value)
        {
            _animEffect.enabled = true;
            _animEffect.Play(0);
        }
        else
        {
            _animEffect.enabled = false;
            _animEffect.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }

    public static bool CanUsePotion(PotionManager.EPotionType potionType)
    {
        if (_instance == null)
        {
            return false;
        }
        else
        {
            switch (potionType)
            {
                case PotionManager.EPotionType.Mana:
                    return !_instance.levelSettings.wonFlag && !_instance.mana.isFull;
                case PotionManager.EPotionType.Health:
                    return !_instance.levelSettings.wonFlag && _instance.CurrentHealth < _instance.maxHealth;
                case PotionManager.EPotionType.Power:
                    return !_instance.levelSettings.wonFlag && (!_instance.mana.isFull || _instance.CurrentHealth < _instance.maxHealth);
            }
            return false;
        }
    }

    private void OnPotionUse(Core.BaseEventParams eventsParams)
    {
        var eventData = eventsParams.GetParameterSafe<PotionUseParameters>();
        if (eventData.used)
        {
            mana.CurrentValue += eventData.manaRecovery;
            CurrentHealth += eventData.healthRecovery;
            if (eventData.healthRecovery > 0)
            {
                wallController.FullRestored();
            }
            LogPotionUse((int)eventData.potionType);
        }
    }

    public void LoadMageView()
    {
        Bonus_Items bonusItems = PPSerialization.Load<Bonus_Items>(EPrefsKeys.Bonuses);
        mageSkins.SetMageById(0);
        mageSkins.SetStaffById(0);
    }

    public void LoadHealthUpgrade()
    {
        GoogleLoadedData = MyGSFU.current;
        float baseHealth = DEFAULT_HEALTH_VALUE;
        if (levelSettings == null)
        {
            levelSettings = LevelSettings.Current;
        }
        if (levelSettings.upgradeItems[1].unlock == true && levelSettings.upgradeItems[1].upgradeLevel > 0)
        {
            baseHealth = baseHealth + GoogleLoadedData.charUpgradesValues[1].characterUpgradesValue[(int)levelSettings.upgradeItems[1].upgradeLevel - 1];
            if (levelSettings.upgradeItems[1].upgradeLevel >= 4)
            {
                wallController.SetupWalls(true);
            }
            else
            {
                wallController.SetupWalls(false);
            }
        }
        else
        {
            wallController.SetupWalls(false);
        }
        if (BuffsLoader.Instance != null)
        {
            baseHealth *= 1f + BuffsLoader.Instance.GetBuffValue(BuffType.additionalHealth) * 0.01f;
        }
        maxHealth = new ObfuscatedFloat(baseHealth);
        CurrentHealth = maxHealth;
        ResizeHealthBarUI();
    }

    public static int HealthUpdate(int upgrade)
    {
        var GoogleLoadedData = FindObjectOfType<MyGSFU>();
        Debug.Log($"MyGSFU.current: {upgrade}");
        float baseHealth = DEFAULT_HEALTH_VALUE;
        baseHealth = baseHealth + GoogleLoadedData.charUpgradesValues[1].characterUpgradesValue[upgrade];
        return (int)baseHealth;
    }
    public static void ResizeHealth(RectTransform rect, RectTransform rectHeath, float maxHealth)
    {
        if (DEFAULT_HEALTH_VALUE < maxHealth)
        {
            RectTransform backUI = rect.transform.parent.GetComponent<RectTransform>();
            float defaultBackWidth = backUI.rect.width;
            float defaultBarWidth = rect.rect.width;
            float maxWidth = 150;
            float xShift = maxWidth * (maxHealth / 10f) / DEFAULT_HEALTH_VALUE;
            backUI.offsetMax = new Vector2(xShift, backUI.offsetMax.y);
            //rect.offsetMax = new Vector2(backUI.offsetMax.x + xShift, rect.offsetMax.y);
            //RectTransform HealthTextRect = rectHeath.GetComponent<RectTransform>();
        }
    }

    private IEnumerator HealthRegen()
    {
        float healthRegen = 0f;
        if (BuffsLoader.Instance != null)
        {
            healthRegen = BuffsLoader.Instance.GetBuffValue(BuffType.healthRegeneration);
        }
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while (gameObject != null)
        {
            yield return waitTime;
            CurrentHealth += healthRegen + baseHealthRegen;
        }
        yield break;
    }

    public void LoadDragon()
    {
        print(levelSettings.upgradeItems[2].upgradeLevel);
        if (levelSettings.upgradeItems[2].unlock == true && Dragon != null && levelSettings.upgradeItems[2].upgradeLevel > 0)
        {
            Dragon.SetActive(true);
            Dragon.GetComponent<MicroDragonController>().LoadParameters();
        }
        else
        {
            Dragon.SetActive(false);
        }
    }

    private void PreDeath()
    {
       
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);
        levelSettings.wonFlag = true;
        Time.timeScale = 0;
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.LEVEL_COMPLETED, false);
        StartCoroutine(WaitForReplicaBeforeCompleteLevel());
    }

    private IEnumerator WaitForReplicaBeforeCompleteLevel()
    {
        yield return null;
        while (UI.ReplicaUI.IsAnyActive)
        {
            yield return new WaitForSecondsRealtime(0.5f);
        }
       
        ToggleFinalUI(true);
      
        defeatMenu.SetActive(enabled);
    }

    public void ShowDefeat()
    {
        StartCoroutine(_ShowDefeat());
    }
    IEnumerator _ShowDefeat()
    {
        FinishMenu.instance.panelBlocker.SetActive(true);
        if (UIAutoHelpersWindow.instance != null)
            UIAutoHelpersWindow.instance.gameObject.SetActive(false);
        var isTip = Tips.instance.Show();
        FinishMenu.instance.UpdateBtnConnection();
        //if (isTip)
        //    yield return new WaitForSecondsRealtime(2.6f);
        var continueGameUI = defeatMenu.GetComponent<UIContinueGame>();
        continueGameUI.defeatMenu.SetActive(true);
        FinishMenu.instance.lineCoinsDefeat[1].panel.SetActive(false);
        FinishMenu.instance.lineCoinsDefeat[2].panel.SetActive(false);

        float buffs = 0;
        int maxGemLvl = 0;
        Wear_Items wearItems = new Wear_Items(WearItem.ItemsNumber);
        wearItems = PPSerialization.Load<Wear_Items>("Wears");
        float isLuckyWearValue = 0;
        for (int i = 0; i < wearItems.Length; i++)
        {
            if (wearItems[i].active && wearItems[i].wearParams.wearType == WearType.cape)
            {
                foreach (var g in wearItems[i].wearParams.gemsInSlots)
                {
                    //Debug.Log($"gem: {g.type}");
                    if (g.type == GemType.White && wearItems[i].wearParams.wearType == WearType.cape)
                    {
                        var b = FinishMenu.instance.buffsLoaderConfig.GetGemBuffInWear(g, wearItems[i].wearParams.wearType);
                        Debug.Log($"gem BUFFS: {b.buffValue}");

                        buffs += b.buffValue / 100;
                        if (g.gemLevel > maxGemLvl)
                            maxGemLvl = g.gemLevel;
                    }
                }
                if (i == 10)
                    isLuckyWearValue = wearItems[i].wearParams.buffs[0].buffValue / 100;
                //Debug.Log($"i: {i} , wear: {wearItems[i].active}");
            }
        }

        Debug.Log($"buffs: {buffs}");

        Text coinsTop = FinishMenu.instance.uiTotalDefeat.CoinsLevelTransform.GetComponent<Text>();
        int earngedGoldOnLevelWithoutMultiplicators = int.Parse(coinsTop.text);
        int earnedGold = Mathf.RoundToInt(earngedGoldOnLevelWithoutMultiplicators * FinishMenu.instance.uiTotalDefeat.levelSettings.goldenMageCoef);
        FinishMenu.instance.videoX2Coins += earnedGold;
        Debug.Log($"coooef: {FinishMenu.instance.uiTotalDefeat.levelSettings.goldenMageCoef}");

        Debug.Log($"loSE COINS: {earnedGold}");
        
        
        // save last lose game for tutorial
        PlayerPrefs.SetInt("LastGameLose",1);
        PlayerPrefs.SetFloat("LastGameHP",currentHealth);
        PlayerPrefs.SetFloat("LastGameMana",mana.CurrentValue);
        
        
        ShotController.Current.SendUsedSpell();
        UIShop.coinsAdded = earnedGold;

        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.IronWill, 1);
        if(CurrentHealth / maxHealth < 0.1f)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Survivor, 1);
        Achievement.AchievementController.Save();
        //CoinsManager.AddCoinsST(earnedGold);

        int allCoins = FinishMenu.instance.videoX2Coins;
        if (buffs > 0)
        {
            FinishMenu.instance.lineCoinsDefeat[1].panel.SetActive(true);
            FinishMenu.instance.lineCoinsDefeat[1].text.transform.parent.gameObject.GetComponent<Text>().text = "+" + (buffs * 100).ToString("F0") + "%";
            FinishMenu.instance.lineCoinsDefeat[1].text.text = ((int)(allCoins * buffs)).ToString();
            FinishMenu.instance.lineCoinsDefeat[1].panel.transform.Find("ParentGem").transform.Find("GemIcon").gameObject.GetComponent<Image>().sprite = FinishMenu.instance.gemsWhite[maxGemLvl];
            FinishMenu.instance.videoX2Coins += (int)(allCoins * buffs);
            Debug.Log($"gems: {(int)(allCoins * buffs)}");
        }

        if (isLuckyWearValue > 0)
        {
            FinishMenu.instance.lineCoinsDefeat[2].text.transform.parent.gameObject.GetComponent<Text>().text = "+" + (isLuckyWearValue * 100).ToString("F0") + "%";
            FinishMenu.instance.lineCoinsDefeat[2].panel.SetActive(true);
            FinishMenu.instance.lineCoinsDefeat[2].text.text = ((int)(allCoins * isLuckyWearValue)).ToString();
            FinishMenu.instance.videoX2Coins += (int)(allCoins * isLuckyWearValue);
            Debug.Log($"wear: {(int)(allCoins * isLuckyWearValue)}");
        }

        if (buffs > 0)
        {
            Debug.Log("Show GEMS");
            yield return new WaitForSecondsRealtime(3.5f / FinishMenu.instance.indexSpeed);
            FinishMenu.instance.lineCoinsDefeat[1].panel.GetComponent<Animator>().enabled = true;
            yield return new WaitForSecondsRealtime(0.5f / FinishMenu.instance.indexSpeed);
            FinishMenu.instance.uiTotalDefeat.SetGold((int)(allCoins * buffs));
        }

        if (isLuckyWearValue > 0)
        {
            Debug.Log("Show WEAR");
            yield return new WaitForSecondsRealtime(1.5f / FinishMenu.instance.indexSpeed);
            FinishMenu.instance.lineCoinsDefeat[2].panel.GetComponent<Animator>().enabled = true;
            yield return new WaitForSecondsRealtime(0.5f / FinishMenu.instance.indexSpeed);
            FinishMenu.instance.uiTotalDefeat.SetGold((int)(allCoins * isLuckyWearValue));
        }

        float t = 0;
        t += (buffs == 0 ? 1.5f : 0);
        t += (isLuckyWearValue == 0 ? 1.5f : 0);
        yield return new WaitForSecondsRealtime(t / FinishMenu.instance.indexSpeed);

        if (FinishMenu.instance.uiTotalDefeat._animDefeat2 != null)
            FinishMenu.instance.uiTotalDefeat._animDefeat2.enabled = true;
        if (FinishMenu.instance.uiTotalDefeat._animDefeat != null)
            FinishMenu.instance.uiTotalDefeat._animDefeat.enabled = true;
    }

    private void FullRestoring()
    {
        var continueGameUI = defeatMenu.GetComponent<UIContinueGame>();
        continueGameUI.ContinueGame(_ressurection);
        levelSettings.wonFlag = false;

        mana.RestoreToFull();
        CurrentHealth = maxHealth;

        wallController.FullRestored();

        ToggleFinalUI(false);
        defeatMenu.SetActive(false);
        Time.timeScale = LevelSettings.Current.usedGameSpeed;
        //LogPotionUse( "Ressurection" );
        //LogPotionUse(3);
        levelSettings.enemies.OnContinueGameUsed();
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.CONTINUE_GAME_USED);
    }

    public void ContinueGame()
    {
        AnalyticsController.Instance.LogMyEvent("Player_Press_Revival_Button");
        var continueGameUI = defeatMenu.GetComponent<UIContinueGame>();
        continueGameUI.startTimer = false;

        var ressurectionCount = _ressurection.CurrentPotion;

        Debug.Log($"ContinueGame: {ressurectionCount}");
        if (ressurectionCount > 0)
        {
            var count = _ressurection.CurrentPotion - 1;
            _ressurection.Save(PotionManager.EPotionType.Resurrection, count);

            FullRestoring();
            SoundController.Instanse.ResumeGamePlaySFX();
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.WalkingDead, 1);
            Achievement.AchievementController.Save();
        }
        else
        {
            //TODO :показать меню c покупкой
            continueGameUI.NotEnoughBottles();
        }


    }

    public void contineTimer()
    {
        var continueGameUI = defeatMenu.GetComponent<UIContinueGame>();
        if (!continueGameUI.gameObject.activeInHierarchy)
        {
            return;
        }
        continueGameUI.startTimer = true;
        continueGameUI.continueTimer();
    }

    private void ToggleFinalUI(bool enabled)
    {
#if DEBUG_MODE || UNITY_EDITOR
        Debug.LogFormat("ToggleFinalUI Lose {0}", enabled);
#endif
        finalMenu.SetActive(enabled);
       

        //FinishMenu.instance.lineCoinsDefeat[0].text.text = (max).ToString("F0");
        //yield return new WaitForSecondsRealtime(0.5f);
        //FinishMenu.instance.lineCoinsDefeat[0].panel.GetComponent<Animator>().enabled = true;
        //yield return new WaitForSecondsRealtime(0.5f);
        //uiTotal.SetGold(max);


        if (enabled)
        {
            levelSettings.pauseObj.pauseCalled = true;
            levelSettings.pauseObj.currentState = UIPauseController.StateOfPause.DEFEAT;
        }
        
        if (PlayerPrefs.HasKey("LastHardLevel") && PlayerPrefs.GetInt("LastHardLevel") == levelSettings.currentLevel)
        {
            PlayerPrefs.SetInt("LastLoses", PlayerPrefs.GetInt("LastLoses") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("LastHardLevel", levelSettings.currentLevel);
            PlayerPrefs.SetInt("LastLoses", 1);
        }
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        win = 1;


    }
    //private void LogPotionUse( string potionName )
    private void LogPotionUse(int potionId)
    {
        if (LevelSettings.Current != null)
        {
            //			int currentLvl = LevelSettings.current.currentLevel;
            //			string prefsKey = string.Format( "PotionsUsedOnLvl_{0}_Potion_{1}", currentLvl, potionName );
            //			int usesNumberOnLevel = PlayerPrefs.GetInt( prefsKey, 0 );
            //			usesNumberOnLevel++;
            //			PlayerPrefs.SetInt( prefsKey, usesNumberOnLevel );
            //			AnalyticsController.instanse.LogMyEvent( "PotionUse", new System.Collections.Generic.Dictionary<string, string>
            //			{ { "Level", currentLvl.ToString() }, { "PotionName", potionName }, { "UseNumber", usesNumberOnLevel.ToString() } } );
            LevelSettings.Current.UsedPotion(potionId);
        }
    }

    void Update()
    {
        //Debug.Log("HElath: " + currentHealth + ", max health: " + maxHealth);
        float h = 1 - (currentHealth / maxHealth);
        //barBlood.color = new Color(barBlood.color.r, barBlood.color.g, barBlood.color.b, h);
        barBlood.gameObject.SetActive(h > 0.6f && Time.timeScale > 0);
        BloodEffect.instance.Set((currentHealth / maxHealth));

        if (effectPlay)
        {
            meshEffect.material.SetFloat("_Alpha", meshEffect.material.GetFloat("_Alpha") - (timeEffect * Time.unscaledDeltaTime));
            if (meshEffect.material.GetFloat("_Alpha") <= 0f)
            {
                effectPlay = false;
                //meshEffect.gameObject.SetActive(false);
            }
        }

        if (editroEffectPlay)
        {
            PlayEffectChangeTexture();
            editroEffectPlay = false;
        }
    }

    public void PlayEffectChangeTexture()
    {
        effectPlay = true;
        meshEffect.gameObject.SetActive(true);

    }
}