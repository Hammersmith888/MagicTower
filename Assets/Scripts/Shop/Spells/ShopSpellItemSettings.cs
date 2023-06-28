using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Animations;
//using UnityEngine.Experimental.PlayerLoop;
using System.Net;

/// <summary>
/// Скрипт отвечает за настройку заклинаний в магазине:
/// 1) Загружает сохранные заклинаний или создает сохранение по умолчанию
/// 2) Выставляет напротив необходимых заклинаний UseMark и включает их, где необходимо
/// 3) Устанавливает иконки сохраненных заклинаний в нужные слоты (дополнительное меню)
/// 4) Прокачка заклинаний
/// 5) Информационное окно
/// </summary>

public partial class ShopSpellItemSettings : BaseShopItemSettings, IEnableObjectCallback
{
    private Spell_Items spellItems = new Spell_Items(SpellItem.SpellsNumber);

    [SerializeField]
    private RectTransform NewlyOpenedSpellHighlight;

    public GameObject slotMenu; // Дополнительный экран выбора слота для заклинания
    public GameObject slots;    // Родительский объект для слотов заклинаний
    public GameObject spellInfo; // Дополнительный экран информации о заклинаниях
    public GameObject infos; // Родительский объект для информации о заклинаниях

    private GameObject[] usingMarks = new GameObject[SpellItem.SpellsNumber]; // Объект-галочка активности заклинания
    private int selectedShopItemIndex; // Номер выбранного заклинания (устанавливается в момент открытия меню выбора слота для заклинания, необходим для сохранения)

    private byte activeSpellsCount = 0; // Количество активных заклинаний (необходимо, чтобы проверять, добавлять ли заклинаний в слот по умолчанию)
    private static Spell.SpellType NewlyOpenedSpellType = Spell.SpellType.None;

    [SerializeField]
    Text count;

    public  int countOpen = 0;

    [SerializeField]
    Transform parent;

    public static Spell.SpellType GetSpellTypeForHighlighting
    {
        get
        {
            return NewlyOpenedSpellType;
        }
    }

    public static bool IsAnySpellNeedHighlighting
    {
        get
        {
            return NewlyOpenedSpellType != Spell.SpellType.None;
        }
    }

    public static ShopSpellItemSettings Current
    {
        get;
        private set;
    }

    public static void SetSpellForHighlighting(Spell.SpellType spellType)
    {
        if (spellType != Spell.SpellType.None)
        {
            NewlyOpenedSpellType = spellType;
        }
    }

    protected override int GetMaxUpgradeLvlIndex
    {
        get
        {
            return SpellItem.MaxUpgradeLevelIndex;
        }
    }

    private Sprite GetSpellIcon(int shopSpellItemIndex)
    {
        return (shopItems[shopSpellItemIndex] as ShopSpellItem).spellIcon;
    }

    override protected void Awake()
    {
        base.Awake();
        Current = this;
        parent.gameObject.GetComponent<EnableObject>().script = this;

        for (int i = 0; i < usingMarks.Length; i++)
        {
            usingMarks[i] = parent.GetChild(i).GetChild(8).GetChild(1).gameObject;
           // Debug.Log($"parent.GetChild(i): {parent.GetChild(i).GetChild(8).GetChild(1).name}");
        }

        LoadSpellSaves();

        UpdateCount();
    }

    public void OnStart()
    {
        InitShopSpellItems();

        // Загружаем сохранения заклинаний

        // Устанавливаем полученные сохранения в магазине
        for (int i = 0; i < spellItems.Length; i++)
        {
            if (i >= shopItemsObjects.Length)
            {
                Debug.LogFormat("Spell index is greater then spells UI elements number provided! Spells {0} UIItems:{1}", spellItems.Length, shopItemsObjects.Length);
                break;
            }

            var shopItemIndex = GetShopItemObjectIndexBySpellIndexAndConvert(i);
            if (shopItemIndex >= 0)
            {
                var shopItemObject = shopItemsObjects[i];
                // Если заклинание разблокировано
                if (spellItems[i].unlock)
                {
                    //Debug.Log($"anim : {i} , {(shopItemsObjects[i].GetComponent<Animator>())}; spellItems[i].effectUnlock: {spellItems[i].effectUnlock}");
                    if(shopItemsObjects[i].GetComponent<Animator>() != null)
                    {
                        if (!spellItems[i].effectUnlock)
                            StartCoroutine(_Unlock(i));
                        else
                            Unlock(i, true);
                    }
                    else
                        Unlock(i, true);

                    shopItemObject.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = spellItems[i].unlockCoins.ToString();
                    if(shopItemObject.transform.GetChild(7).GetComponent<Button>() != null)
                    {
                        shopItemObject.transform.GetChild(7).GetComponent<Button>().onClick.AddListener(() => {
                            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Timelord, 1);
                            Achievement.AchievementController.Save();
                        });
                    }
                }
                else if (i < shopItemsObjects.Length && i < spellItems.Length)
                {
                    // Отобразить необходимое количество монет для разблокировки заклинаний
                    shopItemObject.transform.GetChild(7).GetChild(1).GetComponent<Text>().text = spellItems[i].unlockCoins.ToString();
                    if (shopItemObject.transform.GetChild(7).GetComponent<Button>() != null)
                    {
                        shopItemObject.transform.GetChild(7).GetComponent<Button>().onClick.AddListener(() => {
                            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Timelord, 1);
                            Achievement.AchievementController.Save();
                        });
                    }
                    // Отобразить необходимое количество монет для первого уровня upgrade
                    shopItemObject.transform.GetChild(6).GetChild(2).GetComponent<Text>().text = spellItems[i].upgradeCoins[0] == 0 ? "" : spellItems[i].upgradeCoins[0].ToString();
                }

                shopItems[i].unlockCoins = spellItems[i].unlockCoins;
            }
        }
        countOpen++;
        ShowActualSpellValues();
    }

   

    IEnumerator _Unlock(int i)
    {
        yield return new WaitForSeconds(0.2f);
        shopItemsObjects[i].GetComponent<Animator>().enabled = true;
        var shopItemIndex = GetShopItemObjectIndexBySpellIndexAndConvert(i);
        if (spellItems[i].active)
        {
            if (activeSpellsCount < 4)
            {
                usingMarks[shopItemIndex].SetActive(true); // Заклинание используется в слотах, зеленый чек-бокс справа
                slots.transform.GetChild(spellItems[i].slot).GetChild(0).GetComponent<Image>().sprite = GetSpellIcon(shopItemIndex); // Иконка в слоте
            }
            activeSpellsCount++;
        }
        yield return new WaitForSeconds(1f);
        Unlock(i, false);
        yield return new WaitForSeconds(6f);
        if(shopItemsObjects[i].GetComponent<Animator>() != null)
        shopItemsObjects[i].GetComponent<Animator>().enabled = false;
        Unlock(i, true);
    }

    void Unlock(int i, bool updateIcon)
    {
        try
        {
            var shopItemIndex = GetShopItemObjectIndexBySpellIndexAndConvert(i);
            var shopItemObject = shopItemsObjects[i];
            shopItemObject.transform.GetChild(1).gameObject.SetActive(false); // Убираем замок
            shopItemObject.transform.GetChild(5).gameObject.SetActive(true); // Отображаем уровень Upgrade
            shopItemObject.transform.GetChild(6).gameObject.SetActive(true); // Отображаем кнопку Upgrade
            shopItemObject.transform.GetChild(7).gameObject.SetActive(false); // Выключаем кнопку Unlock
            var obj = shopItemsObjects[i].gameObject.GetComponent<ShopItem>();
            if(updateIcon)
                obj.UpdateIcon();
            spellItems[i].effectUnlock = true;
            PPSerialization.Save<Spell_Items>(EPrefsKeys.Spells, spellItems);
            shopItemObject.transform.GetChild(8).gameObject.SetActive(true); // Отображаем чекбокс включения заклинания в слоты
            if (spellItems[i].active)
            {
                if (activeSpellsCount < 4)
                {
                    usingMarks[shopItemIndex].SetActive(true); // Заклинание используется в слотах, зеленый чек-бокс справа
                    slots.transform.GetChild(spellItems[i].slot).GetChild(0).GetComponent<Image>().sprite = GetSpellIcon(shopItemIndex); // Иконка в слоте
                }
                activeSpellsCount++;
            }

            for (int j = 0; j <= spellItems[i].upgradeLevel; j++) // Отображаем уровень Upgrade заклинания
            {
                shopItemObject.transform.GetChild(5).GetChild(j).gameObject.SetActive(true);
            }

            // Отобразить необходимое количество монет для следующего уровня upgrade, если он существует, иначе выводим сообщение на кнопке, что максимальный уровень достигнут
            if (spellItems[i].upgradeLevel < GetMaxUpgradeLvlIndex)
            {
                shopItemObject.transform.GetChild(6).GetChild(2).GetComponent<Text>().text = spellItems[i].upgradeCoins[spellItems[i].upgradeLevel] == 0 ? "" : spellItems[i].upgradeCoins[spellItems[i].upgradeLevel].ToString();
                Transform description = shopItemObject.transform.GetChild(4);
                if(updateIcon)
                    description.GetChild(0).gameObject.SetActive(false); // Выключаем описание на каком уровне будет доступно данное заклинание
                description.GetChild(1).gameObject.SetActive(true); // Выключаем описание возможности Upgrade
            }
            else
            {
                Transform description = shopItemObject.transform.GetChild(4);
                description.GetChild(0).gameObject.SetActive(false); // Выключаем описание на каком уровне будет доступно данное заклинание
                description.GetChild(1).gameObject.SetActive(true); // Выключаем описание возможности Upgrade

                Transform upgradeBtn = shopItemObject.transform.GetChild(6);
                upgradeBtn.GetComponent<Button>().interactable = false; // Выключаем интерактивность кнопки Upgrade
                foreach (Transform child in upgradeBtn) // Выключаем все описания на кнопке Upgrade
                {
                    child.gameObject.SetActive(false);
                }
                upgradeBtn.GetChild(4).gameObject.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade
            }
            
        }
        catch (System.Exception er)
        {
            Debug.LogError(er);
            Debug.LogError($"spell: {i}");
        }
    }

    public void Open()
    {
        countOpen++;
        if(countOpen > 1)
        {
            for (int i = 0; i < spellItems.Length; i++)
            {
                if (i >= shopItemsObjects.Length)
                {
                    Debug.LogFormat("Spell index is greater then spells UI elements number provided! Spells {0} UIItems:{1}", spellItems.Length, shopItemsObjects.Length);
                    break;
                }
                if (spellItems[i].unlock)
                {
                    spellItems[i].effectUnlock = true;
                    PPSerialization.Save<Spell_Items>(EPrefsKeys.Spells, spellItems);
                    var shopItemIndex = GetShopItemObjectIndexBySpellIndexAndConvert(i);
                    if (shopItemIndex >= 0)
                    {
                        var shopItemObject = shopItemsObjects[i];
                        if (shopItemsObjects[i].GetComponent<Animator>() != null)
                        {
                            if (spellItems[i].unlock && spellItems[i].effectUnlock)
                            {
                                Unlock(i, true);
                                Destroy(shopItemsObjects[i].GetComponent<Animator>());
                                var c = shopItemsObjects[i].GetComponentsInChildren<CanvasGroup>();
                                foreach (var x in c)
                                    Destroy(x);
                                var v = shopItemsObjects[i].GetComponentInChildren<UIImageColorHolderComponent>();
                                if (v != null)
                                    Destroy(v.gameObject);
                            }
                        }
                    }
                }
            }
        }
    }

    private void InitShopSpellItems()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            (shopItems[i] as ShopSpellItem).Init(this);
        }
    }

    void UpdateCount()
    {
        var countUnlock = 0;
        for (int i = 0; i < spellItems.Length; i++)
        {

            var shopItemIndex = GetShopItemObjectIndexBySpellIndexAndConvert(i);
            if (shopItemIndex >= 0)
            {
                // Если заклинание разблокировано
                if (spellItems[i].unlock)
                    countUnlock++;
            }
        }
        count.text = countUnlock + "/" + spellItems.Length;
    }

    private int GetShopItemObjectIndexBySpellIndexAndConvert(int spellIndex, int defaultValue = -1)
    {
        var spellType = SpellInfoUtils.GetSpellTypeBySpellDataIndex(spellIndex);
        if (spellType != Spell.SpellType.AcidSpray_Unused)
        {
            for (int i = 0; i < shopItems.Length; i++)
            {
                if ((shopItems[i] as ShopSpellItem).spellType == spellType)
                {
                    return i;
                }
            }
        }
        return defaultValue;
    }

    private int GetShopItemObjectIndexBySpellIndex(Spell.SpellType spellType, int defaultValue = -1)
    {
        if (spellType != Spell.SpellType.AcidSpray_Unused)
        {
            for (int i = 0; i < shopItems.Length; i++)
            {
                if ((shopItems[i] as ShopSpellItem).spellType == spellType)
                {
                    return i;
                }
            }
        }
        return defaultValue;
    }

    private int GetSpellDataIndexByShopItemIndex(int shopItemIndex)
    {
        return SpellInfoUtils.GetSpellSpellDataIndexBySpellType((shopItems[shopItemIndex] as ShopSpellItem).spellType);
    }

    public Vector2 GetSpellItemUILocalPosition(Spell.SpellType spellType)
    {
        var shopItemIndex = GetShopItemObjectIndexBySpellIndex(spellType, 0);
        return shopItemsObjects[shopItemIndex].transform.localPosition;
    }
    public Transform GetSpellItemUILocalTransform(Spell.SpellType spellType)
    {
        var shopItemIndex = GetShopItemObjectIndexBySpellIndex(spellType, 0);
        return shopItemsObjects[shopItemIndex].transform;
    }

    public void HighlightLastOpenedSpell()
    {
        if (IsAnySpellNeedHighlighting)
        {
            var shopItemIndex = GetShopItemObjectIndexBySpellIndex(NewlyOpenedSpellType);
            //Debug.Log(NewlyOpenedSpellType + "  " + (int)NewlyOpenedSpellType + "  " + shopItemIndex);
            NewlyOpenedSpellHighlight.SetParent(shopItemsObjects[shopItemIndex].transform);
            NewlyOpenedSpellHighlight.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            NewlyOpenedSpellHighlight.SetAsLastSibling();
            NewlyOpenedSpellHighlight.gameObject.SetActive(true);
            NewlyOpenedSpellType = Spell.SpellType.None;
            CoroutinesHolder.StartCoroutine(DisableSpellHighlight);
        }
    }

    private IEnumerator DisableSpellHighlight()
    {
        yield return new WaitForSeconds(5f);
        NewlyOpenedSpellHighlight.GetComponent<Animations.AlphaColorAnimation>().AnimateFromCurrentColor(0f, () =>
         {
             NewlyOpenedSpellHighlight.gameObject.SetActive(false);
         });
    }

    override protected BaseUpgradableShopItem GetItemByShopIndex(int shopItemIndex)
    {
        return spellItems[GetSpellDataIndexByShopItemIndex(shopItemIndex)];
    }

    override protected BaseUpgradableShopItem[] GetAllItems()
    {
        return spellItems.getInnerArray;
    }

    /// <summary>
    /// Метод который проверяет достаточно средств для покупки, если нет, то он показывает серую панель
    /// </summary>
    override protected void CheckAvailableOfItems(int playerCoins = -1)
    {
        if (playerCoins < 0)
        {
            playerCoins = coinsManager.Coins;
        }
        //для всех объектов делаем проверку
        for (int i = 0; i < shopItemsObjects.Length; i++)
        {
            //если цена улучшения выше чем общее количество золота у игрока, то показать серую панель
            if (spellItems[i].upgradeLevel < spellItems[i].upgradeCoins.Length)
            {
                var canNotBeUpgraded = spellItems[i].upgradeCoins[spellItems[i].upgradeLevel] > playerCoins;
                shopItemsObjects[i].transform.GetChild(6).GetChild(0).gameObject.SetActive(canNotBeUpgraded);
            }
        }
    }

    public void LoadSpellSaves()
    {
        spellItems = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells);
        // Установить необходимое количество монет для разблокировки заклинаний и upgrade
        SetSpellCoinsForUnlock();
        SetSpellCoinsForUpgrade();
    }

    public bool IsCan(int shopItemIndex)
    {
        var spellItemIndex = GetSpellDataIndexByShopItemIndex(shopItemIndex);
        int unlockCoins = spellItems[spellItemIndex].unlockCoins;
        return coinsManager.BuySomething(unlockCoins);
    }

    public bool IsUnlock(int shopItemIndex)
    {
        var spellItemIndex = GetSpellDataIndexByShopItemIndex(shopItemIndex);
        return spellItems[spellItemIndex].unlock;
    }

    public void UnlockSpell(int shopItemIndex)
    {
        var spellItemIndex = GetSpellDataIndexByShopItemIndex(shopItemIndex);
        int unlockCoins = spellItems[spellItemIndex].unlockCoins;
        spellItems[spellItemIndex].effectUnlock = true;
        spellItems[spellItemIndex].unlock = true; // Изменяем объект в массиве заклинаний и сохраняем
        PPSerialization.Save(EPrefsKeys.Spells, spellItems);
     }
    public void UnlockSpellObj(int shopItemIndex, bool value = true)
    {
        var spellItemIndex = GetSpellDataIndexByShopItemIndex(shopItemIndex);
        int unlockCoins = spellItems[spellItemIndex].unlockCoins;
   

        shopItemsObjects[shopItemIndex].transform.GetChild(1).gameObject.SetActive(false); // Убираем замок
        if(value)
            shopItemsObjects[shopItemIndex].transform.GetChild(4).GetChild(0).gameObject.SetActive(false); // Выключаем сообщение, что заклинание будет доступно на таком-то уровне
        shopItemsObjects[shopItemIndex].transform.GetChild(4).GetChild(1).gameObject.SetActive(true); // Включаем соообщение, что заклинание может быть Upgrade
        shopItemsObjects[shopItemIndex].transform.GetChild(5).gameObject.SetActive(true); // Отображаем уровень Upgrade
        shopItemsObjects[shopItemIndex].transform.GetChild(6).gameObject.SetActive(true); // Отображаем кнопку Upgrade
        shopItemsObjects[shopItemIndex].transform.GetChild(7).gameObject.SetActive(false); // Выключаем кнопку Unlock
        shopItemsObjects[shopItemIndex].transform.GetChild(8).gameObject.SetActive(true); // Отображаем чекбокс включения заклинания в слоты
        if (activeSpellsCount < 4) // Если активных заклинаний в данный момент меньше 4х, то разблокированное заклинание делаем активным
        {
            usingMarks[shopItemIndex].SetActive(true);
            spellItems[spellItemIndex].active = true;
            slots.transform.GetChild(activeSpellsCount).GetChild(0).GetComponent<Image>().sprite = GetSpellIcon(shopItemIndex); // Иконка в слоте

            spellItems[spellItemIndex].slot = activeSpellsCount;
            activeSpellsCount++;
        }

     
        CheckAvailableOfItems();
        
        ShowActualSpellValues();
        AnalyticsController.Instance.LogMyEvent("SpellUnlocked", new System.Collections.Generic.Dictionary<string, string>() { { "Name", shopItemsObjects[shopItemIndex].name } });
        Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.SPELL_UNLOCKED, shopItemIndex);

        UpdateCount();
    }

    public void UpgradeSpell(int shopItemIndex)
    {
        UpgradeItem(shopItemIndex);
    }

    override protected void OnItemUpgraded(int shopItemIndex)
    {
        var spellItemIndex = GetSpellDataIndexByShopItemIndex(shopItemIndex);
        Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.SPELL_UPGRADED, spellItemIndex, (int)spellItems[spellItemIndex].upgradeLevel);
        if (spellItems[spellItemIndex].upgradeLevel == GetMaxUpgradeLvlIndex)
        {
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Archmage, 1);
            Achievement.AchievementController.Save();
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.UpgradeMaster, 1);
            Achievement.AchievementController.Save();
            Transform description = shopItemsObjects[shopItemIndex].transform.GetChild(4);

            shopItems[shopItemIndex].upgradeBtn.interactable = false;// Выключаем интерактивность кнопки Upgrade
            Transform upgradeBtnTransf = shopItems[shopItemIndex].upgradeBtn.transform;
            foreach (Transform child in upgradeBtnTransf) // Выключаем все описания на кнопке Upgrade
            {
                child.gameObject.SetActive(false);
            }

            shopItems[shopItemIndex].maxUpgradeLabel.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade
        }
        //SoundController.Instanse.upgradeSound.Play(44100);
        ShowActualSpellValues();
        base.OnItemUpgraded(shopItemIndex);
    }

    override protected void SaveItemsData()
    {
        PPSerialization.Save(EPrefsKeys.Spells, spellItems);
    }

    public void OpenSpellSlotSelector(int shopItemIndex)
    {
        // Открываем окно выбора слота, только если заклинание не используется
        if (!usingMarks[shopItemIndex].activeSelf)
        {
            slotMenu.SetActive(true);
            for (int i = 0; i < 4; i++)
            {
                slots.transform.GetChild(i).GetChild(1).GetComponent<Animator>().enabled = false;
                slots.transform.GetChild(i).GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
            selectedShopItemIndex = shopItemIndex;
        }
    }

    public void CloseSpellSlotSelector()
    {
        slotMenu.SetActive(false);
    }

    public void SelectSlot(int slotNumber)
    {
        // Сохраняем изменения для заклинания, которое было в данном слоте (в PlayerPrefs и UsingMark)
        DeactivationSpell(slotNumber);
        // Заменяем иконку в выбранном слоте
        //slots.transform.GetChild(slotNumber).GetChild(0).GetComponent<Image>().sprite = GetSpellIcon(selectedShopItemIndex);
        // Сохраняем изменения
        var selectedSpellIndex = GetSpellDataIndexByShopItemIndex(selectedShopItemIndex);
        spellItems[selectedSpellIndex].active = true;
        spellItems[selectedSpellIndex].slot = (byte)slotNumber;
        PPSerialization.Save(EPrefsKeys.Spells, spellItems);
        // Устанавливаем чекбокс, что заклинание используется
        usingMarks[selectedShopItemIndex].SetActive(true);
        // Закрываем экран выбора слота (с задержкой, чтобы было видно замену иконки в слоте)
        // Invoke("CloseSpellSlotSelector", 0.5f);
       
        slots.transform.GetChild(slotNumber).GetChild(1).GetComponent<Image>().sprite = GetSpellIcon(selectedShopItemIndex);
        slots.transform.GetChild(slotNumber).GetChild(1).GetComponent<Animator>().enabled = true;
        StartCoroutine(_CloseSelectSpeel(slotNumber));
        for (int i = 0; i < 4; i++)
        {
            // отключение кнопки выбора слота
            slots.transform.GetChild(i).gameObject.GetComponent<Button>().enabled = false;
        }
        //Debug.Log($"SelectSlot: {slotNumber}");
    }

    IEnumerator _CloseSelectSpeel(int slotNumber)
    {
        slotMenu.transform.Find("DarkBackground").gameObject.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(1.1f);
        SoundController.Instanse.slotChange.Play();
        yield return new WaitForSeconds(0.7f);
        CloseSpellSlotSelector();
        slots.transform.GetChild(slotNumber).GetChild(1).GetComponent<Animator>().enabled = false;
        slots.transform.GetChild(slotNumber).GetChild(0).GetComponent<Image>().sprite = GetSpellIcon(selectedShopItemIndex);
        for (int i = 0; i < 4; i++)
        {
            // включение кнопки выбора слота
            slots.transform.GetChild(i).gameObject.GetComponent<Button>().enabled = true;
        }
        slotMenu.transform.Find("DarkBackground").gameObject.GetComponent<Button>().enabled = true;
    }

    public void OpenInfo(int _spellNumber)
    {
        Debug.Log($"OpenInfo: {_spellNumber}");
        spellInfo.SetActive(true);
        infos.transform.GetChild(_spellNumber).gameObject.SetActive(true);
    }

    public void CloseInfo(int _spellNumber)
    {
        infos.transform.GetChild(_spellNumber).gameObject.SetActive(false);
        spellInfo.SetActive(false);
    }

    // Выключаем заклинание, которое находится в заданном слоте
    private void DeactivationSpell(int slotNumber)
    {
        for (int i = 0; i < spellItems.Length; i++)
        {
            if (spellItems[i].active && spellItems[i].slot == slotNumber)
            {
                spellItems[i].active = false;
                if (usingMarks.Length > i)
                {
                    usingMarks[i].SetActive(false);
                }
            }
        }
    }

    private void ShowActualSpellValues()
    {
        Spell.SpellType[] typesTable =
        {
            Spell.SpellType.FireBall,
            Spell.SpellType.Lightning,
            Spell.SpellType.IceStrike,
            Spell.SpellType.EarthBall,
            Spell.SpellType.FireWall,
            Spell.SpellType.ChainLightning,
            Spell.SpellType.IceBreath,
            Spell.SpellType.Boulder,
            Spell.SpellType.Meteor,
            Spell.SpellType.ElecticPool,
            Spell.SpellType.Blizzard,
            Spell.SpellType.FireDragon,
            Spell.SpellType.AcidSpray_Unused
        };

        var spellParameters = BalanceTables.Instance.SpellParameters;
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] != null)
            {
                if (shopItems[i].damageValuesUnit != null && shopItems[i].damageValuesUnit.gameObject.activeSelf && typesTable.Length > i)
                {
                    var spellItem = spellItems[GetSpellDataIndexByShopItemIndex(i)];
                    int currentId = InfoLoaderConfig.Instance.GetTableSpellIndex(typesTable[i]) + spellItem.upgradeLevel;
                    var nextUpgradeLvlID = currentId + 1;
                    int currentDamage = (int)(spellParameters[currentId].maxDamage + spellParameters[currentId].minDamage) / 2;
                    shopItems[i].damageValuesUnit.currentValueText.text = currentDamage.ToString();
                    //shopItems[i].damageValuesUnit.currentValueText.text = spellParameters[currentId].name.ToString();
                    if (spellItem.upgradeLevel + 1 <= SpellItem.MaxUpgradeLevelIndex)
                    {
                        shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(true);
                        int addDamage = ((int)spellParameters[nextUpgradeLvlID].maxDamage + (int)spellParameters[nextUpgradeLvlID].minDamage) / 2 - currentDamage;
                        shopItems[i].damageValuesUnit.additionalValueText.text = "+" + addDamage.ToString();
                    }
                    else
                    {
                        shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}