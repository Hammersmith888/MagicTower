using System;
using System.Collections;
using System.Collections.Generic;
using Notifications;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    [SerializeField]
    DailyRewardItem[] items;
    DailyRewardItem dailyRewardItem;
    [SerializeField]
    Text timerBtn, timerBntTake; 
    [SerializeField]
    Text textDay;

    [SerializeField] Button btnTake;
    [SerializeField] GameObject[] btnTakeText;

    [SerializeField] int testDay;
    [SerializeField] bool reset;
    int week, day;
    [SerializeField]
    GameObject panelReplica;
    [SerializeField]
    Text textReplica;

    [System.Serializable]
    public class Replicas
    {
        public string id;
        public string resourcesAudio;
        public float time;
    }
    [SerializeField]
    Replicas[] replicas;
    [SerializeField]
    AudioSource soundReplica, claimBtnSound, openPanelSound;
    [SerializeField]
    Tutorials.Tutorial_4 tutorial4;

    [SerializeField]
    GameObject panelMain, panelClaim;
    [SerializeField]
    Transform claimParentImg;
    GameObject objClaim;


    public UIConsFlyAnimation coinsFly;
    public Transform targetCoinsFly;
    public bool effectCoins = false;

    public bool debug = false;

    bool closePanel = false;
    
    [System.Serializable]
    public class SaveData
    {
        public string utcDailyReward;
        public string utcDailyRewardStart;
        public Dictionary<string,bool> _items = new Dictionary<string, bool>();
        public string items = "{}";


        public void SetItem(string key, bool value)
        {
            if (!_items.ContainsKey(key))
                _items.Add(key, value);
            else
                _items[key] = value;
          
            string json = LitJson.JsonMapper.ToJson(_items);
            items = json;
        }
        public void LoadItems()
        {
            var _it = LitJson.JsonMapper.ToObject(items);
            var keys = new List<string>(_it.Keys);
            _items.Clear();
            foreach (var o in keys)
            {
                _items.Add(o, bool.Parse(_it[o].ToString()));
            }
        }
    }

    public static SaveData saveData = new SaveData();

    private void Awake()
    {
        SoundController.Instanse.timerPlay = 2f;
        if (PPSerialization.Load<SaveData>("DailyReward") != null)
        {
            saveData = PPSerialization.Load<SaveData>("DailyReward");
            saveData.LoadItems();
        }
    }

    IEnumerator Start()
    {
        Debug.Log($"saveData.utcDailyReward: {saveData.utcDailyReward}");
        if (System.String.IsNullOrEmpty(saveData.utcDailyReward))
        {
            saveData.utcDailyReward = saveData.utcDailyRewardStart = "0";
        }

        var  utcStart = Int32.Parse(saveData.utcDailyRewardStart);
        Int32 unixTimestamp = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        var lastD = UnixTimeStampToDateTime(utcStart);
        var curD = UnixTimeStampToDateTime(unixTimestamp);

        int betwenDays = (curD - new DateTime(lastD.Year, lastD.Month, lastD.Day, 0,0,0)).Days;
        Debug.Log($"betwenDays: {betwenDays}");
        if (betwenDays >= 28)
        {
            //testDay = 0;
            betwenDays = 0;
            //saveData.utcDailyReward = saveData.utcDailyRewardStart = unixTimestamp.ToString();
        }

        
        day = testDay = betwenDays;
        textDay.text = (day + 1).ToString();
        
        while(true)
        {
            var utcSave = Int32.Parse(saveData.utcDailyReward);
            var next = UnixTimeStampToDateTime(utcSave);
            //Debug.Log($"next date: {next}, now: {UnbiasedTime.Instance.Now()}");
            TimeSpan t = next - UnbiasedTime.Instance.Now();
            int hours = (int)t.TotalHours;
            int mins = t.Minutes;
            int seconds = t.Seconds;
            timerBtn.text = (hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2"));
            timerBntTake.text = TextSheetLoader.Instance.GetString("t_0611") + System.Environment.NewLine + (hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2"));
            if (t.TotalSeconds < 0)
                timerBtn.text = TextSheetLoader.Instance.GetString("t_0612");
            yield return new WaitForSecondsRealtime(1f);
        }
        
    }

    public void Open()
    {
        saveData.LoadItems();
        Tutorial.Close();
        if (!debug)
        {
            Debug.Log($"utcDailyReward: {saveData.utcDailyReward}, saveData.utcDailyRewardStart: {saveData.utcDailyRewardStart}");
            Int32 unixTimestamp = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var curD = UnixTimeStampToDateTime(unixTimestamp);
            var utcSave = Int32.Parse(saveData.utcDailyReward);
            var utcStart = Int32.Parse(saveData.utcDailyRewardStart);
            var next = UnixTimeStampToDateTime(utcSave);
            var start = UnixTimeStampToDateTime(utcStart);
            TimeSpan t = new DateTime(next.Year, next.Month, next.Day, 0, 0, 0) - UnbiasedTime.Instance.Now();
            int betwenDays = (curD - new DateTime(start.Year, start.Month, start.Day, 0, 0, 0)).Days;
            Debug.Log($"curD: {curD}, next: {new DateTime(start.Year, start.Month, start.Day, 0, 0, 0)}");
            testDay = betwenDays;
        }
        day = testDay;

        Debug.Log($"day: {day}");
        if (day > 27)
        {
            reset = true;
            saveData = new SaveData();
            Int32 unixTimestamp = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            saveData.utcDailyReward = saveData.utcDailyRewardStart = unixTimestamp.ToString();
            
            foreach (var o in items)
            {
                o.Set(day, week, this);
                if (reset)
                    o.ResetSaves();
            }
            //saveData.LoadItems();
            PPSerialization.Save<SaveData>("DailyReward", saveData);
            
            StartCoroutine(Start());
            Open();
            return;
        }   
        week = Mathf.FloorToInt(testDay / 7f);
        foreach (var o in items)
        {
            o.Set(day, week, this);
            if (reset)
                o.ResetSaves();
        }
        if(reset)
        {
            //saveData.utcDailyReward = saveData.utcDailyRewardStart = "";
            //PPSerialization.Save<SaveData>("DailyReward", saveData);
        }
        dailyRewardItem = null;
        foreach (var o in items)
        {
            if(o.isReady)
            {
                dailyRewardItem = o;
                break;
            }
        }
        reset = false;
        btnTake.interactable = dailyRewardItem != null;
        btnTakeText[0].SetActive(btnTake.interactable);
        btnTakeText[1].SetActive(!btnTake.interactable);
        foreach (var o in items)
            o._Update(btnTake.interactable);
    }

    public void Take()
    {
        claimBtnSound.Play();
        AnalyticsController.Instance.LogMyEvent("DailyReward", new Dictionary<string, string>() {
            { "day", (day + 1).ToString() }
        });
        var d = UnbiasedTime.Instance.Now().AddDays(1);
        Debug.Log($"next daily reward: {d}");
        //DateTime newD = new DateTime(d.Year, d.Month, d.Day, 0,1,0);
        Int32 unixNext = (Int32)(d.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        //Int32 unixNow = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        //var sec = unixNext - unixNow;
        //Debug.Log($"second: {sec}");
        saveData.utcDailyReward = unixNext.ToString();

        ShowDailyReward();
        objClaim = dailyRewardItem.Take();
        PPSerialization.Save<SaveData>("DailyReward", saveData);
        closePanel = true;
        if(dailyRewardItem.date == 27 && dailyRewardItem.getRobe)
            StartCoroutine(_StartReplica(1));
        else if (dailyRewardItem.date == 27 || dailyRewardItem.date == 20 || dailyRewardItem.date == 13 || dailyRewardItem.date == 6 ||
           dailyRewardItem.date < 6 )
        {
            if (dailyRewardItem.date == 0)
                StartCoroutine(_StartReplica(0));
            else
            {
                int rand = UnityEngine.Random.Range(2, 5);
                StartCoroutine(_StartReplica(rand));
            }
        }
        
        timerBntTake.text = TextSheetLoader.Instance.GetString("t_0611");

        objClaim.transform.SetParent(claimParentImg);
        objClaim.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        objClaim.transform.localScale = Vector2.one;
        panelMain.SetActive(false);
        panelClaim.SetActive(true);
        
        Open();
    }

    static void ShowDailyReward(double seconds = 86400)
    {
        Debug.Log($"push free: {86400}");
        //Notifications.LocalNotificationsController.instance.ScheduleNotification(
        //    TextSheetLoader.Instance.GetString("t_0691"),
        //    TextSheetLoader.Instance.GetString("t_0692"),
        //    86400, "DailyReward");
    }

    IEnumerator _StartReplica(int index)
    {
        while(closePanel) // waiting when the panel claim will close
            yield return new WaitForSeconds(0.2f);

        SoundController.Instanse.StopMapSFX();
        panelReplica.gameObject.SetActive(true);
        textReplica.text = TextSheetLoader.Instance.GetString(replicas[index].id);
        soundReplica.clip = Resources.Load("Sounds/Replicas/"  + replicas[index].resourcesAudio) as AudioClip;
        soundReplica.Play();
        yield return new WaitForSecondsRealtime(replicas[index].time);
        panelReplica.gameObject.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSecondsRealtime(1.5f);
        panelReplica.SetActive(false);
        SoundController.Instanse.PlayMapSFX();
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dtDateTime;
    }

    public void Close()
    {
        if (TutorialsManager.IsTutorialActive(ETutorialType.DAILY_REWARD))
            TutorialsManager.OnTutorialCompleted();

        panelClaim.SetActive(false);
        panelMain.SetActive(true);
        if (objClaim != null)
            Destroy(objClaim);
    }

    public void CloseClaim()
    {
        closePanel = false;
        if(effectCoins)
            coinsFly.PlayEffect(targetCoinsFly.position);
      
        panelClaim.GetComponent<Animator>().SetTrigger("close");
        StartCoroutine(_Close());
    }

    IEnumerator _Close()
    {
        if (effectCoins)
        {
            for (int i = 0; i < 10; i++)
            {
                SoundController.Instanse.coinsScore.Play();
                yield return new WaitForSecondsRealtime(0.025f);
            }
        }
        else
            yield return new WaitForSecondsRealtime(0.25f);

        panelMain.SetActive(true);
        panelClaim.SetActive(false);
    }
}
