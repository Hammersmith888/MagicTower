using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Animations;

/// <summary>
/// Скрипт отвечает за настройку свитков в магазине:
/// 1) Загружает сохранные свитки или создает сохранение по умолчанию
/// 2) Выставляет количество имеющихся свитков
/// 3) Покупка, прокачка свитков
/// 4) Информационное окно
/// </summary>

public partial class ShopScrollItemSettings : BaseShopItemSettings, IEnableObjectCallback
{
    private const byte MaxActiveScrollsNumber = 4;

    [SerializeField]
    private RectTransform NewlyOpenedScrollHighlight;

    private Scroll_Items scrollItems = new Scroll_Items(ScrollItem.ItemsNumber);
    public GameObject slotMenu; // Дополнительный экран выбора слота для заклинания
    public GameObject slots;    // Родительский объект для слотов заклинаний
    public Sprite[] scrollIcons; // Иконки заклинаний для слотов
    private GameObject[] usingMarks = new GameObject[ScrollItem.ItemsNumber]; // Объект-галочка активности заклинания

    public GameObject info; // Дополнительный экран информации
    public GameObject infos; // Родительский объект для информации о свитках
    private int selectedScrollNumber; // Номер выбранного свитка (устанавливается в момент открытия меню выбора слота для свитка, необходим для сохранения)

    private byte scrollsUnlocked; // Количество разблокированных свитков
    private byte activeScrollsCount = 0; // Количество активных заклинаний (необходимо, чтобы проверять, добавлять ли заклинаний в слот по умолчанию)

    private static Scroll.ScrollType NewlyOpenedScrollType = Scroll.ScrollType.None;


    [SerializeField]
    Text count;

    [SerializeField]
    Transform parent;

    public int countOpen;
    public static Scroll.ScrollType GetScrollTypeForHighlighting
    {
        get
        {
            return NewlyOpenedScrollType;
        }
    }

    public static bool IsAnyScrollNeedHighlighting
    {
        get
        {
            return NewlyOpenedScrollType != Scroll.ScrollType.None;
        }
    }

    public static void SetScrollForHighlighting(Scroll.ScrollType scrollType)
    {
        //Debug.Log("SetScrollForHighlighting");
        if (scrollType != Scroll.ScrollType.None)
        {
            NewlyOpenedScrollType = scrollType;
        }
    }

    public static ShopScrollItemSettings Current
    {
        get; private set;
    }

    public Vector2 GetScrollItemUILocalPosition(Scroll.ScrollType scrollType)
    {
        return shopItemsObjects[(int)scrollType].transform.localPosition;
    }

    public Transform GetScrollItemUILocalTransform(Scroll.ScrollType scrollType)
    {
        Debug.Log($"(int)scrollType: {(int)scrollType}, type: {scrollType}, lenght: {shopItemsObjects.Length}");
        return shopItemsObjects[(int)scrollType].transform;
    }

    public void HighlightLastOpenedScroll()
    {
        Debug.Log("HighlightLastOpenedScroll");
        if (IsAnyScrollNeedHighlighting)
        {
            var shopItemIndex = (int)NewlyOpenedScrollType;
            NewlyOpenedScrollHighlight.SetParent(shopItemsObjects[shopItemIndex].transform);
            NewlyOpenedScrollHighlight.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            NewlyOpenedScrollHighlight.SetAsLastSibling();
            NewlyOpenedScrollHighlight.gameObject.SetActive(true);
            NewlyOpenedScrollType = Scroll.ScrollType.None;
            CoroutinesHolder.StartCoroutine(DisableSpellHighlight);
        }
    }

    private IEnumerator DisableSpellHighlight()
    {
        yield return new WaitForSeconds(5f);
        NewlyOpenedScrollHighlight.GetComponent<Animations.AlphaColorAnimation>().AnimateFromCurrentColor(0f, () =>
        {
            NewlyOpenedScrollHighlight.gameObject.SetActive(false);
        });
    }

    override protected BaseUpgradableShopItem GetItemByShopIndex(int itemNumber)
    {
        return scrollItems[itemNumber];
    }

    override protected BaseUpgradableShopItem[] GetAllItems()
    {
        return scrollItems.getInnerArray;
    }

    override protected int GetMaxUpgradeLvlIndex
    {
        get
        {
            return ScrollItem.MaxUpgradeLevelIndex;
        }
    }

    override protected void Awake()
    {
        base.Awake();
        Current = this;
        parent.gameObject.GetComponent<EnableObject>().script = this;
        // Загружаем сохранения свитков
        LoadScrollSaves();
        UpdateCount();
        OnStart();
    }

    public void OnStart()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        LoadScrollSaves();
        AutoPlaceScrollsToSlots();

        // Устанавливаем полученные сохранения в магазине
        for (int i = 0; i < scrollItems.Length; i++)
        {
            usingMarks[i] = shopItems[i].useButton;
            //Debug.Log($"OnStart SCROLLLLLLLL: {i}: , {scrollItems[i].effectUnlock}");
            // Если заклинание разблокировано
            if (scrollItems[i].unlock)
            {
                if(!scrollItems[i].effectUnlock)
                {
                    StartCoroutine(_Unlock(i));
                }
                else
                {
                    Unlock(i, true);
                }
            }
            else
            {
                shopItemsObjects[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                // Отобразить необходимое количество монет для разблокировки свитка
                shopItemsObjects[i].transform.GetChild(8).GetChild(1).GetComponent<Text>().text = scrollItems[i].unlockCoins.ToString();
                // Отобразить необходимое количество монет для первого уровня upgrade
                shopItemsObjects[i].transform.GetChild(7).GetChild(1).GetComponent<Text>().text = scrollItems[i].upgradeCoins[0].ToString();
            }
            shopItems[i].unlockCoins = scrollItems[i].unlockCoins;
        }
        countOpen++;
        ShowActualSpellValues();
    }

    public void Open()
    {
        countOpen++;
        if (countOpen > 1)
        {
            for (int i = 0; i < scrollItems.Length; i++)
            {
                if (scrollItems[i].unlock)
                {
                    scrollItems[i].effectUnlock = true;
                    PPSerialization.Save<Scroll_Items>(EPrefsKeys.Scrolls, scrollItems);
                    if (shopItemsObjects[i].GetComponent<Animator>() != null)
                    {
                        if (scrollItems[i].unlock && scrollItems[i].effectUnlock)
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

    IEnumerator _Unlock(int i)
    {
        shopItemsObjects[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        shopItemsObjects[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = scrollItems[i].count.ToString();
        Debug.Log($"_Unlock: {i}");
        yield return new WaitForSecondsRealtime((i == 1 || i == 5 || i == 2) ? 1.2f : 0.2f);
        shopItemsObjects[i].GetComponent<Animator>().enabled = true;
        if (scrollItems[i].active)
        {
            if (activeScrollsCount < MaxActiveScrollsNumber)
            {
                usingMarks[i].SetActive(true); // Заклинание используется в слотах, зеленый чек-бокс справа
                slots.transform.GetChild(scrollItems[i].slot).GetChild(0).GetComponent<Image>().sprite = scrollIcons[i]; // Иконка в слоте
            }
            activeScrollsCount++;
        }

        yield return new WaitForSecondsRealtime(1f);
        Unlock(i, false);
        yield return new WaitForSecondsRealtime(4f);
        Unlock(i, true);
    }

    void Unlock(int i, bool value)
    {
        scrollsUnlocked++;
        ShowDescItem(i, true);
        shopItemsObjects[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        shopItemsObjects[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = scrollItems[i].count.ToString(); // Устанавливаем количество купленных свитков
        shopItemsObjects[i].transform.GetChild(1).gameObject.SetActive(false); // Убираем замок
        if (value)
            shopItemsObjects[i].transform.GetChild(4).GetChild(0).gameObject.SetActive(false); // Убираем сообщение о том, когда будет доступен данный свиток
        shopItemsObjects[i].transform.GetChild(4).GetChild(1).gameObject.SetActive(!shopItemsObjects[i].transform.GetChild(4).GetChild(0).gameObject.activeSelf);
        shopItemsObjects[i].transform.GetChild(5).gameObject.SetActive(true); // Отображаем кнопку Buy
        shopItemsObjects[i].transform.GetChild(6).gameObject.SetActive(true); // Отображаем уровень Upgrade
        shopItemsObjects[i].transform.GetChild(7).gameObject.SetActive(true); // Отображаем кнопку Upgrade
        shopItemsObjects[i].transform.GetChild(8).gameObject.SetActive(false); // Выключаем кнопку Unlock
        var obj = shopItemsObjects[i].gameObject.GetComponent<ShopItem>();
        if(value)
            obj.UpdateIcon();
        obj.spellLock.Init(true);

        usingMarks[i].transform.parent.gameObject.SetActive(true);
        scrollItems[i].effectUnlock = true;
        PPSerialization.Save<Scroll_Items>(EPrefsKeys.Scrolls, scrollItems);
        if (scrollItems[i].active)
        {
            if (activeScrollsCount < MaxActiveScrollsNumber)
            {
                usingMarks[i].SetActive(true); // Заклинание используется в слотах, зеленый чек-бокс справа
                slots.transform.GetChild(scrollItems[i].slot).GetChild(0).GetComponent<Image>().sprite = scrollIcons[i]; // Иконка в слоте
            }
            activeScrollsCount++;
        }

        for (int j = 0; j <= scrollItems[i].upgradeLevel; j++) // Отображаем уровень Upgrade заклинания
        {
            shopItemsObjects[i].transform.GetChild(6).GetChild(j).gameObject.SetActive(true);
        }

        // Отобразить необходимое количество монет для следующего уровня upgrade, если он существует, иначе выводим сообщение на кнопке, что максимальный уровень достигнут
        if (scrollItems[i].upgradeLevel < ScrollItem.MaxUpgradeLevelIndex)
        {
            if(shopItemsObjects[i].transform.GetChild(7).GetChild(2).GetComponent<Text>()!=null)
            shopItemsObjects[i].transform.GetChild(7).GetChild(2).GetComponent<Text>().text = scrollItems[i].upgradeCoins[scrollItems[i].upgradeLevel].ToString();

        }
        else
        {
            Transform upgradeBtn = shopItemsObjects[i].transform.GetChild(7);
            upgradeBtn.GetComponent<Button>().interactable = false; // Выключаем интерактивность кнопки Upgrade
            foreach (Transform child in upgradeBtn) // Выключаем все описания на кнопке Upgrade
                child.gameObject.SetActive(false);
            upgradeBtn.GetChild(4).gameObject.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade
        }
    }

    void UpdateCount()
    {
        var countUnlock = 0;
        for (int i = 0; i < scrollItems.Length; i++)
        {
            // Если заклинание разблокировано
            if (scrollItems[i].unlock)
                countUnlock++;
        }
        count.text = countUnlock + "/" + scrollItems.Length;
    }

    public void ClickOpen()
    {
        LoadScrollSaves();
        OnStart();
    }

    private void AutoPlaceScrollsToSlots()
    {
        for (byte i = 0; i < MaxActiveScrollsNumber; i++)
        {
            bool thisEmpty = true;
            for (int j = 0; j < scrollItems.Length; j++)
            {
                if (scrollItems[j].unlock)
                {
                    if (scrollItems[j].active && scrollItems[j].slot == i)
                    {
                        thisEmpty = false;
                        break;
                    }
                }
            }

            if (thisEmpty)
            {
                for (int j = 0; j < scrollItems.Length; j++)
                {
                    if (scrollItems[j].unlock)
                    {
                        if (!scrollItems[j].active)
                        {
                            scrollItems[j].active = true;
                            scrollItems[j].slot = i;
                            break;
                        }
                    }
                }
            }
        }
    }

    public void LoadScrollSaves()
    {
        scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
        // Установить необходимое количество монет для разблокировки свитков и upgrade
        SetScrollCoinsForUnlock();
        SetScrollCoinsForUpgrade();
        SetScrollCoinsForBuy();
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
            if (scrollItems[i].upgradeLevel < scrollItems[i].upgradeCoins.Length)
            {
                var canNotBeUpgraded = scrollItems[i].upgradeCoins[scrollItems[i].upgradeLevel] > playerCoins;
                shopItemsObjects[i].transform.GetChild(7).GetChild(0).gameObject.SetActive(canNotBeUpgraded);
            }
            //если цена  выше чем общее количество золота у игрока, то показать серую панель
            shopItemsObjects[i].transform.GetChild(5).GetChild(0).gameObject.SetActive(scrollItems[i].cost > playerCoins);
        }
    }

    override protected void SaveItemsData()
    {
        PPSerialization.Save(EPrefsKeys.Scrolls, scrollItems);
    }

    protected override void OnItemUnlocked(int itemNumber)
    {
        base.OnItemUnlocked(itemNumber);
        scrollItems[itemNumber].unlock = true; // Изменяем объект в массиве заклинаний и сохраняем
        scrollsUnlocked++;
        scrollItems[itemNumber].order = scrollsUnlocked; // Порядок (номер) каким по счету разблокировано данное заклинание
    }

    public void UnlockScroll(int _scrollNumber)
    {
        if (IsUnlockScroll(_scrollNumber))
            return;
        if (IsCanScroll(_scrollNumber))
            StartCoroutine(_Unloc(_scrollNumber));
        else
            uiShop.OpenBuyCoins();
    }

    public void UpgradeScroll(int _scrollNumber)
    {
        //SoundController.Instanse.upgradeSound.Play(44100);
        UpgradeItem(_scrollNumber);
        ShowActualSpellValues();
    }

    IEnumerator _Unloc(int _scrollNumber)
    {
        var item = shopItemsObjects[_scrollNumber].GetComponent<ShopItem>();
        item.StartCoroutine(item.spellLock.UnlockText());
        shopItemsObjects[_scrollNumber].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        shopItemsObjects[_scrollNumber].gameObject.GetComponent<Animator>().enabled = true;
        scrollItems[_scrollNumber].unlock = true;
        yield return new WaitForSecondsRealtime(1f);

        UnlockItem(_scrollNumber);
        if (scrollItems[_scrollNumber].unlock)
        {
            usingMarks[_scrollNumber].transform.parent.gameObject.SetActive(true);
            if (activeScrollsCount < MaxActiveScrollsNumber) // Если активных заклинаний в данный момент меньше 4х, то разблокированное заклинание делаем активным
            {
                usingMarks[_scrollNumber].SetActive(true);
                scrollItems[_scrollNumber].active = true;
                slots.transform.GetChild(activeScrollsCount).GetChild(0).GetComponent<Image>().sprite = scrollIcons[_scrollNumber]; // Иконка в слоте
                scrollItems[_scrollNumber].slot = activeScrollsCount;
                activeScrollsCount++;
                SaveItemsData();
            }
            ShowActualSpellValues();
        }
        ShowDescItem(_scrollNumber, true);
        UpdateCount();

        scrollItems[_scrollNumber].effectUnlock = true;
        PPSerialization.Save<Scroll_Items>(EPrefsKeys.Scrolls, scrollItems);
        yield return new WaitForSecondsRealtime(4f);
        if(shopItemsObjects[_scrollNumber].gameObject.GetComponent<Animator>() != null)
            shopItemsObjects[_scrollNumber].gameObject.GetComponent<Animator>().enabled = false;
    }

    public void BuyScroll(int _scrollNumber)
    {
        if (coinsManager.BuySomething(scrollItems[_scrollNumber].cost))
        {
            int count = ++scrollItems[_scrollNumber].count;
            shopItemsObjects[_scrollNumber].transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            shopItemsObjects[_scrollNumber].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = count.ToString(); // Изменяем количество свитков
            scrollItems[_scrollNumber].count = count; // Изменяем объект в массиве свитков и сохраняем

            CheckAvailableOfItems();

            PPSerialization.Save("Scrolls", scrollItems, true, true);
            SoundController.Instanse.PlayShopBuySFX();
        }
        else
        {
            uiShop.OpenBuyCoins(); // Открываем окно покупки монет
        }
    }

    public void OpenInfo(int _scrollNumber)
    {
        info.SetActive(true);
        infos.transform.GetChild(_scrollNumber).gameObject.SetActive(true);
    }

    public void OpenScrollSlotSelector(int _scrollNumber)
    {
        // Открываем окно выбора слота, только если заклинание не используется
        if (!usingMarks[_scrollNumber].activeSelf)
        {
            slotMenu.SetActive(true);
            selectedScrollNumber = _scrollNumber;
        }
    }

    public void CloseScrollSlotSelector()
    {
        slotMenu.SetActive(false);
        slotMenu.transform.Find("DarkBackground").gameObject.GetComponent<Button>().enabled = true;
    }

    public void SelectSlot(int _slotNumber)
    {
        StartCoroutine(_SelectScroll(_slotNumber));
    }

    IEnumerator _SelectScroll(int _slotNumber)
    {
        slotMenu.transform.Find("DarkBackground").gameObject.GetComponent<Button>().enabled = false;
        yield return new WaitForEndOfFrame();
        // Сохраняем изменения для заклинания, которое было в данном слоте (в PlayerPrefs и UsingMark)
        DeactivationScroll(_slotNumber);
        // Заменяем иконку в выбранном слоте
        slots.transform.GetChild(_slotNumber).GetChild(0).GetComponent<Image>().sprite = scrollIcons[selectedScrollNumber];
        // Сохраняем изменения
        scrollItems[selectedScrollNumber].active = true;
        scrollItems[selectedScrollNumber].slot = (byte)_slotNumber;
        SaveItemsData();
        Debug.Log($"SelectSlot: {_slotNumber}");
        // Устанавливаем чекбокс, что заклинание используется
        usingMarks[selectedScrollNumber].SetActive(true);
        // Закрываем экран выбора слота (с задержкой, чтобы было видно замену иконки в слоте)
        Invoke("CloseScrollSlotSelector", 0.5f);
    }

    private void DeactivationScroll(int _slotNumber)
    {
        for (int i = 0; i < scrollItems.Length; i++)
        {
            if (scrollItems[i].active && scrollItems[i].slot == _slotNumber)
            {
                scrollItems[i].active = false;
                usingMarks[i].SetActive(false);
            }
        }
    }

    public void CloseInfo(int _scrollNumber)
    {
        infos.transform.GetChild(_scrollNumber).gameObject.SetActive(false);
        info.SetActive(false);
    }

    // Очищаем апгрэйд свитков (для настройки и тестов)
    public void ClearUpgrade(int _scrollNumber)
    {
        scrollItems[_scrollNumber].upgradeLevel = 0;
        PPSerialization.Save(EPrefsKeys.Scrolls, scrollItems);
    }

    private void ShowActualSpellValues()
    {
        var balanceIds = MyGSFU.ScrollsBalanceIdsMap;
        var scrollParameters = BalanceTables.Instance.ScrollParameters;
        var enemyParameters = BalanceTables.Instance.EnemyParameters;

        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] != null)
            {
                if (shopItems[i].damageValuesUnit != null && shopItems[i].damageValuesUnit.gameObject.activeSelf && balanceIds.Length > i)
                {
                    int currentId = balanceIds[i] + scrollItems[i].upgradeLevel;
                    var nextUpgradeLevelId = scrollItems[i].upgradeLevel + 1;
                    int currentDamage;
                    //if (i != 4)
                    //    Debug.Log(i + "  " + currentId + " " + scrollParameters[currentId].name);

                    if (i == 4)
                    {
                        currentDamage = (int)enemyParameters[currentId].dpStrike;
                    }
                    else if (i == 5)
                    {
                        currentDamage = (int)scrollParameters[currentId].abilityEffect;
                    }
                    else
                    {
                        currentDamage = ((int)scrollParameters[currentId].maxDamage + (int)scrollParameters[currentId].minDamage) / 2;
                    }
                    shopItems[i].damageValuesUnit.currentValueText.text = currentDamage.ToString();
                    if (nextUpgradeLevelId < ScrollItem.MaxUpgradeLevelIndex + 1)
                    {
                        int addDamage;
                        if (i == 4)
                        {
                            addDamage = (int)enemyParameters[currentId + 1].dpStrike - currentDamage;
                        }
                        else if (i == 5)
                        {
                            addDamage = (int)scrollParameters[currentId + 1].abilityEffect - currentDamage;
                        }
                        else
                        {
                            addDamage = ((int)scrollParameters[currentId + 1].maxDamage + (int)scrollParameters[currentId + 1].minDamage) / 2 - currentDamage;
                        }
                        shopItems[i].damageValuesUnit.additionalValueText.text = "+" + addDamage.ToString();
                        shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(true);
                    }
                    else
                    {
                        shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(false);
                    }
                }

                if (shopItems[i].rangeValuesUnit != null && shopItems[i].rangeValuesUnit.gameObject.activeSelf && balanceIds.Length > i)
                {
                    int currentId = balanceIds[i] + scrollItems[i].upgradeLevel;
                    var nextUpgradeLevelId = scrollItems[i].upgradeLevel + 1;
                    int currentDamage = (int)enemyParameters[currentId].health;
                    if (i == 4)
                    {
                        currentDamage = (int)enemyParameters[currentId].health;
                    }
                    shopItems[i].rangeValuesUnit.currentValueText.text = currentDamage.ToString();
                    if (nextUpgradeLevelId < ScrollItem.MaxUpgradeLevelIndex + 1)
                    {
                        int addDamage = 0;
                        if (i == 4)
                        {
                            addDamage = (int)enemyParameters[currentId + 1].health - currentDamage;
                        }
                        else
                        {
                            addDamage = ((int)scrollParameters[currentId + 1].maxDamage + (int)scrollParameters[currentId + 1].minDamage) / 2 - currentDamage;
                        }
                        shopItems[i].rangeValuesUnit.additionalValueText.text = "+" + addDamage.ToString();
                        shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(true);
                    }
                    else
                    {
                        shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void ShowDescItem(int id, bool _on)
    {
        if (shopItems[id].damageValuesUnit != null)
        {
            shopItems[id].damageValuesUnit.transform.parent.gameObject.SetActive(_on);
        }
    }
}