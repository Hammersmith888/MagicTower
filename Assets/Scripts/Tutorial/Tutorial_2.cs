using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tutorials;
using UI;

public class Tutorial_2 : MonoBehaviour
{
    private static Tutorial_2 _instance;
    public static Tutorial_2 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Tutorial_2>();
            }
            return _instance;
        }
    }

    public static bool IsActive
    {
        get
        {
            if (_instance != null)
            {
                return _instance.gameObject.activeSelf;
            }
            return false;
        }
    }

    [SerializeField] public Button closeBtn;

    [SerializeField]
    private Button fireballUpgradeBtnComponent;
    public GameObject mapBtn, btnBuyScroll;
    public GameObject btnSCroll;
    [Space(5f)]
    public GameObject UpgradesTab;
    public GameObject manaBtn;
    public GameObject hpBtn;
    public GameObject dragonBtn;
    public GameObject wallBtn;
    public GameObject dragonFreezeBtn;
    [Space(5f)]
    public GameObject staffsButton;
    public GameObject gemsBtn;
    public GameObject pickStaffBtn;
    public GameObject pickRobeBtn;
    public GameObject chainLightningButton;
    public GameObject gemsWindow;

    private GameObject buttonInFocus;
    private int currentMessage;
    private bool animatePointer;

    [Header("Tutorial: Use First Crystal")]
    public Button robeGemInScroll;
    public Button useCrystal;
    public Button robePopupInfo;
    public GameObject closeGems, panelRobeInfo, btnClickInfo, closeWearInfo;
    public ShopWearItem itemShabbyRobe;
    public ShopWearItem itemGrandfathersCrutch;
    public GameObject gemInsertInfo;
    public GemInsertToItemChoose gemInsertToItemChoese;
    public InfoWearWindow infoWearWindow;
    private TutorialUseFirstCrystal useFirstCrystal;

    [Header("Tutorial: Combine Two Crystals")]
    public ShopGemItemSettings gemSettings;
    public Button combineCrystals;
    public Button robeGemInScroll2;
    public GameObject gemCombine1;
    public GameObject gemCombine2, gemInSCroll2;
    public GameObject gemInsertToItemChoese2;
    public GameObject gemNext, btnCloseCombine;
    private TutorialCombineTwoCrystals combineTwoCrystals;

    [Header("Tutorial: 4 slot are full:")]
    public ShopSpellItem fireWallSpell, prevFirewall, lightning, meteor, gorgula, iceRain, wind, rollingRtone, electricPuddle;
    public ShopSpellItem lightingSpell;
    public Button spellPanel;
    public GameObject spellSlots;
    private TutorialSpell4SlotAreFull spellTutorial4SlotAreFull;

    public ShopItem zobieScroll;
    public Button scrollPanel;
    public GameObject scrollSlots;
    private TutorialScroll4SlotAreFull scrollTutorial4SlotAreFull;
    private Transform slotBackground;

    [SerializeField]
    GameObject messageObject, backgroundBlack, btnWear;

    [SerializeField]
    [Space(10f)]
    private List<Text> messageTexts = new List<Text>();

    [Space(10f)]
    [SerializeField]
    private RectTransform handPointer;
    [SerializeField]
    private RectTransform handPointerPressed;
    Coroutine pointerAnim;

    public bool AnimatePointer
    {
        get
        {
            return animatePointer;
        }
        set
        {
            animatePointer = value;
        }
    }

    public List<Text> MessageTexts
    {
        get
        {
            return messageTexts;
        }
    }

    public RectTransform HandPointer
    {
        get
        {
            return handPointer;
        }
    }

    public RectTransform HandPointerPressed
    {
        get
        {
            return handPointerPressed;
        }
    }

    public GameObject ButtonInFocus
    {
        get
        {
            return buttonInFocus;
        }
    }

    public TutorialUseFirstCrystal UseFirstCrystal
    {
        get
        {
            if (useFirstCrystal == null)
            {
                useFirstCrystal = new TutorialUseFirstCrystal(this);
            }
            return useFirstCrystal;
        }
    }

    public TutorialCombineTwoCrystals CombineTwoCrystals
    {
        get
        {
            if (combineTwoCrystals == null)
            {
                combineTwoCrystals = new TutorialCombineTwoCrystals(this);
            }
            return combineTwoCrystals;
        }
    }

    public TutorialSpell4SlotAreFull SpellTutorial4SlotAreFull
    {
        get
        {
            if (spellTutorial4SlotAreFull == null)
            {
                spellTutorial4SlotAreFull = new TutorialSpell4SlotAreFull(this);
            }
            return spellTutorial4SlotAreFull;
        }
    }

    public TutorialScroll4SlotAreFull ScrollTutorial4SlotAreFull
    {
        get
        {
            if (scrollTutorial4SlotAreFull == null)
            {
                scrollTutorial4SlotAreFull = new TutorialScroll4SlotAreFull(this);
            }
            return scrollTutorial4SlotAreFull;
        }
    }

    // Делаем в Awake, потому что прогресс также загружается и сохраняется в CoinManager
    private void Awake()
    {
        _instance = this;
    }

    [HideInInspector] public bool isOldGameVersion = false;

    private void Start()
    {
        if (!SaveManager.GameProgress.Current.tutLevel2 && SaveManager.GameProgress.Current.CompletedLevelsNumber > 2)
        {
            isOldGameVersion = true;
        }

        if (!SaveManager.GameProgress.Current.tutLevel2 && SaveManager.GameProgress.Current.CompletedLevelsNumber == 2 && ShopSpellItemSettings.Current.IsUnlock(1))
        {
            // Tutorial.OpenBlock(timer: 2.7f);
            // UIShop.Instance.ActiveSpellItems();
            // UIShop.Instance.FocusItem(ShopSpellItemSettings.Current.ShopItemsObjects[1].transform);
            // Button btn = ShopSpellItemSettings.Current.ShopItemsObjects[1].transform.Find("UpgradeBtn").gameObject.GetComponent<Button>();
            // Tutorial.Open(target: btn.gameObject, focus: new Transform[] { ShopSpellItemSettings.Current.ShopItemsObjects[1].transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(120, 30), waiting: 2.5f, keyText: "");
            // btn.onClick.AddListener(OnLighthing);
        }

        // if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 5 && !PlayerPrefs.HasKey("ManaWasUpgradeTutorial"))
        //     ShowManaUpgradeTutorial();
        //
        // if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 8 && !PlayerPrefs.HasKey("WallWasUpgradeTutorial"))
        //     StartWallUpgradeTutorial();
        //
        // if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 15 && !PlayerPrefs.HasKey("TutorialPetUpgrate"))
        //     ShowUpgradeDragonTutorial();
        //
        // if (SaveManager.GameProgress.Current.CompletedLevelsNumber >= 2 && !ShopWearItemSettings.instance.CheckActiveWearItems())
        // {
        //     ShopWearItemSettings.instance.UseWear(WearType.staff, 0);
        //     ShopWearItemSettings.instance.UseWear(WearType.cape, 5);
        // }
        //
        // if (isOldGameVersion)
        // {
        //     SaveManager.GameProgress.Current.tutLevel2 = true;
        //     SaveManager.GameProgress.Current.Save();
        //     Tutorial.OpenBlock(timer: 1f);
        //     StartCoroutine(StartWearTutorialOldNewVersion());
        // }
    }
    
    [HideInInspector] public bool infoCheck = false;
    private IEnumerator StartWearTutorialOldNewVersion()
    {
        yield return new WaitForSecondsRealtime(1f);

        while (TutorialsManager.IsAnyTutorialActive) 
            yield return new WaitForSecondsRealtime(1);

        while (infoCheck)
            yield return new WaitForSecondsRealtime(0.5f);

        Tutorial.OpenBlock(timer: 1.2f);
        Tutorial.Close();
        btnWear.GetComponent<Button>().onClick.AddListener(OnWear);
        Tutorial.Open(target: btnWear.gameObject, focus: new Transform[] { btnWear.transform }, mirror: true, rotation: new Vector3(0, 0, -27f), offset: new Vector2(90, 40), waiting: 1f, keyText: "");
    }

    void OnLighthing()
    {
        Tutorial.OpenBlock(timer: 1.2f);
        Button btn = ShopSpellItemSettings.Current.ShopItemsObjects[1].transform.Find("UpgradeBtn").gameObject.GetComponent<Button>();
        btn.onClick.RemoveListener(OnLighthing);
        Tutorial.Close();
        Tutorial.OpenBlock(timer: 1.2f);
        btnWear.GetComponent<Button>().onClick.AddListener(OnWear);
        Tutorial.Open(target: btnWear.gameObject, focus: new Transform[] { btnWear.transform }, mirror: true, rotation: new Vector3(0, 0, -27f), offset: new Vector2(90, 40), waiting: 1f, keyText: "");
    }

    void OnWear()
    {
        Tutorial.Close();
        btnWear.GetComponent<Button>().onClick.RemoveListener(OnWear);
        //TutorialUseFirstCrystal.instance.TutorialOpen(isOldGameVersion);
        SaveManager.GameProgress.Current.tutLevel2 = true;
        SaveManager.GameProgress.Current.Save();
    }

    public void Update()
    {
        // костыль
        if (backgroundBlack.activeSelf != messageObject.transform.parent.gameObject.activeSelf)
            messageObject.transform.parent.gameObject.SetActive(backgroundBlack.activeSelf);
        if (gemsWindow.transform.parent.gameObject.activeSelf)
            messageObject.transform.parent.gameObject.SetActive(false);
    }

    public bool CheckForTutorials()
    {
        var openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        //Debug.Log($"progress.tutorial[1]: {progress.tutorial[1]}");
        if (!SaveManager.GameProgress.Current.tutorial[1] && openLevel > 0)
        {
            if (FireballWasUpgraded())
            {
                buttonInFocus = null;
                this.CallActionAfterDelayWithCoroutine(0.5f, FocusOnMapButton, true);
            }
            return true;
        }
        else if (SaveManager.GameProgress.Current.tutorial[14] && SaveManager.GameProgress.Current.tutorial[15])
        {
            buttonInFocus = null;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
        buttonInFocus = null;
        return false;
    }

    private bool FireballWasUpgraded()
    {
        Spell_Items spellItems = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells);
        return spellItems[0].upgradeLevel > 0;
    }

    bool isInfo = false;

    private void FocusUpgradeButton()
    {
        Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
        Tutorial.Open(target: buttonInFocus.gameObject, focus: new Transform[] { buttonInFocus.transform.parent }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(120, 30), waiting: 0, keyText: "t_0022");
        Time.timeScale = LevelSettings.defaultUsedSpeed;
    }

    public void CloseInfo()
    {
        if (!isInfo)
            return;
        Tutorial.Open(target: btnSCroll.gameObject, focus: new Transform[] { btnSCroll.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(95, 30), waiting: 0, keyText: "");
    }

    private void UpgradeButtonTutorialCallback()
    {
        AnalyticsController.Instance.Tutorial(2, 1);
        fireballUpgradeBtnComponent.onClick.RemoveListener(UpgradeButtonTutorialCallback);
        Tutorial.Close();
        SaveManager.GameProgress.Current.tutorial[1] = true;
        PPSerialization.Save(EPrefsKeys.Progress, SaveManager.GameProgress.Current);
        btnSCroll.GetComponent<Button>().onClick.AddListener(ClickScroll);

        var f = buttonInFocus.transform.parent.Find("Info").gameObject;
        var o = Tutorial.Open(target: f, focus: new Transform[] { f.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(60, 90), waiting: 0);
        o.disableAnimation = true;
        o.dublicateObj = false;
        o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        f.GetComponent<Button>().onClick.AddListener(UpgradeButtonTutorialCallback2);
    }

    void UpgradeButtonTutorialCallback2()
    {
        var f = buttonInFocus.transform.parent.Find("Info").gameObject;
        f.GetComponent<Button>().onClick.RemoveListener(UpgradeButtonTutorialCallback2);
        Tutorial.Close();
        isInfo = true;
        ShopScrollItemSettings.Current.countOpen = -1;
    }

    void ClickScroll()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        btnSCroll.GetComponent<Button>().onClick.RemoveListener(ClickScroll);
        Tutorial.Close();
        Tutorial.OpenBlock(timer:2.5f);
        Tutorial.Open(target: btnBuyScroll, focus: new Transform[] { btnBuyScroll.transform.parent.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(60, 90), waiting: 2.5f);
        btnBuyScroll.GetComponent<Button>().onClick.AddListener(ButScroll);

        SaveManager.GameProgress.Current.tutorial[1] = true;
        SaveManager.GameProgress.Current.Save();
    }

    void ButScroll()
    {
        btnBuyScroll.GetComponent<Button>().onClick.RemoveListener(ButScroll);
        Tutorial.Close();
        FocusOnMapButton();
    }

    private void FocusOnMapButton()
    {
        var mapButton = mapBtn.GetComponentInChildren<Button>();
        if (mapButton != null)
        {
            mapButton.onClick.AddListener(OnMapButtonClick);
        }
        SaveManager.GameProgress.Current.tutorial[1] = true;
        PPSerialization.Save(EPrefsKeys.Progress, SaveManager.GameProgress.Current);
    }

    private void OnMapButtonClick()
    {
        AnalyticsController.Instance.Tutorial(2, 2);
        var mapButton = mapBtn.GetComponentInChildren<Button>();
        if (mapButton != null)
        {
            mapButton.onClick.RemoveListener(OnMapButtonClick);
        }
        Tutorial.Close();
        SaveManager.GameProgress.Current.tutorial[1] = true;
        PPSerialization.Save(EPrefsKeys.Progress, SaveManager.GameProgress.Current);
    }

    private bool EnableUpgradeTutorView()
    {
        var shopUpgradeObj = UpgradesTab.GetComponent<ShopUpgradeItemSettings>();
        if (shopUpgradeObj == null)
        {
            return false;
        }

        shopUpgradeObj.ReloadUI();
        transform.Find("DarkBackground").GetComponent<Button>().enabled = true;
        GameObject.FindObjectOfType<UIShop>().ActiveCastleItems();
        return true;
    }

    public void RunUpgradesTutorial(int id)
    {
        gameObject.SetActive(true);
        var map = new Dictionary<int, System.Action>()
        {
            { 1, ShowMessage_3_01},
            { 2, ShowMessage_3_02},
            { 3, ShowMessage_3_03},
            { 4, ShowMessage_3_04},
            { 5, ShowMessage_3_05},
        };
        if (id > 0 && id < 6)
        {
            map[id].Invoke();
        }
    }

    public void ShowMessage_3_01()
    {
        return;
    }

    private void ShowManaUpgradeTutorial()
    {
        Tutorial.OpenBlock(timer: (1f));
        PlayerPrefs.SetInt("ManaWasUpgradeTutorial", 0);
        PlayerPrefs.Save();
        StartCoroutine(ManaUpgrade());
    }

    private IEnumerator ManaUpgrade()
    {
        yield return new WaitForEndOfFrame();
        UIShop.Instance.ActiveCastleItems();
        UIShop.Instance.FocusItem(manaBtn.transform.parent);
    }

    public void ShowMessage_3_02()
    {
        if (EnableUpgradeTutorView() == false || buttonInFocus != null)
        {
            this.CallActionAfterDelayWithCoroutine(0.1f, ShowMessage_3_02, true);
            return;
        }
        if (!SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.SHOP_UPGRADE_MANA])
        {
            return;
        }
        Debug.Log("ShowMessage_3_02");
    }

    private void StartWallUpgradeTutorial()
    {
        TutorialsManager.OnTutorialStart(ETutorialType.WALL_UPDATE);

        PlayerPrefs.SetInt("WallWasUpgradeTutorial", 0);
        PlayerPrefs.Save();
        var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        Tutorial.OpenBlock(timer: (3.4f));
        StartCoroutine(ShowUpdateWall(upgradeItems));
    }

    [SerializeField] private GameObject wallInfo;
    private IEnumerator ShowUpdateWall(Upgrade_Items upgradeItems)
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        UIShop.Instance.ActiveCastleItems();

        yield return new WaitForSeconds(1f);

        UIShop.Instance.FocusItem(hpBtn.transform.parent);
        SaveManager.GameProgress.Current.tutorial[9] = true;
        SaveManager.GameProgress.Current.Save();
        Tutorial.Open(target: hpBtn.gameObject, focus: new Transform[] { hpBtn.transform.parent }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(120, 30));
        hpBtn.GetComponent<Button>().onClick.AddListener(MageReplicaAfterWallUpdate); 
    }

    private void MageReplicaAfterWallUpdate()
    {
        hpBtn.GetComponent<Button>().onClick.RemoveListener(MageReplicaAfterWallUpdate);
        Tutorial.Close();

        ReplicaUI.ShowReplicaInShop(EReplicaID.Mage_Wall_Upgrade, ReplicaUICanvas.CanvasTransform);
        UI.ReplicaUI.OnReplicaComplete += ReplicaUIOnReplicaComplete;
    }

    private void ReplicaUIOnReplicaComplete(UI.EReplicaID replicaID)
    {
        if (replicaID == EReplicaID.Mage_Wall_Upgrade)
        {
            UI.ReplicaUI.OnReplicaComplete -= ReplicaUIOnReplicaComplete;
            //var tut = Tutorial.Open(target: hpBtn.transform.parent.gameObject, focus: new Transform[] { wallInfo.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(44, 140));
            //tut.dublicateObj = false;
            //wallInfo.transform.GetComponent<Button>().onClick.AddListener(() => { Tutorial.Close(); TutorialsManager.OnTutorialCompleted(); });
            TutorialsManager.OnTutorialCompleted(); // Delete
        }
        //else
        //{
        //    Tutorial.Close();
        //}
        Tutorial.Close();

    }

    public void ShowMessage_3_03()
    {
        return;
    }

    public void ShowUpgradeDragonTutorial()
    {
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber != 15)
            return;
        StartCoroutine(DragonUpgradeTutorial());
    }

    private IEnumerator DragonUpgradeTutorial()
    {
        TutorialsManager.OnTutorialStart(ETutorialType.DRAGON_UPDATE);

        yield return new WaitForEndOfFrame();

        UIShop.Instance.ActiveCastleItems();
        gameObject.SetActive(true);
        UIShop.Instance.FocusItem(dragonBtn.transform.parent);

        SaveManager.GameProgress.Current.tutorial[10] = true;
        SaveManager.GameProgress.Current.Save();

        var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);

        if (upgradeItems[2].upgradeCoins[upgradeItems[2].upgradeLevel] > CoinsManager.Instance.Coins)
            yield break;

        Tutorial.OpenBlock(timer: (upgradeItems[2].effectUnlock ? 0f : 3.4f));
        var tut = Tutorial.Open(target: dragonBtn.gameObject, focus: new Transform[] { dragonBtn.transform.parent }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(120, 30), waiting: upgradeItems[2].effectUnlock ? 0 : 3f);
        tut.dublicateObj = false;

        dragonBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            Tutorial.Close();
            SaveManager.GameProgress.Current.tutorial15lvl = true;
            PlayerPrefs.SetInt("TutorialPetUpgrate", 0);
            PlayerPrefs.Save();

            if (ShopGemItemSettings.instance.GetCount(GemType.Red, 4) > 0)
            {
                Tutorial.Open(target: gemsBtn, focus: new Transform[] { gemsBtn.transform }, mirror: true,
                     rotation: new Vector3(0, 0, 0), offset: new Vector2(50, 50), waiting: 0, keyText: "");

                gemsBtn.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Tutorial.Close();
                    TutorialsManager.OnTutorialCompleted();
                });
            }
        });
    }

    public void ShowMessage_3_04()
    {
        if (EnableUpgradeTutorView() == false || buttonInFocus != null)
        {
            this.CallActionAfterDelayWithCoroutine(0.2f, ShowMessage_3_04, true);
            return;
        }
        UIShop.Instance.ActiveCastleItems();
        Debug.Log("ShowMessage_3_04");
        gameObject.SetActive(true);
        UIShop.Instance.FocusItem(wallBtn.transform.parent);
        SaveManager.GameProgress.Current.tutorial[11] = true;
        SaveManager.GameProgress.Current.Save();
        var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        Tutorial.OpenBlock(timer: (upgradeItems[3].effectUnlock ? 0f : 3.4f));
        Tutorial.Open(target: wallBtn.gameObject, focus: new Transform[] { wallBtn.transform.parent }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(120, 30), waiting: upgradeItems[3].effectUnlock ? 0 : 3f);
        wallBtn.GetComponent<Button>().onClick.AddListener(() => { Tutorial.Close(); });
    }

    public void ShowMessage_3_05()
    {
        if (EnableUpgradeTutorView() == false || buttonInFocus != null)
        {
            this.CallActionAfterDelayWithCoroutine(0.2f, ShowMessage_3_05, true);
            return;
        }
        if (SaveManager.GameProgress.Current.tutorialOpenFreezeDragon)
        {
            return;
        }
        UIShop.Instance.ActiveCastleItems();
        Debug.Log("ShowMessage_3_05");
        gameObject.SetActive(true);
        var rect = dragonFreezeBtn.transform.parent.parent.gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + 220f);
        UIShop.Instance.FocusItem(dragonFreezeBtn.transform.parent);
        SaveManager.GameProgress.Current.tutorialOpenFreezeDragon = true;
        SaveManager.GameProgress.Current.Save();
        var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        Tutorial.OpenBlock(timer: (upgradeItems[3].effectUnlock ? 0.5f : 3.4f));
        Tutorial.Open(target: dragonFreezeBtn.gameObject, focus: new Transform[] { dragonFreezeBtn.transform.parent }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(120, 30), waiting: upgradeItems[3].effectUnlock ? 0.5f : 3f);
        dragonFreezeBtn.GetComponent<Button>().onClick.AddListener(CloseFrost);
    }

    void CloseFrost()
    {
        dragonFreezeBtn.GetComponent<Button>().onClick.RemoveListener(CloseFrost);
        Tutorial.Close();
        var rect = dragonFreezeBtn.transform.parent.parent.gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y - 220f);
    }
    public void RunWearTutor()
    {
        if (!SaveManager.GameProgress.Current.tutorial[14] || !SaveManager.GameProgress.Current.tutorial[15])
        {
            Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
            gameObject.SetActive(true);
            print("progress.tutorial[14] = " + SaveManager.GameProgress.Current.tutorial[14].ToString());
            if (!SaveManager.GameProgress.Current.tutorial[14])
            {
                Invoke("ShowMessage_4_01_WearBtn", 0.05f);
            }
            this.CallActionAfterDelayWithCoroutine(0.5f, ContinueWearTutor, true);
        }
    }

    public void ContinueWearTutor()
    {
        if (!SaveManager.GameProgress.Current.tutorial[14])
        {
            gameObject.SetActive(true);
            UIShop.Instance.ActiveStaffItems();
            this.CallActionAfterDelayWithCoroutine(0.03f, ShowMessage_4_02_RobeBtn, true);
        }
        else if (!SaveManager.GameProgress.Current.tutorial[15])
        {
            UIShop.Instance.ActiveStaffItems();
            gameObject.SetActive(true);
            this.CallActionAfterDelayWithCoroutine(0.03f, ShowMessage_4_02_StaffBtn, true);
        }
    }

    private void ShowMessage_4_01_WearBtn()
    {
        if (buttonInFocus != null)
        {
            Debug.LogFormat("UpgradeButton is busy by {0}", buttonInFocus.transform.name);
            this.CallActionAfterDelayWithCoroutine(0.03f, ShowMessage_4_01_WearBtn, true);
            return;
        }
        MessagaForStaffButton();
        staffsButton.GetComponent<Button>().onClick.AddListener(OnStaffsButtonClicked);
        Debug.Log("ShowMessage_4_01_WearBtn");
        ContinueGame();
        ContinueWearTutor();

    }

    public void MessagaForStaffButton()
    {
        MessagaForButton(staffsButton, "t_0414");
        messageTexts[0].text = TextSheetLoader.Instance.GetString("t_0558");
    }

    public void MessagaForSepllPanelButton()
    {
        UIShop.Instance.ActiveSpellItems();
        UIShop.Instance.FocusItem(spellPanel.gameObject.transform);
    }

    public void MessagaForScrollPanelButton()
    {
        MessagaForButton(scrollPanel.gameObject, "t_0523");
        Debug.Log("Use Crystal 523");
    }

    public void MessagaForButton(GameObject btn, string localization)
    {
        animatePointer = true;
        messageTexts[0].text = TextSheetLoader.Instance.GetString(localization);
        handPointer.localScale = new Vector3(-1f, 1f, 1f);
        handPointerPressed.localScale = new Vector3(-1f, 1f, 1f);
        Debug.Log("MessagaForButton");
        if (pointerAnim != null)
            StopCoroutine(pointerAnim);
        pointerAnim = StartCoroutine(PointTheHandAt(btn.GetComponent<RectTransform>().GetRectCenter()));
        TutorialUtils.AddCanvasOverride(btn.gameObject);
    }

    private void OnStaffsButtonClicked()
    {
        staffsButton.GetComponent<Button>().onClick.RemoveListener(OnStaffsButtonClicked);
        //ContinueGame();
        ContinueWearTutor();
    }

    public void OnWearRobeOrStaffButtonClicked()
    {
        var isAnyWearTutor = false;
        if (!SaveManager.GameProgress.Current.tutorial[14])
        {
            isAnyWearTutor = true;
            SaveManager.GameProgress.Current.tutorial[14] = true;
            TutorialUtils.ClearAllCanvasOverrides();
            Invoke("ShowMessage_4_02_StaffBtn", 0.03f);
            //StartCoroutine (CallActionAfterDelay (ShowMessage_4_02_StaffBtn, 0.5f));
        }
        else if (!SaveManager.GameProgress.Current.tutorial[15])
        {
            currentMessage++;
            isAnyWearTutor = true;
            SaveManager.GameProgress.Current.tutorial[15] = true;
        }
        if (isAnyWearTutor)
        {
            PPSerialization.Save(EPrefsKeys.Progress, SaveManager.GameProgress.Current);
            ContinueGame();
        }
    }

    private void ShowMessage_4_02_RobeBtn()
    {
        Debug.Log("ShowMessage_4_02_RobeBtn");
        FocusUIButtonTutorial(14, pickRobeBtn, "t_0416");
    }

    private void ShowMessage_4_02_StaffBtn()
    {
        Debug.Log("ShowMessage_4_02_StaffBtn");
        FocusUIButtonTutorial(15, pickStaffBtn, "t_0415");
    }

    public void FocusUIButtonTutorial(int tutorialIndex, GameObject objectToFocusOn, string localizationId, float offset = -1)
    {

        System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
        Debug.Log("---FocusUIButtonTutorial" + stackTrace.GetFrame(1).GetMethod().Name);
        Debug.Log($"objectToFocusOn { objectToFocusOn.name}");
        if (SaveManager.GameProgress.Current.tutorial[tutorialIndex])
            return;
        animatePointer = true;
        gameObject.SetActive(true);
        if (offset != -1)
        {
            handPointer.gameObject.SetActive(false);
            handPointerPressed.gameObject.SetActive(false);
        }
        StartCoroutine(_Focus(tutorialIndex, objectToFocusOn, localizationId, offset));
    }

    IEnumerator _Focus(int tutorialIndex, GameObject objectToFocusOn, string localizationId, float offset = -1)
    {
        if (offset != -1)
            yield return new WaitForSecondsRealtime(offset);
        messageTexts[0].GetComponent<LocalTextLoc>().enabled = false;
        messageTexts[0].text = TextSheetLoader.Instance.GetString(localizationId);
        RectTransform rect = objectToFocusOn.GetComponent<RectTransform>();
        var targetPosition = rect.GetRectCenter(normalizedOffsetFactor: new Vector2(-0.25f, 0.25f));
        if (pointerAnim != null)
            StopCoroutine(pointerAnim);

        pointerAnim = StartCoroutine(PointTheHandAt(targetPosition, offset));
        Debug.Log("FocusUIButtonTutorial");
        TutorialUtils.AddCanvasOverride(objectToFocusOn);
        Time.timeScale = 0;
    }

    // Функция вызывается при нажатии на кнопку FireBall - Upgrade
    public void ContinueGameFromUpgrades()
    {
        currentMessage++;
        ContinueGame();
    }
    public void ContinueGame(bool back = true)
    {
        currentMessage++;
        // Возвращаем кнопку обратно
        animatePointer = false;
        if (back)
            TutorialUtils.ClearAllCanvasOverrides();

        Time.timeScale = LevelSettings.defaultUsedSpeed;

        if (currentMessage > 1 && !isOldGameVersion)
            gameObject.SetActive(false);
        else
            GetComponent<Animator>().enabled = false;

        handPointer.localScale = new Vector3(1f, 1f, 1f);
        handPointerPressed.localScale = new Vector3(1f, 1f, 1f);
        buttonInFocus = null;
    }

    public IEnumerator PointTheHandAt(Vector3 position, float offset = -1)
    {
        var tutorTextBar = transform.Find("TutorTextBar");
        transform.Find("DarkBackground").gameObject.SetActive(true);
        tutorTextBar.gameObject.SetActive(true);
        messageObject.gameObject.SetActive(true);
        tutorTextBar.GetComponent<Image>().color = Color.white;
        messageObject.GetComponent<Text>().color = Color.white;

        SetupHandTransform(handPointer, position);
        SetupHandTransform(handPointerPressed, position);
        handPointer.gameObject.SetActive(true);
        handPointerPressed.gameObject.SetActive(false);

        var handPointerImageComponent = handPointer.GetComponent<Image>();
        handPointerImageComponent.color = new Color(1f, 1f, 1f, 1f);
        bool actiave = false;
        Debug.Log("PointTheHandAt: " + animatePointer);
        while (animatePointer == true)
        {
            handPointer.gameObject.SetActive(actiave);
            handPointerPressed.gameObject.SetActive(!actiave);
            yield return new WaitForSecondsRealtime(actiave ? 0.6f : 0.15f);
            actiave = !actiave;
        }
        handPointerImageComponent.color = new Color(1f, 1f, 1f, 0f);
        yield break;
    }

    private void SetupHandTransform(RectTransform rectTarnsform, Vector3 centerPosition)
    {
        var scale = rectTarnsform.lossyScale;
        var size = rectTarnsform.rect.size;
        centerPosition.x += (size.x / 2f) * scale.x - 10f;
        centerPosition.y -= ((size.y / 2f) * scale.y) - 20f;
        rectTarnsform.localPosition = centerPosition;
        Debug.Log("SetupHandTransform: " + centerPosition);
    }

    public void TryStartChainLightTutor(int lightSlotId)
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(ChainLightChangeStartTutor(lightSlotId));
        }
    }

    private IEnumerator ChainLightChangeStartTutor(int lightSlotId)
    {
        yield return new WaitForEndOfFrame();
        while (buttonInFocus != null)
        {
            yield return new WaitForSeconds(0.1f);
        }
        if (SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.CHANGE_LIGHTNINGS])
        {
            yield break;
        }

        UIShop.Instance.FocusItem(chainLightningButton.transform.parent);
        Tutorial.Open(target: chainLightningButton.gameObject, focus: new Transform[] { lightingSpell.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(45, 60), waiting: 0.5f, keyText: "t_0502");
        chainLightningButton.GetComponent<Button>().onClick.AddListener(delegate { OnChaingLightningPicked(lightSlotId); });
        yield break;
    }

    private void OnChaingLightningPicked(int lightSlotId)
    {
        Tutorial.Close();
        buttonInFocus = ShopSpellItemSettings.Current.slots.transform.GetChild(lightSlotId).gameObject;
        chainLightningButton.GetComponent<Button>().onClick.RemoveListener(delegate { OnChaingLightningPicked(lightSlotId); });
        buttonInFocus.GetComponent<Button>().onClick.AddListener(OnChaingLightningChanged);

        Tutorial.Open(target: buttonInFocus.gameObject, focus: new Transform[] { buttonInFocus.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 90), waiting: 0.5f, keyText: "t_0503");
    }
    private void OnChaingLightningChanged()
    {
        Tutorial.Close();
        currentMessage++;
        buttonInFocus.GetComponent<Button>().onClick.RemoveListener(OnChaingLightningChanged);
        TutorialsManager.MarkTutorialAsComplete(ETutorialType.CHANGE_LIGHTNINGS);
    }
}