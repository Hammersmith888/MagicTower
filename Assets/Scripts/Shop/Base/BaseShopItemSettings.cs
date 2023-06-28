using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShopItemSettings : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] shopItemsObjects; // Родительские объекты заклинаний TODO: remove this
    [SerializeField]
    protected ShopItem[] shopItems;
    [SerializeField]
    protected GameObject shopController;

    public CoinsManager  coinsManager;
    public UIShop        uiShop;

    public string values , health;
    public GameObject[] ShopItemsObjects
    {
        get
        {
            return shopItemsObjects;
        }
    }

    //protected T Items;

    virtual protected int GetMaxUpgradeLvlIndex
    {
        get
        {
            return 7;
        }
    }
//#if UNITY_EDITOR
//    [SerializeField]
//    private bool configurateShopItems;

//    private void OnDrawGizmosSelected()
//    {
//        if (configurateShopItems)
//        {
//            configurateShopItems = false;
//            if (shopItemsObjects.IsNullOrEmpty())
//            {
//                shopItemsObjects = new GameObject[transform.childCount];
//            }
//            shopItems = new ShopItem[shopItemsObjects.Length];
//            for (int i = 0; i < shopItems.Length; i++)
//            {
//                if (shopItemsObjects[i] == null)
//                {
//                    shopItemsObjects[i] = transform.GetChild(i).gameObject;
//                }
//                shopItems[i] = shopItemsObjects[i].GetComponent<ShopItem>();
//                if (shopItems[i] == null)
//                {
//                    shopItems[i] = shopItemsObjects[i].AddComponent<ShopItem>();
//                }
//                shopItems[i].CollectReferences_Editor();
//            }
//        }
//    }
//#endif

    virtual protected void Awake()
    {
        coinsManager = CoinsManager.Instance;
        uiShop = shopController.GetComponent<UIShop>();
    }

    virtual protected void Start()
    {
        CoinsManager.OnPlayerCoinsBalanceChanged += OnPlayerCoinsBalanceChanged;
        CheckAvailableOfItems();
    }

    private void OnDestroy()
    {
        CoinsManager.OnPlayerCoinsBalanceChanged -= OnPlayerCoinsBalanceChanged;
    }

    private void OnPlayerCoinsBalanceChanged(int coins)
    {
        CheckAvailableOfItems();
    }

    virtual protected BaseUpgradableShopItem GetItemByShopIndex(int shopItemIndex)
    {
        return null;
    }

    virtual protected BaseUpgradableShopItem[] GetAllItems()
    {
        return null;
    }

    protected void UnlockItem(int shopItemNumber)
    {
        // Проверяем, достаточно ли монет?
        shopItemsObjects[shopItemNumber].transform.GetChild(1).gameObject.SetActive(false); // Убираем замок
        //shopItemsObjects[shopItemNumber].transform.GetChild(4).gameObject.SetActive(false); // Выключаем сообщение, что свиток будет доступен на таком-то уровне
        shopItemsObjects[shopItemNumber].transform.GetChild(5).gameObject.SetActive(true); // Отображаем кнопку Buy
        shopItemsObjects[shopItemNumber].transform.GetChild(6).gameObject.SetActive(true); // Отображаем уровень Upgrade
        shopItemsObjects[shopItemNumber].transform.GetChild(7).gameObject.SetActive(true); // Отображаем кнопку Upgrade
        shopItemsObjects[shopItemNumber].transform.GetChild(8).gameObject.SetActive(false); // Выключаем кнопку Unlock
        //shopItemsObjects[shopItemNumber].gameObject.GetComponent<ShopItem>().UpdateIcon();
        OnItemUnlocked(shopItemNumber);
        CheckAvailableOfItems();
        SaveItemsData();
    }


    virtual protected void OnItemUnlocked(int itemNumber)
    {
    }

    virtual protected void UpdateProgressUI(int itemNumber, int upgradeLevel)
    {
        shopItemsObjects[itemNumber].transform.FindChildWithNameNonRecursive("Upgrade").GetChild(upgradeLevel).gameObject.SetActive(true); // Отображаем уровень Upgrade
        if(shopItems[itemNumber].textLife != null)
        {
            var h = PlayerController.HealthUpdate(upgradeLevel);
            Debug.Log($"health: {h}");
            var n = upgradeLevel < 7 ? PlayerController.HealthUpdate(upgradeLevel + 1) : 0;
            var _a = shopItems[itemNumber].paretnLife.transform.parent.gameObject.GetComponent<Animator>();
            _a.enabled = true;
            _a.Play("healthUpgrade", 0);
           // _a.SetTrigger("play");
            //Debug.Log("play fort");
            StartCoroutine(_Anim(itemNumber, h, n));
        }
    }

    

    IEnumerator _Anim(int itemNumber, int h, int n)
    {
        yield return new WaitForSecondsRealtime(1f);

        shopItems[itemNumber].textLife.text = values;
        shopItems[itemNumber].damageValuesUnit.currentValueText.text = health;
    }

    public void ActualValues(Tuple<string,string> v)
    {
        values = v.object1;
        health = v.object2;
    }

    public bool IsCanScroll(int shopItemIndex)
    {
        int unlockCoins = GetItemByShopIndex(shopItemIndex).unlockCoins;
        return coinsManager.BuySomething(unlockCoins);
    }

    public bool IsUnlockScroll(int shopItemIndex)
    {
        return GetItemByShopIndex(shopItemIndex).unlock;
    }

    protected void UpgradeItem(int shopItemIndex)
    {
        var upgradeableItem = GetItemByShopIndex(shopItemIndex);
        Debug.Log($"----------- UpgradeItem: {upgradeableItem.upgradeLevel}, GetMaxUpgradeLvlIndex: {GetMaxUpgradeLvlIndex} ");
        if (upgradeableItem.upgradeLevel < GetMaxUpgradeLvlIndex)
        {
            byte upgradeLevel = upgradeableItem.upgradeLevel; // Текущий уровень Upgrade

            // Проверяем, достаточно ли монет?
            int upgradeCoins = upgradeableItem.upgradeCoins[upgradeLevel];
            Debug.Log($"upgradeCoins: {upgradeCoins}, shopItemIndex: {shopItemIndex} ");
            if (coinsManager.BuySomething(upgradeCoins))
            {
                upgradeLevel = ++upgradeableItem.upgradeLevel; // Увеличиваем уровень Upgrade
                UpdateProgressUI(shopItemIndex, upgradeLevel);
                Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.UpgradeMaster, 1);
                Achievement.AchievementController.Save();
                if (upgradeLevel < GetMaxUpgradeLvlIndex) // Изменяем стоимость следующего уровня Upgrade, если он существует
                    shopItems[shopItemIndex].priceLabel.text = upgradeableItem.upgradeCoins[upgradeLevel].ToString();

                if (upgradeLevel == GetMaxUpgradeLvlIndex)
                {
                    shopItems[shopItemIndex].upgradeBtn.interactable = false;// Выключаем интерактивность кнопки Upgrade

                    Transform upgradeBtnTransf = shopItems[shopItemIndex].upgradeBtn.transform;
                    foreach (Transform child in upgradeBtnTransf) // Выключаем все описания на кнопке Upgrade
                    {
                        child.gameObject.SetActive(false);
                    }

                    shopItems[shopItemIndex].maxUpgradeLabel.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade
                }

                AnalyticsController.Instance.LogMyEvent("ShopUpgrade", new Dictionary<string, string>() {
                                        { upgradeableItem.ToString(), shopItems[shopItemIndex].name },
                                        { "update level", upgradeableItem.upgradeLevel.ToString() }
                                    });

                CheckAvailableOfItems();
                OnItemUpgraded(shopItemIndex);
                SaveItemsData();
            }
            else
            {
                uiShop.OpenBuyCoins(); // Открываем окно покупки монет
            }
        }
    }


    /// <summary>
    /// Метод который проверяет достаточно средств для покупки, если нет, то он показывает серую панель
    /// </summary>
    virtual protected void CheckAvailableOfItems(int playerCoins = -1)
    {
    }

    virtual protected void OnItemUpgraded(int upgradedItem)
    {
    }

    virtual protected void SaveItemsData()
    {

    }
}
