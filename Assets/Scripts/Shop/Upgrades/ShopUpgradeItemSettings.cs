using Animations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UpgradeItemClass = UpgradeItem;

/// <summary>
/// Скрипт отвечает за настройку улучшений в магазине:
/// 1) Загружает сохранные улучшений или создает сохранение по умолчанию
/// 2) Прокачка улучшений
/// 3) Информационное окно
/// </summary>
public class ShopUpgradeItemSettings : BaseShopItemSettings, IEnableObjectCallback
{
    [SerializeField]

    private RectTransform NewlyOpenedScrollHighlight;

    private Upgrade_Items upgradeItems = new Upgrade_Items(UpgradeItemClass.ItemsNumber);

    public GameObject info; // Дополнительный экран информации
    public GameObject infos; // Родительский объект для информации о свитках

    override protected BaseUpgradableShopItem GetItemByShopIndex(int itemNumber)
    {
        return upgradeItems[itemNumber];
    }

    override protected BaseUpgradableShopItem[] GetAllItems()
    {
        return upgradeItems.getInnerArray;
    }

    protected override int GetMaxUpgradeLvlIndex
    {
        get
        {
            return UpgradeItemClass.MaxUpgradeLevelIndex + 1;
        }
    }

    private static UpgradeItemClass.UpgradeType NewlyOpenedUpgradeType = UpgradeItemClass.UpgradeType.None;

    public static UpgradeItemClass.UpgradeType GetUpgradeTypeForHighlighting
    {
        get
        {
            return NewlyOpenedUpgradeType;
        }
    }

    private static bool isShowStaffPanelWhenShopOpen = false;

    // Eugene show shop staff after levels
    public static bool IsShowStaffPanelWhenShopOpen
    {
        get { return isShowStaffPanelWhenShopOpen; }
        set { isShowStaffPanelWhenShopOpen = value; }
    }

    public static bool IsAnyUpgradeNeedHighlighting
    {
        get
        {
            return NewlyOpenedUpgradeType != UpgradeItemClass.UpgradeType.None;
        }
    }

    public static void SetUpgradeForHighlighting(UpgradeItemClass.UpgradeType upgradeType)
    {
        if (upgradeType != UpgradeItemClass.UpgradeType.None)
        {
            NewlyOpenedUpgradeType = upgradeType;
            Debug.Log($"SetUpgradeForHighlighting: {upgradeType}");
        }
    }

    public static ShopUpgradeItemSettings Current
    {
        get; private set;
    }

    public Vector2 GetUpgradeItemUILocalPosition(UpgradeItemClass.UpgradeType upgradeType)
    {
        int index = (int)upgradeType;
        index--;
        return shopItemsObjects[index].transform.localPosition;
    }

    public Transform GetUpgradeItemUILocalTransform(UpgradeItemClass.UpgradeType upgradeType)
    {
        int index = (int)upgradeType;
        index--;
        return shopItemsObjects[index].transform;
    }


    [SerializeField]
    Text count;

    [SerializeField]
    Transform parent;

    int countOpen;

    public void HighlightLastOpenedScroll()
    {
        if (IsAnyUpgradeNeedHighlighting)
        {
            var shopItemIndex = (int)NewlyOpenedUpgradeType - 1;
            NewlyOpenedScrollHighlight.SetParent(shopItemsObjects[shopItemIndex].transform);
            NewlyOpenedScrollHighlight.anchoredPosition3D = new Vector3(0f, 0f, 0f);
            NewlyOpenedScrollHighlight.SetAsLastSibling();
            NewlyOpenedScrollHighlight.gameObject.SetActive(true);
            NewlyOpenedUpgradeType = UpgradeItemClass.UpgradeType.None;
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

    override protected void Awake()
    {
        base.Awake();
        Current = this;
        parent.gameObject.GetComponent<EnableObject>().script = this;
        LoadUpgradeSaves();
        UpdateCount();
    }

    public void OnStart()
    {
        ReloadUI();
        countOpen++;
    }

    public void ReloadUI()
    {
        LoadUpgradeSaves();
        // Устанавливаем полученные сохранения в магазине
        for (int i = 0; i < upgradeItems.Length; i++)
        {
            // Если заклинание разблокировано
            if (upgradeItems[i].unlock)
            {
                if (!upgradeItems[i].effectUnlock)
                    StartCoroutine(_Unlock(i));
                else
                    Unlock(i);
            }
            else
            {
                // Отобразить необходимое количество монет для разблокировки улучшения
                Text textComponent = shopItemsObjects[i].transform.GetChild(7).GetChild(1).GetComponent<Text>();
                if (textComponent == null)
                {
                    textComponent = shopItemsObjects[i].transform.GetChild(7).Find("Value").GetComponent<Text>();
                }
                if (textComponent != null)
                {
                    textComponent.text = upgradeItems[i].unlockCoins.ToString();
                }
                // Отобразить необходимое количество монет для первого уровня upgrade
                int upgradePrice = upgradeItems[i].upgradeCoins[0];
                if (upgradePrice > 0)
                {
                    shopItems[i].priceLabel.text = upgradePrice.ToString();
                }
                else
                {
                    shopItems[i].priceLabel.text = "";
                    //LocalTextLoc localizator = shopItems[i].upgradeTextObj.GetComponent<LocalTextLoc>();
                    //localizator.enabled = false;
                    //localizator.SetText("t_0271", true);
                }
            }
            shopItems[i].unlockCoins = upgradeItems[i].unlockCoins;
        }

        ShowActualUpgradeValues();
    }

    public void Open()
    {
        countOpen++;
        if (countOpen > 1)
        {
            for (int i = 0; i < upgradeItems.Length; i++)
            {
                if (upgradeItems[i].unlock)
                {

                    upgradeItems[i].effectUnlock = true;
                    PPSerialization.Save<Upgrade_Items>(EPrefsKeys.Upgrades, upgradeItems);
                    if (shopItemsObjects[i].GetComponent<Animator>() != null)
                    {
                        if (upgradeItems[i].unlock && upgradeItems[i].effectUnlock)
                        {
                            Unlock(i);
                            Destroy(shopItemsObjects[i].GetComponent<Animator>());
                            var c = shopItemsObjects[i].GetComponentsInChildren<CanvasGroup>();
                            foreach (var x in c)
                                Destroy(x);
                            var v = shopItemsObjects[i].GetComponentInChildren<UIImageColorHolderComponent>();
                            if (v != null)
                                Destroy(v.gameObject);
                        }
                    }
                    if(i == 1)
                    {
                        shopItemsObjects[i].transform.Find("MaskHealth").GetComponent<Animator>().enabled = false;
                        var r = shopItemsObjects[i].transform.Find("MaskHealth").transform.Find("HealthBackground").transform.Find("HealthValue").GetComponent<RectTransform>();
                        r.offsetMax = new Vector2(-59.36f, r.offsetMax.y);
                    }
                }
            }
        }
    }

    IEnumerator _Unlock(int i)
    {
        yield return new WaitForSeconds(0.2f);
        if (i == 0 && upgradeItems[0].upgradeLevel == 0)
            UpgradeUpgrade(0);
        shopItemsObjects[i].GetComponent<Animator>().enabled = true;
        if (shopItems[i].useButton != null)
        {
            shopItems[i].useButton.transform.parent.gameObject.SetActive(true);
            shopItems[i].useButton.gameObject.SetActive(upgradeItems[i]._active);
        }
        UpdateInfo(i);
        //yield return new WaitForSeconds(1f);
        //Unlock(i);
        upgradeItems[i].effectUnlock = true;
        PPSerialization.Save<Upgrade_Items>(EPrefsKeys.Upgrades, upgradeItems);
        yield return new WaitForSeconds(6f);
        var anim = shopItemsObjects[i].GetComponent<Animator>();
        if (anim != null)
            anim.enabled = false;
        Unlock(i);
    }

    void Unlock(int i)
    {
        shopItemsObjects[i].transform.GetChild(1).gameObject.SetActive(false); // Убираем замок
        shopItemsObjects[i].transform.GetChild(4).GetChild(0).gameObject.SetActive(false); // Убираем сообщение о том, когда будет доступно данное улучшение
        shopItemsObjects[i].transform.GetChild(4).GetChild(1).gameObject.SetActive(true); // Отображаем сообщение о том, что улучшение всегда используется
        shopItemsObjects[i].transform.GetChild(5).gameObject.SetActive(true); // Отображаем кнопку Upgrade
        shopItemsObjects[i].transform.GetChild(6).gameObject.SetActive(true); // Отображаем уровень Upgrade
        shopItemsObjects[i].transform.GetChild(7).gameObject.SetActive(false); // Выключаем кнопку Unlock
        var obj = shopItemsObjects[i].gameObject.GetComponent<ShopItem>();
        obj.UpdateIcon();
        obj.spellLock.Init(true);

        if (shopItems[i].useButton != null)
        {
            shopItems[i].useButton.transform.parent.gameObject.SetActive(true);
            shopItems[i].useButton.gameObject.SetActive(upgradeItems[i]._active);
        }

        UpdateInfo(i);
    }

    void UpdateInfo(int i)
    {
        for (int j = 0; j < upgradeItems[i].upgradeCoins.Length; j++) // Отображаем уровень Upgrade заклинания
        {
            shopItemsObjects[i].transform.GetChild(6).GetChild(j).gameObject.SetActive(j < upgradeItems[i].upgradeLevel);
        }

        // Отобразить необходимое количество монет для следующего уровня upgrade, если он существует, иначе выводим сообщение на кнопке, что максимальный уровень достигнут
        if (upgradeItems[i].upgradeLevel < GetMaxUpgradeLvlIndex)
        {
            int upgradePrice = upgradeItems[i].upgradeCoins[upgradeItems[i].upgradeLevel];
            if (upgradePrice > 0)
            {
                shopItems[i].priceLabel.text = upgradePrice.ToString();
                shopItems[i].upgradeTextObj.gameObject.ToggleComponent<LocalTextLoc>(true);
            }
            else
            {
                shopItems[i].priceLabel.text = "";
                //LocalTextLoc localizator = shopItems[i].upgradeTextObj.GetComponent<LocalTextLoc>();
                //localizator.enabled = false;
                //localizator.SetText("t_0271", true);
            }
        }
        else
        {
            Transform upgradeBtn = shopItems[i].upgradeBtn.transform;
            shopItems[i].upgradeBtn.interactable = false; // Выключаем интерактивность кнопки Upgrade
            foreach (Transform child in upgradeBtn) // Выключаем все описания на кнопке Upgrade
            {
                child.gameObject.SetActive(false);
            }

            shopItems[i].maxUpgradeLabel.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade
        }
    }


    private void LoadUpgradeSaves()
    {
        upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        if (upgradeItems == null || upgradeItems.getInnerArray.IsNullOrEmpty())
        {
            upgradeItems = new Upgrade_Items();
        }
        else
        {
        }
        // Установить необходимое количество монет для разблокировки заклинаний и upgrade
        SetUpgradeCoinsForUnlock();
        SetUpgradeCoinsForUpgrade();
    }

    protected override void OnItemUnlocked(int itemNumber)
    {
        base.OnItemUnlocked(itemNumber);
        upgradeItems[itemNumber].unlock = true; // Изменяем объект в массиве и сохраняем
        upgradeItems[itemNumber].upgradeLevel = 0; // Изменяем объект в массиве и сохраняем
    }

    void UpdateCount()
    {
        var countUnlock = 0;
        for (int i = 0; i < upgradeItems.Length; i++)
        {
            // Если заклинание разблокировано
            if (upgradeItems[i].unlock)
                countUnlock++;
        }
        count.text = countUnlock + "/" + upgradeItems.Length;
    }

    override protected void UpdateProgressUI(int itemNumber, int upgradeLevel)
    {
        base.UpdateProgressUI(itemNumber, upgradeLevel - 1);
    }

    public void UnlockUpgrade(int shopUpgradeIndex)
    {
        if (upgradeItems[shopUpgradeIndex].unlock)
            return;
        // Проверяем, достаточно ли монет?
        int unlockCoins = upgradeItems[shopUpgradeIndex].unlockCoins;
        if (coinsManager.BuySomething(unlockCoins))
        {
            if (shopUpgradeIndex == 1)
                Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.SrongerBetter, 1);
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.UpgradeMaster, 1);
            Achievement.AchievementController.Save();
            StartCoroutine(_Unloc(shopUpgradeIndex));
        }
        else
            uiShop.OpenBuyCoins();
    }

    IEnumerator _Unloc(int shopUpgradeIndex)
    {
        var item = shopItemsObjects[shopUpgradeIndex].GetComponent<ShopItem>();
        item.StartCoroutine(item.spellLock.UnlockText());

        shopItemsObjects[shopUpgradeIndex].gameObject.GetComponent<Animator>().enabled = true;
        var upgradeItem = upgradeItems[shopUpgradeIndex];
        upgradeItem.unlock = true; // Изменяем объект в массиве и сохраняем
        upgradeItem.upgradeLevel = 0; // Изменяем объект в массиве и сохраняем
       
        yield return new WaitForSecondsRealtime(1f);
      
        shopItemsObjects[shopUpgradeIndex].transform.GetChild(1).gameObject.SetActive(false); // Убираем замок
        //shopItemsObjects[shopUpgradeIndex].transform.GetChild(4).GetChild(0).gameObject.SetActive(false); // Убираем сообщение о том, когда будет доступно данное улучшение
        shopItemsObjects[shopUpgradeIndex].transform.GetChild(4).GetChild(1).gameObject.SetActive(true); // Отображаем сообщение о том, что улучшение всегда используется
        shopItemsObjects[shopUpgradeIndex].transform.GetChild(5).gameObject.SetActive(true); // Отображаем кнопку Upgrade
        shopItemsObjects[shopUpgradeIndex].transform.GetChild(6).gameObject.SetActive(true); // Отображаем уровень Upgrade
        shopItemsObjects[shopUpgradeIndex].transform.GetChild(7).gameObject.SetActive(false); // Выключаем кнопку Unlock
        //shopItemsObjects[shopUpgradeIndex].gameObject.GetComponent<ShopItem>().UpdateIcon();

      

        CheckAvailableOfItems();

        PPSerialization.Save(EPrefsKeys.Upgrades, upgradeItems);

        for (int j = 0; j < upgradeItem.upgradeCoins.Length; j++) // Отображаем уровень Upgrade заклинания
        {
            shopItemsObjects[shopUpgradeIndex].transform.GetChild(6).GetChild(j).gameObject.SetActive(j < upgradeItem.upgradeLevel);
        }
        ShowActualUpgradeValues();
        UpdateCount();

        upgradeItems[shopUpgradeIndex].effectUnlock = true;
        PPSerialization.Save<Upgrade_Items>(EPrefsKeys.Upgrades, upgradeItems);
        yield return new WaitForSecondsRealtime(4f);
        if(shopItemsObjects[shopUpgradeIndex].gameObject.GetComponent<Animator>() != null)
        shopItemsObjects[shopUpgradeIndex].gameObject.GetComponent<Animator>().enabled = false;
    }



    public void UpgradeUpgrade(int shopUpgradeIndex)
    {
        UpgradeItem(shopUpgradeIndex);
        //SoundController.Instanse.upgradeSound.Play(44100);
        if (shopUpgradeIndex != 1)
            ShowActualUpgradeValues();
        ActualValues(GetUpgradeValues());
    }

    override protected void OnItemUpgraded(int shopUpgradeIndex)
    {
        if (upgradeItems[shopUpgradeIndex].upgradeLevel < GetMaxUpgradeLvlIndex)
        {
            shopItems[shopUpgradeIndex].upgradeTextObj.gameObject.ToggleComponent<LocalTextLoc>(true);
        }
        if (shopUpgradeIndex == 1) // ограждение
        {
        }
        base.OnItemUpgraded(shopUpgradeIndex);
    }

    override protected void SaveItemsData()
    {
        PPSerialization.Save(EPrefsKeys.Upgrades, upgradeItems);
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
            if (upgradeItems[i].upgradeLevel < upgradeItems[i].upgradeCoins.Length)
            {
                var canNotBeUpgraded = upgradeItems[i].upgradeCoins[upgradeItems[i].upgradeLevel] > playerCoins;
                try
                {
                    shopItemsObjects[i].transform.GetChild(5).GetChild(0).gameObject.SetActive(canNotBeUpgraded);
                }
                catch { }
            }
        }
    }

    public void OpenInfo(int scrollNumber)
    {
        info.SetActive(true);
        infos.transform.GetChild(scrollNumber).gameObject.SetActive(true);
        if (scrollNumber == 0)
        {
            infos.transform.GetChild(scrollNumber).transform.GetChild(2).gameObject.GetComponent<Text>().text = infos.transform.GetChild(scrollNumber).transform.GetChild(2).gameObject.GetComponent<Text>().text.Replace("*", value);
        }

        if (Tutorial_2.IsActive && Tutorial_2.Instance.isOldGameVersion)
        {
            Tutorial_2.Instance.infoCheck = true;
        }
    }

    public void CloseInfo(int scrollNumber)
    {
        infos.transform.GetChild(scrollNumber).gameObject.SetActive(false);
        info.SetActive(false);
    }

    private void SetUpgradeCoinsForUnlock()
    {
        //upgradeItems[0].unlockCoins = 2500;
        //upgradeItems[1].unlockCoins = 5000;
        //upgradeItems[2].unlockCoins = 10000;
        //upgradeItems[3].unlockCoins = 10000;
        //upgradeItems[4].unlockCoins = 10000;
    }

    private void SetUpgradeCoinsForUpgrade()
    {

        var scrollParameters = BalanceTables.Instance.CharacterUpgrades;

        int x = 0;
        int v = 0;
        for (int i = 0; i < upgradeItems.Length; i++)
        {
            if (x < scrollParameters.Length)
            {
                //UnityEngine.Debug.Log($"scrollItems: {scrollParameters.Length}, x: {x}");
                upgradeItems[i].unlockCoins = scrollParameters[x].cost_open;
            }
            for (int z = 0; z < upgradeItems[i].upgradeCoins.Length; z++)
            {
                //UnityEngine.Debug.Log($"z: {z}, name: { scrollParameters[v].Name}, count: {scrollParameters[v].upg_cost}");
                upgradeItems[i].upgradeCoins[z] = scrollParameters[v].upg_cost;
                v++;
            }
            for (int z = 0; z < scrollParameters.Length / upgradeItems.Length; z++)
                x++;
        }
    }

    string value;

    private void ShowActualUpgradeValues()
    {
        var balanceUpgradeId = MyGSFU.UpgradesBalanceIdsMap;
        var upgradesBalanceData = BalanceTables.Instance.CharacterUpgrades;
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] == null)
            {
                continue;
            }

            if (shopItems[i].damageValuesUnit != null && shopItems[i].damageValuesUnit.gameObject.activeSelf && balanceUpgradeId.Length > i)
            {
                var upgradeLevelOffset = upgradeItems[i].upgradeLevel;
                if (upgradeLevelOffset > 0)
                {
                    upgradeLevelOffset--;
                }
                int currentId = balanceUpgradeId[i] + upgradeLevelOffset;
                //Debug.Log(i + "  " + currentId + " " + upgradesBalanceData[currentId].Name);
                var nextUpgradeLvlID = currentId + 1;
                int currentValue = CountUpgradeValue(i, balanceUpgradeId[i], upgradeItems[i].upgradeLevel);

                if (i > 1)
                {
                    currentValue = (int)upgradesBalanceData[currentId].Value;
                }

                if(i == 0)
                    value = (currentValue + PlayerController.DEFAULT_HEALTH_VALUE).ToString();
                int nv = 0;
                if (upgradeItems[i].upgradeLevel + 1 <= GetMaxUpgradeLvlIndex)
                {
                    shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(true);
                    int addValue = 0;
                    if (i > 1)
                    {
                        addValue = (int)upgradesBalanceData[nextUpgradeLvlID].Value - currentValue;
                        if(i == 2 && upgradeItems[i].upgradeLevel == 0)
                        {
                            currentValue -= addValue;
                        }
                        //Debug.Log($"addValue: currentValue {currentValue}, (int)upgradesBalanceData[nextUpgradeLvlID].Value: {(int)upgradesBalanceData[nextUpgradeLvlID].Value}");
                    }
                    else
                    {
                        addValue = CountUpgradeValue(i, balanceUpgradeId[i], upgradeItems[i].upgradeLevel + 1) - currentValue;
                    }
                    nv = addValue;
                    shopItems[i].damageValuesUnit.additionalValueText.text = "+" + addValue.ToString();
                }
                else
                {
                    shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(false);
                }
                if (i == 0)
                    shopItems[i].damageValuesUnit.currentValueText.text = (currentValue + Mana.DEFAULT_MAX_MANA).ToString();
                else if (i == 1)
                {
                    shopItems[i].damageValuesUnit.currentValueText.text = (currentValue + PlayerController.DEFAULT_HEALTH_VALUE).ToString();
                    if (shopItems[i].textLife != null)
                    {
                        shopItems[i].textLife.text = (currentValue + PlayerController.DEFAULT_HEALTH_VALUE).ToString() + " / " + (currentValue + PlayerController.DEFAULT_HEALTH_VALUE + nv).ToString();
                        // PlayerController.ResizeHealth(shopItems[i].valueLife, shopItems[i].textLife.GetComponent<RectTransform>(), (currentValue + 100));
                    }
                }
                else
                {
                    //Debug.Log($"currentValue: {currentValue}");
                    shopItems[i].damageValuesUnit.currentValueText.text = currentValue.ToString();
                    if (shopItems[i].textLife != null)
                    {
                        shopItems[i].textLife.text = currentValue.ToString() + " / " + (currentValue + nv).ToString();
                        // PlayerController.ResizeHealth(shopItems[i].valueLife, shopItems[i].textLife.GetComponent<RectTransform>(), currentValue);
                    }
                }
            }


         

            if (shopItems[i].rangeValuesUnit != null && shopItems[i].rangeValuesUnit.gameObject.activeSelf && balanceUpgradeId.Length > i)
            {
                var upgradeLevelOffset = upgradeItems[i].upgradeLevel;
                if (upgradeLevelOffset > 0)
                {
                    upgradeLevelOffset--;
                }
                int currentId = balanceUpgradeId[i] + upgradeLevelOffset;
                var nextUpgradeLvlID = currentId + 1;
                int currentValue = (int)upgradesBalanceData[currentId].Radius;

                shopItems[i].rangeValuesUnit.currentValueText.text = currentValue.ToString();
                
                if (upgradeItems[i].upgradeLevel + 1 <= GetMaxUpgradeLvlIndex)
                {
                    shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(true);
                    int addValue = (int)upgradesBalanceData[nextUpgradeLvlID].Radius - currentValue;
                    shopItems[i].rangeValuesUnit.additionalValueText.text = "+" + addValue.ToString();
                }
                else
                {
                    shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(false);
                }
            }
        }
    }

    private Tuple<string,string> GetUpgradeValues()
    {
        var balanceUpgradeId = MyGSFU.UpgradesBalanceIdsMap;
        var upgradesBalanceData = BalanceTables.Instance.CharacterUpgrades;
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] == null)
            {
                continue;
            }

            if (shopItems[i].damageValuesUnit != null && shopItems[i].damageValuesUnit.gameObject.activeSelf && balanceUpgradeId.Length > i)
            {
                var upgradeLevelOffset = upgradeItems[i].upgradeLevel;
                if (upgradeLevelOffset > 0)
                {
                    upgradeLevelOffset--;
                }
                int currentId = balanceUpgradeId[i] + upgradeLevelOffset;
                //Debug.Log(i + "  " + currentId + " " + upgradesBalanceData[currentId].Name);
                var nextUpgradeLvlID = currentId + 1;
                int currentValue = CountUpgradeValue(i, balanceUpgradeId[i], upgradeItems[i].upgradeLevel);

                if (i > 1)
                {
                    currentValue = (int)upgradesBalanceData[currentId].Value;
                }

                int nv = 0;
                if (upgradeItems[i].upgradeLevel + 1 <= GetMaxUpgradeLvlIndex)
                {
                    shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(true);
                    int addValue = 0;
                    if (i > 1)
                    {
                        addValue = (int)upgradesBalanceData[nextUpgradeLvlID].Value - currentValue;
                    }
                    else
                    {
                        addValue = CountUpgradeValue(i, balanceUpgradeId[i], upgradeItems[i].upgradeLevel + 1) - currentValue;
                    }
                    nv = addValue;
                    shopItems[i].damageValuesUnit.additionalValueText.text = "+" + addValue.ToString();
                }
                else
                {
                    shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(false);
                }

                if (i <= 1)
                {
                    //shopItems[i].damageValuesUnit.currentValueText.text = (currentValue + 100).ToString();
                    if (shopItems[i].textLife != null)
                        return new Tuple<string,string> ((currentValue + PlayerController.DEFAULT_HEALTH_VALUE).ToString() + " / " + (currentValue + PlayerController.DEFAULT_HEALTH_VALUE + nv).ToString(), (currentValue + PlayerController.DEFAULT_HEALTH_VALUE).ToString());
                }
                else
                {
                    //shopItems[i].damageValuesUnit.currentValueText.text = currentValue.ToString();
                    return new Tuple<string, string>(currentValue.ToString() + " / " + (currentValue + nv).ToString(), currentValue.ToString());
                }
            }
        }
        return new Tuple<string, string>("", "");
    }

    private int CountUpgradeValue(int id, int balanceID, int upgradeLevel)
    {
        int to_return = 0;
        var upgradesBalanceData = BalanceTables.Instance.CharacterUpgrades;
        for (int i = 0; i < upgradeLevel; i++)
        {
            to_return += (int)upgradesBalanceData[balanceID + i].Value;
        }
        return to_return;
    }

    public void SetItemActive(int upgradeId)
    {
        //LoadUpgradeSaves();
        var _upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        shopItems[upgradeId].useButton.gameObject.SetActive(!shopItems[upgradeId].useButton.gameObject.activeSelf);
        _upgradeItems[upgradeId]._active = shopItems[upgradeId].useButton.gameObject.activeSelf;
        PPSerialization.Save(EPrefsKeys.Upgrades, _upgradeItems);
        //Debug.Log($"SetItemActive: {upgradeId}. active: {_upgradeItems[upgradeId]._active }");
    }
}
