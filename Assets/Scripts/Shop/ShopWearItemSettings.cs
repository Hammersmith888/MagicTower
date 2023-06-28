using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class WearItem : BaseUpgradableShopItem
{
    public const int ItemsNumber = 11;

    [SerializeField]
    public bool active;
    [SerializeField]
    public Wear wearParams;
}

[System.Serializable]
public class Wear_Items : ArrayInClassWrapper<WearItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return WearItem.ItemsNumber;
        }
    }

    public Wear_Items(int capacity) : base(capacity)
    {
    }
}


public class ShopWearItemSettings : BaseShopItemSettings
{

    private Wear_Items wearItems = new Wear_Items(WearItem.ItemsNumber);

    //	public GameObject slotMenu; // Дополнительный экран выбора слота для заклинания
    //	public GameObject slots;    // Родительский объект для слотов заклинаний
    public Sprite[] spellIcons; // Иконки заклинаний для слотов
    public string[] wearNamesIds;
    public GameObject spellInfo; // Дополнительный экран информации о заклинаниях
    public GameObject infos, extractWindow, replaceWindow; // Родительский объект для информации о заклинаниях

    private GameObject[] usingMarks; // Объект-галочка активности заклинания
    private int selectedWearNumber; // Номер выбранного заклинания (устанавливается в момент открытия меню выбора слота для заклинания, необходим для сохранения)

    //private const byte maxSpellUpgrade = 4;
    private byte activeWearsCount = 0; // Количество активных заклинаний (необходимо, чтобы проверять, добавлять ли заклинаний в слот по умолчанию)
                                       //private Wear capeUsed, staffUsed;
    public ShopWearItem[] shopWearItems;
    //[SerializeField]
    public ShopGemItemSettings shopGemItemSettings;
    [SerializeField]
    private OverUIPopup activeGemPopup;

    public WearItem activeWear;
    public WearItem activePosoh;
    public int wearSlot, posohSlot;

    public InfoWearWindow infoWear;

    public UIConsFlyAnimation flyRemove, flyChange;
    public Sprite[] btnSprites;

    override protected BaseUpgradableShopItem GetItemByShopIndex(int itemNumber)
    {
        return wearItems[itemNumber];
    }

    override protected BaseUpgradableShopItem[] GetAllItems()
    {
        return wearItems.getInnerArray;
    }

    public static ShopWearItemSettings instance;

    [System.Serializable]
    class WearColor
    {
        public BuffType buffType;
        public Color color;
    }

    [SerializeField]
    List<WearColor> wearColor = new List<WearColor>();

    override protected void Awake()
    {
        base.Awake();
        instance = this;
        usingMarks = new GameObject[shopWearItems.Length];
        for (int i = 0; i < usingMarks.Length; i++)
        {
            usingMarks[i] = shopWearItems[i].activeSlot.transform.GetChild(1).gameObject;
        }

        // Загружаем сохранения заклинаний
       

        UpdateData();
       
    }

    public void UpdateData()
    {
        activeWear = activePosoh = null;
        LoadWearSaves();
        // Устанавливаем полученные сохранения в магазине
        for (int i = 0; i < shopWearItems.Length; i++)
        {
            UpdateBuffs(i);
            // Если заклинание разблокировано
            shopWearItems[i].wear = wearItems[i].wearParams;

            shopWearItems[i].PlaceGems();
            if (wearItems[i].unlock)
            {
                shopItemsObjects[i].transform.GetChild(2).gameObject.SetActive(true);


                shopWearItems[i].activeSlot.SetActive(true);
                //shopWearItems[i].unlockText.SetActive(false);
                if (shopWearItems[i].halo != null)
                    shopWearItems[i].halo.SetActive(false);
                shopWearItems[i].BuyButton.SetActive(false);
                shopWearItems[i].UnlockButton.SetActive(false);
                var lockIcon = shopWearItems[i].transform.Find("LockIcon");
                if (lockIcon != null)
                    lockIcon.gameObject.SetActive(false);
                shopWearItems[i].slots.SetActive(true);

                if (wearItems[i].active)
                {
                    //Debug.Log($"active: {i}");
                    if (activeWearsCount < 4)
                    {
                        usingMarks[i].SetActive(true); // Заклинание используется в слотах, зеленый чек-бокс справа
                       
                    }
                    if (wearItems[i].wearParams.wearType == WearType.cape)
                    {
                        activeWear = wearItems[i];
                        wearSlot = i;
                    }
                    if (wearItems[i].wearParams.wearType == WearType.staff)
                    {
                        activePosoh = wearItems[i];
                        posohSlot = i;
                    }
                    activeWearsCount++;
                }

            }
            else if (i < shopItemsObjects.Length && i < shopWearItems.Length)
            {
                // Отобразить необходимое количество монет для разблокировки заклинаний
                shopWearItems[i].unlockCoinsText.text = wearItems[i].unlockCoins.ToString();
            }

        }
    }

    public void ResetBuffs(int i)
    {
        for (int z = 0; z < shopWearItems[i].buffShowObjects.Count; z++)
        {
            infoWear.ResetBuffValue();
        }
    }

    public void UpdateBuffs(int i, Buff buff = null, float value = 0)
    {
        for (int z = 0; z < shopWearItems[i].buffShowObjects.Count; z++)
        {
            infoWear.SetDataBuffs(shopWearItems[i].buffShowObjects[z], shopWearItems[i].idInBase, z, buff, value);
        }
    }

    void OnEnable()
    {
        CheckAvailableOfItems();
    }


    public void MovePanel()
    {
        activeGemPopup.CloseIt();
    }
    public void LoadWearSaves()
    {
        for (int i = 0; i < wearItems.Length; i++)
        {
            wearItems[i] = new WearItem();
        }

        wearItems = PPSerialization.Load<Wear_Items>("Wears");

        // Установить необходимое количество монет для разблокировки заклинаний и upgrade
        SetWearCoinsForUnlock();
    }
    public ShopWearItem tempExtractWearItem;
    public int tempExtractWearItemSlotID, tempExtractWearItemGemLevel, tempExtractWearItemGemSlot;
    public Gem tempExtractWearGem, tempReplaceOldGem, tempReplaceNewGem;
    [SerializeField]
    private Image extractGemImage, replaceOldGemImage, replaceNewGemImage;
    [SerializeField]
    private Text extractPriceText;

    public void CallActiveGemPopup(ShopWearItem callFrom, int inBaseID, int slotID, Gem gem, Vector3 pos)
    {
        tempExtractWearItem = callFrom;
        tempExtractWearItemSlotID = inBaseID;
        tempExtractWearItemGemSlot = slotID;
        tempExtractWearGem = gem;
        tempExtractWearItemGemLevel = gem.gemLevel;
        activeGemPopup.OpenIt(pos);
    }

    public void CallExtractWindow()
    {
        Sprite newSprite = Resources.Load<Sprite>(shopGemItemSettings.gemsLoaderConfig.GetGem(tempExtractWearGem));
        if (newSprite != null)
        {
            extractGemImage.sprite = newSprite;
        }
        extractPriceText.text = SpendCoins(tempExtractWearItemGemLevel).ToString();
        UpdBtnExtract();
        ConfirmExtract();
        shopGemItemSettings.gameObject.SetActive(true);
        shopGemItemSettings.craftWindow.SetActive(false);
        infoWear.HideWearInfo();
    }

    public void UpdBtnExtract()
    {
        var btn = extractWindow.transform.Find("ExtractButton").gameObject.GetComponent<Image>();
        btn.sprite = coinsManager.Coins >= SpendCoins(tempExtractWearItemGemLevel) ? btnSprites[0] : btnSprites[1];
    }

    public void CallCombineWindowForReplace(Transform btn)
    {
        print("call popup for gem slot " + tempExtractWearItemGemSlot);
        shopGemItemSettings.OpenForWear(tempExtractWearItem.wear, tempExtractWearItemSlotID, btn, tempExtractWearItemGemSlot, true);
        infoWear.HideWearInfo();
    }
    public void CallReplaceWindow(Gem newGem)
    {
        var newSprite = Resources.Load<Sprite>(shopGemItemSettings.gemsLoaderConfig.GetGem(tempExtractWearGem));
        var newNewSprite = Resources.Load<Sprite>(shopGemItemSettings.gemsLoaderConfig.GetGem(newGem));
        if (newSprite != null)
        {
            replaceOldGemImage.sprite = newSprite;
        }
        replaceNewGemImage.sprite = newNewSprite;
        tempReplaceNewGem = newGem;
        replaceWindow.SetActive(true);
    }

    public void ConfirmExtract()
    {
        SaveManager.GameProgress.Current.tutorialRemoveGem = true;
        SaveManager.GameProgress.Current.Save();
        tempExtractWearItem.ExtractGem(tempExtractWearItemGemSlot);
        GemFly();
    }

    public void ConfirmReplace()
    {
        replaceWindow.SetActive(false);
        shopGemItemSettings.craftWindow.SetActive(false);
       
        ReplaceGemInWear(tempExtractWearItem.idInBase, tempExtractWearItemGemSlot, tempReplaceNewGem);
        tempExtractWearItem.ReplaceGem(tempExtractWearItemGemSlot);
        GemFly();
    }

    public void GemFly()
    {
        Sprite newSprite = Resources.Load<Sprite>(shopGemItemSettings.gemsLoaderConfig.GetGem(tempExtractWearGem));
        ParticleSystemRenderer pr = (ParticleSystemRenderer)flyRemove.effectParticles.gameObject.GetComponent<ParticleSystemRenderer>();
        pr.renderMode = ParticleSystemRenderMode.VerticalBillboard;
        pr.material.SetTexture("_MainTex", newSprite.texture);
        flyRemove.transform.position = shopGemItemSettings.gemImgTransform.position;
        flyRemove.PlayEffect();

        shopGemItemSettings.gemImgTransform = null;
    }

    private int SpendCoins(int gemLevel)
    {
        List<int> prices = new List<int> {
            50,100,200,400,800,1200,1350,1550,2500,3500
        };
        return prices[gemLevel];
    }

    public void UnlockWear(int wearNumber)
    {
        // Проверяем, достаточно ли монет?
        int unlockCoins = wearItems[wearNumber].unlockCoins;
        if (coinsManager.BuySomething(unlockCoins))
        {
            IntArrayWrapper achievementConditions = PPSerialization.Load<IntArrayWrapper>("AchievemtConditions");
            if (wearItems[wearNumber].wearParams.wearType == WearType.staff)
                Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.MasterOfStaves, 1);
            Achievement.AchievementController.Save();
            FuncUnlockWear(wearNumber);
        }
        else
        {
            uiShop.OpenBuyCoins(); // Открываем окно покупки монет
        }
    }

    public void PurchaseWear(int wearNumber)
    {
        IntArrayWrapper achievementConditions = PPSerialization.Load<IntArrayWrapper>("AchievemtConditions");
        FuncUnlockWear(wearNumber);
        shopItemsObjects[wearNumber].GetComponent<Animator>().enabled = true;
        UI.MessageWindow.Show(UI.MessageWindow.EMessageWindowType.UNLOCK_ITEM, shopWearItems[wearNumber].wearName.text, "t_0648");
        Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.PremiumMage, 1);
        Achievement.AchievementController.Save();
    }

    public void FuncUnlockWear(int wearNumber)
    {
        shopItemsObjects[wearNumber].transform.GetChild(2).gameObject.SetActive(false); // Убираем замок
        shopWearItems[wearNumber].activeSlot.SetActive(true);
        shopWearItems[wearNumber].UnlockButton.SetActive(false);
        var lockIcon = shopWearItems[wearNumber].transform.Find("LockIcon");
        if (lockIcon != null)
            lockIcon.gameObject.SetActive(false);
        shopWearItems[wearNumber].BuyButton.SetActive(false);
        //shopWearItems[wearNumber].unlockText.SetActive(false);
        if (shopWearItems[wearNumber].halo != null)
            shopWearItems[wearNumber].halo.SetActive(false);
        shopWearItems[wearNumber].slots.SetActive(true);
        wearItems[wearNumber].unlock = true; // Изменяем объект в массиве заклинаний и сохраняем
        UseWear(wearItems[wearNumber].wearParams.wearType, wearNumber);
        CheckAvailableOfItems();
        PPSerialization.Save("Wears", wearItems, true, true);

        AnalyticsController.Instance.LogMyEvent("SpellUnlocked", new Dictionary<string, string>() { { "Name", shopItemsObjects[wearNumber].name } });
    }

    override protected void SaveItemsData()
    {
        PPSerialization.Save("Wears", wearItems, true, true);
    }

    public bool CheckActiveWearItems()
    {
        foreach (WearItem item in wearItems)
        {
            if (item.active)
                return true;
        }
        return false;
    }

    public int GetActiveItem(WearType type)
    {
        for (int i = 0; i < wearItems.Length; i++)
        {
            if (wearItems[i].active)
            {
                if (wearItems[i].wearParams.wearType == type)
                {
                    return i;
                }
            }
        }
        return 0;
    }

    public void UseWear(WearType type, int slot)
    {
        DeactivationWear(type);
        wearItems[slot].active = true;
        PPSerialization.Save("Wears", wearItems, true, true);
        usingMarks[slot].SetActive(true);
        UpdateData();
    }
    public void OpenInfo(int _spellNumber)
    {
        spellInfo.SetActive(true);
        infos.transform.GetChild(_spellNumber).gameObject.SetActive(true);
    }

    public void CloseInfo(int _spellNumber)
    {
        infos.transform.GetChild(_spellNumber).gameObject.SetActive(false);
        spellInfo.SetActive(false);
    }

    private void SetWearCoinsForUnlock()
    {
        // spellItems[0] - открыто всегда
        wearItems[0].unlockCoins = 0;
        wearItems[1].unlockCoins = 5000;
        wearItems[2].unlockCoins = 5000;
        wearItems[3].unlockCoins = 5000;
        wearItems[4].unlockCoins = 5000;
        wearItems[5].unlockCoins = 5000;
        wearItems[6].unlockCoins = 5000;
        wearItems[7].unlockCoins = 5000;
        wearItems[8].unlockCoins = 5000;
        wearItems[9].unlockCoins = 5000;
        wearItems[10].unlockCoins = 5000;
    }

    // Выключаем заклинание, которое находится в заданном слоте
    private void DeactivationWear(WearType type)
    {
        for (int i = 0; i < usingMarks.Length; i++)
        {
            if (wearItems[i].active && wearItems[i].wearParams.wearType == type)
            {
                wearItems[i].active = false;
                usingMarks[i].SetActive(false);
            }
        }
    }

    public void ShowGemsForWear(Wear wear, Transform btn, int slot, int gemSlot)
    {
        shopGemItemSettings.OpenForWear(wear, slot, btn, gemSlot);
    }

    public void InsertGemToWear(Wear wear, int slot, Gem gem, int gemSlot = -1)
    {
        Gem_Items gemItems = PPSerialization.Load<Gem_Items>("Gems");

        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gem.type && gemItems[i].gem.gemLevel == gem.gemLevel)
            {
                gemItems[i].count--;
                break;
            }
        }
        PPSerialization.Save("Gems", gemItems, true, true);
        shopGemItemSettings.UpdateGemsCounter();
        LoadWearSaves();
        if (gemSlot < 0)
        {
            for (int j = 0; j < wearItems[slot].wearParams.gemsInSlots.Length; j++)
            {
                if (wearItems[slot].wearParams.gemsInSlots[j].type == GemType.None)
                {
                    wearItems[slot].wearParams.gemsInSlots[j] = gem;
                    shopWearItems[slot].wear = wearItems[slot].wearParams;
                    AnalyticsController.Instance.LogMyEvent("GemsAndWear", new Dictionary<string, string>() {
                        { "gem", gem.type.ToString() },
                    });
                    //shopWearItems[slot].PlaceGems();
                    //shopWearItems[slot].AnimateGemSlot(j);
                    break;
                }
            }
        }
        else
        {
            wearItems[slot].wearParams.gemsInSlots[gemSlot] = gem;
            shopWearItems[slot].wear = wearItems[slot].wearParams;
            //shopWearItems[slot].PlaceGems();
            //shopWearItems[slot].AnimateGemSlot(gemSlot);
        }
        PPSerialization.Save("Wears", wearItems, true, true);
        SaveManager.GameProgress.Current.InitWearGemsSave();
        //Debug.Log($"InsertGemToWear: {slot}, gem slot: {gemSlot}");
        //Debug.Log($"mainscript.progress.gemsAnimationSlot: {SaveManager.GameProgress.Current.gemsAnimationSlot.Length}");
        SaveManager.GameProgress.Current.gemsAnimationSlot[slot] = true;
        SaveManager.GameProgress.Current.gemsAnimationGemSlot[gemSlot] = true;
        SaveManager.GameProgress.Current.Save();

        UIShop.Instance.FocusItem(shopWearItems[slot].gameObject.transform);
       
       
        if (gemSlot < 0)
        {
            for (int j = 0; j < wearItems[slot].wearParams.gemsInSlots.Length; j++)
            {
                if (wearItems[slot].wearParams.gemsInSlots[j].type == GemType.None)
                {
                    shopWearItems[slot].PlaceGems();
                    shopWearItems[slot].AnimateGemSlot(j);
                    break;
                }
            }
        }
        else
        {
            shopWearItems[slot].PlaceGems();
            shopWearItems[slot].AnimateGemSlot(gemSlot);
        }
    }

    public void AnimGemInSlot(int slot)
    {
        //for (int i = 0; i < shopWearItems[slot].gemSlots.Length; i++)
        //    shopWearItems[slot].AnimateGemSlot(i);

    }

    public void ExtractGemFromWear(int slot, int gemSlot, UnityAction _action)
    {
        LoadWearSaves();
        Gem workingGem = new Gem() { type = wearItems[slot].wearParams.gemsInSlots[gemSlot].type, gemLevel = wearItems[slot].wearParams.gemsInSlots[gemSlot].gemLevel };
        Gem_Items gemItems = PPSerialization.Load<Gem_Items>("Gems");
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == workingGem.type && gemItems[i].gem.gemLevel == workingGem.gemLevel)
            {
                gemItems[i].count++;
                break;
            }
        }
        PPSerialization.Save("Gems", gemItems, true, true);
        shopGemItemSettings.UpdateGemsCounter();
        wearItems[slot].wearParams.gemsInSlots[gemSlot].type = GemType.None;
        shopWearItems[slot].wear = wearItems[slot].wearParams;
        shopWearItems[slot].PlaceGems();
        PPSerialization.Save("Wears", wearItems, true, true);
        SaveManager.GameProgress.Current.gemsAnimationSlot[slot] = false;
        SaveManager.GameProgress.Current.gemsAnimationGemSlot[gemSlot] = false;
        SaveManager.GameProgress.Current.Save();
        AnalyticsController.Instance.LogMyEvent("Remove_Stone_lvl_" + workingGem.gemLevel + "_" + workingGem.type.ToString());
        if (_action != null)
            _action();
    }
    public void ReplaceGemInWear(int slot, int gemSlot, Gem gem)
    {

        LoadWearSaves();
        Gem_Items gemItems = PPSerialization.Load<Gem_Items>("Gems");
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gem.type && gemItems[i].gem.gemLevel == gem.gemLevel)
            {
                gemItems[i].count--;
                break;
            }
        }
        //Debug.Log($"tempExtractWearItem.idInBase: {(tempExtractWearItem)}");
        //Debug.Log($" tempExtractWearGem: {(tempExtractWearGem.type)}, level: {tempExtractWearGem.gemLevel}");
        //Debug.Log($" slot: {slot}, gemSlot: {gemSlot}, gem: {gem.type}, level: {gem.gemLevel}");
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == tempExtractWearGem.type && gemItems[i].gem.gemLevel == tempExtractWearGem.gemLevel)
            {
                gemItems[i].count++;
                break;
            }
        }



        PPSerialization.Save("Gems", gemItems, true, true);
        shopGemItemSettings.UpdateGemsCounter();
        wearItems[slot].wearParams.gemsInSlots[gemSlot].type = gem.type;
        wearItems[slot].wearParams.gemsInSlots[gemSlot].gemLevel = gem.gemLevel;
        shopWearItems[slot].wear = wearItems[slot].wearParams;
        shopWearItems[slot].PlaceGems();
        PPSerialization.Save("Wears", wearItems, true, true);
        UIShop.Instance.ActiveStaffItems();
        UIShop.Instance.FocusItem(shopWearItems[slot].gameObject.transform);
        AnalyticsController.Instance.LogMyEvent("Replace_Stone_lvl_" + gem.gemLevel + "_" + gem.type.ToString());
        UpdateData();
    }


    public Color GetBuffColor(BuffType type)
    {
        foreach (var o in wearColor)
        {
            if(o.buffType == type)
            {
                return o.color;
            }
        }
        return Color.white;
    }
}
