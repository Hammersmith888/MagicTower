using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Data.SqlTypes;

/// <summary>
/// Скрипт отвечает за настройку зелей в магазине:
/// 1) Загружает сохранные зелья или создает сохранение по умолчанию
/// 2) Выставляет количество имеющихся зелей
/// 3) Покупка, прокачка зелей
/// 4) Информационное окно
/// </summary>

// Item для свитков в магазине
[System.Serializable]
public class PotionItem : BaseConsumableShopItem
{
    public const int PotionsNumber = 4;
}

[System.Serializable]
public class Potion_Items : ArrayInClassWrapper<PotionItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return PotionItem.PotionsNumber;
        }
    }

    public Potion_Items() : base(PotionItem.PotionsNumber)
    {
    }

    public Potion_Items(int capacity) : base(capacity)
    {
    }
}

public class ShopPotionItemSettings : BaseShopItemSettings
{
    private Potion_Items potionItems = new Potion_Items(PotionItem.PotionsNumber);
    public GameObject info; // Дополнительный экран информации
    public GameObject infos; // Родительский объект для информации о зельях

    private const byte MAX_POTION_UPGRADE = 7;

    override protected BaseUpgradableShopItem GetItemByShopIndex(int itemNumber)
    {
        return potionItems[itemNumber];
    }

    override protected BaseUpgradableShopItem[] GetAllItems()
    {
        return potionItems.getInnerArray;
    }

    public static ShopPotionItemSettings instance;

    override protected void Awake()
    {
        base.Awake();

        // Загружаем сохранения зелий
        LoadPotionSaves();

        RefreshItemsCounts();

        // Устанавливаем полученные сохранения в магазине
        //Ну: shopItemsObjects.Length == potionItems.Length, если нет у Вас проблемка
        ShowActualPotValues();

        instance = this;
    }

    override protected void SaveItemsData()
    {
        PPSerialization.Save(EPrefsKeys.Potions, potionItems);
    }

    public void RefreshItemsCounts()
    {
        for (int i = 0; i < shopItemsObjects.Length; i++)
        {
            shopItemsObjects[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = potionItems[i].count.ToString(); // Устанавливаем количество купленных зелий

            for (int j = 0; j <= potionItems[i].upgradeLevel; j++) // Отображаем уровень Upgrade заклинания
                shopItemsObjects[i].transform.GetChild(5).GetChild(j).gameObject.SetActive(true);


            // Отобразить необходимое количество монет для следующего уровня upgrade, если он существует, иначе выводим сообщение на кнопке, что максимальный уровень достигнут
            if (potionItems[i].upgradeLevel < MAX_POTION_UPGRADE)
            {
                shopItemsObjects[i].transform.GetChild(6).GetChild(2).GetComponent<Text>().text = potionItems[i].upgradeCoins[potionItems[i].upgradeLevel].ToString();
            }
            else
            {
                Transform upgradeBtn = shopItemsObjects[i].transform.GetChild(6);
                upgradeBtn.GetComponent<Button>().interactable = false; // Выключаем интерактивность кнопки Upgrade

                foreach (Transform child in upgradeBtn) // Выключаем все описания на кнопке Upgrade
                {
                    child.gameObject.SetActive(false);
                }
                upgradeBtn.GetChild(4).gameObject.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade
            }
        }

    }

    public void ClickOpen()
    {
        //var r = GetComponent<RectTransform>();
        //r.anchoredPosition = new Vector2(-2000f,r.anchoredPosition.y);
        LoadPotionSaves();
        RefreshItemsCounts();
        SpecialOffer.instance.Open();
       // StartCoroutine(_ClickOpen()) ;
    }

    public void Open()
    {
        LoadPotionSaves();
        RefreshItemsCounts();
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
            if (potionItems[i].upgradeLevel < potionItems[i].upgradeCoins.Length)
                shopItemsObjects[i].transform.GetChild(6).GetChild(0).gameObject.SetActive(potionItems[i].upgradeCoins[potionItems[i].upgradeLevel] > playerCoins);

            //если цена  выше чем общее количество золота у игрока, то показать серую панель
            shopItemsObjects[i].transform.GetChild(4).GetChild(0).gameObject.SetActive(potionItems[i].cost > playerCoins);
        }
    }

    private void LoadPotionSaves()
    {
        for (int i = 0; i < potionItems.Length; i++)
            potionItems[i] = new PotionItem();

        potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);

        // Установить необходимое количество монет для разблокировки зелий и upgrade
        SetPotionCoinsForUpgrade();
    }

    public void UpgradePotion(int _potionNumber)
    {
        UpgradeItem(_potionNumber);
        ShowActualPotValues();
    }

    override protected void OnItemUpgraded(int upgradedItem)
    {
        base.OnItemUpgraded(upgradedItem);
        Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.POTION_UPGRADED, upgradedItem, GetItemByShopIndex(upgradedItem).upgradeLevel);
    }

    public void BuyPotion(int _potionNumber)
    {
        Debug.Log($"potion: {potionItems[_potionNumber].cost}");
        if (coinsManager.BuySomething(potionItems[_potionNumber].cost))
        {
            int count = ++potionItems[_potionNumber].count;
            shopItemsObjects[_potionNumber].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = count.ToString(); // Изменяем количество зелий
            potionItems[_potionNumber].count = count; // Изменяем объект в массиве зелий и сохраняем

            CheckAvailableOfItems();
            PPSerialization.Save(EPrefsKeys.Potions, potionItems);
            SoundController.Instanse.PlayShopBuySFX();
            Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.POTION_BOUGHT, _potionNumber);
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

    public void CloseInfo(int _scrollNumber)
    {
        infos.transform.GetChild(_scrollNumber).gameObject.SetActive(false);
        info.SetActive(false);
    }

    private void SetPotionCoinsForUpgrade()
    {
        var scrollParameters = BalanceTables.Instance.PotionsParameters;

        int x = 0;
        int v = 0;
        for (int i = 0; i < potionItems.Length - 1; i++)
        {
            if (x < scrollParameters.Length)
            {
                potionItems[i].cost = scrollParameters[x].cost;
            }
            for (int z = 0; z < potionItems[i].upgradeCoins.Length; z++)
            {
                potionItems[i].upgradeCoins[z] = scrollParameters[v].upg_cost;
                potionItems[i].values[z] = scrollParameters[v].add_value;
                v++;
            }
            for (int z = 0; z < scrollParameters.Length / (potionItems.Length - 1); z++)
                x++;
        }
    }

    private void ShowActualPotValues()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] != null)
            {
                if (true)
                {
                    float currentPotionEffect = 0f;
                    float effectBustValueAfterUpgrade = 0;
                    currentPotionEffect = potionItems[i].values[(int)potionItems[i].upgradeLevel];
                    if (potionItems[i].upgradeLevel < MAX_POTION_UPGRADE)
                        effectBustValueAfterUpgrade = potionItems[i].values[(int)potionItems[i].upgradeLevel + 1] - currentPotionEffect;
                    shopItems[i].damageValuesUnit.currentValueText.text = currentPotionEffect.ToString();
                    shopItems[i].rangeValuesUnit.currentValueText.text = currentPotionEffect.ToString();
                    if (potionItems[i].upgradeLevel < MAX_POTION_UPGRADE)
                    {
                        shopItems[i].damageValuesUnit.additionalValueText.text = "+" + effectBustValueAfterUpgrade.ToString();
                        shopItems[i].rangeValuesUnit.additionalValueText.text = "+" + effectBustValueAfterUpgrade.ToString();
                    }
                    else
                    {
                        shopItems[i].damageValuesUnit.additionalValueText.gameObject.SetActive(false);
                        shopItems[i].rangeValuesUnit.additionalValueText.gameObject.SetActive(false);
                    }
                }

            }
        }
    }
}
