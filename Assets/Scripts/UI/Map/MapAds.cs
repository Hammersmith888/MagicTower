using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class MapAds : MonoBehaviour
{
    [SerializeField]
    GameObject panel, btnWait, panelMain, badge, imgView, imgCoin, btnAds;
    [SerializeField]
    Text btnText, coinText, replicaText, timerText, badgeText;
    [SerializeField]
    Button btnTake;
    [SerializeField]
    Transform parentCoins;
    [SerializeField]
    UIConsFlyAnimation flyCoins;
    [SerializeField]
    int[] coinsAward;

    [SerializeField]
    RectTransform rectCoin, rectReplica;

    bool effect = false;
    int coinsEffect, startCoins;
    [SerializeField]
    float speedEffect = 1;
    private bool startTimer;
    private TimeSpan timeSpan = new TimeSpan();

    bool isTimer = false;
    AdsMap timer = new AdsMap();
    bool close = true;

    public bool isShow = false;
    bool newLevel = false;

    public static MapAds instance;

    [SerializeField]
    RectTransform rectPanel;
    [SerializeField]
    GameObject replica;
    [SerializeField]
    GameObject btnOk;
    [SerializeField]
    Transform coinImgTransform;

    void Awake()
    {
        instance = this;
        badge.transform.parent.gameObject.SetActive(false);
    }

    [Serializable]
    public class AdsMap
    {
        public SerializedToStringDateTime UnlockNextTime;

        override public string ToString()
        {
            return string.Format("UnlockNextTime: {0}", UnlockNextTime);
        }
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {

        if (String.IsNullOrEmpty(PPSerialization.GetJsonDataFromPrefs("AdsMapCurrent")))
            PPSerialization.Save("AdsMapCurrent", "0");

        try
        {
            timer = PPSerialization.Load<AdsMap>("AdsMapWatch");
            if (timer == null)
            {
                PPSerialization.Save("AdsMapWatch", new AdsMap { UnlockNextTime = UnbiasedTime.Instance.Now() });
                timer = PPSerialization.Load<AdsMap>("AdsMapWatch");
                Debug.Log("New timer: " + timer);
            }
        }
        catch
        {
            PPSerialization.Save("AdsMapWatch", new AdsMap { UnlockNextTime = UnbiasedTime.Instance.Now() });
            timer = new AdsMap { UnlockNextTime = UnbiasedTime.Instance.Now() };
            Debug.Log("New timer");
        }

        // PPSerialization.Save("AdsMapCurrent", "0");
        //int lastLevel = gameProgress.finishCount.Count(i => i > 0) - 1;
        int lastLevel = SaveManager.GameProgress.Current.CompletedLevelsNumber;
        if (lastLevel < 2)
        {
            badge.transform.parent.transform.parent.gameObject.SetActive(false);
            yield break;
        }

        badge.SetActive(false);
        timerText.transform.parent.gameObject.SetActive(false);
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber >= 2)
        {
            if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 3)
            {
                yield return new WaitForSecondsRealtime(4);
                btnAds.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
            }
            if(SaveManager.GameProgress.Current.CompletedLevelsNumber > 3)
                btnAds.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
        }

        yield return new WaitForSecondsRealtime(0.5f);
        startTimer = true;
        RestartTimerInternal();
        UpdateDate();
        yield return new WaitForSecondsRealtime(2f);
        if (!newLevel)
            badge.transform.parent.gameObject.SetActive(true);
    }



    void UpdateDate()
    {
        var cur = PPSerialization.GetJsonDataFromPrefs("AdsMapCurrent");
        if (!Application.isEditor)
        {
            //if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
            badge.SetActive(cur == "0" && !isTimer || cur == "1" || cur == "2");
        }
        else
            badge.SetActive(cur == "0" && !isTimer || cur == "1" || cur == "2");
        timerText.transform.parent.gameObject.SetActive(!badge.activeSelf && cur == "4");
        badgeText.text = cur == "0" ? "2" : "1";

        //= badge.activeSelf;
        //btnAds.GetComponent<Animator>().enabled 
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber >= 2)
        {
            if (SaveManager.GameProgress.Current.CompletedLevelsNumber == 3)
            {
                StartCoroutine(waitFirstWallOffer());
            }
            if(SaveManager.GameProgress.Current.CompletedLevelsNumber > 3)
                btnAds.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
        }
        // btnAds.SetActive(timerText.transform.parent.gameObject.activeSelf);
    }

    IEnumerator waitFirstWallOffer()
    {
        yield return new WaitForSecondsRealtime(4);
        btnAds.SetActive(ADs.AdsManager.Instance.isAnyVideAdAvailable);
    }



    public void OpenPanel()
    {
        if (replica == null)
        {
            replica = FindObjectOfType<ReplicaUI>().gameObject;
        }

        if (!Application.isEditor)
        {
            if (!ADs.AdsManager.Instance.isAnyVideAdAvailable)
            {
                panelMain.SetActive(false);
                btnWait.SetActive(true);
                return;
            }
        }
        var cur = PPSerialization.GetJsonDataFromPrefs("AdsMapCurrent");
        rectCoin.gameObject.SetActive(false);
        btnTake.gameObject.SetActive(false);
        btnOk.SetActive(false);
        replica.GetComponent<Animator>().Play(0);
        StartCoroutine(_Open(cur));
        Debug.Log("Ads MAP: " + cur);
        rectReplica.anchoredPosition = new Vector2(rectReplica.anchoredPosition.x, -86f);
        panel.SetActive(true);
        panelMain.SetActive(cur != "4");
        //btnWait.SetActive(cur == "4");
        btnText.text = TextSheetLoader.Instance.GetString(cur == "0" || cur == "2" ? "t_0565" : "t_0566");
        replicaText.text = TextSheetLoader.Instance.GetString(cur == "0" ? "t_0567" : "t_0568");
        if (cur == "4")
            replicaText.text = TextSheetLoader.Instance.GetString("t_0569");
        replicaText.text = replicaText.text.Replace("/n", System.Environment.NewLine);
        coinText.text = cur == "0" || cur == "1" ? coinsAward[0].ToString() : coinsAward[1].ToString();
        Debug.Log("COINS: " + coinsAward[0].ToString() + ", sad: " + coinText.text);
        imgView.SetActive(cur == "0" || cur == "2");
        imgCoin.SetActive(cur == "1" || cur == "3");
        btnTake.interactable = true;
        rectPanel.anchoredPosition = new Vector2(rectPanel.anchoredPosition.x, (imgCoin.activeSelf && cur != "4" ? 2f : -61f));
        replica.SetActive(imgView.activeSelf || cur == "4");
        if (cur == "4")
            rectReplica.anchoredPosition = new Vector2(rectReplica.anchoredPosition.x, -159f);

       
    }
    IEnumerator _Open(string cur)
    {
        if (cur != "4")
        {
            yield return new WaitForSecondsRealtime(0.2f);
            rectCoin.gameObject.SetActive(true);
            rectCoin.gameObject.GetComponent<Animator>().Play(0);
            if (cur == "0" || cur == "2")
            {
                yield return new WaitForSecondsRealtime(0.2f);
                btnTake.gameObject.SetActive(true);
                btnTake.gameObject.GetComponent<Animator>().Play(0);
            }
        }
        else
        {
            yield return new WaitForSecondsRealtime(0.6f);
            btnOk.SetActive(true);
            btnOk.GetComponent<Animator>().Play(0);
        }
    }


    public void PlayBoss(int t, bool newLevel = false)
    {
        this.newLevel = newLevel;
        if (t == 1)
        {
            badge.transform.parent.gameObject.SetActive(true);
        }
    }

    public void StartView()
    {
        var cur = PPSerialization.GetJsonDataFromPrefs("AdsMapCurrent");
        if (cur == "1" || cur == "3")
        {
            var cc = "";
            if (cur == "3")
                cc = "4";
            if (cur == "1")
                cc = "2";
            PPSerialization.Save("AdsMapCurrent", cc);

            var coins = cur == "1" ? coinsAward[0] : coinsAward[1];
            CoinsManager.AddCoinsST(coins);
            AnalyticsController.Instance.CurrencyAccrual(coins, DevToDev.AccrualType.Earned);

            rectCoin.anchoredPosition = new Vector2(rectCoin.anchoredPosition.x, 36f);
            flyCoins.transform.position = coinImgTransform.position;
         
            var parent = parentCoins.transform.parent;
            parentCoins.SetParent(panel.transform);
           
            //btnTake.interactable = false;
            btnTake.gameObject.SetActive(false);
            coinsEffect = startCoins = coins;
            StartCoroutine(_Effect(parent));
            return;
        }

        if (!Application.isEditor)
        {
            if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
            {
                ADs.AdsManager.ShowVideoAd((bool result) =>
                {
                    if (result)
                    {
                        Debug.Log("PressedVideo: View");
                        isShow = true;
                        StartCoroutine(_Finish());
                    }
                });
            }
            else
            {
                Debug.Log("PressedVideo: NoVideoAvailable");
            }
        }
        else
        {
            isShow = true;
            StartCoroutine(_Finish());
        }
    }

    IEnumerator _Effect(Transform parent)
    {
        rectCoin.anchoredPosition = new Vector2(rectCoin.anchoredPosition.x, 36f);
        flyCoins.transform.position = coinImgTransform.position;
        var target = parentCoins.Find("CoinTargetEffect").transform;
        yield return new WaitForSecondsRealtime(2f);
        effect = true;
        flyCoins.PlayEffect(target.position);

        close = false;
        while (effect)
            yield return null;

        yield return new WaitForSecondsRealtime(0.1f);
        Debug.Log("============== _Effect");
        coinText.text = 0.ToString();
        parentCoins.SetParent(parent);
        OpenPanel();
        close = true;
        //btnTake.interactable = true;
        rectCoin.anchoredPosition = new Vector2(rectCoin.anchoredPosition.x, 125f);
        //btnTake.gameObject.SetActive(true);
    }

    void Update()
    {
        if (effect)
        {
            coinsEffect -= (int)((startCoins / 500) / speedEffect);
            coinText.text = coinsEffect.ToString();
            if (coinsEffect <= 150)
            {
                coinText.text = 0.ToString();
                effect = false;
            }
        }
    }

    public void Close()
    {
        if (close)
            panel.SetActive(false);
    }

   
    public void Finish()
    {
        StartCoroutine(_Finish());
    }

    IEnumerator _Finish()
    {
        if (!isShow)
            yield break;
        var cur = PPSerialization.GetJsonDataFromPrefs("AdsMapCurrent");
        string cc = "0";
        if (cur == "3")
            cc = "4";
        if (cur == "2")
        {
            cc = "3";
            timer.UnlockNextTime = UnbiasedTime.Instance.Now() + TimeSpan.FromMinutes(!Application.isEditor ? 7 : 1);
            PPSerialization.Save("AdsMapWatch", timer);
        }
        if (cur == "1")
            cc = "2";
        if (cur == "0")
        {
            cc = "1";
            timer.UnlockNextTime = UnbiasedTime.Instance.Now() + TimeSpan.FromMinutes(!Application.isEditor ? 5 : 1);
            PPSerialization.Save("AdsMapWatch", timer, true, true);
        }
        Debug.Log("_Finish VIDEO");
        PPSerialization.Save("AdsMapCurrent", cc);
        isShow = false;
        OpenPanel();
        StartView();
        yield return new WaitForSeconds(2);
    }

   
    private void RestartTimerInternal()
    {
        startTimer = true;
        timer = PPSerialization.Load<AdsMap>("AdsMapWatch");
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        CountDownTimer();
        if (startTimer)
        {
            while (startTimer)
            {
                yield return new WaitForSecondsRealtime(1f);
                CountDownTimer();
            }
        }
    }

    private void CountDownTimer()
    {
        UpdateDate();
        var timeSpan = timer.UnlockNextTime - UnbiasedTime.Instance.Now();  //ts.Subtract( TimeSpan.FromSeconds( 1 ) );
        isTimer = true;
        if (timeSpan.Ticks <= 0)
        {
            //startTimer = false;
            timeSpan = TimeSpan.Zero;
            isTimer = false;
            PPSerialization.Save("AdsMapCurrent", "0");
            return;
        }
        int hours = (int)timeSpan.TotalHours;
        int mins = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        timerText.text = (mins.ToString("D2") + ":" + seconds.ToString("D2"));
    }
}
