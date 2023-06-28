
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

public class UIMenu : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
    }

    [SerializeField]
    private Animation splash_anim;
    [SerializeField]
    private Animation btnplay_anim;
    [SerializeField]
    private Animation highlight_anim;
    [SerializeField]
    private Transform uiParent;
    [SerializeField]
    GameObject playBtn;
    [SerializeField]
    private UISettingsPanel uiSettingsPanel;

    private float splash_appear_timer;
    private bool appear_flag_01;
    public List<Transform> appear_fields;

    public UIBlackPatch BlackScreen;

    [SerializeField]
    private GameObject ExitWindow;

    IEnumerator Start()
    {
        Debug.Log($"======================= MENU ==========================");
        PlayerPrefs.SetString("currentLvl", "1");
        splash_appear_timer = Time.time;

        checkPlayingDay();
        SoundController.Instanse.StopAllBackgroundSFX();
        SoundController.Instanse.PlayGameSFX();

        if (PlayerPrefs.GetInt("Application_launch") == 2)
        {
            if (PlayerPrefs.GetInt("last_promo", 0) != System.DateTime.Now.ToUniversalTime().Day)
            {
                try
                {
                    gameObject.GetComponent<CrossPromoWindowController>().Init();
                    gameObject.GetComponent<CrossPromoWindowController>().OpenWindow();
                }
                catch (System.Exception e)
                {
                    Debug.Log("Exception on crosspromo show " + e.Message);
                }
                PlayerPrefs.SetInt("last_promo", System.DateTime.Now.ToUniversalTime().Day);
                PlayerPrefs.Save();
            }
        }

        try
        {
            if (!String.IsNullOrEmpty(DevToDev.Analytics.UserId))
            {
                SaveManager.ProfileSettings profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings.ToString());
                profileSettings.devToDevId = DevToDev.Analytics.UserId;
                PPSerialization.Save<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings.ToString(), profileSettings, true, true);
            }
            Debug.Log($"DEV TO DEV USER ID: { DevToDev.Analytics.UserId}");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        yield return new WaitForSecondsRealtime(300);
    }

    public void checkPlayingDay()
    {
        string savedDate = PlayerPrefs.GetString("LaunchDate", "");
        if (savedDate == "")
        { // if not saved yet...
          // convert current date to string...
            savedDate = System.DateTime.Now.ToString();
            // and save it in PlayerPrefs as LaunchDate:
            PlayerPrefs.SetString("LaunchDate", savedDate);
        }
        // at this point, the string savedDate contains the launch date
        // let's convert it to DateTime:
        System.DateTime launchDate;
        System.DateTime.TryParse(savedDate, out launchDate);
        // get current DateTime:
        System.DateTime now = System.DateTime.Now;
        // calculate days ellapsed since launch date:
        long days = (now - launchDate).Days;

        if (days == 2)
        {
            AnalyticsController.Instance.LogMyEvent("StartGameDay2");
        }
        if (days == 5)
        {
            AnalyticsController.Instance.LogMyEvent("StartGameDay5");
        }
    }

    void Update()
    {
        if (splash_appear_timer + 1.5f <= Time.time && !appear_flag_01)
        {
            appear_flag_01 = true;
            splash_anim.Play();
            btnplay_anim.Play();
            for (int i = 0; i < appear_fields.Count; i++)
            {
                appear_fields[i].gameObject.SetActive(true);
            }
        }
        if (splash_appear_timer + 0.5f <= Time.time)
        {
            highlight_anim.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !UI.UIWindowBase.isAnyWindowActive)
        {
            PlayerPrefs.SetString("EscapePressedFrom", "none");
            ExitWindow.SetActive(true);
        }
       

    }

    public void ToMap()
    {
        try { AnalyticsController.Instance.LogMyEvent("press_play_main_menu"); }
        catch (Exception e) { Debug.LogError(e.Message); }
        SoundController.Instanse.StopAllBackgroundSFX();
        SaveManager.ProfileSettings profileSettings = PPSerialization.Load(EPrefsKeys.ProfileSettings, SaveManager.ProfileSettings.Default);
        //if (!profileSettings.notificationWindowWasShown)
        //{
        //    profileSettings.notificationWindowWasShown = true;
        //    PPSerialization.Save(EPrefsKeys.ProfileSettings.ToString(), profileSettings);
        //    NotificationsPopup notificationsPopup = (Instantiate(Resources.Load("UI/NotificationsPopup"), uiParent) as GameObject).GetComponent<NotificationsPopup>();
        //    notificationsPopup.Init(notificationsON =>
        //   {
        //       uiSettingsPanel.SetupNotification(notificationsON);
        //       AchievementsChecker.SetSweetData();
        //       ToMapOrToLevel();
        //   });
        //}
        //else
        //{
        //    AchievementsChecker.SetSweetData();
        //    ToMapOrToLevel();
        //}
        ToMapOrToLevel();
        uiSettingsPanel.SetupNotification(true);
    }

    private void ToMapOrToLevel()
    {
        var openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);
        if (openLevel > 0)
        {
            BlackScreen.Appear("Map");
        }
        else
        {
            BlackScreen.Appear("Level_1_Tutorial");
        }
    }

    public void ToSettings()
    {

    }

    public void ToRecords()
    {

    }

    public void Share()
    {
        ShareController.instance.Share();
    }

    public void ToShop()
    {
        // SceneManager.LoadScene("Shop");
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear("Shop");
    }

    public void ToFacebook()
    {
        //OneSignalController.instanse.testNotification ();
        SoundController.Instanse.StopAllBackgroundSFX();
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene("Menu");
        BlackScreen.Appear("Menu");
    }

    public void ToCrossPromo()
    {

    }

    public void ToRateApp()
    {
        AnalyticsController.Instance.LogMyEvent("MenuRateUS");
#if UNITY_ANDROID
        //Application.OpenURL("https://play.google.com/store/apps/details?id=com.akpublish.magicsiege");
        Application.OpenURL("market://details?id=com.akpublish.magicsiege");
#elif UNITY_IOS
		Application.OpenURL( "https://itunes.apple.com/us/app/magic-siege-defender-hd/id1369002248" );
#endif
    }

    public void ToLevelEditor()
    {
        // SceneManager.LoadScene("LevelEditor");
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear("LevelEditor");
    }

    public void ToMenuEditor()
    {
        //SceneManager.LoadScene("MenuEditor");
        SoundController.Instanse.StopAllBackgroundSFX();
        BlackScreen.Appear("MenuEditor");
    }

    public void closePromo()
    {
        gameObject.GetComponent<CrossPromoWindowController>().CloseWindow();
    }
}