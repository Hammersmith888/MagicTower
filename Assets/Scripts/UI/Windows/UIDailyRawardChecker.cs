using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDailyRawardChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject dailyRewardWindow;
    private CurrentTimeScript timer;

    void Awake()
    {
        timer = GetComponent<CurrentTimeScript>();
    }

    IEnumerator Start()
    {
        PlayerPrefs.SetInt("Application_launch", 1);
        dailyRewardWindow.SetActive(false);
        if (PlayerPrefs.GetInt("Application_launch") < 1)
        {
            if (SceneManager.GetActiveScene().name != "Map")
            {
                yield break;
            }
            else
            {
                PlayerPrefs.SetInt("Application_launch", 1);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Map")
        {
            StartMapTutor();
            yield break;
        }
        InnerPush();
        //dailyRewardWindow.SetActive( true );

        yield return null;
    }

    private void InnerPush()
    {
        if (PlayerPrefs.GetInt("last_daily_push", 0) != System.DateTime.Now.ToUniversalTime().Day)
        {
            //PlayerPrefs.SetString( "DailyRewardOneSignalPushDate", System.DateTime.Now.AddDays( 1 ).ToString( "U" ) );
            if (UISettingsPanel.SettingsGame.NotificationsIsOn)
            {
               // Notifications.LocalNotificationsController.instance.StartDailyRewardNotification();
            }
            //OneSignalController.instanse.startDailyRewardNotification (PlayerPrefs.GetString ("DailyRewardOneSignalPushDate"));
            PlayerPrefs.SetInt("last_daily_push", System.DateTime.Now.ToUniversalTime().Day);
            PlayerPrefs.Save();
        }
    }

    public void HardShowDailies()
    {
        UIDailyRewardController.SHOW_FOR_TEST = true;
        dailyRewardWindow.SetActive(true);
    }

    //IEnumerator GetTime( )
    //{
    //	drc.currentDate = UnbiasedTime.Instance.Now();
    //	dailyRewardWindow.SetActive( true );
    //	InnerPush();
    //	yield break;

    //	/*WWW www = new WWW("https://time.gov/HTML5/actualtime.cgi?lzbc=siqm9b");
    //       yield return www;

    //       if (String.IsNullOrEmpty(www.error))
    //       {
    //           string time = Regex.Match(www.text, @"(?<=\btime="")[^""]*").Value;
    //           double milliseconds = Convert.ToInt64(time) / 1000.0;
    //           drc.currentDate = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds);
    //           showDailyRewards = true;
    //		dailyRewardWindow.SetActive(true);
    //		InnerPush ();
    //       }*/

    //}

    public void StartMapTutor()
    {
        Tutorials.Tutorial_4 mapTutor = GameObject.FindObjectOfType<Tutorials.Tutorial_4>();
        if (mapTutor != null)
        {
            mapTutor.StartTutor();
        }
    }
}
