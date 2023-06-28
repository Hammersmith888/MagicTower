using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using JetBrains.Annotations;
using UnityEngine.UI;

public class SpecialOffer : MonoBehaviour
{
    [Serializable]
    public class Item
    {
        public bool enable = true;
        public GameObject prefab;
        public Transform targetFly;
        public int amount;
        public string type; // write wich type of item
        public int cost;
        public string idTimer;
        public int indexScroll = -1; // if -1 it`s disable option
        public DateTime time
        {
            get
            {
                if (!saveData._items.ContainsKey("timeroffer_" + idTimer))
                {
                    var t = UnbiasedTime.Instance.Now();
                    saveData.SetItem("timeroffer_" + idTimer, t.ToString());
                }
                if (saveData._items["timeroffer_" + idTimer] == "")
                {
                    var t = UnbiasedTime.Instance.Now();
                    saveData.SetItem("timeroffer_" + idTimer, t.ToString());
                }
                DateTime time;
                //Debug.Log(saveData._items["timeroffer_" + idTimer]);
                try
                {
                    time = DateTime.Parse(saveData._items["timeroffer_" + idTimer]);
                }
                catch (Exception)
                {
                    time = DateTime.Now;
                }
                return time;
            }
        }
        public string keyLocalization;
        public string typeBuy
        {
            get
            {
                if (!saveData._items.ContainsKey("countbuyoffer_" + idTimer))
                    saveData.SetItem("countbuyoffer_" + idTimer, "");
                return saveData._items["countbuyoffer_" + idTimer];
            }
        }

        public void SetCountBuy(string value)
        {
            saveData.SetItem("countbuyoffer_" + idTimer, value);
            PPSerialization.Save<SaveData>("special_offer", saveData, true, true);
        }

        public void SetTimer()
        {
            // время оффера бутылочек
            saveData.SetItem("timeroffer_" + idTimer, (UnbiasedTime.Instance.Now() + TimeSpan.FromMinutes(!Application.isEditor ? 5 : 1)).ToString());
            PPSerialization.Save<SaveData>("special_offer", saveData);
        }
        public void AddItem(int value)
        {
            SoundController.Instanse.PlayShopBuySFX();
            if (indexScroll == -1)
            {
                Potion_Items potionItems = new Potion_Items(PotionItem.PotionsNumber);
                for (int i = 0; i < potionItems.Length; i++)
                    potionItems[i] = new PotionItem();

                potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
                var x = 0;
                if (type == "power")
                    x = 2;
                if (type == "health")
                    x = 1;
                potionItems[x].count += value; // Изменяем объект в массиве зелий и сохраняем
                PPSerialization.Save(EPrefsKeys.Potions, potionItems);
                return;
            }
            Scroll_Items scrollItems = new Scroll_Items(ScrollItem.ItemsNumber);
            scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            var c = scrollItems[indexScroll].count + value; // Изменяем объект в массиве свитков и сохраняем
            scrollItems[indexScroll].count = c;

            PPSerialization.Save("Scrolls", scrollItems, true, true);
        }

        public void Reset()
        {
            saveData.SetItem("countbuyoffer_" + idTimer, "");
            saveData.SetItem("timeroffer_" + idTimer, "");
            PPSerialization.Save<SaveData>("special_offer", saveData, true, true);
        }
    }

    public class SaveData
    {
        public bool newStartOffer = false;
        public string offer_time;
        public int offer_type;
        public Dictionary<string, string> _items = new Dictionary<string, string>();
        public string items;
        public void SetItem(string key, string value)
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
            foreach (var o in keys)
                _items.Add(o, _it[o].ToString());
        }
    }

    public static SaveData saveData = new SaveData();

    public static SpecialOffer instance;
    public AudioSource soundOpen;

    void Awake()
    {
        saveData = PlayerPrefs.HasKey("SaveDataIsHere")
            ? PPSerialization.Load<SaveData>("special_offer")
            : new SaveData();

        if (saveData == null)
            saveData = new SaveData();

        PlayerPrefs.SetInt("SaveDataIsHere",1);
        instance = this;
        if (PPSerialization.Load<SaveData>("special_offer") != null)
        {
            saveData = PPSerialization.Load<SaveData>("special_offer");
            saveData.LoadItems();
        }
        
        //parentPanel = panelObj.transform.parent.gameObject.GetComponent<RectTransform>();
        startX = parentPanel.anchoredPosition.x;
    }


    [SerializeField]
    GameObject[] panel;
    [SerializeField]
    Text timerText;
    [SerializeField]
    List<Item> items = new List<Item>();
    [SerializeField]
    List<OfferItem> objs = new List<OfferItem>();
    DateTime timeOffer;
    private Scroll_Items scrollItems = new Scroll_Items(ScrollItem.ItemsNumber);
    [SerializeField]
    VerticalLayoutGroup[] layouts;
    [SerializeField]
    RectTransform panelHEader, panelObj;
    [SerializeField] RectTransform parentPanel;
    float startX;

    [SerializeField]
    GameObject fireworks;

    private bool startPush = false;

    public void Open()
    {
        if (PPSerialization.Load<SaveData>("special_offer") != null)
        {
            saveData = PPSerialization.Load<SaveData>("special_offer");
            saveData.LoadItems();
        }
        if (panelHEader != null)
            panelHEader.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        int openLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        if (openLevel <= 8)
        {
            Debug.Log($"special_offer _Open2: {openLevel}");
            StartCoroutine(_Open2());
            return;
        }

        if (!saveData.newStartOffer)
            StartCoroutine(SetBottleWindow());

        if (System.String.IsNullOrEmpty(saveData.offer_time) && saveData.offer_type == 0)
        {
            var t = UnbiasedTime.Instance.Now() + TimeSpan.FromMinutes(!Application.isEditor ? 30 : 6);
            saveData.offer_time = t.ToString();
            saveData.offer_type = 1;
            saveData.newStartOffer = false;
            PPSerialization.Save<SaveData>("special_offer", saveData);
        }
        timeOffer = GetTime();

        var timeSpan = timeOffer - UnbiasedTime.Instance.Now();
        foreach (var p in panel)
            p.SetActive(saveData.offer_type == 1 && timeSpan.Ticks > 0);

        scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);

        UpdateList();
        CloseItem();

        StartCoroutine(_Open());
    }

    private IEnumerator SetBottleWindow()
    {
        yield return new WaitForEndOfFrame();
        UIShop.Instance.ActiveBottleItems();
        panelHEader.anchoredPosition = new Vector3(panelHEader.anchoredPosition.x, 0);
    }

    public void UpdateList()
    {
        var dict = new Dictionary<string, List<Item>>();

        foreach (var o in items)
        {
            if (!dict.ContainsKey(o.type))
            {
                dict.Add(o.type, new List<Item>());
                dict[o.type].Add(o);
            }
            else
                dict[o.type].Add(o);
        }
        var keys = new List<string>(dict.Keys);
        foreach (var o in keys)
        {
            dict[o].Sort((x, y) => y.cost.CompareTo(x.cost));
            dict[o].Reverse();
            for (int i = 0; i < dict[o].Count; i++)
            {
                dict[o][i].enable = true;
                if (i > 0 && dict[o][i - 1].typeBuy != "2")
                {
                    dict[o][i].enable = false;
                    //Debug.Log($"i: {i}, type: {dict[o][i].type}, enable: {}");
                }
            }
        }

        for (int i = 0; i < objs.Count; i++)
        {
            if (items[i].enable && items[i].indexScroll != -1)
                items[i].enable = scrollItems[items[i].indexScroll].unlock;
            objs[i].Open(items[i], this);
        }
    }

    IEnumerator _Open()
    {
        foreach (var l in layouts)
            l.enabled = false;

        yield return new WaitForEndOfFrame();

        foreach (var l in layouts)
            l.enabled = true;

        yield return new WaitForEndOfFrame();

        panelHEader.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        panel[0].transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().spacing += 0.01f;
        if (!saveData.newStartOffer) //
        {
            var end = panelHEader.anchoredPosition = new Vector2(panelHEader.anchoredPosition.x, (panelObj.anchoredPosition.y) * -1);
            panelHEader.anchoredPosition = new Vector2(panelHEader.anchoredPosition.x, (panelObj.anchoredPosition.y - 140) * -1);
            saveData.newStartOffer = true;
            PPSerialization.Save<SaveData>("special_offer", saveData);

            yield return new WaitForSecondsRealtime(0.5f);


            var timer = 0f;
            while (timer <= 0.7f)
            {
                yield return new WaitForEndOfFrame();
                panelHEader.anchoredPosition = Vector2.Lerp(panelHEader.anchoredPosition, new Vector2(end.x, 0), Time.deltaTime * 5f);
                timer += Time.deltaTime;
                SoundController.Instanse.shopSFX.volume -= 0.01f;
            }

            if (soundOpen.enabled == true)
            {
                soundOpen.Play();
            }

            SoundController.Instanse.PlayShopBuySFX();
            while (SoundController.Instanse.shopSFX.volume < 1)
            {
                SoundController.Instanse.shopSFX.volume += 0.1f;
                yield return new WaitForSecondsRealtime(0.1f);
            }

        }
    }

    IEnumerator _Open2()
    {
        foreach (var p in panel)
            p.SetActive(false);
        foreach (var l in layouts)
            l.enabled = false;
        yield return new WaitForEndOfFrame();
        foreach (var l in layouts)
            l.enabled = true;
        yield return new WaitForEndOfFrame();

        //yield return new WaitForSecondsRealtime(2);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        //parentPanel.anchoredPosition = new Vector2(startX, parentPanel.anchoredPosition.y);

        panelHEader.gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }

    float timer = 0;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            foreach (var o in objs)
                o.CountDownTimer();
            timer = 1;
            CountDownTimer();
        }
    }

    public void CountDownTimer()
    {
        if (saveData == null || saveData.offer_time == "" || saveData.offer_time == null)
            return;
        TimeSpan timeSpan;
        try
        {
            timeSpan = DateTime.Parse(saveData.offer_time) - UnbiasedTime.Instance.Now();
        }
        catch(Exception)
        {
            timeSpan = DateTime.Now - UnbiasedTime.Instance.Now();
        }
        //Debug.Log($"tiks: {timeSpan.Ticks},special offer timer: {timeOffer}, type: {PPSerialization.GetJsonDataFromPrefs("offer_type")}");
        if (timeSpan.Ticks <= 0)
        {
            if (saveData.offer_type == 2)
            {
                ResetData();
            }
            if (saveData.offer_type == 1)
            {
                var time = GetTime();
                //Debug.Log($"saved time: {PPSerialization.GetJsonDataFromPrefs("offer_time")}, time end offer: {time}");
                var t = time + TimeSpan.FromMinutes(!Application.isEditor ? 2880 : 2); //2
                saveData.offer_time = t.ToString();
                saveData.offer_type = 2;
                PPSerialization.Save<SaveData>("special_offer", saveData);
                foreach (var p in panel)
                    p.SetActive(false);

                StartCoroutine(_Open());
            }
            return;
        }
        int hours = (int)timeSpan.TotalHours;
        int mins = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        //timerText.color = timeSpan.TotalSeconds > 10 ? Color.white : Color.red;

        if (timeSpan.TotalSeconds < 30 && !startPush)
        {
            startPush = true;
            timerText.color = Color.red;
            timerText.GetComponent<Animation>().enabled = true;
        }

        if (timeSpan.TotalSeconds <= 1)
        {
            StartCoroutine(FadeOutClock());
        }

        timerText.text = (hours.ToString("D2") + ":" + mins.ToString("D2") + ":" + seconds.ToString("D2"));
    }

    private DateTime GetTime()
    {
        DateTime time;
        try
        {
            time = DateTime.Parse(saveData.offer_time);
        }
        catch (Exception)
        {
            time = DateTime.Now;
        }
        return time;
    }
    private IEnumerator FadeOutClock()
    {
        Vector3 tempScaler = new Vector3(.05f,.05f);
        while (timerText.transform.localScale.x > .1f)
        {
            yield return new WaitForSeconds(.05f);
            timerText.rectTransform.localScale -= tempScaler;
        }
    }

    public void CloseItem()
    {
        var x = 0;
        foreach (var o in items)
        {
            if (o.typeBuy == "2")
                x++;
        }

        UpdateList();

        if (x >= items.Count)
        {
            foreach (var p in panel)
                p.SetActive(false);

            StartCoroutine(_Open());
        }
    }

    public void ResetData()
    {
        saveData.offer_time = "";
        saveData.offer_type = 0;
        PPSerialization.Save<SaveData>("special_offer", saveData);
        foreach (var i in items)
            i.Reset();
    }
}
