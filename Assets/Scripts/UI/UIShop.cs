using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

public class UIShop : UI.UIBackbtnClickDispatcher, UI.IOnbackButtonClickListener
{
    public static string LastActiveShopPagePrefsKey = "LastActiveShopPage";
    private const string LastActiveScrollYPositionPrefsKey = "LastActiveShopPageScrollYPosition";

    public static UIShop Instance { get; private set; }
    private static Spell.SpellType lastOpenNewSpell;


    public ScrollRect scrollRect; // Для указания области скроллинга (переключаются кнопками слева)
    public GameObject activeGlow, activeGlowRight; // Подсветка активной кнопки
    public GameObject[] groupBtn; // Массив кнопок слева
    public GameObject[] groupItems;    // Массив областей скроллинга (заклинания, свитки и т.д.)
    public Animator buyCoinsAnimator;

    public GameObject btnAds, gemsBtn;

    [SerializeField]
    private GameObject shopItemsMaskObj;

    [SerializeField]
    private GameObject infoWithPurching;

    //[SerializeField]
    //private Button restorePurchasesBtn;
    private GameObject activeBtn;
    public GameObject mapBtn;
    private GameObject activeItems;
    private Color activeColor, notactiveColor;
    private Vector3[] glowPos = new Vector3[6], glowPosRight = new Vector3[2]; // Массив позиций подсветки активной кнопки
    public UIBlackPatch BlackScreen;

    [Space(15f)]
    public UIConsFlyAnimation coinsFlyAnimation;
    [SerializeField]
    private Transform videoAdBtnTransf;
    [SerializeField]
    public Transform coinsIndecatorIconTransf;

    public FastLinkGameobjectsLists onOffLinks;

    public GameObject[] tutorialHand;
    [SerializeField]
    VipControllerBonus vipBonus;

    public UIScaleEffect scaleGems;

    public Transform iceStrike;

    public Sprite spriteBtnInfo, spriteBtnInfoDefault;
    public Sprite[] spriteBtnBuy;

    public GameObject btnSellGem, btnSellPlus;

    public int openPanel = -1; // если необходимо открыть панель с вещами после определённого действия
                               // 0 - spell after close achivement 
                               // 1 - spell after close info wear 

    public Tutorial_2 tutor;

    public Transform speel3;
    public Text coinsAddedText;
    public static int coinsAdded;

    [SerializeField] private GameObject yellowGlowEffect;
    [SerializeField] private GameObject yellowGlowEffectRight;

    [SerializeField] private GameObject fireDragon;
    [SerializeField] private GameObject iceDragon;

    [SerializeField] private Button barrierInfo;

    GameObject CurrentButtonPosition;
    GameObject CurrentBackPosition;

    [Space(5f)]
    [SerializeField] GameObject gemsLock;
    [SerializeField] GameObject staffLock;
    override protected bool IsBackButtonClicked
    {
        get
        {
            return (BlackScreen.isOuted && base.IsBackButtonClicked && !UI.UIWindowBase.isAnyWindowActive);
        }
    }

    void OnDisable()
    {
        //Debug.LogError("UIShop removed");
    }

    void Awake()
    {
        SoundController.Instanse.timerPlay = 2f;
        Instance = this;
        AddOnBackButtonListener(this);

        UIControl.countRestart = 0;

    }

    IEnumerator Start()
    {
        Debug.Log($"======================= SHOP ==========================");
        SaveManager.GameProgress.Current.Save(true);
        StartCoroutine(_Start());
        OpenInfoItem_Acid();
        // if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 1 && !SaveManager.GameProgress.Current.tutAchivement && !PlayerPrefs.HasKey("AcidTut"))
        // {
        //     yield return new WaitForEndOfFrame();
        //     Instance.ActiveScrollItems();
        //     Tutorial.OpenBlock(timer: 2);
        //     yield return new WaitForSecondsRealtime(2);
        //     Destroy(GameObject.Find("Item_Acid").GetComponent<Animator>());
        //     var b = GameObject.Find("Item_Acid").transform.GetChild(2).GetComponent<Button>();
        //     var t = Tutorial.Open(target: b.gameObject,
        //         focus: new Transform[] { b.transform },
        //         mirror: false, 
        //         rotation: new Vector3(0, 0, 20f), 
        //         offset: new Vector2(40, 80), 
        //         waiting: 0);
        //     t.dublicateObj = false;
        //     b.onClick.AddListener(OpenInfoItem_Acid);
        // }
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber < 2)
        {
            gemsLock.SetActive(true);
            staffLock.SetActive(true);
        }
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 4 && !PlayerPrefs.HasKey("BarierTut"))
        {
            yield return new WaitForEndOfFrame();
            Instance.ActiveScrollItems();
            yield return new WaitForSecondsRealtime(.25f);
            var t = Tutorial.Open(target: barrierInfo.gameObject, focus: new Transform[] { barrierInfo.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 20f), offset: new Vector2(40, 80), waiting: 0);
            t.dublicateObj = false;
            barrierInfo.onClick.AddListener(OpenInfoItem_Barier);
        }

        coinsAddedText.gameObject.SetActive(coinsAdded > 0);
        coinsAddedText.text = "+" + coinsAdded.ToString();
        yield return new WaitForSecondsRealtime(4.8f);

        CoinsManager.AddCoinsST(coinsAdded);
        coinsAdded = 0;
    }

    void OpenInfoItem_Barier()
    {
        Tutorial.Close();
        PlayerPrefs.SetInt("BarierTut", 1);
        barrierInfo.onClick.RemoveListener(OpenInfoItem_Barier);
    }

    private Button infoSpell;

    void OpenInfoItem_Acid()
    {
        Tutorial.Close();
        PlayerPrefs.SetInt("AcidTut", 1);
        PlayerPrefs.Save();

        var acidInfo = GameObject.Find("Item_Acid").transform.GetChild(2).GetComponent<Button>();
        acidInfo.onClick.RemoveListener(OpenInfoItem_Acid);

        infoSpell = GameObject.Find("InfoSpell(Clone)").transform.GetChild(1).GetComponent<Button>();
        infoSpell.onClick.AddListener(ShowAchivmentTutorial);
    }

    void ShowAchivmentTutorial()
    {
        if (infoSpell != null)
            infoSpell.onClick.RemoveListener(ShowAchivmentTutorial);
        UIAchievementsHelper.instance.OpenTutorialBtn();
    }

    IEnumerator _MapBtn()
    {
        yield return new WaitForSecondsRealtime(5);
        mapBtn.GetComponent<Animator>().enabled = true;
    }

    // если необходимо открыть панель с вещами после определённого действия
    public void ActiveAndAction()
    {
        if (openPanel == 0 || openPanel == 1)
        {
            UIShop.Instance.ActiveScrollItems();
            StartCoroutine(_MapBtn());
        }

        if (Tutorial_2.IsActive && Tutorial_2.Instance.isOldGameVersion)
        {
            Tutorial_2.Instance.infoCheck = false;
        }

        openPanel = -1;
    }

    private void FixedUpdate()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
    }

    void UpdatePositionContent()
    {
        var currentContentPosition = scrollRect.content.anchoredPosition;
        currentContentPosition.y = PlayerPrefs.GetFloat(LastActiveScrollYPositionPrefsKey + scrollRect.content.name, currentContentPosition.y);
        scrollRect.content.anchoredPosition = currentContentPosition;
    }

    IEnumerator _Start()
    {
        int lastActiveShopPage = PlayerPrefs.GetInt(LastActiveShopPagePrefsKey, 0);
        if (lastActiveShopPage >= 0)
        {
            if (lastActiveShopPage == 0 && SaveManager.GameProgress.Current.finishCount.Count(i => i > 0) == 2)
                lastActiveShopPage = 2;
            ActivateShopGroup(lastActiveShopPage);
            UpdatePositionContent();
            scrollRect.onValueChanged.AddListener((Vector2 v) => {
                //Debug.Log($"{LastActiveScrollYPositionPrefsKey + scrollRect.content.name}, y: {scrollRect.content.anchoredPosition.y}");
                PlayerPrefs.SetFloat(LastActiveScrollYPositionPrefsKey + scrollRect.content.name, scrollRect.content.anchoredPosition.y);
            });
        }

        ForceShopItemHighlighting();

        var isAnyTutorial = Tutorial_2.Instance.CheckForTutorials();//Order matters :/

        UpgradeItem.UpgradeType openNewUpgrade = UpgradeItem.UpgradeType.None;
        bool unlockUpgrades = mainscript.AutoUnlockPlayerUpgrades(out openNewUpgrade);
        ShopUpgradeItemSettings.SetUpgradeForHighlighting(openNewUpgrade);

        //isAnyTutorial |= unlockUpgrades;

        if (activeItems == null)
        {
            activeBtn = groupBtn[0];
            activeItems = groupItems[0];
        }
        else if (activeItems != groupItems[0])
            groupItems[0].gameObject.SetActive(false);
        InfoLoaderConfig.Instance.maxOpenedLevel = 99999;
        // Позиции подсветки активной кнопки
        float yPos = 180;
        for (int i = 0; i < glowPos.Length; i++)
        {
            glowPos[i] = new Vector3(0f, yPos, 0f);
            yPos -= 105;
        }
        for (int i = 0; i < glowPosRight.Length; i++)
        {
            glowPosRight[i] = new Vector3(0f, yPos, 0f);
            yPos += 213.4f;
        }

        SpecialOffer.instance.Open();
        SoundController.Instanse.StopAllBackgroundSFX();
        SoundController.Instanse.RlayShopSFX();

        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 6 && !SaveManager.GameProgress.Current.tutLevel6) // 
        {
            SaveManager.GameProgress.Current.tutLevel6 = true;

            ActiveSpellItems();
            FocusItem(speel3);
            Tutorial.OpenBlock(timer: 4f);

            yield return new WaitForSecondsRealtime(4);

            Tutorial.Close();
            Tutorial_2.Instance.CombineTwoCrystals.Run();
        }

        if (isAnyTutorial)
            yield break;

        btnAds.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);

        yield return new WaitForEndOfFrame();

        bool shouldOpenTutorial = false;
        int tutorialType = -1;

        if (!SaveManager.GameProgress.Current.tutorial30lvl && SaveManager.GameProgress.Current.CompletedLevelsNumber == 30 && ShopGemItemSettings.instance.GetCount(GemType.Blue, 5) > 0)
        {
            SaveManager.GameProgress.Current.tutorial30lvl = true;
            shouldOpenTutorial = true;
            tutorialType = 1;
        }
        else if (!SaveManager.GameProgress.Current.tutorial45lvl && SaveManager.GameProgress.Current.CompletedLevelsNumber == 45 && ShopGemItemSettings.instance.GetCount(GemType.White, 6) > 0)
        {
            SaveManager.GameProgress.Current.tutorial45lvl = true;
            shouldOpenTutorial = true;
            tutorialType = 2;
        }
        else if (!SaveManager.GameProgress.Current.tutorial70lvl && SaveManager.GameProgress.Current.CompletedLevelsNumber == 70 && ShopGemItemSettings.instance.GetCount(GemType.Yellow, 8) > 0)
        {
            SaveManager.GameProgress.Current.tutorial70lvl = true;
            shouldOpenTutorial = true;
            tutorialType = 3;
        }
        else if (!SaveManager.GameProgress.Current.tutorial95lvl && SaveManager.GameProgress.Current.CompletedLevelsNumber == 95 && ShopGemItemSettings.instance.GetCount(GemType.Red, 8) > 0)
        {
            SaveManager.GameProgress.Current.tutorial95lvl = true;
            shouldOpenTutorial = true;
            tutorialType = 4;
        }

        if (shouldOpenTutorial)
            SaveManager.GameProgress.Current.Save();

        if (shouldOpenTutorial)
        {
            Tutorial.Open(target: gemsBtn, focus: new Transform[] { gemsBtn.transform }, mirror: true,
                     rotation: new Vector3(0, 0, 0), offset: new Vector2(50, 50), waiting: 0, keyText: "");

            gemsBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                Tutorial.Close();
                if (tutorialType == 1)
                {
                    ShopGemItemSettings.instance.GemSelect(4, GemType.Blue, effect: !SaveManager.GameProgress.Current.tutorial30lvl);
                }
                else if (tutorialType == 2)
                {
                    ShopGemItemSettings.instance.GemSelect(5, GemType.White, effect: !SaveManager.GameProgress.Current.tutorial45lvl);
                }
                else if (tutorialType == 3)
                {
                    ShopGemItemSettings.instance.GemSelect(7, GemType.Yellow, effect: !SaveManager.GameProgress.Current.tutorial70lvl);
                }
                else if (tutorialType == 4)
                {
                    ShopGemItemSettings.instance.GemSelect(7, GemType.Red, effect: !SaveManager.GameProgress.Current.tutorial95lvl);
                }
            });
        }
        else
        {
            int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber + 1;

            Debug.Log($"---- ----- openLevel: {openLevel}");

            if (openLevel == 8)
            {
                ActiveScrollItems();
                UIShop.Instance.FocusItem(ShopScrollItemSettings.Current.ShopItemsObjects[2].transform);
            }
            if (openLevel == 4 || openLevel == 53)
                ActiveSpellItems();
            if (openLevel == 25)
                ActiveBottleItems();
            if (openLevel == 50)
                ActiveCastleItems();
            if (openLevel == 61 || openLevel == 32 || openLevel == 33 || openLevel == 45 || openLevel == 43 || openLevel == 52)
                ActiveStaffItems();
            if (openLevel == 66)
            {
                ActiveSpellItems();
                UIShop.Instance.FocusItem(ShopSpellItemSettings.Current.ShopItemsObjects[ShopSpellItemSettings.Current.ShopItemsObjects.Length - 3].transform);
            }
            if (openLevel == 67)
            {
                ActiveStaffItems();
                UIShop.Instance.FocusItem(ShopWearItemSettings.instance.shopWearItems[ShopWearItemSettings.instance.shopWearItems.Length - 1].transform);
            }
            if (openLevel == 62 || openLevel == 65 || openLevel == 86)
                ActiveBonusItems();

            if (openLevel == 34) // || openLevel == 81
            {
                //SpecialOffer.instance.ResetData();
                ActiveBottleItems();
            }

            if (openLevel == 51) // || openLevel == 81
            {
                ActiveCastleItems();
                FocusItem(ShopUpgradeItemSettings.Current.ShopItemsObjects[ShopUpgradeItemSettings.Current.ShopItemsObjects.Length - 1].transform);
            }

            if (openLevel == 85)
            {
                ActiveCastleItems();
                UIShop.Instance.FocusItem(ShopUpgradeItemSettings.Current.ShopItemsObjects[ShopUpgradeItemSettings.Current.ShopItemsObjects.Length - 1].transform);
            }

            if (openLevel - 1 == mainscript.levelOpenSellGem && !SaveManager.GameProgress.Current.tutorialSellShop)
            {
                var tut = Tutorial.Open(target: gemsBtn.gameObject, focus: new Transform[] { gemsBtn.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 50), waiting: 0.5f, keyText: "");
                gemsBtn.GetComponent<Button>().onClick.AddListener(ClickToGem);
            }
        }
    }

    void ClickToGem()
    {
        btnSellGem.GetComponent<Animator>().enabled = true;
        var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
        int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Red, 0);
        gemItems[gem1Id].count += 1;
        PPSerialization.Save(EPrefsKeys.Gems, gemItems);
        Tutorial.Close();
        ShopGemItemSettings.instance.WearChoose(WearType.staff);
        gemsBtn.GetComponent<Button>().onClick.RemoveListener(ClickToGem);
        var o = Tutorial.Open(target: btnSellGem.gameObject, focus: new Transform[] { btnSellGem.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(55, 50), waiting: 0.5f, keyText: "");
        o.disableAnimation = true;
        o.dublicateObj = false;
        o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        btnSellGem.GetComponent<Button>().onClick.AddListener(ClickSell);
    }

    void ClickSell()
    {
        Tutorial.Close();
        btnSellGem.GetComponent<Button>().onClick.RemoveListener(ClickSell);
        StartCoroutine(_CLose());
        btnSellPlus.GetComponent<Button>().onClick.AddListener(ClickToGemPlus);
        var o = Tutorial.Open(target: btnSellPlus.gameObject, focus: new Transform[] { btnSellPlus.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(55, 50), waiting: 0.5f, keyText: "");
        o.disableAnimation = true;
        o.dublicateObj = false;
        o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    void ClickToGemPlus()
    {
        Tutorial.Close();
        btnSellPlus.GetComponent<Button>().onClick.RemoveListener(ClickToGemPlus);
        SaveManager.GameProgress.Current.tutorialSellShop = true;
        SaveManager.GameProgress.Current.Save();
    }

    IEnumerator _CLose()
    {
        yield return new WaitForSecondsRealtime(2f);
        //BtnUnlock
        btnSellGem.transform.Find("BtnUnlock").gameObject.SetActive(false);
        btnSellGem.GetComponent<Animator>().enabled = false;
    }

    private void ForceShopItemHighlighting()
    {
        var shopHighlightingData = ShopHighlightingData.Load();
        int openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0) + 1;

        try
        {
            if (openLevel > 4 && !shopHighlightingData.scroll[(int)Scroll.ScrollType.Barrier])
            {
                ActiveScrollItems();
                Transform t = ShopScrollItemSettings.Current.GetScrollItemUILocalTransform(Scroll.ScrollType.Barrier);
                Debug.Log($"Barrier");
                StartCoroutine(_SCrollView(t));
            }
        }
        catch (System.Exception er){
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 7 && !shopHighlightingData.spell[(int)Spell.SpellType.IceStrike])
            {
                ActiveSpellItems();
                Transform t = ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting);
                Debug.Log($"IceStrike");
                StartCoroutine(_SCrollView(t));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel == 11 && !shopHighlightingData.spell[(int)Spell.SpellType.EarthBall])
            {
                StartCoroutine(FocusOnEarthSpell());
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel == 12 && !shopHighlightingData.scroll[(int)Scroll.ScrollType.Minefield])
            {
                StartCoroutine(FocusOnMineHiglight());
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 21 && !shopHighlightingData.spell[(int)Spell.SpellType.IceBreath])
            {
                ActiveSpellItems();
                StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 26 && !shopHighlightingData.spell[(int)Spell.SpellType.Boulder])
            {
                ActiveSpellItems();
                StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 50 && !shopHighlightingData.castle[(int)UpgradeItem.UpgradeType.GuardPetFrost])
            {
                ActiveCastleItems();
                StartCoroutine(_SCrollView(ShopUpgradeItemSettings.Current.GetUpgradeItemUILocalTransform(UpgradeItem.UpgradeType.GuardPetFrost)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 52 && !shopHighlightingData.spell[(int)Spell.SpellType.Meteor])
            {
                ActiveSpellItems();
                StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 67 && !shopHighlightingData.spell[(int)Spell.SpellType.ElecticPool])
            {
                ActiveSpellItems();
                StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 75 && !shopHighlightingData.spell[(int)Spell.SpellType.Blizzard])
            {
                ActiveSpellItems();
                StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 80 && !shopHighlightingData.spell[(int)Spell.SpellType.FireDragon])
            {
                ActiveSpellItems();
                StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        try
        {
            if (openLevel > 86 && !shopHighlightingData.scroll[(int)Scroll.ScrollType.Haste])
            {
                ActiveScrollItems();
                StartCoroutine(_SCrollView(ShopScrollItemSettings.Current.GetScrollItemUILocalTransform(Scroll.ScrollType.Haste)));
            }
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
        }
        shopHighlightingData.Save();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackButtonClick();
        }
        if (CurrentButtonPosition != null)
        {
            //yellowGlowEffect.transform.position = CurrentButtonPosition.GetComponent<RectTransform>().GetRectCenter();
            CurrentBackPosition.transform.position = CurrentButtonPosition.GetComponent<RectTransform>().GetRectCenter();
        }
    }

    private IEnumerator FocusOnMineHiglight()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        ActiveScrollItems();
        Tutorial.OpenBlock(timer: 1f);

        FocusItem(ShopScrollItemSettings.Current.GetScrollItemUILocalTransform(Scroll.ScrollType.Minefield));

        yield return new WaitForSecondsRealtime(1f);
        Tutorial.Close();
    }

    private IEnumerator FocusOnEarthSpell()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        ActiveSpellItems();
        Tutorial.OpenBlock(timer: 1f);
        var spell = ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(Spell.SpellType.EarthBall);
        FocusItem(spell);

        yield return new WaitForSecondsRealtime(1f);
        Tutorial.Close();
    }

    public static void SetOpenNewSpell(Spell.SpellType spellType)
    {
        lastOpenNewSpell = spellType;
    }

    public void OpenNewSpellToView()
    {
        var shopHighlightingData = ShopHighlightingData.Load();

        if (!shopHighlightingData.spell[(int)ShopSpellItemSettings.GetSpellTypeForHighlighting])
        {
            shopHighlightingData.spell[(int)ShopSpellItemSettings.GetSpellTypeForHighlighting] = true;
            shopHighlightingData.Save();
        }

        ActiveSpellItems();
        StartCoroutine(_SCrollView(ShopSpellItemSettings.Current.GetSpellItemUILocalTransform(ShopSpellItemSettings.GetSpellTypeForHighlighting)));
    }

    public void OpenNewScrollToView()
    {
        if (ShopScrollItemSettings.GetScrollTypeForHighlighting == Scroll.ScrollType.Acid)
        {
            return;
        }

        var shopHighlightingData = ShopHighlightingData.Load();
        if (!shopHighlightingData.scroll[(int)ShopScrollItemSettings.GetScrollTypeForHighlighting])
        {
            shopHighlightingData.scroll[(int)ShopScrollItemSettings.GetScrollTypeForHighlighting] = true;
            shopHighlightingData.Save();
        }

        ActiveScrollItems();
        StartCoroutine(_SCrollView(ShopScrollItemSettings.Current.GetScrollItemUILocalTransform(ShopScrollItemSettings.GetScrollTypeForHighlighting)));
    }

    public void OpenNewCastleToView()
    {
        if (ShopUpgradeItemSettings.GetUpgradeTypeForHighlighting == UpgradeItem.UpgradeType.Knowledge ||
            ShopUpgradeItemSettings.GetUpgradeTypeForHighlighting == UpgradeItem.UpgradeType.Fortification)
        {
            Debug.Log($"OpenNewCastleToView RETURN: {ShopUpgradeItemSettings.GetUpgradeTypeForHighlighting}");
            return;
        }

        var shopHighlightingData = ShopHighlightingData.Load();
        if (!shopHighlightingData.castle[(int)ShopUpgradeItemSettings.GetUpgradeTypeForHighlighting])
        {
            shopHighlightingData.castle[(int)ShopUpgradeItemSettings.GetUpgradeTypeForHighlighting] = true;
            shopHighlightingData.Save();
        }

        ActiveCastleItems();
        StartCoroutine(_SCrollView(ShopUpgradeItemSettings.Current.GetUpgradeItemUILocalTransform(ShopUpgradeItemSettings.GetUpgradeTypeForHighlighting)));
    }

    IEnumerator _SCrollView(Transform tr)
    {
        Debug.Log($"_SCrollView");
        FocusItem(tr);
        yield return new WaitForEndOfFrame();
    }

    public void OnBackButtonClick()
    {
        ToMap();
    }

    Transform isFocus = null;

    public void FocusItem(Transform itemTransform)
    {
        //var position = scrollRect.content.anchoredPosition;
        //var rect = itemTransform.gameObject.GetComponent<RectTransform>();
        //position.y = -(rect.anchoredPosition.y + (rect.sizeDelta.y));
        //Debug.Log($"focus: position: {position}, rect: {rect}, position.y: {position.y}");
        //scrollRect.content.anchoredPosition = position;
        StartCoroutine(_ScrollReset(itemTransform.gameObject.GetComponent<RectTransform>()));
    }
    IEnumerator _ScrollReset(RectTransform rect)
    {
        yield return new WaitForEndOfFrame();
       // yield return new WaitForSecondsRealtime(1.5f);
        //Debug.Log($"======= Item Rect: {rect.anchoredPosition}");
        scrollRect.content.anchoredPosition = new Vector2(0f, -(rect.anchoredPosition.y + (rect.sizeDelta.y)));
        //Debug.Log($"======= Item Rect  xxx: {scrollRect.content.anchoredPosition}");
    }

    private void ActivateShopGroup(int index)
    {
        //Debug.Log("ActivateShopGroup: " + index);
        PlayerPrefs.SetInt(LastActiveShopPagePrefsKey, index);
        Deactivation();
        activeItems = groupItems[index];
        activeBtn = groupBtn[index];
        Activation(index);
        //scrollRect.StopMovement();
        ResetScrollRectPosition(index);
        StartCoroutine(_Active());
    }

    IEnumerator _Active()
    {
        yield return new WaitForEndOfFrame();
        var s = FindObjectsOfType<ShopItem>();
        foreach (var o in s)
            o.UpdateButtonsUnlock();
    }

    public void ResetScrollRectPosition(int index = -1)
    {
       
    }
    
    public void OnSpellsButtonClicked()
    {
        if (IsActiveSpellItems())
            return;

        ActiveSpellItems();
        ShopSpellItemSettings.Current.Open();
    }

    public void OnScrollButtonClicked()
    {
        if (IsActiveScrollItems())
            return;

        ActiveScrollItems();
        ShopScrollItemSettings.Current.ClickOpen();
        ShopScrollItemSettings.Current.Open();
    }

    public void OnBottleButtonClicked()
    {
        if (IsActiveBottleItems())
            return;

        ActiveBottleItems();
        ShopPotionItemSettings.instance.ClickOpen();
    }

    public void OnCastleButtonClicked()
    {
        if (IsActiveCastleItems())
            return;

        ActiveCastleItems();
        ShopUpgradeItemSettings.Current.Open();
    }

    public void OnBonusButtonClicked()
    {
        if (IsActiveBonusItems())
            return;

        ActiveBonusItems();
    }

    public void OnStaffButtonClicked()
    {
        if (IsActiveStaffItems())
            return;

        ActiveStaffItems();
    }

    public void ActiveSpellItems()
    {
        ActivateShopGroup(0);
    }

    public void ActiveScrollItems()
    {
        ActivateShopGroup(1);
    }

    public void ActiveBottleItems()
    {
        ActivateShopGroup(2);
    }

    public void ActiveCastleItems()
    {
        ActivateShopGroup(3);
    }

    public void ActiveBonusItems()
    {
        btnAds.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
        ActivateShopGroup(4);
        vipBonus.Open();
    }

    public void ActiveStaffItems()
    {
        ActivateShopGroup(5);
    }

    public void ActiveWearItems()
    {
        ActivateShopGroup(6);
    }

    public bool IsActiveSpellItems()
    {
        return IsActiveGroup(0);
    }

    public bool IsActiveScrollItems()
    {
        return IsActiveGroup(1);
    }

    public bool IsActiveBottleItems()
    {
        return IsActiveGroup(2);
    }

    public bool IsActiveCastleItems()
    {
        return IsActiveGroup(3);
    }

    public bool IsActiveBonusItems()
    {
        return IsActiveGroup(4);
    }

    public bool IsActiveStaffItems()
    {
        return IsActiveGroup(5);
    }

    public bool IsActiveWearItems()
    {
        return IsActiveGroup(6);
    }

    private bool IsActiveGroup(int index)
    {
        return activeBtn == groupBtn[index];
    }

    // Включение отображения кнопки и соответствующей области скроллинга
    private void Activation(int _numBtn)
    {
       // Debug.Log("activeItems: " + activeItems.GetComponent<RectTransform>());
        scrollRect.content = activeItems.GetComponent<RectTransform>();
        var leftGlowActive = _numBtn < 5;
        activeGlow.SetActive(leftGlowActive);
        activeGlowRight.SetActive(!leftGlowActive);
        //yellowGlowEffectRight.SetActive(!leftGlowActive);
        var currentGlow = leftGlowActive ? activeGlow : activeGlowRight;
        //currentGlow.transform.position = groupBtn[_numBtn].GetComponent<RectTransform>().GetRectCenter();

        CurrentBackPosition = currentGlow;

        //yellowGlowEffect.SetActive(leftGlowActive);
        //yellowGlowEffect.transform.position = groupBtn[_numBtn].GetComponent<RectTransform>().GetRectCenter();
        CurrentButtonPosition = groupBtn[_numBtn];
        var anim = groupBtn[_numBtn].GetComponent<Animator>();

        foreach (var btn in groupBtn)
        {
            var button = btn.GetComponent<Animator>();
            if (button != null && button.enabled == true)
            {
                button.SetTrigger("Deselect");
            }
        }

        if (anim != null)
        {
            anim.Rebind();
            anim.enabled = true;
        }

        activeItems.SetActive(true);
    }


    // Выключение отображения кнопки и соответствующей области скроллинга
    private void Deactivation()
    {
        //Debug.Log(scrollRect.content);
        if (scrollRect.content != null)
        {
            scrollRect.content.gameObject.SetActive(false);
           // scrollRect.content.anchoredPosition = new Vector2(-3000, scrollRect.content.anchoredPosition.y);
        }
        //foreach (var o in groupItems)
        //{
        //    var ac = o.GetComponent<RectTransform>().anchoredPosition;
        //    o.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3000, ac.y);
        //}
    }


    // Кнопка перехода на карту
    public void ToMap()
    {
        if (BlackScreen.IsPlaying)
            return;

        SoundController.Instanse.StopAllBackgroundSFX();

        var openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        if (openLevel > 0)
        {
            if (openLevel > 2)
            {
                try { SendAnalyticsEvent(); }
                catch (System.Exception e) { Debug.LogError(e.Message); }
            }

            BlackScreen.Appear("Map");
        }
        else
        {
            BlackScreen.Appear("Level_1_Tutorial");
        }
    }

    private Potion_Items potionItems = new Potion_Items(PotionItem.PotionsNumber);

    private void SendAnalyticsEvent()
    {
        potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);

        AnalyticsController.Instance.LogMyEvent("ShopBottleStatistics", new Dictionary<string, string>() {
                                        { "health", potionItems[1].count.ToString() },
                                        { "mana", potionItems[0].count.ToString() },
                                        { "power", potionItems[2].count.ToString() },
                                        { "ressurection", potionItems[3].count.ToString() }
                                    });

        var wear = PPSerialization.Load<Wear_Items>("Wears");
        int capeIndex = ShopWearItemSettings.instance.GetActiveItem(WearType.cape);
        int staffIndex = ShopWearItemSettings.instance.GetActiveItem(WearType.staff);

        AnalyticsController.Instance.LogMyEvent("ShopGemStatistics", new Dictionary<string, string>() {
                                        { wear[capeIndex].wearParams.wearType.ToString(), GetGemsStatistics(wear, capeIndex) },
                                        { wear[staffIndex].wearParams.wearType.ToString(), GetGemsStatistics(wear, staffIndex) }
                                    });
    }

    private string GetGemsStatistics(Wear_Items wear, int index)
    {
        string text = string.Empty;
        foreach (var item in wear[index].wearParams.gemsInSlots)
            text += item.type.ToString() + " GemLevel: " + item.gemLevel.ToString() + ", ";

        return text;
    }

    public void ToMenu()
    {
        //SceneManager.LoadScene("Menu");
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear("Menu");
    }

    public void OpenBuyCoins()
    {
        //  buyCoinsAnimator.SetTrigger("pause");
        infoWithPurching.SetActive(true);
        for (int i = 1; i < infoWithPurching.transform.childCount; i++)
        {
            infoWithPurching.transform.GetChild(i).gameObject.SetActive(false);
        }
        infoWithPurching.transform.Find("Gold").gameObject.SetActive(true);
    }

    public void CloseBuyCoins()
    {
        buyCoinsAnimator.SetTrigger("game");
    }

    public void ToLevelByName(string _name)
    {
        //SceneManager.LoadScene(_name);
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear(_name);
    }

    private bool nowShowingVideo;
    public void ShowAdvVideo()
    {
        if (nowShowingVideo || !ADs.AdsManager.Instance.isAnyVideAdAvailable)
        {
            return;
        }
        nowShowingVideo = true;
        ADs.AdsManager.ShowVideoAd((bool viewResult) =>
       {
           if(viewResult)
           {
               nowShowingVideo = false;
               CoinsManager.AddCoinsST(500, false, 1f);
               PlayerPrefs.SetInt("VideoViewsLeft1", PlayerPrefs.GetInt("VideoViewsLeft1") - 1);
               GameObject.FindObjectOfType<ShopBonusItemSettings>().CheckVideoAdsAble();
               coinsFlyAnimation.PlayEffect(videoAdBtnTransf.position, coinsIndecatorIconTransf.position);
           }
       });
    }

    public void ShowOfferWall()
    {
        AnalyticsController.Instance.LogMyEvent("ShowOfferwall Click");
        ADs.AdsManager.Instance.ShowOfferwall();
    }

#if UNITY_EDITOR
    [Space(15f)]
    [SerializeField]
    private bool playVideoAdCoinsAnim_EDITOR;
    [SerializeField]
    private bool resetVideLimit_EDITOR;
    private void OnDrawGizmosSelected()
    {
        if (playVideoAdCoinsAnim_EDITOR)
        {
            playVideoAdCoinsAnim_EDITOR = false;
            coinsFlyAnimation.PlayEffect(videoAdBtnTransf.position, coinsIndecatorIconTransf.position);
        }
        if (resetVideLimit_EDITOR)
        {
            resetVideLimit_EDITOR = false;
            PlayerPrefs.SetInt("VideoViewsLeft1", 3);
        }
    }
#endif
}