using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Tutorials;

public class VIP : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    private static string noVIP = "";
    private CurrentTimeScript timer;
    [SerializeField]
    private Transform Coins, GreenPotions;
    private string experienceTime;

    [SerializeField]
    private GameObject vipActiveBtn;
    [SerializeField]
    private GameObject buyVipButton;
    [SerializeField]
    public GameObject SignObj;
    public GameObject WindowObj;
    private bool isWindowAnimPlaying;

    const int VIP_UNLOCK_LVL = 7;
    private readonly Vector3 CENTER_POS = new Vector3(0f, 0f, 0f);

    private static VIP current;

    bool isDeactiveBtn = true;
    public UIAutoHelpersWindow windowSpeel;
    [SerializeField]
    VipControllerBonus vipBonus;

    public static bool isOpen;

    [SerializeField] private GameObject DefeatBack;
    [SerializeField] private GameObject SpellBlock;
    private bool isGame = false;

    public static VIP Current
    {
        get
        {
            if (current == null)
            {
                current = FindObjectOfType<VIP>();
            }
            return current;
        }
    }

    float maxScale = 1;

    // Use this for initialization
    IEnumerator Start()
    {
        current = this;
        timer = GetComponent<CurrentTimeScript>();
        ReloadProgress();

        // открыем робу если в старой версии был куплен вип
        if (SaveManager.GameProgress.Current.VIP)
        {
            if (!SaveManager.GameProgress.Current.VIPold)
            {
                Debug.LogError("ShopWearItemSettings.instance: " + ShopWearItemSettings.instance);
                if (ShopWearItemSettings.instance != null)
                {
                    ShopWearItemSettings.instance.FuncUnlockWear(10);
                    SaveManager.GameProgress.Current.VIPold = true;
                    SaveManager.GameProgress.Current.Save();
                }
            }
        }

        if (Camera.main.aspect >= 1.8f)
            maxScale = 0.9f;

        vipActiveBtn.SetActive(SaveManager.GameProgress.Current.VIP);
        buyVipButton.SetActive(!SaveManager.GameProgress.Current.VIP);

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level_1_Tutorial")
        {
            isGame = true;
        }

        if (!isGame)
        {
            ShowSign(true);
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Shop")
        {
            if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 30 || 
                SaveManager.GameProgress.Current.CompletedLevelsNumber == 45 || 
                SaveManager.GameProgress.Current.CompletedLevelsNumber == 70)
            {
                yield return new WaitForSecondsRealtime(2.5f);
                Debug.Log($"Tutorial.objs.Count: {Tutorial.objs.Count}");
                while (ShopGemItemSettings.instance.craftWindow.activeSelf || Tutorial.objs.Count > 0)
                    yield return new WaitForSecondsRealtime(0.1f);
                ShowWindow(true);
            }
            if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 60)
            {
                ShowWindow(true);
            }
            if (PlayerPrefs.HasKey("LoseStreak") && SaveManager.GameProgress.Current.CompletedLevelsNumber >= 7)
            {
                var streak = PlayerPrefs.GetInt("LoseStreak");
                if (streak >= 2)
                {
                    AnalyticsController.Instance.LogMyEvent("Open_Vip_Offer_Louse_Streak");
                    PlayerPrefs.SetInt("LoseStreak", 0);
                    ShowWindow(true);
                }
            }
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Map")
        {
            if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 4)
            {
                yield return new WaitForSeconds(1.5f);

                while (TutorialsManager.IsAnyTutorialActive)
                    yield return new WaitForSeconds(0.1f);

                Tutorial.OpenBlock(timer: 1f);

                //ShowSign(true);
                SaveManager.ProfileSettings profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings);
                if (!profileSettings.vipWindowWasShown)
                {
                    //profileSettings.vipWindowWasShown = true;
                    PPSerialization.Save(EPrefsKeys.ProfileSettings.ToString(), profileSettings, true, true);
                    yield return new WaitForSecondsRealtime(0.5f);
                    ShowWindow(true);
                }
            }
            if (SaveManager.GameProgress.Current.finishCount.Count(i => i > 0) == 88)
            {
                if (!SaveManager.GameProgress.Current.VIP)
                {
                    yield return new WaitForSecondsRealtime(1.5f);
                    ShowWindow(true);
                }
            }
        }

        //Debug.Log($"---=== VIP ===---");
    }

    void ReloadProgress()
    {
      //  progress = PPSerialization.Load<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString());
        //		if (progress.VIPendTime == null) {
        //			progress.VIPendTime = UnbiasedTime.Instance.Now();
        //			PPSerialization.Save(EPrefsKeys.Progress.ToString(), progress);
        //		}
    }

    private static void SetPermanentVIP()
    {
        SaveManager.GameProgress.Current.VIP = true;
        SaveManager.GameProgress.Current.Save();
    }

    private void SetupTimerLabel()
    {
        TimeSpan delta = SaveManager.GameProgress.Current.VIPendTime - UnbiasedTime.Instance.Now();
        if (delta.Days == 0)
        {
            int hours = (int)delta.TotalHours;
            int mins = delta.Minutes;
            int seconds = delta.Seconds;
            if (delta > TimeSpan.Zero)
            {
                experienceTime = "" + hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2");
                CancelInvoke();
                Invoke("SetupTimerLabel", 1f);
            }
            else
            {
                RenewPlayerNameColor();
                SetCloseDate();
            }
        }
        else if (delta.Days < 0)
        {
            RenewPlayerNameColor();
            SetCloseDate();
        }
        else
        {
            int halfDay = delta.Days;
            if (delta.Hours > 12)
                halfDay += 1;
            experienceTime = halfDay.ToString() + " days";
            Invoke("SetupTimerLabel", 1f);
        }
        SetVisualTimers();
    }

    private void SetVisualTimers()
    {
        //timerText.text = experienceTime;
    }

    IEnumerator GetTime()
    {
        if (SaveManager.GameProgress.Current.VIPendTime > UnbiasedTime.Instance.Now())
        {
            SetupTimerLabel();
        }
        else
        {
            SetCloseDate();
            SetVisualTimers();
        }
        yield break;
    }

    private void SetCloseDate()
    {
        experienceTime = noVIP;
    }

    public void AddVIPtime(int hours)
    {
        SetPermanentVIP();
        if (vipBonus != null)
            vipBonus.Open();
        return;
        //ReloadProgress();
        if (SaveManager.GameProgress.Current.VIPendTime <= UnbiasedTime.Instance.Now())
        {
            SaveManager.GameProgress.Current.VIPendTime = UnbiasedTime.Instance.Now();
        }
        for (int i = 0; i < hours; i++)
        {
            SaveManager.GameProgress.Current.VIPendTime += new TimeSpan(TimeSpan.TicksPerHour);
        }
        SaveManager.GameProgress.Current.Save();
        //ReloadProgress ();
        RenewPlayerNameColor();
        StartCoroutine(GetTime());
    }

    private void RenewPlayerNameColor()
    {
        //если дойдем до таблиц лидеров и прочего ПвП, тут будем менять цвет ника игрока
    }
    public void CallBuyDays3()
    {
#if !UNITY_EDITOR
		if( Purchaser.Instance != null )
			Purchaser.Instance.BuyDays3();
#else
        if (DebugButtons.Instance != null)
        {
            if (Purchaser.Instance != null)
                Purchaser.Instance.BuyDays3();
        }
        else
            BuyDays3();
#endif
    }

    public static void BuyDays3()
    {
        SetPermanentVIP();
      
        if (Current != null)
        {
            Current.StartCoroutine(Current.DisappearWindow(true));
            Current.vipActiveBtn.SetActive(true);
            Current.buyVipButton.SetActive(false);
            if (Current.windowSpeel != null)
                Current.windowSpeel.UpdateVip();

            if (Current.vipBonus != null)
                Current.vipBonus.Open();
        }
    }

    public void ShowSign(bool _on)
    {
        if (SignObj != null && isDeactiveBtn)
            SignObj.SetActive(_on);
    }

    public void ShowWindowOnClick(bool disableBtn = true)
    {
        if (isGame)
        {
            DefeatBack.SetActive(false);
            SpellBlock.SetActive(false);
        }
        isDeactiveBtn = disableBtn;
        AnalyticsController.Instance.LogMyEvent("VipWindow Click");
        var s = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (s == "Level_1_Tutorial")
            AnalyticsController.Instance.LogMyEvent("Clicked_Vip_GameScene");
        else
            AnalyticsController.Instance.LogMyEvent(s == "Map" ? "Clicked_Vip_Map" : "Clicked_Vip_Store");
        StartCoroutine(AppearWindow());
    }

    private void ShowWindow(bool _on)
    {
        if (isWindowAnimPlaying)
        {
            return;
        }
        if (_on)
        {
            if(!isOpen)
            {
                StartCoroutine(AppearWindow());
                isOpen = true;
            }
        }
        else
        {
            SaveManager.ProfileSettings profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings);
            if (!SaveManager.GameProgress.Current.vipFirstWindow && profileSettings.vipWindowWasShown)
            {
                SaveManager.GameProgress.Current.vipFirstWindow = true;
                SaveManager.GameProgress.Current.Save();
                UIShop.Instance.ActiveBonusItems();
            }
            StartCoroutine(DisappearWindow(true));
        }
    }

    public IEnumerator AppearWindow()
    {
        isWindowAnimPlaying = true;
        Transform Window = WindowObj.transform.GetChild(1);
        Vector3 SignPos = WindowObj.transform.InverseTransformPoint(SignObj.transform.position);
        //Vector3 EndPos = Window.position;

        Window.localPosition = SignPos;
        Window.localScale = Vector3.zero;
        WindowObj.SetActive(true);
        ShowSign(false);
        int steps = 10;
        float timer = 0.15f;
        float animProgress;
        for (int i = 0; i < steps; i++)
        {
            animProgress = (i + 1) / (float)steps;
            Window.localPosition = Vector3.Lerp(SignPos, CENTER_POS, animProgress);
            Window.localScale = new Vector3(animProgress, animProgress, animProgress);
            yield return new WaitForSecondsRealtime(timer / steps);
        }
        isWindowAnimPlaying = false;
        yield break;
    }

    public IEnumerator DisappearWindow(bool showSign)
    {
        if (isGame)
        {
            DefeatBack.SetActive(true);
            SpellBlock.SetActive(true);
        }

        isWindowAnimPlaying = true;
        Transform Window = WindowObj.transform.GetChild(1);
        Vector3 SignPos = WindowObj.transform.InverseTransformPoint(SignObj.transform.position);
        //Vector3 EndPos = Window.position;
        Window.localScale = Vector3.one;
        int steps = 10;
        float timer = 0.15f;
        float animProgress;
        //float speed = Vector3.Distance( EndPos, SignPos ) / timer;
        for (int i = 0; i < steps; i++)
        {
            animProgress = (i + 1) / (float)steps;
            Window.localPosition = Vector3.Lerp(CENTER_POS, SignPos, animProgress);
            animProgress = 1f - animProgress;
            Window.localScale = new Vector3(animProgress, animProgress, animProgress);
            yield return new WaitForSecondsRealtime(timer / steps);
        }
        WindowObj.SetActive(false);
        ShowSign(showSign);
        Window.localPosition = CENTER_POS;
        isWindowAnimPlaying = false;
        yield break;
    }
}
