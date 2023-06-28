using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrownsController : MonoBehaviour
{
    public static CrownsController instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField]
    GameObject panel, victory;
    [SerializeField]
    CrownEffect[] crowns;
    int current;
    [SerializeField]
    AudioSource soundCrown;
    [SerializeField]
    Animator _animBagEffect;
    [SerializeField]
    Text textCurrentCrown, coins, coinsAward;
    [SerializeField]
    GameObject panelBag;
    public int money;
    public bool isWait = false;
    public bool isAward = false;
    public bool isAwardWait = false;
    private int test;
    int levelOnePerDay = 70;

    public bool isTimeToOpen = true;


    public void Calculate()
    {
        Int32 unixTimestamp = (Int32)(UnbiasedTime.Instance.Now().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        var utcStart = Int32.Parse(SaveManager.GameProgress.Current.crownsUtc);
        isTimeToOpen = true;
        if (mainscript.CurrentLvl >= levelOnePerDay)
        {
            if (unixTimestamp > utcStart)
                Calc();
            else
                isTimeToOpen = false;
        }
        else Calc();
       
    }

    void Calc()
    {
        isAward = false;
        SaveManager.GameProgress.Current.crownsCount++;
        var mon = SaveManager.GameProgress.Current.crownsMoney;
        current = SaveManager.GameProgress.Current.crownsCount;
        if (SaveManager.GameProgress.Current.crownsCount >= 2)
        {
            isAward = isAwardWait = true;
            current = 2;
            FinishMenu.instance.videoX2Coins += mon;
            //CoinsManager.AddCoinsST(mon);
            SaveManager.GameProgress.Current.crownsCount = -1;

            var nextMoney = (mon + 50);
            if (nextMoney >= 1500)
                nextMoney = 1500;
            var money = mon;
            SaveManager.GameProgress.Current.crownsMoney = nextMoney;
            FinishMenu.instance.lineCoins[3].text.text = money.ToString();
            Debug.Log($"calculate monet: {money}");
            var d = UnbiasedTime.Instance.Now().AddDays(1);
            var dd = new DateTime(d.Year, d.Month, d.Day, 0, 1, 0);
            Int32 unix = (Int32)(dd.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            SaveManager.GameProgress.Current.crownsUtc = unix.ToString();
            SaveManager.GameProgress.Current.Save();
        }
    }

    public void Open()
    {
        isWait = true;
        StartCoroutine(_Open());
    }

    IEnumerator _Open()
    {
        for (int i = 0; i < crowns.Length; i++)
        {
            //crowns[i].gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            // show opened yet
            crowns[i].gameObject.SetActive(i < current);
            if (crowns[i].gameObject.activeSelf)
                crowns[i].gameObject.GetComponent<Image>().color = Color.white;
        }
        var money = SaveManager.GameProgress.Current.crownsMoney;
        if (current >= 2)
            money -= 50;
        coins.text = coinsAward.text = money.ToString();
        textCurrentCrown.text = TextSheetLoader.Instance.GetString("t_0579") + " " + (current + 1) + "/3";
        yield return new WaitForSecondsRealtime(0.5f);
        panel.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        // current++;
        Debug.Log("current: " + current);
        crowns[current].Open();
        soundCrown.Play(150);
        textCurrentCrown.text = TextSheetLoader.Instance.GetString("t_0579") + " " + (current + 1) + "/3";
        if (current >= 2)
        {
            this.money = money;
            FinishMenu.instance.lineCoins[3].text.text = CrownsController.instance.money.ToString();
        }
        Save();
        yield return new WaitForSecondsRealtime(1f);
        if (current >= 2)
        {
            _animBagEffect.enabled = true;
            yield return new WaitForSecondsRealtime(1.5f);
            panelBag.SetActive(true);
            victory.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1500, victory.GetComponent<RectTransform>().anchoredPosition.y);
            panel.SetActive(false);
            //yield return new WaitForSecondsRealtime(5);
            //CloseAwardBag();
        }
        else
            isWait = false;
    }

    public void OpenBagAwardPanel()
    {
        var money = SaveManager.GameProgress.Current.crownsMoney;
        if (current >= 2)
            money -= 50;
        coins.text = coinsAward.text = money.ToString();
        panelBag.SetActive(true);
        panel.SetActive(false);
        victory.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1500, victory.GetComponent<RectTransform>().anchoredPosition.y);
    }

    public void CloseAwardBag()
    {
        if (panelBag.activeSelf)
        {
            panelBag.GetComponent<Animator>().Play("reverse");
            StartCoroutine(_Close());
        }
    }

    IEnumerator _Close()
    {
        FinishMenu.instance.CloseCrowns();
        yield return new WaitForSecondsRealtime(0.8f);
        panelBag.SetActive(false);
        victory.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, victory.GetComponent<RectTransform>().anchoredPosition.y);
        isWait = false;
        isAwardWait = false;

    }

    public void Save()
    {
        //PPSerialization.Save("crownsCount", current.ToString());
        //if (current >= 2)
        //{
        //    FinishMenu.instance.videoX2Coins += money;
        //    CoinsManager.AddCoinsST(money);
        //    PPSerialization.Save("crownsCount", "-1");
        //    var nextMoney = (money + 50);
        //    if (nextMoney >= 1500)
        //        nextMoney = 1500;
        //    PPSerialization.Save("crownsMoney", nextMoney.ToString());
        //}
    }
}
