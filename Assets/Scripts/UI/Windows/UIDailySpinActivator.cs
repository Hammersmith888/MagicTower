using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDailySpinActivator : MonoBehaviour
{
    [SerializeField]
    private UIDailySpin mainScript;
    public Text nextTimeFreeText;

    private bool startTimer;
    private TimeSpan timeSpan;
    private UIDailySpin.DailyItem dailyItem;
    public Text badge;

    public static UIDailySpinActivator Current;

    public static void RestartTimer()
    {
        if (Current != null)
        {
            Current.RestartTimerInternal();
        }
    }


    public void UpdateBadge()
    {
        badge.text = SaveManager.GameProgress.Current.countFreeSpin.ToString();
        badge.transform.parent.gameObject.SetActive(SaveManager.GameProgress.Current.countFreeSpin > 0);
        UIDailySpin.Current.UpdateBadge();
    }

    private void Start()
    {
        Current = this;
        //int lastLevel = gameProgress.finishCount.Count(i => i > 0) - 1;
        int lastLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        if (lastLevel < 1)
        {
            gameObject.SetActive(false);
            return;
        }
        RestartTimerInternal();
        UpdateBadge();
    }

    public void CallWindow()
    {
        mainScript.OnOpen();
        //UIDailySpin.Current.bigStopButton = GameObject.Find("ButtonStop");
        UIDailySpin.Current.CheckIfCanStop();
        if (!PlayerPrefs.HasKey("FirstSpinPopUp"))
        {
            PlayerPrefs.SetInt("FirstSpinPopUp", 1);
            try
            {
                FindObjectOfType<Tutorial>().mainPanel.SetActive(false);
                FindObjectOfType<Tutorial>().panelText.SetActive(false);
            }
            catch (Exception) { }
        }
    }

    private void RestartTimerInternal()
    {
        startTimer = true;
        dailyItem = PPSerialization.Load<UIDailySpin.DailyItem>("DailySpin");
        gameObject.SetActive(true);
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        CountDownTimer();
        if (startTimer)
        {
            WaitForSeconds wait = new WaitForSeconds(1.0f);
            while (startTimer)
            {
                yield return wait;
                CountDownTimer();
            }
        }
    }

    private void CountDownTimer()
    {
        if (nextTimeFreeText == null)
            nextTimeFreeText = transform.GetChild(1).gameObject.GetComponent<Text>();

        if (dailyItem != null)
        {
            timeSpan = dailyItem.UnlockNextTime - UnbiasedTime.Instance.Now();  //ts.Subtract( TimeSpan.FromSeconds( 1 ) );
        }
        else
        {
            timeSpan = TimeSpan.Zero;
        }
        if (timeSpan.Ticks <= 0)
        {
            startTimer = false;
            timeSpan = TimeSpan.Zero;
            nextTimeFreeText.text = TextSheetLoader.Instance.GetString("t_0612");
            return;
        }
        int hours = (int)timeSpan.TotalHours;
        int mins = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        nextTimeFreeText.text = (hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2"));
    }

}
