using UI;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public static event System.Action<int> OnPlayerCoinsBalanceChanged;

    public Text coinsValue;
    private int _coins;
    public int Coins
    {
        get
        {
            return SaveManager.GameProgress.Current.gold;
        }
        private set
        {
            _coins = value;
            if (_coins < 0)
            {
                _coins = 0;
            }
            coinsValue.text = _coins.ToString();
            SaveManager.GameProgress.Current.gold = _coins;
            SaveManager.GameProgress.Current.Save();
            GameMetaSave.SetData(SaveManager.GameProgress.Current.gold, SaveManager.GameProgress.Current.CompletedLevelsNumber);
            OnPlayerCoinsBalanceChanged.InvokeSafely(_coins);
        }
    }

    private static CoinsManager _instance;
    public static CoinsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoinsManager>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        // Загружаем сохранения количество золота
        UpdateCoinsInternalValueAndUI();
    }

    private void UpdateCoinsInternalValueAndUI()
    {
        _coins = Coins;
        if (coinsValue != null)
        {
            coinsValue.text = _coins.ToString();
        }
        Upd();
    }

    private void Upd()
    {
        var s = FindObjectsOfType<ShopItem>();
        foreach (var o in s)
            o.UpdateButtonsUnlock();
        if (ShopWearItemSettings.instance != null)
            ShopWearItemSettings.instance.UpdBtnExtract();
    }

    private void UpdateCoinsUIWithSound()
    {
        if (coinsValue != null)
        {
            coinsValue.text = _coins.ToString();
        }
        SoundController.Instanse.PlayBuyCoinsSFX();
        Upd();
    }

    // Методы для добавления/траты монет
    public void AddCoins(int coinsNumber, bool showMessageWindow = false, float updateUIDelay = 0)
    {
        if (updateUIDelay <= 0)
        {
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Treasurer, coinsNumber);
            Achievement.AchievementController.Save();
            SaveManager.GameProgress.Current.gold += coinsNumber;
            if (SaveManager.GameProgress.Current.gold < 0)
            {
                SaveManager.GameProgress.Current.gold = 0;
            }
            _coins = SaveManager.GameProgress.Current.gold;
            SaveManager.GameProgress.Current.Save();
            GameMetaSave.SetData(SaveManager.GameProgress.Current.gold, SaveManager.GameProgress.Current.CompletedLevelsNumber);
            OnPlayerCoinsBalanceChanged.InvokeSafely(_coins);
            UpdateCoinsUIWithSound();
        }
        else
        {
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Treasurer, coinsNumber);
            Achievement.AchievementController.Save();
            SaveManager.GameProgress.Current.gold += coinsNumber;
            _coins = SaveManager.GameProgress.Current.gold;
            GameMetaSave.SetData(SaveManager.GameProgress.Current.gold, SaveManager.GameProgress.Current.CompletedLevelsNumber);
            SaveManager.GameProgress.Current.Save();
            OnPlayerCoinsBalanceChanged.InvokeSafely(SaveManager.GameProgress.Current.gold);
            this.CallActionAfterDelayWithCoroutine(updateUIDelay, UpdateCoinsUIWithSound);
        }
        if (showMessageWindow && coinsNumber > 0)
        {
            //UI.MessageWindow.Show(UI.MessageWindow.EMessageWindowType.COINS, coinsNumber.ToString());
            var o = GameObject.FindGameObjectWithTag("UIShop");
            CoinsWindow.Show(coinsNumber.ToString(), o != null ? o.transform : null);
        }
    }

    public static void AddCoinsST(int coinsNumber, bool showMessageWindow = false, float updateUIDelay = 0)
    {
        if (coinsNumber > 0)
        {
            if (Instance == null)
            {
                Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Treasurer, coinsNumber);
                Achievement.AchievementController.Save();
                SaveManager.GameProgress.Current.gold += coinsNumber;
                OnPlayerCoinsBalanceChanged.InvokeSafely(SaveManager.GameProgress.Current.gold);
                SaveManager.GameProgress.Current.Save();
                GameMetaSave.SetData(SaveManager.GameProgress.Current.gold, SaveManager.GameProgress.Current.CompletedLevelsNumber);
                if (showMessageWindow)
                {
                    // UI.MessageWindow.Show(UI.MessageWindow.EMessageWindowType.COINS, coinsNumber.ToString());
                    var o = GameObject.FindGameObjectWithTag("UIShop");
                    CoinsWindow.Show(coinsNumber.ToString(), o != null ? o.transform : null);
                }
            }
            else
            {
                Debug.Log($"Instance.AddCoins");
                Instance.AddCoins(coinsNumber, showMessageWindow, updateUIDelay);
                Instance.Upd();
            }
        }
    }

    public void SpendCoins(int _addCoins)
    {
        Coins -= _addCoins;
        Upd();
    }

    public bool BuySomething(int cost)
    {
        _coins = Coins;
        if (_coins >= cost && cost >= 0)
        {
            _coins -= cost;
            Coins = _coins;
            Upd();
            return true;
        }
        return false;
    }

    public bool CheckCount(int cost)
    {
        return Coins >= cost && cost >= 0;
    }

    private void OnFacebookLoginListener()
    {
        UpdateCoinsInternalValueAndUI();
    }

    private void OnEnable()
    {
        Social.FacebookManager.OnFacebookLogin += OnFacebookLoginListener;
    }

    private void OnDisable()
    {
        Social.FacebookManager.OnFacebookLogin -= OnFacebookLoginListener;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddCoins(5000);
        }
    }
#endif
}