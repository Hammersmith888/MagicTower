using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tutorials;
using Notifications;

public class UIAction : MonoBehaviour
{
    private const string ACTION_WORK_TIME_KEY = "ActionWorkTime";
    private const string WAS_ACTION_KEY = "WasAction";
    private readonly Vector3 CENTER_POS = new Vector3(0f, 0f, 0f);

    [SerializeField]
    bool isInstance = true;

    [SerializeField]
    private ShopWearItemSettings shopWearItemSettings;

    #region VARIABLES
    [SerializeField]
    private bool DisableAction;

    private Potion_Items potionItems = new Potion_Items(4);
    private CurrentTimeScript timer;
    public DateTime currentDate;

    [SerializeField]
    private List<Text> Clocks = new List<Text>();
    public GameObject WindowObj;
    [SerializeField] Text coins, bottlesText;
    //public List<GameObject> actionVariants = new List<GameObject> ();

    private TimeSpan lastTimer;
    private string experienceTimeString;
    private bool isWindowAnimPlaying;

    private bool signedForEvent;
    private bool isTutorialStarted;

    [SerializeField]
    float startScale = 0.8f;
    int[] coinsHotDeal = new int[3] { 50000, 140000, 400000 };
    int idHotDeal = 0;
    [SerializeField]
    IAPPriceLocalizer[] pricesId;
    [SerializeField]
    RectTransform panelParent;
    [SerializeField]
    GameObject uibutton;

    [SerializeField]
    float timerOpen = 0;

    [SerializeField]
    ActionClone clone;

    public static bool showInMap = false;


    public static bool setNotification = false;

    private CurrentTimeScript getTimer
    {
        get
        {
            if (timer == null)
            {
                timer = GetComponent<CurrentTimeScript>();
            }
            return timer;
        }
    }
    #endregion

    Coroutine timerCoroutine;

    private static UIAction current;

    [SerializeField]
    AudioSource[] sounds;

    public static bool IsActive
    {
        get
        {
            if (current != null)
            {
                return current.WindowObj.activeSelf;
            }
            return false;
        }
    }

    private void Awake()
    {
        if (isInstance)
            current = this;
    }

    IEnumerator Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Map" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Shop")
        {
            UIActionButton.Toggle(false);
            ActionTimeOpenBtn();
            if (DisableAction)
            {
                yield break;
            }
            if (!PlayerPrefs.HasKey(WAS_ACTION_KEY))
            {
                PlayerPrefs.SetInt(WAS_ACTION_KEY, 3);
            }

            for (int i = 0; i < Tutorial.objs.Count; i++)
            {
                if (Tutorial.objs[i] == null)
                    Tutorial.objs.RemoveAt(i);
            }
            while (Tutorial.objs.Count > 0)
                yield return new WaitForSecondsRealtime(0.2f);

            LookForActions();
            yield break;
        }
        else
            yield break;
    }

    public void LookForActions()
    {
        int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        if (openLevel > 2)
        {
            if (openLevel == 12 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Map")
                return;

            SaveLoadActionTime();
        }
    }

    public void OpenOffer()
    {
        ShowActionSubWindow();
        StartCoroutine(AppearWindow());
    }

    public void ShowWindow(bool _on)
    {
        if (isWindowAnimPlaying)
        {
            return;
        }
        if (_on)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Map" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Shop")
            {
                if(!showInMap)
                    StartCoroutine(_Show());
            }
            else
                StartCoroutine(_Show());
            showInMap = true;
        }
        else
        {
            StartCoroutine(DisappearWindow(true));
        }
    }

    IEnumerator _Show()
    {
        yield return new WaitForSecondsRealtime(timerOpen);
        ShowActionSubWindow();
        if(UIShop.Instance != null)
        {
            UIShop.Instance.ActiveBonusItems();
            UIShop.Instance.FocusItem(clone.transform.parent);
        }
        StartCoroutine(AppearWindow());
    }
    private void ActionTimeOpenBtn()
    {
        if (PlayerPrefs.GetInt(ACTION_WORK_TIME_KEY) == 1)//Activate sign
        {
            SetupTimerLabel();
            UIActionButton.Toggle(true);
        }
    }

    private void SaveLoadActionTime()
    {
        if (!PlayerPrefs.HasKey(ACTION_WORK_TIME_KEY))//Show windows automatically first time
        {
            LoadActionTime();
            return;
        }
        else if (PlayerPrefs.GetInt(ACTION_WORK_TIME_KEY) == 1)//Activate sign
        {
            StartCoroutine(ActiveSign());
        }
        else if (PlayerPrefs.GetInt(ACTION_WORK_TIME_KEY) == 0)
        {
            if (getTimer.unbiasedTimerEndTimestamp <= UnbiasedTime.Instance.Now())
            {
                LoadActionTime(true);
            }
        }
    }

    private IEnumerator ActiveSign()
    {
        yield return new WaitForSeconds(0.5f);

        while (TutorialsManager.IsAnyTutorialActive)
            yield return new WaitForSeconds(0.1f);

        SetupTimerLabel();
        UIActionButton.Toggle(true);
        OpenClone();
    }

    private void LoadActionTime(bool isLoad = false)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Map" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Shop")
        {
            int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
            if (openLevel != 15 && openLevel != 30 && openLevel != 45 && openLevel != 70 && openLevel != 95)
            {
                if(isLoad)
                    SetNewActionWindowID();

                PlayerPrefs.SetInt(ACTION_WORK_TIME_KEY, 1);
                var timer = getTimer.SetBigTimerDT(!Application.isEditor ? 3600 : 420); // 900

                if(!setNotification)
                { 
                    SetNotification(timer);
                    setNotification = true;
                }
                ShowWindow(true);
                currentDate = getTimer.unbiasedTimerEndTimestamp;
                ShowActionSubWindow();
                SetupTimerLabel();
                OpenClone();
            }
        }
    }

    private void SetNotification(DateTime timer)
    {
        var lostTime = timer.AddMinutes(-5).ToUniversalTime();
        var tims = lostTime - DateTime.UtcNow;
       // LocalNotificationsController.instance.ScheduleNotification(TextSheetLoader.Instance.GetString("t_0704"), TextSheetLoader.Instance.GetString("t_0705"), (int)tims.TotalSeconds, "HotOffer");
        StartCoroutine(ResetNotification(tims));
    }

    private IEnumerator ResetNotification(TimeSpan time)
    {
        yield return new WaitForSeconds((int)time.TotalSeconds);
        setNotification = false;
    }

    IEnumerator _DecTimer()
    {
        var delta = CalculateTime();
        SetVisualTimers();
        if (delta > TimeSpan.Zero && PlayerPrefs.GetInt(ACTION_WORK_TIME_KEY) == 1)
        {
            yield return new WaitForSecondsRealtime(1f);
            if (timerCoroutine != null)
                StopCoroutine(timerCoroutine);
            timerCoroutine = StartCoroutine(_DecTimer());
        }
        else
            SetCloseDate();
    }

    private void SetupTimerLabel()
    {
        CalculateTime();
        SetVisualTimers();

        if (PlayerPrefs.GetInt(ACTION_WORK_TIME_KEY) == 1)
        {
            if (timerCoroutine != null)
                StopCoroutine(timerCoroutine);
            timerCoroutine = StartCoroutine(_DecTimer());
        }
    }

    void Update()
    {
        //OpenClone();
    }
    private TimeSpan CalculateTime()
    {
        TimeSpan delta = getTimer.unbiasedTimerEndTimestamp - UnbiasedTime.Instance.Now();
        int hours = (int)delta.TotalHours;
        int mins = delta.Minutes;
        int seconds = delta.Seconds;

        experienceTimeString = string.Format("{0}:{1}:{2}", hours.ToString("D2"), mins.ToString("D2"), seconds.ToString("D2"));
        return delta;
    }

    public void SetVisualTimers()
    {
        TimeSpan delta = getTimer.unbiasedTimerEndTimestamp - UnbiasedTime.Instance.Now();
        for (int i = 0; i < Clocks.Count; i++)
        {
            if (Clocks[i] != null)
            {
                Clocks[i].text = experienceTimeString;
                Clocks[i].color = delta.TotalSeconds > 10 ? Color.white : Color.red;
            }
        }
        if (clone != null)
            clone.SetTimer(experienceTimeString, delta);
        UIActionButton.SetTimerText(experienceTimeString);
        //OpenClone();
    }

    void OpenClone()
    {
        if (clone != null)
        {
            var id = idHotDeal = Mathf.Clamp(PlayerPrefs.GetInt(WAS_ACTION_KEY) - 1, 0, 2);
            var s = CustomFormat(coinsHotDeal[id].ToString());

            try
            {
                var curLang = TextSheetLoader.Instance.langId;
                if (curLang == "JP")
                    s = s.Replace(".", ",");
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }


            var xx = new string[3] { "buy_action199", "buy_action499", "buy_action1399" };
            if (clone != null)
                clone.Show(s, "X6 " + TextSheetLoader.Instance.GetString("t_0588"), uibutton.activeSelf || WindowObj.activeSelf, xx[id]);
        }
    }

    public void SetCloseDate()
    {
        if (clone != null)
            clone.Show("", "", false, "");
        UIActionButton.Toggle(false);
        StartCoroutine(DisappearWindow(false));
        getTimer.SetBigTimer(!Application.isEditor ? 172800 : 300);
        PlayerPrefs.SetInt(ACTION_WORK_TIME_KEY, 0);
    }

    private void ShowActionSubWindow()
    {
        idHotDeal = Mathf.Clamp(PlayerPrefs.GetInt(WAS_ACTION_KEY) - 1, 0, 2);
        bottlesText.text = "X6 " + TextSheetLoader.Instance.GetString("t_0588");
        var s = CustomFormat(coinsHotDeal[idHotDeal].ToString());

        try
        {
            var curLang = TextSheetLoader.Instance.langId;
            if (curLang == "JP")
                s = s.Replace(".", ",");
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }

        coins.text = s;

        var xx = new string[3] { "buy_action199", "buy_action499", "buy_action1399" };
        foreach (var o in pricesId)
        {
            o.productId = xx[idHotDeal];
        }

        //if (clone != null)
        //    clone.Show(s, bottlesText.text, true, xx[idHotDeal]);
    }

    private void SetNewActionWindowID()
    {
        int newId = UnityEngine.Random.Range(1, 4);
        int breakCounter = 0;
        while (newId == PlayerPrefs.GetInt(WAS_ACTION_KEY))
        {
            newId = UnityEngine.Random.Range(1, 4);
            breakCounter++;
            if (breakCounter > 1000)
            {
                break;
            }
        }
        if(PlayerPrefs.GetInt(WAS_ACTION_KEY) == 0)
            PlayerPrefs.SetInt(WAS_ACTION_KEY, 3);
        else
            PlayerPrefs.SetInt(WAS_ACTION_KEY, newId);
    }

    string CustomFormat(string value)
    {
        if (value.Length > 3)
            value = value.Insert(value.Length - 3, ".");
        return value;
    }

    Vector3 lastPos;

    public IEnumerator AppearWindow()
    {
        isWindowAnimPlaying = true;
        Transform windowTransform = WindowObj.transform.GetChild(1);
        Vector3 signPosition = WindowObj.transform.InverseTransformPoint(UIActionButton.Position);
        signPosition.z = 0f;
        windowTransform.localPosition = signPosition;
        windowTransform.localScale = Vector3.zero;
        WindowObj.SetActive(true);
        //UIActionButton.Toggle(false);
        int steps = 10;
        float timer = 0.15f;
        float animProgress;
        for (int i = 0; i < steps; i++)
        {
            animProgress = (i + 1) / (float)steps;
            windowTransform.localPosition = Vector3.Lerp(signPosition, CENTER_POS, animProgress);
            windowTransform.localScale = new Vector3(startScale * animProgress, startScale * animProgress, animProgress);
            yield return new WaitForSecondsRealtime(timer / steps);
        }
        StartCoroutine(_Open());
        isWindowAnimPlaying = false;
        lastPos = windowTransform.localPosition;
        yield break;
    }

    IEnumerator _Open()
    {
        if(sounds.Length > 0)
        {
            sounds[0].Play();
            yield return new WaitForSecondsRealtime(0.3f);
            sounds[1].Play();
        }
    }

    public IEnumerator DisappearWindow(bool showSign)
    {
       
        isWindowAnimPlaying = true;
        Transform windowTransform = WindowObj.transform.GetChild(1);
        Vector3 signPosition = WindowObj.transform.InverseTransformPoint(UIActionButton.Position);
        signPosition.z = 0f;
        //Vector3 EndPos = Window.position;
        windowTransform.localScale = new Vector3(startScale, startScale, startScale);
        int steps = 10;
        float timer = 0.15f;
        float animProgress;
        //float speed = Vector3.Distance( EndPos, SignPos ) / timer;
        for (int i = 0; i < steps; i++)
        {
            animProgress = (i + 1) / (float)steps;
            windowTransform.localPosition = Vector3.Lerp(lastPos, signPosition, animProgress);
            animProgress = startScale - animProgress;
            if(animProgress >= 0)
                windowTransform.localScale = new Vector3(animProgress, animProgress, animProgress);
            yield return new WaitForSecondsRealtime(timer / steps);
        }
       
        WindowObj.SetActive(false);
        UIActionButton.Toggle(showSign);
        windowTransform.localPosition = CENTER_POS;
        isWindowAnimPlaying = false;

        yield break;
    }


    //TODO: Why buy logic is here? Move this logic to separate class.
    private void LoadItemsSaves()
    {
        potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions.ToString());
    }

    private void SaveItemSaves()
    {
        PPSerialization.Save(EPrefsKeys.Potions.ToString(), potionItems, true, true);

        var inshopPotions = GameObject.FindObjectOfType<ShopPotionItemSettings>();
        if (inshopPotions != null)
        {
            inshopPotions.RefreshItemsCounts();
        }
        SoundController.Instanse.PlayShopBuySFX();
    }

    #region BUY FUNCTIONS

    public void BuyHotDealPurchase()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            if (idHotDeal == 0)
                INAPPS.BuyAction199(this);
            if (idHotDeal == 1)
                INAPPS.BuyAction499(this);
            if (idHotDeal == 2)
                INAPPS.BuyAction1399(this);
        }
    }

    public void BuyHotDeal(int value)
    {
        LoadItemsSaves();
        CoinsManager.AddCoinsST(coinsHotDeal[value]);
        AnalyticsController.Instance.CurrencyAccrual(coinsHotDeal[value], DevToDev.AccrualType.Purchased);

        potionItems[0].count += 2;
        potionItems[1].count += 2;
        potionItems[3].count += 2;
        SoundController.Instanse.PlayBuyCoinsSFX();
        SaveItemSaves();
        SetCloseDate();
        if (clone != null)
            clone.Show("", "", false, "");
    }


    public void BuyWear_PyromaniacRobe()
    {
        shopWearItemSettings.PurchaseWear(6);
    }

    public void BuyWear_PyromaniacStuff()
    {
        shopWearItemSettings.PurchaseWear(1);
    }

    public void BuyWear_FreezingRobe()
    {
        shopWearItemSettings.PurchaseWear(7);
    }

    public void BuyWear_FreezingStuff()
    {
        shopWearItemSettings.PurchaseWear(2);
    }

    public void BuyWear_RobeOfGeomency()
    {
        shopWearItemSettings.PurchaseWear(8);
    }

    public void BuyWear_StuffOfGeomency()
    {
        shopWearItemSettings.PurchaseWear(3);
    }

    public void BuyWear_ElectrophoresisRobe()
    {
        shopWearItemSettings.PurchaseWear(9);
    }

    public void BuyWear_ElectrophoresisStuffy()
    {
        shopWearItemSettings.PurchaseWear(4);
    }

    public void BuyWear_RobeOfLuck()
    {
        shopWearItemSettings.PurchaseWear(10);
    }

    private void RessurectionPotionsBought(int amount)
    {
        var obj = PoisonsManager.Get(PotionManager.EPotionType.Resurrection);
        obj.Save(PotionManager.EPotionType.Resurrection, obj.CurrentPotion + amount);
    }

    private void PotionsBought(int potionIndex, int numberBought)
    {
        var obj = PoisonsManager.Get((PotionManager.EPotionType)(potionIndex));
        obj.Save((PotionManager.EPotionType)(potionIndex), obj.CurrentPotion + numberBought);
        PotionManager.RefreshPotionsCount();
    }

    public void BuyForRes(int n)
    {
        RessurectionPotionsBought(n);
    }

    public void BuyForPoison(int index, int n)
    {
        PotionsBought(index, n);
    }


    public void BuyFor10Res()
    {
        RessurectionPotionsBought(10);
    }

    public void BuyFor30Res()
    {
        RessurectionPotionsBought(30);
    }

    public void BuyFor90Res()
    {
        RessurectionPotionsBought(90);
    }

    public void BuyFor10Mana()
    {
        PotionsBought(0, 10);
    }

    public void BuyFor30Mana()
    {
        PotionsBought(0, 30);
    }

    public void BuyFor90Mana()
    {
        PotionsBought(0, 90);
    }

    public void BuyFor10Health()
    {
        PotionsBought(1, 10);
    }

    public void BuyFor30Health()
    {
        PotionsBought(1, 30);
    }

    public void BuyFor90Health()
    {
        PotionsBought(1, 90);
    }

    public void BuyFor10Power()
    {
        PotionsBought(2, 10);
    }

    public void BuyFor30Power()
    {
        PotionsBought(2, 30);
    }

    public void BuyFor90Power()
    {
        PotionsBought(2, 90);
    }

    public void CallBuy10k()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy10k();
    }

    public void CallBuy50k()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy50k();
    }

    public void CallBuy140k()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy140k();
    }

    public void CallBuy400k()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy400k();
    }

    public void CallBuy10res()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy10ressurrect();
    }

    public void CallBuy30res()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy30ressurrect();
    }

    public void CallBuy90res()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy90ressurrect();
    }

    public void CallBuy10mana()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy10mana();
    }

    public void CallBuy30mana()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy30mana();
    }

    public void CallBuy90mana()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy90mana();
    }

    public void CallBuy10health()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy10health();
    }

    public void CallBuy30health()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy30health();
    }

    public void CallBuy90health()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy90health();
    }

    public void CallBuy10power()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy10power();
    }

    public void CallBuy30power()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy30power();
    }

    public void CallBuy90power()
    {
        Purchaser INAPPS = Purchaser.Instance;
        if (INAPPS != null)
            INAPPS.Buy90power();
    }



    public void CallBuyPyromaniacRobe()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyPyromaniacRobe();
        }
    }

    public void CallBuyPyromaniacStuff()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyPyromaniacStuff();
        }
    }

    public void CallBuyFreezingRobe()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyFreezingRobe();
        }
    }

    public void CallBuyFreezingStuff()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyFreezingStuff();
        }
    }

    public void CallBuyRobeOfGeomency()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyRobeOfGeomency();
        }
    }

    public void CallBuyStuffOfGeomency()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyStuffOfGeomency();
        }
    }

    public void CallBuyElectrophoresisRobe()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyElectrophoresisRobe();
        }
    }

    public void CallBuyElectrophoresisStuffy()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyElectrophoresisStuffy();
        }
    }

    public void CallBuyRobeOfLuck()
    {
        Purchaser INAPPS = Purchaser.Instance;
        SoundController.Instanse.PlayShowPauseSFX();
        if (INAPPS != null)
        {
            INAPPS.BuyRobeOfLuck();
        }
    }
    #endregion
}
