using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class UIAutoHelpersWindow : MonoBehaviour
{
    public static UIAutoHelpersWindow instance;

    [SerializeField]
    private Button closeButton;
    public GameObject parentPanel, btnClose;
    [SerializeField]
    GameObject[] panelBackgroud;
    [SerializeField]
    private Toggle manaCheckbox, healthCheckbox, powerCheckbox, spellCheckbox, speedCheckbox;
    public CustomToggle _manaCheckbox, _healthCheckbox, _powerCheckbox, _spellCheckbox, _commonToogle;
    [SerializeField]
    GameObject chekbox;
    [SerializeField]
    private UIAutoHelperPickSpells uiAutoHelperPickSpells;

    [SerializeField]
    Animator[] btnsSize;

    [SerializeField]
    VIP vipController;

    public GameObject btnBuy, blocker, btnFree;
    [SerializeField]
    Button btnAds;
    [SerializeField]
    Text btnTextAds;

    bool isVipRequired = true;
    int currentStatus;
    public Sprite selectedSprite;

    public bool isFree = false;


    [SerializeField]
    RectTransform labelSpell;
    [SerializeField]
    VerticalLayoutGroup vertGroup;

    public bool reset = false;

    [SerializeField]
    RectTransform rectParent;
    double totalSeconds = 0;

    [System.Serializable]
    public class SaveData
    {
        public string auto_help_timer;
        public string auto_help_status;
        public string auto_pick_purchase;
        public float auto_timer = -1;
        public bool tutorial_end;
        public int count;
    }

    public static SaveData saveData = new SaveData();

    public float timerForIt = 900; // 15 min in sec

    private void Awake()
    {
        instance = this;
        // rectParent.anchoredPosition = new Vector2(-5000, 0);
        if (PPSerialization.Load<SaveData>("auto_helper") != null)
        {
            PPSerialization.Save<UIAutoHelpersWindow.SaveData>("auto_helper", UIAutoHelpersWindow.saveData);
            //Debug.Log($"load save data: {PPSerialization.Load<SaveData>("auto_helper")};");
            saveData = PPSerialization.Load<SaveData>("auto_helper");
        }
        Debug.Log($"load save data time: {saveData.auto_timer}");
        Time.timeScale = 0;
        if (Application.isEditor)
            timerForIt = 60;
    }

    private void OnEnable()
    {
        UIAutoHelperButton.panelIsOpen = true;

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (btnAds!=null)
            {
                btnBuy.GetComponent<Button>().interactable = false;
                btnBuy.GetComponent<Button>().image.sprite = btnBuy.GetComponent<Button>().spriteState.disabledSprite;
                btnAds.interactable = false;
                btnAds.image.sprite = btnAds.GetComponent<Button>().spriteState.disabledSprite;
            }
        }
    }


    IEnumerator Start()
    {
        if (reset)
        {
            saveData.auto_help_status = saveData.auto_help_timer = saveData.auto_pick_purchase = "";
            saveData.auto_timer = 0;
            PPSerialization.Save<SaveData>("auto_helper", saveData);
        }
        closeButton.onClick.AddListener(CloseIt);
        chekbox.SetActive(false);
        UpdateCheckbox();

        _manaCheckbox._action = ToggleCheckBoxMana;
        _healthCheckbox._action = ToggleCheckBoxHealth;
        _spellCheckbox._action = ToggleCheckBoxSpell;
        _powerCheckbox._action = ToggleCheckBoxPower;
        _commonToogle._action = ToggleCommon;

        transform.SetSiblingIndex(transform.GetSiblingIndex() - 2);
        vipController = VIP.Current;
        vipController.windowSpeel = this;
        yield return new WaitForEndOfFrame();
        UpdateVip();
        SoundController.Instanse.windowsActivitySFX.Play();
        StartCoroutine(_Timer());

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        // yield return new WaitForSecondsRealtime(2);
        //  rectParent.anchoredPosition = new Vector2(0, 0);

    }

    public void UpdateCheckbox()
    {
        _manaCheckbox.SetDefault(LevelPlayerHelpersLoader.Current.manaUse);
        _healthCheckbox.SetDefault(LevelPlayerHelpersLoader.Current.healthUse);
        _powerCheckbox.SetDefault(LevelPlayerHelpersLoader.Current.powerUse);
        _spellCheckbox.SetDefault(LevelPlayerHelpersLoader.Current.spellUse);
        _commonToogle.SetDefault(LevelPlayerHelpersLoader.Current.manaUse);
    }
    IEnumerator _Timer()
    {
        while (true)
        {
            blocker.GetComponent<Image>().enabled = !btnTextAds.transform.parent.gameObject.activeSelf;
            TimeSpan t = TimeSpan.FromSeconds(saveData.auto_timer);

            btnTextAds.text = (t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2"));
            btnTextAds.transform.parent.gameObject.SetActive(saveData.auto_timer > 0);

            if (saveData.auto_timer < 0 && saveData.auto_pick_purchase != "1")
            {
                //saveData.auto_help_timer = "";
                saveData.auto_help_status = "0";
                saveData.auto_timer = -1;
                PPSerialization.Save<SaveData>("auto_helper", saveData);
                _spellCheckbox.Set(false);
                LevelPlayerHelpersLoader.Current.spellUse = false;
                PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseSpellSave, false ? 1 : 0);
                UpdateVip();
            }
            btnTextAds.color = saveData.auto_timer < 6 ? Color.red : Color.white;
            btnTextAds.GetComponent<Outline>().enabled = saveData.auto_timer < 6;
            if (UIAutoHelperButton.instance != null)
            {
                UIAutoHelperButton.instance.textTimer.transform.parent.gameObject.SetActive(t.TotalSeconds > 0);
                UIAutoHelperButton.instance.textTimer.text = btnTextAds.text;
            }
            if (btnTextAds.color == Color.red)
            {
                btnTextAds.GetComponent<AudioSource>().Play();
                btnTextAds.GetComponent<Animator>().enabled = true;
                StartCoroutine(_DisableAnimator());
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator _DisableAnimator()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        btnTextAds.GetComponent<Animator>().enabled = false;
    }

    public void UpdateVip(bool resize = true)
    {
        if (saveData.auto_pick_purchase == "1")
        {
            blocker.SetActive(false);
            spellCheckbox.interactable = true;
            if (resize)
            {
                _commonToogle.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -112);
                _spellCheckbox.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 97);
                UIAutoHelperButton.instance.textTimer.transform.parent.gameObject.SetActive(false);
            }
            return;
        }


        if (String.IsNullOrEmpty(saveData.auto_help_status))
            saveData.auto_help_status = "0";
        currentStatus = int.Parse(saveData.auto_help_status);
        Debug.Log($"current status: {currentStatus},  isFree: {isFree}");

        if (!isFree)
            btnFree.SetActive(currentStatus < 0);
        else
            btnFree.SetActive(true);

        btnAds.gameObject.SetActive(saveData.auto_timer < 0);
        btnTextAds.transform.parent.gameObject.SetActive(false);

        blocker.SetActive(true);
        PPSerialization.Save<SaveData>("auto_helper", saveData);
    }

    public void ViewAds()
    {
        if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
        {
            ADs.AdsManager.ShowVideoAd((bool result) =>
            {
                if (result)
                {
                    AnalyticsController.Instance.LogMyEvent("SpellPressUnlocked_Ads");
                    //saveData.auto_timer = Application.isEditor ? (saveData.count >= 1 ? (60 / 2) : 60) : (saveData.count >= 1 ? (timerForIt / 2) : timerForIt);
                    //saveData.auto_timer = Application.isEditor ? 60 : timerForIt;
                    saveData.auto_timer = timerForIt;
                    saveData.count++;
                    saveData.auto_help_status = "2";
                    btnAds.gameObject.SetActive(false);
                    btnTextAds.color = Color.white;
                    btnTextAds.GetComponent<Outline>().enabled = false;
                    btnTextAds.text = TimeSpan.FromSeconds(timerForIt).Minutes - 1 + ":59";
                    Debug.Log($"timer: {btnTextAds.text}");
                    btnTextAds.transform.parent.gameObject.SetActive(true);

                    _spellCheckbox.Set(true);
                    LevelPlayerHelpersLoader.Current.spellUse = true;
                    PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseSpellSave, true ? 1 : 0);
                    PlayerPrefs.SetInt("LevelEasyMod", mainscript.CurrentLvl);
                    PPSerialization.Save<SaveData>("auto_helper", saveData);
                }
            });
        }
        else
        {
            btnAds.image.sprite = btnTextAds.GetComponent<Button>().spriteState.disabledSprite;
            Debug.Log("PressedVideo: NoVideoAvailable");
        }
    }

    private void CloseIt()
    {
        UIAutoHelperButton.panelIsOpen = false;
        UIPauseController.Instance.pauseCalled = false;
        Time.timeScale = LevelSettings.Current.usedGameSpeed;
        Destroy(gameObject);
    }

    public void Free()
    {
        if (String.IsNullOrEmpty(saveData.auto_help_status))
            saveData.auto_help_status = "0";
        //saveData.auto_timer = Application.isEditor ? 60 : timerForIt;
        saveData.auto_timer = timerForIt;
        saveData.count++;
        saveData.auto_help_status = "2";
        btnAds.gameObject.SetActive(false);
        btnTextAds.color = Color.white;
        btnTextAds.GetComponent<Outline>().enabled = false;
        btnTextAds.text = TimeSpan.FromSeconds(timerForIt).Minutes - 1 + ":59";
        btnTextAds.transform.parent.gameObject.SetActive(true);

        _spellCheckbox.Set(true);
        LevelPlayerHelpersLoader.Current.spellUse = true;
        PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseSpellSave, true ? 1 : 0);
        PlayerPrefs.SetInt("LevelEasyMod", mainscript.CurrentLvl);
        PPSerialization.Save<SaveData>("auto_helper", saveData);
        UpdateVip();
        StartCoroutine(_Timer());
    }

    public void Buy()
    {
        AnalyticsController.Instance.LogMyEvent("SpellPressUnlocked_money");
        if (DebugButtons.Instance == null)
            Purchaser.Instance.BuyAutoPick();
        else
        {
            saveData.auto_pick_purchase = "1";
            PPSerialization.Save<SaveData>("auto_helper", saveData);
            UpdateVip();
        }
    }

    private void ToggleCheckBoxMana()
    {
        LevelPlayerHelpersLoader.Current.manaUse = _manaCheckbox.GetValue;
        PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseManaSave, _manaCheckbox.GetValue ? 1 : 0);
    }

    private void ToggleCheckBoxHealth()
    {
        LevelPlayerHelpersLoader.Current.healthUse = _healthCheckbox.GetValue;
        PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseHealthSave, _healthCheckbox.GetValue ? 1 : 0);
    }

    private void ToggleCheckBoxPower()
    {
        LevelPlayerHelpersLoader.Current.powerUse = _powerCheckbox.GetValue;
        PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUsePowerSave, _powerCheckbox.GetValue ? 1 : 0);
    }

    private void ToggleCommon()
    {
        LevelPlayerHelpersLoader.Current.manaUse = _commonToogle.GetValue;
        PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseManaSave, _commonToogle.GetValue ? 1 : 0);
        LevelPlayerHelpersLoader.Current._Update();
    }

    public static bool IsActive()
    {
        return LevelPlayerHelpersLoader.Current.manaUse || LevelPlayerHelpersLoader.Current.spellUse;
    }

    private void ToggleCheckBoxSpell()
    {
        LevelPlayerHelpersLoader.Current.spellUse = _spellCheckbox.GetValue;
        PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseSpellSave, _spellCheckbox.GetValue ? 1 : 0);
        AnalyticsController.Instance.LogMyEvent(_spellCheckbox.GetValue ? "PressSwitchMagic_On" : "PressSwitchMagic_Off");
        if (_spellCheckbox.GetValue)
            PlayerPrefs.SetInt("LevelEasyMod", mainscript.CurrentLvl);
        if (_spellCheckbox.GetValue && ShotController.Current.GetCount() >= 4)
        {
            for (int i = 0; i < panelBackgroud.Length; i++)
            {
                panelBackgroud[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(3000, 0);
            }
            uiAutoHelperPickSpells.ShowSpellSlots(this);
        }
    }
    public void OnScale()
    {
        foreach (var o in btnsSize)
            o.SetTrigger("play");
    }

    public void CloseSpeels()
    {
        for (int i = 0; i < panelBackgroud.Length; i++)
        {
            panelBackgroud[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
    }

    private void ToggleCheckBoxSpeed(bool on)
    {
        if (on)
        {
            LevelSettings.Current.usedGameSpeed = LevelSettings.Current.increasedUsedSpeed;
            PlayerPrefs.SetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 1);
        }
        else
        {
            LevelSettings.Current.usedGameSpeed = LevelSettings.defaultUsedSpeed;
            PlayerPrefs.SetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0);
        }

    }

    private void Update()
    {
        Time.timeScale = 0;
    }

    public void Bought()
    {
        UpdateVip(false);
    }

    public Toggle GetHPCheckbox()
    {
        return healthCheckbox;
    }
    public Toggle GetManaCheckbox()
    {
        return manaCheckbox;
    }
    public Toggle GetHealthCheckbox()
    {
        return healthCheckbox;
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dtDateTime;
    }
}