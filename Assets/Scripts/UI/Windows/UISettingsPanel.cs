using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsPanel : UI.UIWindowBase
{
    [System.Serializable]
    public class FlagPos
    {
        public string Id;
        public Sprite flag;
    }

    [System.Serializable]
    public class SettingsGame
    {
        public bool musicOn = true;
        public bool soundOn = true;
#if UNITY_IOS
		public bool notifOn = false;
#else
        public bool notifOn = true;
#endif
        public bool vibroOn = true;
        public bool damageViewOn = true;
        //  public string localization = "ENG";

        public static bool NotificationsIsOn
        {
            get
            {
                return PPSerialization.Load(EPrefsKeys.SettingsGame.ToString(), new SettingsGame()).notifOn;
            }
        }
    }

    [SerializeField]
    private GameObject musicBtnChild;
    [SerializeField]
    private GameObject soundBtnChild;
    [SerializeField]
    private GameObject notifBtnChild;
    [SerializeField]
    private GameObject vibroBtnChild;
    [SerializeField]
    private GameObject damageBtnChild;

    [Space(10f)]
    [SerializeField]
    private Text playerIDLabel;
    [SerializeField]
    private Text gameVersionLabel;

    [SerializeField]
    [Space(20f)]
    private Image flagObj;
    [SerializeField]
    private List<FlagPos> flags = new List<FlagPos> ();

    private  SettingsGame sg = new SettingsGame();
    private SoundController soundController;

    public static bool vibroIsOn
    {
        get
        {
            return PPSerialization.Load(EPrefsKeys.SettingsGame.ToString(), new SettingsGame()).vibroOn;
        }
    }

    private void Start()
    {
        gameVersionLabel.text = string.Format("{0}: {1}", TextSheetLoader.Instance.GetString("t_0549"), Application.version);
        SetStartFlag();
    }

    override protected void OnEnable()
    {
        SpecialOffer.saveData = PlayerPrefs.HasKey("SaveDataIsHere")
            ? PPSerialization.Load<SpecialOffer.SaveData>("special_offer")
            : new SpecialOffer.SaveData();
        base.OnEnable();
        sg = PPSerialization.Load<SettingsGame>(EPrefsKeys.SettingsGame.ToString(), new SettingsGame());
        sg.vibroOn = SystemInfo.supportsVibration && sg.vibroOn;
        if (soundController == null)
        {
            soundController = SoundController.Instanse;
        }
        musicBtnChild.SetActive(!sg.musicOn);
        soundBtnChild.SetActive(!sg.soundOn);
        vibroBtnChild.SetActive(!sg.vibroOn);
        notifBtnChild.SetActive(!sg.notifOn);
        damageBtnChild.SetActive(!sg.damageViewOn);

        playerIDLabel.gameObject.SetActive(true);
        playerIDLabel.text = string.Format("{0}: {1}", TextSheetLoader.Instance.GetString("t_0548"), SaveManager.ProfileSettings.CurrentProfileID);
    }

    public void NextFlagBtn()
    {
        ChangeFlag(1);
    }

    public void PrevFlagBtn()
    {
        ChangeFlag(-1);

    }

    public void MusicBtn()
    {
        sg.musicOn = !sg.musicOn;
        SetupMusic(sg.musicOn);
    }

    public void SoundBtn()
    {
        sg.soundOn = !sg.soundOn;
        SetupSound(sg.soundOn);
    }

    public void NotifBtn()
    {
        sg.notifOn = !sg.notifOn;
        SetupNotification(sg.notifOn);
    }

    public void VibroBtn()
    {
        if (SystemInfo.supportsVibration)
        {
            sg.vibroOn = !sg.vibroOn;
            SetupVibration(sg.vibroOn);
        }
    }

    public void DamageBtn()
    {
        sg.damageViewOn = !sg.damageViewOn;
        SetupDamageView(sg.damageViewOn);
    }

    public void SetupNotification(bool on)
    {
        sg.notifOn = on;
        notifBtnChild.SetActive(!on);
        PPSerialization.Save(EPrefsKeys.SettingsGame.ToString(), sg, false, true);
        //Notifications.LocalNotificationsController.instance.ReScheduledFullEnergyNotification();
    }

    private void SetupVibration(bool on)
    {
        sg.vibroOn = on;
        vibroBtnChild.SetActive(!on);
        PPSerialization.Save(EPrefsKeys.SettingsGame.ToString(), sg, false, true);
    }

    private void SetupDamageView(bool on)
    {
        sg.damageViewOn = on;
        damageBtnChild.SetActive(!on);
        PPSerialization.Save(EPrefsKeys.SettingsGame.ToString(), sg, false, true);
        if (UIControl.Current != null)
            UIControl.Current.showDamageView = on;
    }

    private void SetupSound(bool on)
    {
        //TODO: soundcontroller sound
        sg.soundOn = on;
        soundBtnChild.SetActive(!on);
        PPSerialization.Save(EPrefsKeys.SettingsGame.ToString(), sg, false, true);
        if (soundController != null)
            soundController.EnableSoundsVolume(on);
    }

    private void SetupMusic(bool on)
    {
        //TODO: soundcontroller music
        sg.musicOn = on;
        musicBtnChild.SetActive(!on);
        PPSerialization.Save(EPrefsKeys.SettingsGame.ToString(), sg, false, true);
        if (soundController != null)
            soundController.EnableMusicsVolume(on);
    }

    //change language from rus to eng and reverce 

    private void SetStartFlag()
    {
        string currentLangId = PlayerPrefs.GetString("CurrentLanguage");
        int currentId = 0;
        for (int i = 0; i < flags.Count; i++)
        {
            if (flags[i].Id == currentLangId)
            {
                currentId = i;
                break;
            }
        }
        flagObj.sprite = flags[currentId].flag;
    }

    private void ChangeFlag(int inc)
    {
        string currentLangId = PlayerPrefs.GetString("CurrentLanguage");
        Debug.Log("Current lang: " + currentLangId);
        int currentId = 0;
        for (int i = 0; i < flags.Count; i++)
        {
            if (flags[i].Id == currentLangId)
            {
                currentId = i + inc;
                break;
            }
        }

        if (currentId >= flags.Count)
            currentId = 0;
        if (currentId < 0)
            currentId = flags.Count - 1;
        PlayerPrefs.SetString("CurrentLanguage", flags[currentId].Id);
        SetStartFlag();
        TextSheetLoader.Instance.SetDefaultLanguage(flags[currentId].Id);

        UIPauseAnimation pauseOnScene = GameObject.FindObjectOfType<UIPauseAnimation>();
        if (pauseOnScene != null)
            pauseOnScene.ReSetLevelText();
        if (UIControl.Current != null)
        {
            UIControl.Current.ReSetLevelText();
        }

        /*if (LocalizationManager.CurrentLanguage.Equals("English (United States)"))
            SetupLanguage("Russian");
        else
            SetupLanguage("English (United States)");*/
        playerIDLabel.text = string.Format("{0}: {1}", TextSheetLoader.Instance.GetString("t_0548"), SaveManager.ProfileSettings.CurrentProfileID);
        gameVersionLabel.text = string.Format("{0}: {1}", TextSheetLoader.Instance.GetString("t_0549"), Application.version);
        if(LevelWaveInfoText.Current != null)
        LevelWaveInfoText.Current.UpdateFont();
    }

    private void SetupLanguage(string _Language)
    {
        if (LocalizationManager.HasLanguage(_Language))
            LocalizationManager.CurrentLanguage = _Language;
        else
            Debug.LogError(_Language + " Not import in project");
    }
}
