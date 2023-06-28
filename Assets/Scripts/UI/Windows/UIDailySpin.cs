using System;
using System.Collections;
using System.Collections.Generic;
using Notifications;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class UIDailySpin : UI.UIWindowBase
{
    public enum RewardType { Coins, PotionMana, PotionHealth, PotionPower, PotionResurrection, None };
    // Item для DailyReword
    [Serializable]
    public class DailyItem
    {
        public SerializedToStringDateTime UnlockNextTime;
        public bool watchedVideoToday;
        public int coinsCost;

        override public string ToString()
        {
            return string.Format("UnlockNextTime: {0}", UnlockNextTime);
        }
    }

    [Serializable]
    public class SingleReward
    {
        public RewardType rewardType = RewardType.None;
        public int number;
    }
    [Serializable]
    public class RewardItem
    {
        public int id;
        public int chanceValue;
        public List<SingleReward> rewards = new List<SingleReward>();
        public GameObject rewardObjects;
    }

    [SerializeField]
    private RewardItem[] rewardVariants;

    #region VARIABLES

    private readonly int MaxCoinsPriceForUse = 2500;
    private readonly int CoinsToAddOnUse = 250;
    private readonly TimeSpan DAILY_REWARD_INTERVAL = new TimeSpan(TimeSpan.TicksPerDay);
    private static bool RESET_FOR_TEST = false; // Edit this

    [SerializeField]
    private Text nextTime, buttonCoinsValue;
    [SerializeField]
    private GameObject WheelWindow, RewardWindow, buttonVideo, buttonCoins, buttonStop, winFrame, bodyGroup, textSpin, lamps;
    [SerializeField]
    private Button ButtonFree;
    [SerializeField]
    private Sprite spriteFree, spriteUnactive, spriteGreen;
    [SerializeField]
    private Transform wheelTransform;
    [SerializeField]
    private Button closeWindowButton;

    [SerializeField] PoisonsManager poisonsManager;

    private TimeSpan ts;
    private bool startTimer;
    private DailyItem dailyItem;
    private DateTime currentDate;
    private int currentReward;
    private bool nowRotating;
    private bool wheelHandBreaker;
    [HideInInspector]
    public bool pendingReward;
    //private readonly TimeSpan DAILY_REWARD_INTERVAL = new TimeSpan( TimeSpan.TicksPerSecond * 100 );
    Animation lampsAnimation;

    [SerializeField]
    GameObject btnTakeReward;
    [SerializeField]
    Transform targetCoins;
    Transform parentTargetCoins;

    [SerializeField]
    Transform targetRessurection;
    Transform parentTargetRessurection;

    [SerializeField]
    Transform targetShop;
    Transform parentTargetShop;


    [SerializeField]
    bool isEditor = false;
    [SerializeField]
    int winNumber = 0;


    #endregion

    [SerializeField]
    Transform parentReward, parentFly, parentJackpot;
    [SerializeField]
    Transform[] jackpotRewards;

    bool effect = false;

    public AudioSource coinsAudio;

    [SerializeField]
    List<Text> textBadge = new List<Text>();

    [SerializeField]
    GameObject panelInfo;
    [SerializeField]
    GameObject[] infoO;

    public GameObject bigStopButton;

    protected static UIDailySpin m_Current;
    public static UIDailySpin Current
    {
        get
        {
            if (m_Current == null)
            {
                m_Current = FindObjectOfType<UIDailySpin>();
            }
            return m_Current;
        }
    }

    protected void Awake()
    {
        m_Current = this;
        LoadOrInit();
        startTimer = false;
        closeWindowButton.onClick.AddListener(OnCloseWithBackButton);
        lampsAnimation = lamps.GetComponent<Animation>();
        parentTargetCoins = targetCoins.transform.parent;
        parentTargetShop = targetShop.transform.parent;
        parentTargetRessurection = targetRessurection.transform.parent.transform.parent;
        transform.localScale = new Vector3(0.92f,0.92f,1);
        transform.localPosition += -new Vector3(0, 15, 0);
    }

    public void UpdateBadge()
    {
        foreach(var o in textBadge)
        {
            o.text = SaveManager.GameProgress.Current.countFreeSpin.ToString();
            o.transform.parent.gameObject.SetActive(SaveManager.GameProgress.Current.countFreeSpin > 0);
        }
    }
    public void OnOpen()
    {
        if (BossProgress.instance != null)
            BossProgress.instance.IconRemoveCanvas();
        lamps.SetActive(true);
        bodyGroup.SetActive(true);
        btnTakeReward.SetActive(true);
        wheelTransform.localEulerAngles = new Vector3(0f, 0f, 0f);
        SoundController.Instanse.PlayDailySpinOpen();
        currentDate = UnbiasedTime.Instance.Now();
        if (currentDate >= dailyItem.UnlockNextTime)
        {
            UseFreeButton();
            RotateWheel();
            AnalyticsController.Instance.LogMyEvent("DailySpin_Free");
        }
        else
        {
            FreeActive(false);
            SetupTimerLabel();
            ChangeButtonToStop(3);
        }

        if (SaveManager.GameProgress.Current.countFreeSpin > 0)
        {
            dailyItem = new DailyItem();
            ResetDailyItem();
        }
    }

    public void CheckIfCanStop()
    {
        if (currentDate >= dailyItem.UnlockNextTime)
        {
            bigStopButton.SetActive(true);
        }
        else
        {
            bigStopButton.SetActive(false);
        }
    }

    override protected void OnEnable()
    {
        base.OnEnable();
        currentDate = UnbiasedTime.Instance.Now();
        //переменная чтобы после получения подарка не показывать анимацию бэкграунда
        //Debug.LogFormat( "{0} {1} {2}", currentDate, di.UnlockNextTime, di.ResetTime );

        //Момент когда получена награда и идет таймер до следующей
        if (currentDate < dailyItem.UnlockNextTime)
        {
            if (nowRotating)
            {
                FreeActive(false);
                UIDailyRewardController.ResetVideoLimits();
                SetupTimerLabel();
                Close();
            }
        }
    }

    protected void OnDisable()
    {
        if (pendingReward)
        {
            GiveReward(currentReward);
        }
        
    }

#if UNITY_EDITOR
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(dailyItem.UnlockNextTime);
            dailyItem.UnlockNextTime = UnbiasedTime.Instance.Now() - new TimeSpan(TimeSpan.TicksPerDay);
        }
    }
#endif

    protected override void OnCloseWithBackButton()
    {
        if (pendingReward)
        {
            return;
        }
        if (destroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            bodyGroup.SetActive(false);
        }
    }

    private void FreeActive(bool on)
    {
        if (on)
        {
            nextTime.gameObject.SetActive(false);
            textSpin.SetActive(true);
            ButtonFree.image.sprite = spriteGreen;
            ButtonFree.interactable = true;
            dailyItem.watchedVideoToday = false;
            buttonCoins.SetActive(false);
            buttonVideo.SetActive(false);
        }
        else
        {
            nextTime.gameObject.SetActive(true);
            textSpin.SetActive(false);
            ButtonFree.image.sprite = spriteFree;
            ButtonFree.interactable = false;
        }
    }

    private void LoadOrInit()
    {
        dailyItem = PPSerialization.Load<DailyItem>("DailySpin");
        if (RESET_FOR_TEST)
        {
            dailyItem = null;
        }

        if (dailyItem == null)
        {
            dailyItem = new DailyItem();
            ResetDailyItem();
        }
    }

    public void ResetDailyItem()
    {
        dailyItem.UnlockNextTime = new DateTime(0);
        dailyItem.watchedVideoToday = false;
        SaveStatus();
    }

    public void UseFreeButton()
    {
        DateTime tempTime = UnbiasedTime.Instance.Now() + DAILY_REWARD_INTERVAL;
        dailyItem.UnlockNextTime = tempTime;
        dailyItem.watchedVideoToday = false;
        dailyItem.coinsCost = CoinsToAddOnUse;
        buttonCoinsValue.text = dailyItem.coinsCost.ToString();
        FreeActive(false);
        SaveStatus();
        SetupTimerLabel();
        ChangeButtonToStop(0);
        if(SaveManager.GameProgress.Current.countFreeSpin == 0)
        {
           
            /*
            Int32 unixNext = (Int32)(tempTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Int32 unixNow = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var sec = unixNext - unixNow;
            */
            //var sec = LocalNotificationsController.instance.CheckHowMuchSecondsTillTomorrow();
            Debug.Log($"push free: {86400}");
            // отправка уведомлений
            //Notifications.LocalNotificationsController.instance.ScheduleNotification(
            //   TextSheetLoader.Instance.GetString("t_0693"),
            //   TextSheetLoader.Instance.GetString("t_0694"),
            //   86400, "DailySpin");
        }
        if (SaveManager.GameProgress.Current.countFreeSpin > 0)
        {
            SaveManager.GameProgress.Current.countFreeSpin--;
            UIDailySpinActivator.Current.UpdateBadge();
            if (SaveManager.GameProgress.Current.countFreeSpin < 0)
                SaveManager.GameProgress.Current.countFreeSpin = 0;
            //nextTime.text = SaveManager.GameProgress.Current.countFreeSpin.ToString();
            //nextTime.text = TextSheetLoader.GetStringST("t_0356");
            nextTime.text = "";
            textSpin.SetActive(nextTime.text == "");
            if (SaveManager.GameProgress.Current.countFreeSpin > 0)
            {
                dailyItem = new DailyItem();
                ResetDailyItem();
            }
            SaveManager.GameProgress.Current.Save();
        }
    }

    private void ChangeButtonToStop(int buttonId)
    {
        buttonCoinsValue.text = dailyItem.coinsCost.ToString();

        switch (buttonId)
        {
            case 0:
                buttonStop.gameObject.SetActive(true);
                ButtonFree.gameObject.SetActive(false);
                break;
            case 1:
                buttonStop.gameObject.SetActive(true);
                buttonVideo.gameObject.SetActive(false);
                break;
            case 2:
                buttonStop.gameObject.SetActive(true);
                buttonCoins.gameObject.SetActive(false);
                break;
            case 3:
                ButtonFree.gameObject.SetActive(true);
                buttonVideo.gameObject.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
                buttonCoins.gameObject.SetActive(!ADs.AdsManager.Instance.isAnyVideAdAvailable);
                break;
        }
    }

    private void GiveCoins(int coins)
    {
        CoinsManager.AddCoinsST(coins);
        AnalyticsController.Instance.CurrencyAccrual(coins, DevToDev.AccrualType.Earned);
    }

    //не работает в паузе, но поскольку вся логика проверки в OnEnable, ето не столь важно, наверное)
    private void SetupTimerLabel()
    {
        TimeSpan delta = dailyItem.UnlockNextTime - UnbiasedTime.Instance.Now();

        int hours = (int)delta.TotalHours;
        int mins = delta.Minutes;
        int seconds = delta.Seconds;
        nextTime.gameObject.SetActive(true);
        nextTime.text = (hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2"));

        ts = delta;
        startTimer = true;
        UIDailySpinActivator.RestartTimer();
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (startTimer)
        {
            yield return new WaitForSeconds(1.0f);
            CountDownTimer();
        }
    }

    private void CountDownTimer()
    {
        ts = dailyItem.UnlockNextTime - UnbiasedTime.Instance.Now();  //ts.Subtract( TimeSpan.FromSeconds( 1 ) );
        int hours = (int)ts.TotalHours;
        int mins = ts.Minutes;
        int seconds = ts.Seconds;
        if(SaveManager.GameProgress.Current.countFreeSpin == 0)
        {
            nextTime.text = (hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2"));
            textSpin.SetActive(false);
        }
        if (ts <= new TimeSpan(0) && !nowRotating)
        {
            FreeActive(true);
            //nowRotating = false;
            nextTime.gameObject.SetActive(false);
            startTimer = false;
        }
    }

    private void SaveStatus()
    {
        PPSerialization.Save("DailySpin", dailyItem);
    }

    public void RotateWheel()
    {
        if (wheelTransform == null || nowRotating)
        {
            return;
        }
        btnTakeReward.SetActive(true);
        nowRotating = true;
        winFrame.SetActive(false);

        wheelHandBreaker = false;
        StartCoroutine(Rotating());
        SoundController.Instanse.PlayDailySpinRotate();
    }

    private IEnumerator Rotating()
    {
        yield return null;
        yield return null;
        yield return null;

        lamps.SetActive(true);

        currentReward = GetRewardId();
        pendingReward = true;
        var rotationSpeed = 500f;
        var angleStepPerReward = 360f / (float)rewardVariants.Length;
        var targetRewardAngle = (angleStepPerReward * currentReward) - 360f;
        var currentAngles = wheelTransform.localEulerAngles;

        //Debug.Log(currentReward + "  " + targetRewardAngle + "  " + rewardVariants[currentReward].rewards[0].rewardType);

        while (!wheelHandBreaker)
        {
            currentAngles.z -= rotationSpeed * Time.deltaTime;
            if (currentAngles.z < -360f)
            {
                currentAngles.z = (currentAngles.z - -360f);
            }
            wheelTransform.localEulerAngles = currentAngles;
            Debug.Log($"rotation");
            if (wheelHandBreaker)
            {
                break;
            }
            yield return null;
        }
        var rotationTime = 0.1f;
        var timer = 0f;
        while (timer < rotationTime)
        {
            timer += Time.deltaTime;
            currentAngles.z -= rotationSpeed * Time.deltaTime;
            if (currentAngles.z < -360f)
            {
                currentAngles.z = (currentAngles.z - -360f);
            }
            Debug.Log($"timer rotation");
            wheelTransform.localEulerAngles = currentAngles;
            yield return null;
        }

        var diff = targetRewardAngle - currentAngles.z;
        if (diff > -300f)
        {
            targetRewardAngle -= 360f;
        }
        // Debug.LogFormat("After {0} {1}", targetRewardAngle, currentAngles.z);
        var fullDistance = Mathf.Abs(targetRewardAngle - currentAngles.z);
        while (true)
        {
            var currentDistance = Mathf.Abs(targetRewardAngle - currentAngles.z);
            //Debug.Log($"CUR DIS: {currentDistance}");
            currentAngles.z -= (rotationSpeed) * Mathf.Max((currentDistance / fullDistance), 0.03f) * Time.deltaTime; // 
            //currentAngles.z += rotationSpeed * EndRotationCurve.Evaluate(currentDistance / fullDistance) * Time.deltaTime;
            if (currentAngles.z <= targetRewardAngle)
            {
                currentAngles.z = targetRewardAngle;
                break;
            }

            wheelTransform.localEulerAngles = currentAngles;
            yield return null;
        }



        lamps.transform.rotation = wheelTransform.rotation;
        lampsAnimation["ActionsSignLamps"].speed = -1; // revert animation

        lamps.SetActive(true);
        GetComponent<AudioSource>().Play();
        //Eugene add stop sound

        StartCoroutine(BlickWinFrame());


        yield return new WaitForSeconds(0.75f);
        GiveReward(currentReward);
        GiveRewardVisual();
    }

    private IEnumerator BlickWinFrame()
    {
        WaitForSeconds wait = new WaitForSeconds(0.11f);
        for (int i = 0; i < 5; i++)
        {
            winFrame.SetActive(true);
            yield return wait;
            winFrame.SetActive(false);
            yield return wait;
        }
        winFrame.SetActive(true);

    }

    private void GiveReward(int rewardId)
    {
        pendingReward = false;
        var isPotionsInReward = false;
        var rewards = rewardVariants[rewardId].rewards;
        var rewardsCount = rewards.Count;
        for (int i = 0; i < rewardsCount; i++)
        {
            var rewardType = rewards[i].rewardType;
            if (rewardType == RewardType.PotionHealth || rewardType == RewardType.PotionResurrection ||
                rewardType == RewardType.PotionMana || rewardType == RewardType.PotionPower)
            {
                isPotionsInReward = true;
                break;
            }
        }
        Potion_Items potionItems = null;
        if (isPotionsInReward)
        {
            potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
        }

        for (int i = 0; i < rewardsCount; i++)
        {
            switch (rewards[i].rewardType)
            {
                case RewardType.Coins:
                    GiveCoins(rewards[i].number);
                    break;
                case RewardType.PotionMana:
                    potionItems[0].count += rewards[i].number;
                    break;
                case RewardType.PotionHealth:
                    potionItems[1].count += rewards[i].number;
                    break;
                case RewardType.PotionPower:
                    potionItems[2].count += rewards[i].number;
                    break;
                case RewardType.PotionResurrection:
                    potionItems[3].count += rewards[i].number;
                    break;
            }
        }

        if (isPotionsInReward)
        {
            PPSerialization.Save(EPrefsKeys.Potions, potionItems);
        }
    }

    private void GiveRewardVisual()
    {
        WheelWindow.SetActive(false);
        RewardWindow.SetActive(true);
        rewardVariants[currentReward].rewardObjects.SetActive(true);

        for (int i = 0; i < rewardVariants[currentReward].rewardObjects.transform.childCount; i++)
        {
            rewardVariants[currentReward].rewardObjects.transform.GetChild(i).gameObject.SetActive(true);
        }

        foreach (var x in jackpotRewards)
        {
            for (int i = 0; i < x.childCount; i++)
            {
                x.GetChild(i).gameObject.SetActive(true);
            }
        }

        var firstRewardType = rewardVariants[currentReward].rewards[0].rewardType;
        var isPotionsInReward =
            (firstRewardType == RewardType.PotionHealth
            || firstRewardType == RewardType.PotionResurrection
            || firstRewardType == RewardType.PotionMana
            || firstRewardType == RewardType.PotionPower);

        if (isPotionsInReward)
        {
            SoundController.Instanse.playUseBottle2SFX();
        }
        else
        {
            SoundController.Instanse.PlayBuyCoinsSFX();
        }
        SoundController.Instanse.PlayDailySpinCongrats();
    }

    IEnumerator _Coins()
    {
        for (int i = 0; i < 8; i++)
        {
            coinsAudio.Play();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }


    public void CloseRewardVisual()
    {
        SoundController.Instanse.buyCoinsSFX.Play();

        if (rewardVariants[currentReward].rewards[0].rewardType == RewardType.Coins)
        {
            //targetCoins.SetParent(transform);
            var target = targetCoins.Find("CoinTargetEffect").transform;
            rewardVariants[currentReward].rewardObjects.GetComponent<UIConsFlyAnimation>().PlayEffect(target.position);
            rewardVariants[currentReward].rewardObjects.transform.SetParent(parentFly);
            StartCoroutine(_Coins());
            foreach (var oo in rewardVariants[currentReward].rewardObjects.GetComponentsInChildren<Transform>())
            {
                if (oo.name == "shine" || oo.name == "coins" || oo.name == "number")
                    oo.gameObject.SetActive(false);
            }
        }
        else if (rewardVariants[currentReward].rewards[0].rewardType == RewardType.PotionResurrection && currentReward != 1)
        {
            rewardVariants[currentReward].rewardObjects.transform.SetParent(parentFly);
            foreach (var oo in rewardVariants[currentReward].rewardObjects.GetComponentsInChildren<Transform>())
            {
                if (oo.name == "shine" || oo.name == "bottle" || oo.name == "number")
                    oo.gameObject.SetActive(false);
            }
           // targetRessurection.transform.parent.SetParent(transform);
            rewardVariants[currentReward].rewardObjects.GetComponent<UIConsFlyAnimation>().PlayEffect(targetRessurection.position);
        }
        else
        {
            for (int i = 0; i < rewardVariants[currentReward].rewards.Count; i++)
            {
                if (rewardVariants[currentReward].rewards[i].rewardType == RewardType.PotionPower ||
                   rewardVariants[currentReward].rewards[i].rewardType == RewardType.PotionHealth ||
                   rewardVariants[currentReward].rewards[i].rewardType == RewardType.PotionMana)
                {
                    //targetShop.SetParent(transform);
                    var objs = rewardVariants[currentReward].rewardObjects.GetComponentsInChildren<UIConsFlyAnimation>();
                    foreach (var o in objs)
                    {
                        if (o.gameObject.name == rewardVariants[currentReward].rewards[i].rewardType.ToString())
                        {
                            o.gameObject.transform.SetParent(parentFly);
                            foreach (var oo in o.gameObject.GetComponentsInChildren<Transform>())
                            {
                                if (oo.name == "shine" || oo.name == "bottle" || oo.name == "number")
                                    oo.gameObject.SetActive(false);
                            }
                            o.gameObject.GetComponent<UIConsFlyAnimation>().PlayEffect(targetShop.position);
                        }
                    }
                }
                else if (rewardVariants[currentReward].rewards[i].rewardType == RewardType.PotionResurrection)
                {
                    //targetRessurection.transform.parent.SetParent(transform);
                    var objs = rewardVariants[currentReward].rewardObjects.GetComponentsInChildren<UIConsFlyAnimation>();
                    foreach (var o in objs)
                    {
                        if (o.gameObject.name == rewardVariants[currentReward].rewards[i].rewardType.ToString())
                        {
                            o.gameObject.transform.SetParent(parentFly);
                            foreach (var oo in o.gameObject.GetComponentsInChildren<Transform>())
                            {
                                if (oo.name == "shine" || oo.name == "bottle" || oo.name == "number")
                                    oo.gameObject.SetActive(false);
                            }
                            o.gameObject.GetComponent<UIConsFlyAnimation>().PlayEffect(targetRessurection.position);
                        }
                    }
                }
            }
        }
        btnTakeReward.SetActive(false);
        StartCoroutine(_Close());
    }
    IEnumerator _Close()
    {
        effect = true;
        buttonCoins.GetComponent<Button>().interactable = buttonVideo.GetComponent<Button>().interactable = false;
        Close();
        if (rewardVariants[currentReward].rewards[0].rewardType != RewardType.Coins)
            SoundController.Instanse.playDrobScrollSFX();
        yield return new WaitForSecondsRealtime(0.9f);
        if (rewardVariants[currentReward].rewards[0].rewardType == RewardType.Coins)
        {
            targetCoins.SetParent(parentTargetCoins);
            rewardVariants[currentReward].rewardObjects.transform.SetParent(parentReward);
        }
        if (rewardVariants[currentReward].rewards[0].rewardType == RewardType.PotionResurrection)
        {
            poisonsManager.UpdateCount();
            targetRessurection.transform.parent.SetParent(parentTargetRessurection);
            rewardVariants[currentReward].rewardObjects.transform.SetParent(parentReward);
        }
        for (int i = 0; i < rewardVariants[currentReward].rewards.Count; i++)
        {
            if (rewardVariants[currentReward].rewards[i].rewardType == RewardType.PotionResurrection)
            {
                poisonsManager.UpdateCount();
                targetRessurection.transform.parent.SetParent(parentTargetRessurection);
            }
            if (currentReward != 1)
                rewardVariants[currentReward].rewardObjects.transform.SetParent(parentReward);
            else
            {
                poisonsManager.UpdateCount();
                foreach (var x in jackpotRewards)
                    x.SetParent(parentJackpot);
            }
        }
       
        rewardVariants[currentReward].rewardObjects.SetActive(false);
        effect = false;
        buttonCoins.GetComponent<Button>().interactable = buttonVideo.GetComponent<Button>().interactable = true;
    }


    void Close()
    {
        GetComponent<AudioSource>().Stop();
        WheelWindow.SetActive(true);
        RewardWindow.SetActive(false);
        //rewardVariants[currentReward].rewardObjects.SetActive(false);
        if (dailyItem.UnlockNextTime > UnbiasedTime.Instance.Now())
        {
            if (!dailyItem.watchedVideoToday)
            {
                buttonVideo.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
            }
            else
            {
                textSpin.SetActive(false);
                buttonVideo.SetActive(false);
                buttonCoins.SetActive(true);
                buttonCoinsValue.text = dailyItem.coinsCost.ToString();
            }
        }
        nowRotating = false;
    }

    private int GetRewardId()
    {
        if (Application.isEditor && isEditor)
            return winNumber;
        int to_return = 0;
        int totalChances = 0;
        for (int i = 0; i < rewardVariants.Length; i++)
        {
            totalChances += rewardVariants[i].chanceValue;
        }
        for (int i = 0; i < rewardVariants.Length; i++)
        {
            if (rewardVariants[i].chanceValue >= UnityEngine.Random.Range(0, totalChances))
            {
                to_return = i;
                break;
            }
            else
            {
                totalChances -= rewardVariants[i].chanceValue;
            }
        }
        return to_return;
    }

    public void HandleStoppingWheel()
    {
        //Eugene add stop sound
        if(!wheelHandBreaker)
            SoundController.Instanse.StopDailySpinRotate();
        
        TutorialDailySpin.Instance.OnDailyFinishTutorial();
        HideStopButton();
        wheelHandBreaker = true;
    }

    public void PressedVideo()
    {
        if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
        {
            ADs.AdsManager.ShowVideoAd((bool result) =>
               {
                   if (result)
                   {
                       AnalyticsController.Instance.LogMyEvent("DailySpin_Ads");
                       dailyItem.watchedVideoToday = true;
                       SaveStatus();
                       buttonVideo.SetActive(false);
                       ChangeButtonToStop(1);
                       bigStopButton.SetActive(true);
                       RotateWheel();
                   }
               });
        }
        else
        {
            Debug.Log("PressedVideo: NoVideoAvailable");
        }
    }

    private void HideStopButton()
    {
        buttonStop.SetActive(false);
        ButtonFree.gameObject.SetActive(true);
    }

    public void PressedCoins()
    {
        int needCoins = dailyItem.coinsCost;
        if (CoinsManager.Instance.BuySomething(needCoins))
        {
            AnalyticsController.Instance.LogMyEvent("DailySpin_money");
            if (dailyItem.coinsCost < MaxCoinsPriceForUse)
            {
                dailyItem.coinsCost += CoinsToAddOnUse;
            }
            buttonCoinsValue.text = dailyItem.coinsCost.ToString();
            SaveStatus();
            buttonCoins.SetActive(false);
            ChangeButtonToStop(2);
            RotateWheel();
        }
    }

    public void OpenInfo(int i)
    {
        panelInfo.SetActive(true);
        infoO[i].SetActive(true);
    }
}