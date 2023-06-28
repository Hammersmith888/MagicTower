using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Скрипт отвечает за настройку бонусов в магазине:
/// 1) Загружает сохранные бонусы или создает сохранение по умолчанию
/// 2) Покупка бонусов
/// 3) Скрипт рассчитан на то что существует два скина мага, при добавлении новых необходимо изменять числа (или сделать более универсально)
/// </summary>

// Item для свитков в магазине
[System.Serializable]
public class BonusItem
{
    public const int  ItemsNumber = 2;

    public ObfuscatedInt cost;
    public bool bought, active; // Для типа мага (куплен, активен)
}

[System.Serializable]
public class Bonus_Items : ArrayInClassWrapper<BonusItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return BonusItem.ItemsNumber;
        }
    }

    public Bonus_Items() : this(BonusItem.ItemsNumber)
    {
    }

    public Bonus_Items(int capacity) : base(capacity)
    {
        ValidateInnerArraySize();
    }
}

public class ShopBonusItemSettings : MonoBehaviour
{

    private Bonus_Items bonusItems = new Bonus_Items(BonusItem.ItemsNumber);

    public GameObject shopController;
    public GameObject[] bonusObj; // Родительские объекты бонусов
    public GameObject info; // Дополнительный экран информации
    public GameObject infos; // Родительский объект для информации о бонусах
    

    [SerializeField]
    private GameObject[] usingMarks = new GameObject[BonusItem.ItemsNumber]; // Родительский объект переключателя (галочки) активности мага

    private CoinsManager coinsManager;
    private UIShop uiShop;

    private void Awake()
    {
        // Получаем скрипты из объект ShopController
        coinsManager = CoinsManager.Instance;
        uiShop = shopController.GetComponent<UIShop>();

        // Загрузка сохранения бонусов
        LoadBonusSaves();

        // Настраиваем магов (куплены или нет, активны или нет)
        for (int i = 0; i < BonusItem.ItemsNumber; i++)
        {
            // Если скин мага куплен
            if (bonusItems[i].bought)
            {
                Transform buyBtn = bonusObj[i].transform.GetChild(4);
                buyBtn.GetComponent<Button>().interactable = false; // Выключить интерактивность кнопки
                foreach (Transform child in buyBtn) // Выключаем все описания на кнопке Upgrade
                    child.gameObject.SetActive(false);
                buyBtn.GetChild(4).gameObject.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade         
                usingMarks[i].SetActive(true); // Показать родительский объект переключателя справа

                // Если скин мага применен в данный момент
                if (bonusItems[i].active)
                {
                    usingMarks[i].transform.GetChild(0).gameObject.SetActive(true); // Включаем переключатель справа
                }
                // открыем робу если в старой версии были куплены робы
                ShopWearItemSettings.instance.FuncUnlockWear(10);
            }
            //Debug.Log(bonusItems[i].cost + " | " + bonusItems[i].bought, gameObject);
        }
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

    private void LoadBonusSaves()
    {
        for (int i = 0; i < bonusItems.Length; i++)
            bonusItems[i] = new BonusItem();

        bonusItems = PPSerialization.Load<Bonus_Items>(EPrefsKeys.Bonuses.ToString());

        // Установить необходимое количество монет для покупки бонусов
        SetBonusCoinsForBuy();
    }


    private void SetBonusCoinsForBuy()
    {
        bonusItems[0].cost = 45000;
        bonusItems[1].cost = 25000;
    }

    /// <summary>
    /// Метод который проверяет достаточно средств для покупки, если нет, то он показывает серую панель
    /// </summary>
    private void CheckAvailableOfItems()
    {
        int playerCoins = coinsManager.Coins;
        //для всех объектов делаем проверку
        for (int i = 0; i < BonusItem.ItemsNumber; i++)
        {
            //если цена  выше чем общее количество золота у игрока, то показать серую панель
            bonusObj[i].transform.GetChild(4).GetChild(0).gameObject.SetActive(bonusItems[i].cost > playerCoins);
        }
        CheckVideoAdsAble();
    }

    public void CheckVideoAdsAble()
    {
        if (PlayerPrefs.GetInt("VideoViewsLeft1") == 0)
        {
            bonusObj[bonusObj.Length - 1].SetActive(false);
        }
    }

    public void BuyBonus(int _bonusNumber)
    {
        // Проверяем, достаточно ли монет?
        int unlockCoins = bonusItems[_bonusNumber].cost;
        if (coinsManager.BuySomething(unlockCoins))
        {
            // Если купили скин мага
            if (_bonusNumber == 0 || _bonusNumber == 1)
            {
                Transform buyBtn = bonusObj[_bonusNumber].transform.GetChild(4);
                buyBtn.GetComponent<Button>().interactable = false; // Выключить интерактивность кнопки
                foreach (Transform child in buyBtn) // Выключаем все описания на кнопке Upgrade
                    child.gameObject.SetActive(false);
                buyBtn.GetChild(4).gameObject.SetActive(true); // Включаем сообщение на кнопке, что достингут максимальный уровень Upgrade         
                bonusItems[_bonusNumber].bought = true;

                ChangeMageSkin(_bonusNumber);
            }
            Core.ShopGameEvents.Instance.LaunchEvent(Core.EShopGameEvent.BONUS_BOUGHT, _bonusNumber);
            CheckAvailableOfItems();
            PPSerialization.Save(EPrefsKeys.Bonuses.ToString(), bonusItems, true, true);
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


    // Смена активного скина мага
    public void ChangeMageSkin(int _activeNumber)
    {
        // Если нажимаем на переключатель скина мага, который уже и так активен, то ничего не делаем
        if (bonusItems[_activeNumber].active)
            return;

        for (int i = 0; i < BonusItem.ItemsNumber; i++)
        {
            bonusItems[i].active = _activeNumber == i;
            if (bonusItems[i].bought)
            {
                usingMarks[i].SetActive(true);
                usingMarks[i].transform.GetChild(0).gameObject.SetActive(bonusItems[i].active); // Переключаем переключатель справа
            }
        }

        CheckAvailableOfItems();
        PPSerialization.Save(EPrefsKeys.Bonuses.ToString(), bonusItems, true, true);
    }
}
