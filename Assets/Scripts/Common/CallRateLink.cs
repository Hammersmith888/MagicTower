using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using I2.Loc;
using System.Collections;
using Tutorials;

public class CallRateLink : MonoBehaviour
{
    public static CallRateLink instance;

    public GameObject panel, panelAward;
    public GameObject[] awards;
    public Text text;

    public int _level;
    public UIConsFlyAnimation coinsFly, spinFly;
    public Transform targetCoins, targetSpin;

    public Button btnSpin;

    void Awake()
    {
        instance = this;
    }


    public static void Open(int l = -1)
    {
        int level = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0);

        SaveManager.ProfileSettings profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings.ToString());

        instance._level = level;
        Debug.Log($"Rate us: {level}");
        var rate = PPSerialization.GetJsonDataFromPrefs("ratethegame");
        if (rate != "1" && level == 6 ||
            rate != "1" && level == 15 ||
            rate != "1" && level == 30 ||
            rate != "1" && level == 45 ||
            rate != "1" && level == 60 ||
            rate != "1" && level == 70
            )
        {
            AnalyticsController.Instance.LogMyEvent("RateUsClicked_" + level);
            OpenPanel();
        }
    }

    public static void Open()
    {
        instance.panel.SetActive(true);
        instance.OpenRate();
    }
    public static void OpenLate(float t)
    {
        instance.StartCoroutine(instance._Late(t));  
    }
    IEnumerator _Late(float t)
    {
        yield return new WaitForSeconds(t);
        instance.panel.SetActive(true);
        instance.OpenRate();
    }

    private static void OpenPanel()
    {
        instance.OpenAward();
    }

    public void OpenRate()
    {
        //var str = new string[] { "t_0573", "t_0646" };
        instance.panel.SetActive(true);
        //instance.text.text = TextSheetLoader.Instance.GetString(str[Random.Range(0, str.Length)]);
    }

    public void OpenAward()
    {
        //if(SaveManager.GameProgress.Current.CompletedLevelsNumber >= 30)
        //{
        //    StartCoroutine(_OpenRate());
        //    return;
        //}
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 6 || SaveManager.GameProgress.Current.CompletedLevelsNumber == 15
            || SaveManager.GameProgress.Current.CompletedLevelsNumber == 45 || SaveManager.GameProgress.Current.CompletedLevelsNumber == 70
            || SaveManager.GameProgress.Current.CompletedLevelsNumber == 95 ||
             SaveManager.GameProgress.Current.CompletedLevelsNumber == 60)
        {
            OpenRate();
            return;
        }
        instance.panelAward.SetActive(true);
        foreach (var o in awards)
            o.SetActive(false);

        //PlayerPrefs.SetInt("rate_award", PlayerPrefs.GetInt("rate_award") == 0 ? 1 : 0);
        PlayerPrefs.SetInt("rate_award", 1);
        awards[PlayerPrefs.GetInt("rate_award")].SetActive(true);
    }

    IEnumerator _OpenRate()
    {
        yield return new WaitForSecondsRealtime(4);
        OpenRate();
    }

    public void TakeAward()
    {
        panelAward.SetActive(false);
        Tutorial.OpenBlock();
        StartCoroutine(_TakeAward());
        SoundController.Instanse.buyCoinsSFX.Play();

    }

    IEnumerator _TakeAward()
    {
        //yield return new WaitForSecondsRealtime(2f);
        if (PlayerPrefs.GetInt("rate_award") == 0)
        {
            CoinsManager.AddCoinsST(3000);
            coinsFly.PlayEffect(targetCoins.position);
            yield return new WaitForSecondsRealtime(1.5f);
            Tutorial.Close();
        }
        if (PlayerPrefs.GetInt("rate_award") == 1)
        {
            spinFly.PlayEffect(targetSpin.position);
            TutorialDailySpin.spinClose = 1;
            Tutorial.Close();

            var o = Tutorial.Open(target: btnSpin.gameObject, focus: new Transform[] { btnSpin.transform }, mirror: true, rotation: new Vector3(0, 0, -70), offset: new Vector2(60, 90), waiting: 1.5f);
            //o.disableAnimation = true;
            //o.dublicateObj = false;
            //o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            btnSpin.GetComponent<Button>().onClick.AddListener(() => {
                Tutorial.Close();
            });
            UIDailySpin.Current.ResetDailyItem();
            SaveManager.GameProgress.Current.countFreeSpin = 3;
            SaveManager.GameProgress.Current.Save();
            UIDailySpinActivator.Current.UpdateBadge();
        }

        while (TutorialDailySpin.spinClose == 1)
            yield return new WaitForSecondsRealtime(0.5f);
        OpenRate();
    }

    public void Rate(int click)
    {
        try
        {
            if (click == 0)
            {
                // rate
                PPSerialization.Save("ratethegame", "1");
                Application.OpenURL("market://details?id=com.akpublish.magicsiege");
                AnalyticsController.Instance.LogMyEvent("RateUs", new Dictionary<string, string>() {
                                        { "level", _level.ToString() },
                                        { "action", "toStore" }
                                    });
            }
            if (click == 1)
            {
                // don`t show
                PPSerialization.Save("ratethegame", "1");
                AnalyticsController.Instance.LogMyEvent("RateUs", new Dictionary<string, string>() {
                                        { "level", _level.ToString() },
                                        { "action", "later" }
                                    });
            }
            if (click == 2)
            {
                // later
                AnalyticsController.Instance.LogMyEvent("RateUs", new Dictionary<string, string>()
            {
                                            { "level", _level.ToString() },
                                            { "action", "no" }
                                        });
            }
        }
        catch (System.Exception) { panel.SetActive(false); }

        panel.SetActive(false);
    }


#if UNITY_EDITOR
    [SerializeField]
    private bool showWindow_Editor;
    private void OnDrawGizmosSelected()
    {
        if (showWindow_Editor)
        {
            showWindow_Editor = false;
            (Instantiate(Resources.Load("UI/RateUsWindow"), transform.parent) as GameObject).transform.SetAsLastSibling();
        }
    }
#endif
}
