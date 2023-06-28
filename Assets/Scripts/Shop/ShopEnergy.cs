using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Notifications;

public class ShopEnergy : MonoBehaviour
{
    private const float ENERGY_SAVE_TO_CLOUD_INTERVAL = 10f;
    private const float UpdateUITimeInterval = 1f;

    #region VARIABLES
    public GameObject info; // Дополнительный экран информации
    public GameObject infos; // Родительский объект для информации об энергии
    public Transform energy_counter;
    public Image energy_sign_active;
    public Transform energy_elapsed_time;
    public float TimeToEnergyCharge;
    private int currentEnergy;
    [SerializeField]
    private Image[] energy_icons;
    public List<Sprite> energy_states;
    private float currentTime;

    private LivesManager _liveManager;
    private Text energy_counter_Label;
    private Text energy_elapsed_time_Label;
    private Text helperText1Lbl;
    private Text helperText2Lbl;

    private float nextTimeForEnergyIndicatorUpdate;

    private static bool isFullEnergySaved;
    private static float nextSaveToCloudTime;

    private GameObject infoButtonsBackObj;
    private GameObject getInfoButtonsBackGameObj
    {
        get
        {
            if (infoButtonsBackObj == null)
            {
                infoButtonsBackObj = infos.transform.Find("HorizontalLayout").gameObject;
            }
            return infoButtonsBackObj;
        }
    }

    [ SerializeField]
    private PoisonsManager resObj;

    [SerializeField]
    GameObject btnEnergy, hotOfferEnergy;

    #endregion

    private void Start()
    {
        CheckVideoAdsAble();
        _liveManager = LivesManager.Instance;
        if (TimeToEnergyCharge < 0.001f)
        {
            TimeToEnergyCharge = 900f;
        }
        energy_counter = transform.Find("Energy").transform.Find("value");
        energy_sign_active = transform.Find("Energy").transform.Find("active").GetComponent<Image>();

        energy_counter_Label = energy_counter.GetComponent<Text>();
        energy_elapsed_time_Label = energy_elapsed_time.GetComponent<Text>();
        helperText1Lbl = transform.Find("HelperText1").GetComponent<Text>();
        helperText2Lbl = transform.Find("HelperText2").GetComponent<Text>();

        if (mainscript.ZeroEnergy)
        {
            mainscript.ZeroEnergy = false;
            SendNotification();
            OpenInfo();
        }
        SetInfoEnergyIcons();
        energy_counter_Label.text = _liveManager.getCurrentLives().ToString();
    }

    void SendNotification()
    {
        //var sec = LocalNotificationsController.instance.CheckHowMuchSecondsTillTomorrow();
        //int id = Notifications.LocalNotificationsController.instance.ScheduleNotification(
        //   TextSheetLoader.Instance.GetString("t_0695"),
        //   TextSheetLoader.Instance.GetString("t_0696"),
        //   sec, "Energy");
        //PlayerPrefs.SetInt("push_energy", id);
    }

    public void CheckVideoAdsAble()
    {
        int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        if (openLevel < 8 || !ADs.AdsManager.Instance.isAnyVideAdAvailable)
        {
            GameObject videoBtn = getInfoButtonsBackGameObj.transform.Find("get_energy_video").gameObject;
            videoBtn.SetActive(false);
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ChangeEnergy(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ChangeEnergy(-1);
        }
#endif
        if (nextTimeForEnergyIndicatorUpdate < Time.time)
        {
            SetInfoEnergyIcons();
        }

        if(btnEnergy != null)
            btnEnergy.SetActive(!hotOfferEnergy.activeSelf);
    }

    private void SetInfoEnergyIcons()
    {
        nextTimeForEnergyIndicatorUpdate = Time.time + UpdateUITimeInterval;
        var currentEnergyData = SaveManager.Energy.Current;
        if (currentEnergyData != null)
        {
            currentTime = Time.realtimeSinceStartup;
            currentEnergy = _liveManager.getCurrentLives();
            energy_sign_active.enabled = (currentEnergy != 0);

            if (currentEnergy == LMConfig.BASIC_LIFE_SLOTS)
            {
                for (int i = 0; i < energy_icons.Length; i++)
                {
                    energy_icons[i].sprite = energy_states[energy_states.Count - 1];
                }
                currentEnergyData.timeStumpOnStartCharge = 0f;
                SaveEnergyData();
                energy_elapsed_time_Label.text = "";
                if (isFullEnergySaved)
                {
                    return;
                }
            }
            else
            {
                isFullEnergySaved = false;
                if (currentEnergyData.timeStumpOnStartCharge < 0.001f || currentEnergyData.timeStumpOnStartCharge > currentTime)
                {
                    currentEnergyData.timeStumpOnStartCharge = currentTime;
                    SaveEnergyData();
                }
                else
                {
                    if (currentEnergyData.timeStumpOnStartCharge + TimeToEnergyCharge <= currentTime)
                    {
                        //if (LocalNotificationsController.instance != null)
                        //    LocalNotificationsController.instance.Remove(PlayerPrefs.GetInt("push_InviteFriends"));
                        //currentEnergyData.timeStumpOnStartCharge += TimeToEnergyCharge;
                        bool toCloud = nextSaveToCloudTime <= Time.unscaledTime;
                        currentEnergyData.Change(1, toCloud);
                        if(toCloud)
                        {
                            nextSaveToCloudTime = Time.unscaledTime + ENERGY_SAVE_TO_CLOUD_INTERVAL;
                        }
                    }
                }
                
                RefreshEnergyRegenTimerUI();
                RefreshEnergyIconsUI();
            }

            energy_counter_Label.text = _liveManager.getCurrentLives().ToString();
            if (currentEnergy == LMConfig.BASIC_LIFE_SLOTS)
            {
                isFullEnergySaved = true;
            }
        }
    }

    private void SaveEnergyData()
    {
        if (nextSaveToCloudTime <= Time.unscaledTime)
        {
            nextSaveToCloudTime = Time.unscaledTime + ENERGY_SAVE_TO_CLOUD_INTERVAL;
            SaveManager.Energy.Current.Save(true);
        }
        else
        {
            SaveManager.Energy.Current.Save(false);
        }
    }

    private void RefreshEnergyRegenTimerUI()
    {
        string time_left_string;
        float total_time = (float)_liveManager.getRefillSecondsLeft();
        int minutes_left = (int)Mathf.Floor(total_time / 60f);
        total_time = total_time - ((float)(minutes_left)) * 60f;
        int seconds_left = (int)Mathf.Ceil(total_time);
        if (minutes_left < 10)
        {
            time_left_string = "0" + minutes_left.ToString();
        }
        else
        {
            time_left_string = minutes_left.ToString();
        }
        time_left_string += ":";
        if (seconds_left < 10)
        {
            time_left_string += "0" + seconds_left.ToString();
        }
        else
        {
            time_left_string += seconds_left.ToString();
        }

        if (currentEnergy == 0)
        {
            time_left_string = helperText1Lbl.text + " " + time_left_string;
        }

        energy_elapsed_time_Label.text = time_left_string + " " + helperText2Lbl.text;
    }

    private void RefreshEnergyIconsUI()
    {
        for (int i = 0; i < energy_icons.Length; i++)
        {
            if (i < currentEnergy)
            {
                energy_icons[i].sprite = energy_states[energy_states.Count - 1];
            }
            else
            {
                if (i == currentEnergy)
                {
                    int energy_state_id = (int)Mathf.Round((float)(energy_states.Count - 1) * (((int)_liveManager.getRefillSecondsLeft()) / LMConfig.REFILL_LIFE_SECONDS));
                    if (energy_state_id < energy_states.Count && energy_state_id >= 0)
                    {
                        energy_icons[i].sprite = energy_states[energy_state_id];
                    }
                }
                else
                {
                    energy_icons[i].sprite = energy_states[0];
                }
            }
        }
    }

    public void ChangeEnergy(int amount = 1)
    {
        Debug.Log($"ChangeEnergy: {amount}");
        //SaveManager.Energy.Current.Change(amount);
        if(amount < 0)
            _liveManager.canLooseLife();
        SetupInfoWindow(_liveManager.getCurrentLives());
    }

    private void SetupInfoWindow(int energy)
    {
        GameObject videoBtn = getInfoButtonsBackGameObj.transform.Find("get_energy_video").gameObject;

        infos.transform.Find("EnergyIcons").gameObject.SetActive(true);
        infos.transform.Find("FullText").gameObject.SetActive(energy >= LMConfig.BASIC_LIFE_SLOTS);

        //GameObject fbBtn = infos.transform.Find("get_energy_fb").gameObject;
        //fbBtn.SetActive(false);

        getInfoButtonsBackGameObj.SetActive(false);

        if (energy == 0)
        {
            getInfoButtonsBackGameObj.SetActive(true);
            infos.transform.Find("FullText").gameObject.SetActive(false);

            //fbBtn = infos.transform.Find("get_energy_fb").gameObject;
            //fbBtn.SetActive(false);

            videoBtn.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);

            infos.transform.Find("EnergyIcons").gameObject.SetActive(false);
            getInfoButtonsBackGameObj.transform.Find("RefillNow").gameObject.SetActive(true);
        }

    }

    [SerializeField]
    private GameObject energyPopup, energyPopupBack, infoPurchageGroup, resPurchage;

    public void RefilNow()
    {
        if (resObj.CurrentPotion > 0)
        {
            if (resObj != null)
                resObj.Save(PotionManager.EPotionType.Resurrection, resObj.CurrentPotion - 1);
            _liveManager.refillAllLives();
            SoundController.Instanse.playUseBottle2SFX();
            SetupInfoWindow(_liveManager.getCurrentLives());
            SetInfoEnergyIcons();
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.WalkingDead, 1);
            Achievement.AchievementController.Save();
        }
        else
        {
            if (energyPopup != null)
            {
                energyPopup.SetActive(false);
            }
            if (energyPopupBack != null)
            {
                energyPopupBack.SetActive(false);
            }
            if (infoPurchageGroup != null)
            {
                infoPurchageGroup.SetActive(true);
            }
            CloseInfo();
            if (resPurchage != null)
            {
                resPurchage.SetActive(true);
            }
        }
    }

    public void OpenInfo()
    {
        CheckVideoAdsAble();
        SetupInfoWindow(_liveManager.getCurrentLives());
        info.SetActive(true);
        infos.SetActive(true);
    }

    public void CloseInfo()
    {
        infos.SetActive(false);
        info.SetActive(false);
    }

    public void OpenVideoUrl()
    {
        if (!ADs.AdsManager.Instance.isAnyVideAdAvailable)
        {
            return;
        }
        ADs.AdsManager.ShowVideoAd((bool viewResult) =>
       {
           if(viewResult)
           {
               for (int i = 0; i < 3; i++)
               {
                   if (_liveManager.canRefillLives())
                       _liveManager.refillOneLife();
                   SetupInfoWindow(_liveManager.getCurrentLives());
               }
           }
       });

        //Application.OpenURL("http://youtube.com");
    }

    public void OpenFacebookUrl()
    {
        if (_liveManager.canRefillLives())
        {
            _liveManager.refillOneLife();
        }
        Application.OpenURL("http://facebook.com");
    }
}
