#pragma warning disable CS0649
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class ShopGemItemSettings : BaseShopItemSettings
{
    private const string GEMS_CONFIG_FILE = "GemsLoaderConfig";
    private const string BUFFS_CONFIG_FILE = "BuffsLoaderConfig";

    public static ShopGemItemSettings instance;

    public GameObject info, infos, craftWindow, incButton, decButton;
    [SerializeField]
    private GemInfoHelper currentDesc, nextDesc;
    [SerializeField]
    private GemInsertToItemChoose currentWearChoose, nextWearChoose;
    [SerializeField]
    private List<GemShopSlot> gemsSized = new List<GemShopSlot>(), gemsTypes = new List<GemShopSlot>();
    [SerializeField]
    private GemShopSlot currentGem, nextGem, chooseRed, chooseBlue, chooseWhite, chooseYellow, combine1, combine2;
    public GemsLoaderConfig gemsLoaderConfig;
    public BuffsLoaderConfig buffsLoaderConfig;
    private GemType activeType;
    private int activeLevelIndex;
    [SerializeField]
    private Text combineNumberText, price, gemsCounter, newGemText;
    private int combineNumberCurrent = 1;

    [SerializeField]
    private ShopWearItemSettings shopWearItemSettings;
    [SerializeField]
    private CongratsGemCombine congratsGemCombine;
    [SerializeField]
    private Image combineButton, insertButton;
    [SerializeField]
    private GameObject combineButtonNonInteractable;
    private Wear openWithWear;
    private int openForWearSlot, openForWearGemSlot;
    private Gem_Items gemItems;
    public OverUIPopup activeGemObj;

    private bool firstClick = false;
    private bool blockIncCountToCombine = false;

    public Transform gemImgTransform;

    bool isWear = false;

    [Header("SELL GEMS")]
    public GameObject panelSell;
    public Button insertS, sellS, sellBtn;
    public Image imageGemSell, imageFrameSell;
    public Text countSell, coinsSell, textCoinFrameSell;
    int countGemSell;
    public GameObject closeSell, txtClose;
    public Font _font;
    public ParticleSystem[] effectCrystal;

    override protected void Awake()
    {
        base.Awake();
        instance = this;
        gemsLoaderConfig = Resources.Load<GemsLoaderConfig>(GEMS_CONFIG_FILE);
        buffsLoaderConfig = Resources.Load<BuffsLoaderConfig>(BUFFS_CONFIG_FILE);
    }

    override protected void Start()
    {
        base.Start();
        UpdateGemsCounter();
    }

    #region INSERT

    private IEnumerator SetStartState()
    {
        yield return new WaitForSeconds(0.01f);
        PickLastActiveOrDefaultGemType();
        yield break;
    }

    public void UpdateGemsCounter()
    {
        LoadGemSaves();
        int totalCounter = 0;
        int red = 0;
        int blue = 0;
        int white = 0;
        int yellow = 0;

        for (int i = 0; i < gemItems.Length; i++)
        {
            totalCounter += gemItems[i].count;
            if (i >= 0 && i <= 9)
                red += gemItems[i].count;
            if (i >= 10 && i <= 19)
                blue += gemItems[i].count;
            if (i >= 20 && i <= 29)
                white += gemItems[i].count;
            if (i >= 30 && i <= 39)
                yellow += gemItems[i].count;
        }


        gemsCounter.text = totalCounter.ToString();
        chooseRed.SetCount(red, false);
        chooseBlue.SetCount(blue, false);
        chooseWhite.SetCount(white, false);
        chooseYellow.SetCount(yellow, false);
    }



    private void LoadGemSaves()
    {
        gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
    }

    public int GetGemId(GemType gemType, int gemLevel)
    {
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gemType && gemItems[i].gem.gemLevel == gemLevel)
            {
                return i;
            }
        }
        return 0;
    }

    public int GetCount(GemType gemType, int gemLevel)
    {
        int x = 0;
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gemType && gemItems[i].gem.gemLevel == gemLevel - 1)
            {
                x += gemItems[i].count;
            }
        }
        return x;
    }

    public static int GetGemIdWithItems(Gem_Items gemItems, GemType gemType, int gemLevel)
    {
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gemType && gemItems[i].gem.gemLevel == gemLevel)
            {
                return i;
            }
        }
        return 0;
    }

    private GemItem LoadSingleGemSave(GemType gemType, int gemLevel)
    {
        GemItem to_return = new GemItem();
        Gem compairGem = new Gem();
        compairGem.gemLevel = gemLevel;
        compairGem.type = gemType;
        for (int i = 0; i < gemItems.Length; i++)
        {
            to_return = gemItems[i];
            //to_return.gem.gemLevel = GetRealLevelFromSave (i);
            if (to_return.gem == compairGem)
            {
                return to_return;
            }
        }
        return to_return;
    }

    private void SaveGemSaves()
    {
        PPSerialization.Save(EPrefsKeys.Gems, gemItems);
    }

    public static GemType GemTypeByName(string name)
    {
        GemType gemType = GemType.Blue;
        switch (name)
        {
            case "red":
                gemType = GemType.Red;
                break;
            case "blue":
                gemType = GemType.Blue;
                break;
            case "white":
                gemType = GemType.White;
                break;
            case "yellow":
                gemType = GemType.Yellow;
                break;
        }
        return gemType;
    }

    public static string GemNameByType(GemType type)
    {
        switch (type)
        {
            case GemType.Red:
                return "red";
            case GemType.Blue:
                return "blue";
            case GemType.White:
                return "white";
            case GemType.Yellow:
                return "yellow";
        }
        return null;
    }

    public void ChooseGem(int gemLevelIndex, GemType type = GemType.None, bool effect = false)
    {
        if (type == GemType.None)
            type = activeType;
        activeLevelIndex = gemLevelIndex;
        for (int i = 0; i < gemsSized.Count; i++)
        {
            if (gemsSized[i].activeFrameImage != null)
            {
                if (gemsSized[i].gemLevel == activeLevelIndex)
                {
                    gemsSized[i].activeFrameImage.color = Color.white;
                }
                else
                {
                    gemsSized[i].activeFrameImage.color = new Color(1f, 1f, 1f, 0.01f);
                }
            }
        }
        currentGem.gemLevel = activeLevelIndex;
        currentGem.SetType(type);
        if (activeLevelIndex < Gem.MaxLevelIndex)
        {
            nextGem.gemLevel = activeLevelIndex + 1;
        }
        else
        {
            nextGem.gemLevel = activeLevelIndex;
        }
        nextGem.SetType(type);
        combine1.gemLevel = combine2.gemLevel = activeLevelIndex;
        combine1.SetType(type);
        combine2.SetType(type);

        activeType = type;

        SetImageSellGem(type, activeLevelIndex);

        SetActualDescriptions();
        //for (int i = 0; i < effectCrystal.Length; i++)
        //{
        //    effectCrystal[i].gameObject.SetActive(false);
        //}
        if (effect)
        {
            Debug.Log($"PLAY EFFECT");
            effectCrystal[gemLevelIndex].gameObject.SetActive(true);
            effectCrystal[gemLevelIndex].Play();
        }
        //effectCrystal[gemLevelIndex].gameObject.SetActive(true);
        //effectCrystal[gemLevelIndex].Play();

    }

    public void GemSelect(int gemLevelIndex, GemType type = GemType.Red, bool effect = false)
    {
        Debug.Log($"GemSelect");
        ChooseType(type.ToString());
        ChooseGem(gemLevelIndex, type, effect);
    }


    public void SetItemChoose(string name, int t)
    {
        currentWearChoose.ActivateItemObj(name);
        nextWearChoose.ActivateItemObj(name);
        isWear = name == "cape";
        Debug.Log($"SetItemChoose: {name}");
    }

    public void SetActualDescriptions(int t = 2)
    {
        closeSell.SetActive(SaveManager.GameProgress.Current.CompletedLevelsNumber < mainscript.levelOpenSellGem);

        //Debug.Log($"t: {(t)}, currentWearChoose: {currentWearChoose.chosenWear}, nextWearChoose: {nextWearChoose.chosenWear}");

        //if (t != 2)
        //    nextWearChoose.chosenWear = currentWearChoose.chosenWear;
        //else
        //    currentWearChoose.chosenWear = nextWearChoose.chosenWear;

        if (t != 2)
            nextWearChoose.chosenWear = currentWearChoose.chosenWear;

        Gem usedGem = new Gem() { type = activeType, gemLevel = activeLevelIndex };
        if (currentWearChoose.chosenWear != WearType.none)
        {
           
            Buff workingBuff1 = buffsLoaderConfig.GetGemBuffInWear(usedGem, currentWearChoose.chosenWear);
            if (currentDesc.description != null && currentDesc.description.TextComponent != null)
            {
                //Debug.Log(gemsLoaderConfig.GetStringId(workingBuff1.buffType));
                currentDesc.description.TextComponent.text = TextSheetLoader
                    .Instance.GetString(gemsLoaderConfig.GetStringId(workingBuff1.buffType))
                    .Replace("#", workingBuff1.buffValue.ToString()).ToUpper();
                currentDesc.description.TextComponent.resizeTextMaxSize = 24;
            }
            if (currentDesc.icon != null)
            {
                currentDesc.icon.sprite = Resources.Load<Sprite>(gemsLoaderConfig.GetBuff(workingBuff1.buffType));
                currentDesc.icon.color = Color.white;
            }
            //else
            //    currentDesc.description.TextComponent.text = "";
        }
        else
        {
            if (currentDesc.description != null && currentDesc.description.TextComponent != null)
            {
                currentDesc.description.TextComponent.text = TextSheetLoader.Instance.GetString("t_0368");
                currentDesc.description.TextComponent.resizeTextMaxSize = 24;
            }
            if (currentDesc.icon != null)
            {
                currentDesc.icon.color = Color.clear;
              
            }
        }
        //Debug.Log($"count: {GetCount(activeType, activeLevelIndex + 1)}");
        //if(GetCount(activeType, activeLevelIndex + 1) == 0)
        //{
        //    currentDesc.description.TextComponent.text = "";
        //    currentDesc.icon.color = Color.clear;
        //}


        bool nextIsEmpty = false;
        //Debug.Log($"SetActualDescriptions: wear:  {currentWearChoose.chosenWear}, level gem : {activeLevelIndex} , Gem.MaxLevelIndex: {Gem.MaxLevelIndex} ");
        if (activeLevelIndex >= 0 && activeLevelIndex < Gem.MaxLevelIndex && nextWearChoose.chosenWear != WearType.none)
        {
            Gem nextGem = new Gem() { type = activeType, gemLevel = activeLevelIndex + 1 };
            Buff workingBuff2 = buffsLoaderConfig.GetGemBuffInWear(nextGem, nextWearChoose.chosenWear);

            //Debug.Log($"activeLevelIndex: {activeLevelIndex}, count: {gemItems[activeLevelIndex].count}, CheckGemCountPresent(activeGem): {CheckGemCountPresent(usedGem)}");
            nextIsEmpty = (workingBuff2.buffType == BuffType.none) || CheckGemCountPresent(usedGem) < 2;

            nextDesc.description.gameObject.SetActive(!nextIsEmpty);
            nextDesc.emptyText.gameObject.SetActive(false);
            string tempId = gemsLoaderConfig.GetStringId(workingBuff2.buffType);
            string tempDesc = TextSheetLoader.Instance.GetString(tempId).Replace("#", workingBuff2.buffValue.ToString()).ToUpper();
            nextDesc.description.TextComponent.text = tempDesc;
            nextDesc.description.TextComponent.resizeTextMaxSize = 24;
            if (nextDesc.icon != null)
            {
                if (workingBuff2.buffType != BuffType.none)
                {
                    nextDesc.icon.sprite = Resources.Load<Sprite>(gemsLoaderConfig.GetBuff(workingBuff2.buffType));
                    nextDesc.icon.color = Color.white;
                }
                else
                {
                    nextDesc.icon.color = Color.clear;
                }
            }
        }
        else
        {
            nextIsEmpty = true;
            if (nextDesc.icon != null)
            {
                nextDesc.icon.color = Color.clear;
            }
            nextDesc.description.TextComponent.text = TextSheetLoader.Instance.GetString(gemsLoaderConfig.GetStringId(BuffType.none)).ToUpper();
            nextDesc.description.TextComponent.resizeTextMaxSize = 24;
        }
        //nextDesc.description.gameObject.SetActive(true);
        nextDesc.emptyText.gameObject.SetActive(false);
        CheckActiveGemLevel();
    }

    private void CheckActiveGemLevel()
    {
        Gem activeGem = new Gem() { type = activeType, gemLevel = activeLevelIndex };
        //insertButton.gameObject.SetActive(true);
        // && openWithWear != null && currentWearChoose.chosenWear == openWithWear.wearType
        //insertButton.gameObject.SetActive(CheckGemCountPresent(activeGem) != 0  );
        insertButton.GetComponent<Button>().interactable = CheckGemCountPresent(activeGem) != 0;
        BlockCombine((activeLevelIndex == Gem.MaxLevelIndex || (activeLevelIndex < Gem.MaxLevelIndex && CheckGemCountPresent(activeGem) < 2)));
    }

    private void BlockCombine(bool on)
    {
        incButton.SetActive(!on);
        decButton.SetActive(!on);
        //nextDesc.gameObject.SetActive (!on);
        if (!on)
        {
            nextDesc.icon.color = Color.white;
        }
        else
        {
            nextDesc.icon.color = Color.clear;
            nextDesc.description.TextComponent.text = TextSheetLoader.Instance.GetString("t_0368");
            nextDesc.description.TextComponent.resizeTextMaxSize = 24;
        }
        combineButton.enabled = !on;
        combineButtonNonInteractable.SetActive(on);
        newGemText.gameObject.SetActive(!on);
        if (on)
        {
            if (GetGemCount(new Gem() { type = activeType, gemLevel = activeLevelIndex }) > 0)
            {
                combine1.SetCount(1);
            }
            else
            {
                combine1.SetCount(0);
            }
            combine2.SetCount(0);
            nextGem.SetCount(0);
            combineNumberCurrent = 0;
        }
        else
        {
            combine1.SetCount(1);
            combine2.SetCount(1);
            nextGem.SetCount(1);
            combineNumberCurrent = 1;
        }
        SetCombineView(combineNumberCurrent);
    }

    public int GetGemCount(Gem gem)
    {
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.gemLevel == gem.gemLevel && gemItems[i].gem.type == gem.type)
            {
                return gemItems[i].count;
            }
        }
        return 0;
    }

    private int CheckGemCountPresent(Gem gem)
    {
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gem.type && gemItems[i].gem.gemLevel == gem.gemLevel)
            {
                return gemItems[i].count;
            }
        }
        return 0;
    }

    private void SetCombineView(int number)
    {
        combineNumberCurrent = number;
        combineNumberText.text = combineNumberCurrent.ToString();
        price.text = GetGemsCombinePrice().ToString();
        LayoutRebuilder.ForceRebuildLayoutImmediate(price.transform.parent as RectTransform);
        var v = coinsManager.CheckCount(GetGemsCombinePrice());
        //Debug.Log($"count: {GetGemsCombinePrice()}, value: {v}");
        combineButton.gameObject.GetComponent<Button>().interactable = v && GetGemsCombinePrice() > 0;
    }

    public void ChooseType(string gemType)
    {
        activeType = GemTypeByName(gemType.ToLower());
        for (int i = 0; i < gemsTypes.Count; i++)
        {
            if (gemsTypes[i].activeFrameImage != null)
            {
                if (gemsTypes[i].gemType == activeType)
                {
                    gemsTypes[i].activeFrameImage.color = Color.white;
                }
                else
                {
                    gemsTypes[i].activeFrameImage.color = new Color(1f, 1f, 1f, 0.01f);
                }
            }
        }
        Gem tempGem = new Gem();
        tempGem.type = activeType;
        LoadGemSaves();
        for (int i = 0; i < gemsSized.Count; i++)
        {
            tempGem.gemLevel = i;
            gemsSized[i].SetType(activeType);
            gemsSized[i].SetCount(CheckGemCountPresent(tempGem));
        }
        PlayerPrefs.SetInt(GameConstants.SaveIds.LastGemTypeShownInShop, (int)activeType);
        ChooseGem(activeLevelIndex, activeType);
    }

    public void CombineGems()
    {
        if (activeLevelIndex == Gem.MaxLevelIndex)
        {
            return;
        }
        LoadGemSaves();
        int gem1Id = GetGemId(activeType, activeLevelIndex);
        int gem2Id = GetGemId(activeType, activeLevelIndex + 1);
        if (combineNumberCurrent <= 0)
        {
            combineNumberCurrent = 0;
            SetCombineView(combineNumberCurrent);
            //combineNumberText.text = combineNumberCurrent.ToString ();
            return;
        }
        if (combineNumberCurrent > gemItems[gem1Id].count / 2)
        {
            combineNumberCurrent = gemItems[gem1Id].count / 2;
        }
        SetCombineView(combineNumberCurrent);
        if (coinsManager.BuySomething(GetGemsCombinePrice()))
        {
            gemItems[gem1Id].count -= combineNumberCurrent * 2;
            gemItems[gem2Id].count += combineNumberCurrent;
            SaveGemSaves();
            combineNumberCurrent = 0;
            SetCombineView(combineNumberCurrent);

            ChooseType(activeType.ToString());
            UpdateGemsCounter();
            congratsGemCombine.StartWithGem(gemItems[gem2Id].gem, nextWearChoose.chosenWear);

            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Craftsman, 1);
            Achievement.AchievementController.Save();
            TutorialsManager.MarkTutorialAsComplete(ETutorialType.COMBINE_TWO_CRYSTALS);
        }
        else
        {
            uiShop.OpenBuyCoins(); // Открываем окно покупки монет
        }
    }

    public int GetGemsCombinePrice()
    {
        return GetGemsCombinePrice(activeLevelIndex, combineNumberCurrent);
    }

    public static int GetGemsCombinePrice(int activeLevelIndex, int combineNumberCurrent)
    {
        int startPrice = 100;
        int countedPrice = startPrice;
        for (int i = 0; i < activeLevelIndex; i++)
        {
            countedPrice += countedPrice + countedPrice * 2 / 5;
        }
        return countedPrice * combineNumberCurrent;
    }

    private bool openedForReplaceGem;
    public void InsertGem()
    {
        if (!openedForReplaceGem)
        {
            if (openWithWear != null)
            {

                InsertGemToWear(openWithWear, openForWearSlot, openForWearGemSlot);
                TutorialsManager.MarkTutorialAsComplete(ETutorialType.FIRST_CRYSTAL_SHOP);
            }
            else
            {
                shopWearItemSettings.UpdateData();
                int count = 0;
                Debug.Log($"isWear: {isWear}");
                if(isWear)
                {
                    for (int i = 0; i < shopWearItemSettings.activeWear.wearParams.gemsInSlots.Length; i++)
                    {
                        Debug.Log($"Insert wear: {i}, gem: {shopWearItemSettings.activeWear.wearParams.gemsInSlots[i].type}");
                        if (shopWearItemSettings.activeWear.wearParams.gemsInSlots[i].type == GemType.None)
                        {
                            Debug.Log($"Insert wear");
                            InsertGemToWear(shopWearItemSettings.activeWear.wearParams, shopWearItemSettings.wearSlot, i);
                            count++;
                            shopWearItemSettings.UpdateData();
                            UIShop.Instance.ActiveStaffItems();
                            LoadGemSaves();
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < shopWearItemSettings.activePosoh.wearParams.gemsInSlots.Length; i++)
                    {
                        Debug.Log($"Insert posoh: {i}, gem: {shopWearItemSettings.activePosoh.wearParams.gemsInSlots[i].type}");
                        if (shopWearItemSettings.activePosoh.wearParams.gemsInSlots[i].type == GemType.None)
                        {
                            Debug.Log($"Insert posoh");
                            InsertGemToWear(shopWearItemSettings.activePosoh.wearParams, shopWearItemSettings.posohSlot, i);
                            count++;
                            shopWearItemSettings.UpdateData();
                            UIShop.Instance.ActiveStaffItems();
                            LoadGemSaves();
                            break;
                        }
                    }
                }

                Debug.Log($"===== USE INSERT GEM: {count}");

                if(count == 0)
                {
                    // замена кристала от выбранной вещи
                    shopWearItemSettings.tempExtractWearItem = shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot];
                    shopWearItemSettings.tempExtractWearGem = !isWear ? shopWearItemSettings.activePosoh.wearParams.gemsInSlots[0] : shopWearItemSettings.activeWear.wearParams.gemsInSlots[0];
                    shopWearItemSettings.CallReplaceWindow(new Gem() { gemLevel = activeLevelIndex, type = activeType });
                    //if (SaveManager.GameProgress.Current.tutorialRemoveGem)
                    //{
                    //    shopWearItemSettings.tempExtractWearItem = shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot];
                    //    shopWearItemSettings.tempExtractWearGem = shopWearItemSettings.activeWear.wearParams.gemsInSlots[0];
                    //    shopWearItemSettings.CallReplaceWindow(new Gem() { gemLevel = activeLevelIndex, type = activeType });
                    //}
                    //else
                    //{
                    //    UIShop.Instance.ActiveStaffItems();
                    //    UIShop.Instance.FocusItem(shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot].transform);
                    //    Tutorial.Open(target: shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot].gemSlots[0].gameObject, 
                    //        focus: new Transform[] { shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot].transform },
                    //        mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 90), waiting: 0, keyText: "");
                    //    craftWindow.SetActive(false);
                    //    //gameObject.SetActive(false);
                    //    shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot].gemSlots[0].transform.parent.gameObject.GetComponent<Button>().onClick
                    //        .AddListener(TutBtnClick);
                    //}
                }
            }
        }
        else
        {
            //Debug.Log($"activeLevelIndex: {activeLevelIndex}, activeType: {activeType}");
            shopWearItemSettings.CallReplaceWindow(new Gem() { gemLevel = activeLevelIndex, type = activeType });
        }
    }

    void TutBtnClick()
    {
        var x = shopWearItemSettings.shopWearItems[!isWear ? shopWearItemSettings.posohSlot : shopWearItemSettings.wearSlot];
        x.gemSlots[0].transform.parent.gameObject.GetComponent<Button>().onClick.RemoveListener(TutBtnClick);
        Tutorial.Close();
        Tutorial.Open(target: activeGemObj.extractBtn,
              focus: new Transform[] { activeGemObj.transform, x.transform },
              mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(-7500, 90), waiting: 0, keyText: "t_0645");
        var o = Tutorial.Open(target: activeGemObj.extractBtn,
            focus: new Transform[] { activeGemObj.extractBtn.transform },
            mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 90), waiting: 0.05f, keyText: "");
        o.layerID = 302;
        o.mainPanel.transform.parent.gameObject.GetComponent<Canvas>().sortingLayerID = 302;
        o.disableAnimation = true;
        o.dublicateObj = false;
        activeGemObj.isClose = false;

        activeGemObj.replaceBtn.GetComponent<Image>().color = new Color(0.49f, 0.49f, 0.49f);

        o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
       
        activeGemObj.extractBtn.GetComponent<Button>().onClick.AddListener(TutBtnClick2);
    }

    void TutBtnClick2()
    {
        activeGemObj.replaceBtn.GetComponent<Image>().color = Color.white;
        activeGemObj.isClose = true;
        activeGemObj.extractBtn.GetComponent<Button>().onClick.RemoveListener(TutBtnClick2);
        Tutorial.Close();
        SaveManager.GameProgress.Current.tutorialRemoveGem = true;
        SaveManager.GameProgress.Current.Save();
    }

    private void InsertGemToWear(Wear wear, int slot, int gemSlot = -1)
    {
        AnalyticsController.Instance.LogMyEvent("Added_Stone_Lv_" + activeLevelIndex + "_" + activeType.ToString());
        AnalyticsController.Instance.LogMyEvent(wear.wearType == WearType.cape ? "Added_Stone_to_cape" : "Added_Stone_to_staff");
        Debug.Log("InsertGemToWear");
        shopWearItemSettings.InsertGemToWear(wear, slot, new Gem() { gemLevel = activeLevelIndex, type = activeType }, gemSlot);
        craftWindow.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void IncCountToCombine(int number)
    {
        if (blockIncCountToCombine)
        {
            return;
        }
        int gemId = GetGemId(activeType, activeLevelIndex);
        combineNumberCurrent += number;
        if (combineNumberCurrent < 0)
        {
            combineNumberCurrent = 0;
        }
        if (combineNumberCurrent > gemItems[gemId].count / 2)
        {
            combineNumberCurrent = gemItems[gemId].count / 2;
        }
        //var v = !coinsManager.CheckCount(GetGemsCombinePrice());
        //combineButton.gameObject.GetComponent<Button>().interactable = v;
        //combineButtonNonInteractable.SetActive(!v);
        SetCombineView(combineNumberCurrent);
        combineNumberText.text = combineNumberCurrent.ToString();
    }

    public void OpenForWear(Wear wear, int slot, Transform btn, int gemSlot = 0, bool forReplace = false)
    {
        openedForReplaceGem = forReplace;
        LoadGemSaves();
        openWithWear = wear;
        openForWearSlot = slot;
        openForWearGemSlot = gemSlot;
        // gameObject.SetActive(true);
        craftWindow.SetActive(true);
        //GetComponent<UIScaleEffect>().Open(btn);

        PickLastActiveOrDefaultGemType();

        currentWearChoose.ActivateItem(wear.wearType.ToString());
        nextWearChoose.ActivateItem(wear.wearType.ToString());
        SetActualDescriptions();
        Debug.Log($"OpenForWear =========-------- ");
    }

    public void Close()
    {
        //GetComponent<UIScaleEffect>().Close(craftWindow);
        //gameObject.SetActive(false);
        craftWindow.SetActive(false);
    }

    public void WearAutoChoose()
    {
        LoadGemSaves();
        currentWearChoose.ActivateItem(WearType.cape.ToString());
        nextWearChoose.ActivateItem(WearType.staff.ToString());
        openWithWear = null;
        CheckActiveGemLevel();
        gameObject.SetActive(true);
        StartCoroutine(SetStartState());

        SetDefaultActiveSlot();


        insertButton.gameObject.SetActive(true);
    }
    public void WearChoose(WearType _type)
    {
        LoadGemSaves();
        currentWearChoose.ActivateItem(_type.ToString());
        nextWearChoose.ActivateItem(_type.ToString());
        openWithWear = null;
        CheckActiveGemLevel();
        gameObject.SetActive(true);
        StartCoroutine(SetStartState());

        SetDefaultActiveSlot();


        insertButton.gameObject.SetActive(true);
    }

    private void SetDefaultActiveSlot()
    {
        if (!firstClick)
        {
            firstClick = true;
            ChooseType("red");
           
        }
        ChooseGem(0, activeType);
    }

    private int GetHighestGemLevelOfType(GemType type)
    {
        int toReturn = -1;
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == type && gemItems[i].count > 0 && gemItems[i].gem.gemLevel > toReturn)
            {
                toReturn = gemItems[i].gem.gemLevel;
            }
        }
        return toReturn;
    }

    private void PickLastActiveOrDefaultGemType()
    {
        int showGemType = PlayerPrefs.GetInt(GameConstants.SaveIds.LastGemTypeShownInShop, -1);
        if (showGemType > -1)
        {
            activeType = (GemType)showGemType;
        }

        if (GetHighestGemLevelOfType(activeType) == -1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GetHighestGemLevelOfType((GemType)i) > -1)
                {
                    activeType = (GemType)i;
                    break;
                }
            }
        }
        ChooseType(activeType.ToString());
        //ChooseGem(GetHighestGemLevelOfType(activeType));
    }

    public void InterectableGemsSized(bool enable)
    {
        for (int i = 0; i < gemsSized.Count; i++)
        {
            gemsSized[i].ActiveFrameButton.interactable = enable;
        }
    }

    public void InterectableGemsType(bool enable)
    {
        for (int i = 0; i < gemsTypes.Count; i++)
        {
            gemsTypes[i].ActiveFrameButton.interactable = enable;
        }
    }

    public List<GemShopSlot> GemsSized
    {
        get
        {
            return gemsSized;
        }
    }

    public List<GemShopSlot> GemsTypes
    {
        get
        {
            return gemsTypes;
        }
    }

    public bool BlockIncCountToCombine
    {
        get
        {
            return blockIncCountToCombine;
        }

        set
        {
            blockIncCountToCombine = value;
        }
    }
    #endregion

    #region SELL

    public void OpenInsert()
    {
        panelSell.SetActive(false);
        insertS.interactable = false;
        sellS.interactable = true;
        
    }

    public void OpenSell()
    {
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber < mainscript.levelOpenSellGem)
            return;

        panelSell.SetActive(true);
        insertS.interactable = true;
        sellS.interactable = false;
        sellBtn.interactable = false;
        StartCoroutine(_VertivalUpdate("0"));
    }

    public void OpenSellPanel()
    {
        Debug.Log("OpenSellPanel");
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber < mainscript.levelOpenSellGem)
        {
            txtClose.GetComponent<Text>().text = TextSheetLoader.Instance.GetString("t_0673") + mainscript.levelOpenSellGem;
            //if (PlayerPrefs.GetString("CurrentLanguage") != "English")
            //    txtClose.GetComponent<Text>().font = _font;
            txtClose.SetActive(true);
            txtClose.GetComponent<Animator>().Play(0);
            closeSell.GetComponent<Animator>().Play(0);
            return;
        }
    }

    public void SetImageSellGem(GemType gemType, int gemLevel)
    {
        Gem newGem = new Gem();
        newGem.gemLevel = gemLevel;
        newGem.type = gemType;
        Sprite newSprite = Resources.Load<Sprite>(gemsLoaderConfig.GetGem(newGem));
        if (newSprite != null)
        {
            if (GetCount(activeType, gemLevel + 1) > 0)
            {
                imageGemSell.color = Color.white;
                imageGemSell.sprite = newSprite;
            }
            else
                imageGemSell.color = Color.clear;
        }
           

        if (newSprite != null)
            imageFrameSell.sprite = newSprite;

        countSell.text = coinsSell.text = "0";
        countGemSell = 0;
        sellBtn.interactable = countGemSell > 0;
        StartCoroutine(_VertivalUpdate("0"));
    }

    public void AddSell()
    {
        //Debug.Log($"sell gems count: {GetCount(activeType, activeLevelIndex + 1)}");
        if (GetCount(activeType, activeLevelIndex + 1) == 0)
            return;
        if(countGemSell < GetCount(activeType, activeLevelIndex + 1))
            countGemSell++;
        var p = BalanceTables.Instance.GemSellCostParameters;
        int cost = 0;
        if (activeType == GemType.Red)
            cost = p[activeLevelIndex].value;
        if (activeType == GemType.Blue)
            cost = p[activeLevelIndex + 10].value;
        if (activeType == GemType.White)
            cost = p[activeLevelIndex + 20].value;
        if (activeType == GemType.Yellow)
            cost = p[activeLevelIndex + 30].value;

        sellBtn.interactable = countGemSell > 0;
        countSell.text = countGemSell.ToString();
        coinsSell.text = (cost * countGemSell).ToString();
        textCoinFrameSell.text = (cost * countGemSell).ToString();
        coinsSell.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing += 0.001f;
        StartCoroutine(_VertivalUpdate((cost * countGemSell).ToString()));
    }

    IEnumerator _VertivalUpdate(string v)
    {
        coinsSell.text = v;
        yield return new WaitForEndOfFrame();
        try
        {
            coinsSell.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing += 0.001f;
            textCoinFrameSell.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing += 0.001f;
        }
        catch (Exception e)
        {
            Debug.LogWarning($"{e.Message}");
        }
    }
    IEnumerator _VertivalUpdate2()
    {
        yield return new WaitForEndOfFrame();
        try
        {
            textCoinFrameSell.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing += 0.001f;
        }
        catch (Exception e)
        {
            Debug.LogWarning($"{e.Message}");
        }
    }

    public void MinusSell()
    {
        if (countGemSell <= 0)
            return;
        countGemSell--;
        var p = BalanceTables.Instance.GemSellCostParameters;
        int cost = 0;
        if (activeType == GemType.Red)
            cost = p[activeLevelIndex].value;
        if (activeType == GemType.Blue)
            cost = p[activeLevelIndex + 10].value;
        if (activeType == GemType.White)
            cost = p[activeLevelIndex + 20].value;
        if (activeType == GemType.Yellow)
            cost = p[activeLevelIndex + 30].value;
        sellBtn.interactable = countGemSell > 0;
        countSell.text = countGemSell.ToString();
        textCoinFrameSell.text = (cost * countGemSell).ToString();
        StartCoroutine(_VertivalUpdate((cost * countGemSell).ToString()));
    }


    public void OpenPanelSellSure()
    {
        StartCoroutine(_VertivalUpdate2());
    }


    public void Sell()
    {
        Debug.Log($"type: {activeType}, activeLevelIndex: {activeLevelIndex}, count: {countGemSell}, cost: {coinsSell.text}");
        Gem_Items gemItems = PPSerialization.Load<Gem_Items>("Gems");
        CoinsManager.AddCoinsST(int.Parse(coinsSell.text));
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == activeType && gemItems[i].gem.gemLevel == activeLevelIndex)
            {
                gemItems[i].count -= countGemSell;
                if (gemItems[i].count < 0)
                    gemItems[i].count = 0;
                break;
            }
        }
        PPSerialization.Save("Gems", gemItems, true, true);
        UpdateGemsCounter();
        //WearAutoChoose();

        LoadGemSaves();
        currentWearChoose.ActivateItem(currentWearChoose.chosenWear.ToString());
        nextWearChoose.ActivateItem(currentWearChoose.chosenWear.ToString());
        openWithWear = null;
        CheckActiveGemLevel();
        gameObject.SetActive(true);
        StartCoroutine(SetStartState());

        SetDefaultActiveSlot();


        insertButton.gameObject.SetActive(true);


        StartCoroutine(_VertivalUpdate("0"));
    }

    #endregion
}
