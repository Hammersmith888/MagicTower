using ADs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    public static FinishMenu instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField]
    GameObject panelFinish, victory;
    [SerializeField]
    GameObject[] diffrents; // boss win or notd

    [Header("The first win at day")]
    [SerializeField]
    GameObject firstWin;
    [SerializeField]
    int awardWinFirstDay;
    [SerializeField]
    UIConsFlyAnimation dayFly;
    [SerializeField]
    Transform[] dayTarget;
    [SerializeField]
    Text coinsFirstWin, textLabelSuccess, valueSuccees, valueTotalText;
    [SerializeField]
    Transform lineTotal;
    bool countCoins = false;
    int startCoin = 0;
    public   UIGoldValueAnimator uiTotal, uiTotalDefeat;
    int valueTotal = -1;
    int levelGold = 0;

    public Button btnMap;

    [Serializable]
    public class AwardTriples
    {
        public string name;
        public GameObject prefab;
        public EPrefsKeys type;
        public int t;
    }

    AwardTriples GetObjAward(string name)
    {
        foreach (var o in awards)
        {
            if (o.name == name)
                return o;
        }
        return null;
    }

    void SetAwardFromAwards(EPrefsKeys type, int t, int count)
    {
        if (type == EPrefsKeys.Scrolls)
        {
            var _upgradeItems = PPSerialization.Load<Scroll_Items>(type.ToString());
            _upgradeItems[t].count += count;
            PPSerialization.Save(type.ToString(), _upgradeItems, true, true);
        }
        if (type == EPrefsKeys.Potions)
        {
            var _upgradeItems = PPSerialization.Load<Potion_Items>(type.ToString());
            _upgradeItems[t].count += count;
            PPSerialization.Save(type.ToString(), _upgradeItems, true, true);
        }
    }

    [SerializeField]
    List<AwardTriples> awards = new List<AwardTriples>();
    [SerializeField]
    GameObject[] panelsBoss;
    [SerializeField]
    Text[] textBottles;
    [SerializeField]
    Image[] imgBottles;
    [SerializeField]
    Button btnTake;
    bool takeAward = false;
    [SerializeField]
    Animator[] _anims;

    [SerializeField]
    GameObject btnX2;


    public int videoX2Coins;
    bool isWaitBag = false;
    bool boss = false;
    public AudioSource coinsAudio;


    [System.Serializable]
    public class LineCoins
    {
        public GameObject panel;
        public Transform targetCoins;
        public Text text;
    }
    public LineCoins[] lineCoins, lineCoinsDefeat;
    Coroutine openCoroutine;

    public UIControl uicontrol;
    public AudioSource nextPlay;
    public GameObject mapNext;
    public BuffsLoaderConfig buffsLoaderConfig;
    public Sprite[] gemsWhite;

    public Image[] btnx2Sprites;
    public Sprite x2Green, x2Gray, x2Default;
    public GameObject[] tips;


    public float indexSpeed = 1;
    public Animator[] _animators;

    bool allFinishPanels = false;
    bool isActiveX2 = true;

    public bool isWatchedVideo = false;

    public GameObject panelBlocker;

    [SerializeField] private GameObject PlayerArmature;
    [SerializeField] private GameObject PlayerStaff;

    private void Start()
    {
        foreach (var o in _animators)
            o.speed = indexSpeed;
    }

    public void Open(bool boss, int levelBoss)
    {
        PlayerArmature.layer = 8;
        if (PlayerStaff != null)
            PlayerStaff.layer = 8;

        if (UIAutoHelpersWindow.instance != null)
            UIAutoHelpersWindow.instance.gameObject.SetActive(false);
        openCoroutine = StartCoroutine(_Open(boss, levelBoss));
    }



    IEnumerator _Open(bool boss, int levelBoss)
    {
        ShotController.Current.SendUsedSpell();
        panelBlocker.SetActive(true) ;
        UIControl.countRestart = 0;
        int level = mainscript.CurrentLvl - 1;
        level = level < 0 ? 0 : level;  // fix this problem...
        if ((level + 1) % 6 == 0)
        {
            foreach (var o in btnx2Sprites)
            {
                o.sprite = x2Green;
                SpriteState ss = new SpriteState();
                ss.highlightedSprite = x2Green;
                ss.pressedSprite = x2Green;
                o.gameObject.GetComponent<Button>().spriteState = ss;
            }
        }

        UpdateBtnConnection();

        SoundController.Instanse.StopAllMusic();
        panelFinish.SetActive(true);
        victory.SetActive(true);
        diffrents[0].gameObject.GetComponent<Image>().enabled = !boss;
        diffrents[1].SetActive(boss);
       
        uiTotal.hidePanels = true;

        BloodEffect.instance.gameObject.SetActive(false);

        int toLevelCrown = 70; 
        lineTotal.GetComponent<Animator>().enabled = false;
    
        FinishMenu.instance.lineCoins[0].panel.SetActive(true);
        FinishMenu.instance.lineCoins[2].panel.SetActive(SaveManager.GameProgress.Current.finishCount[level] == 1);

        lineCoins[5].panel.SetActive(false);
        lineCoins[6].panel.SetActive(false);

        Text coinsTop = uiTotal.CoinsLevelTransform.GetComponent<Text>();
        int earngedGoldOnLevelWithoutMultiplicators = int.Parse(coinsTop.text);
        int earnedGold = Mathf.RoundToInt(earngedGoldOnLevelWithoutMultiplicators * uiTotal.levelSettings.goldenMageCoef);
        FinishMenu.instance.videoX2Coins += earnedGold;

        int healthGold = 0;
        int health = (int)uiTotal.levelSettings.playerController.CurrentHealth;
        if (health < 0)
        {
            health = 0;
        }
        healthGold = Mathf.RoundToInt(health * uiTotal.levelSettings.goldenMageCoef);
        FinishMenu.instance.videoX2Coins += healthGold;

        if (SaveManager.GameProgress.Current.finishCount[level] == 1)//Level was completed first time 
        {
            levelGold = LevelSettings.Current.GetGoldFromLevel(level);
            if (SaveManager.GameProgress.Current.VIP)
                levelGold = (int)(levelGold * 1.5f);
            if (levelGold == 0 && level == 0)
                levelGold = 1;

            var bottles = BalanceTables.Instance.BottlesWinParameters;
            var bottle = bottles[level].GetItems();
            if (bottle.Count > 0)
            {
                isActiveX2 = false;
                foreach (var o in panelsBoss)
                    o.SetActive(true);
                for (int i = 0; i < 3; i++)
                {
                    imgBottles[i].transform.parent.parent.gameObject.SetActive(false);
                }
                int num = 0;
                foreach (var item in bottle)
                {
                    textBottles[num].text = "x" + item.count.ToString();
                    GameObject obj = Instantiate(GetObjAward(item.name).prefab, imgBottles[num].transform) as GameObject;
                    imgBottles[num].transform.parent.parent.gameObject.SetActive(true);
                    num++;
                }
                StartCoroutine(_WaitBossPanel());
            }
            lineCoins[2].panel.transform.Find("Label").gameObject.GetComponent<Text>().text = TextSheetLoader.Instance.GetString(boss ? "t_0582" : "t_0581");
            lineCoins[2].text.text = levelGold.ToString();


            startCoin = levelGold;
            videoX2Coins += levelGold;
            if (boss && bottles[level].GetItems().Count > 0)
            {
                this.boss = boss;
                foreach (var o in _anims)
                    o.gameObject.SetActive(false);
            }
        }


        lineCoins[3].panel.SetActive(false);
        if(level <= toLevelCrown && SaveManager.GameProgress.Current.finishCount[level] == 1)
            CrownsController.instance.Calculate();
        lineCoins[3].panel.SetActive(CrownsController.instance.isAward && SaveManager.GameProgress.Current.finishCount[level] == 1);

        if (CrownsController.instance.isAward && SaveManager.GameProgress.Current.finishCount[level] == 1)
        {
            foreach (var o in btnx2Sprites)
            {
                o.sprite = x2Green;
                SpriteState ss = new SpriteState();
                ss.highlightedSprite = x2Green;
                ss.pressedSprite = x2Green;
                o.gameObject.GetComponent<Button>().spriteState = ss;
            }
        }

        float buffs = 0;
        int maxGemLvl = 0;
        Wear_Items wearItems = new Wear_Items(WearItem.ItemsNumber);
        wearItems = PPSerialization.Load<Wear_Items>("Wears");
        float isLuckyWearValue = 0;
        for (int i = 0; i < wearItems.Length; i++)
        {
            if(wearItems[i].active && wearItems[i].wearParams.wearType == WearType.cape)
            {
                foreach (var g in wearItems[i].wearParams.gemsInSlots)
                {
                    if (g.type == GemType.White && wearItems[i].wearParams.wearType == WearType.cape)
                    {
                        var b = buffsLoaderConfig.GetGemBuffInWear(g, wearItems[i].wearParams.wearType);
                        
                        buffs += b.buffValue / 100;
                        if (g.gemLevel > maxGemLvl)
                            maxGemLvl = g.gemLevel;
                    }
                }
                if (i == 10)
                    isLuckyWearValue = wearItems[i].wearParams.buffs[0].buffValue / 100;
                //Debug.Log($"i: {i} , wear: {wearItems[i].active}");
            }
        }
       
        //Debug.Log($"buffs: {buffs}");
        
        int allCoins = videoX2Coins;
        if (buffs > 0)
        {
            lineCoins[5].panel.SetActive(true);
            lineCoins[5].text.transform.parent.gameObject.GetComponent<Text>().text = "+" + (buffs * 100).ToString("F0") + "%";
            lineCoins[5].text.text = ((int)(allCoins * buffs)).ToString();
            lineCoins[5].panel.transform.Find("ParentGem").transform.Find("GemIcon").gameObject.GetComponent<Image>().sprite = gemsWhite[maxGemLvl];
            videoX2Coins += (int)(allCoins * buffs);
        }

        if (isLuckyWearValue > 0)
        {
            lineCoins[6].text.transform.parent.gameObject.GetComponent<Text>().text = "+" + (isLuckyWearValue * 100).ToString("F0") + "%";
            lineCoins[6].panel.SetActive(true);
            lineCoins[6].text.text = ((int)(allCoins * isLuckyWearValue)).ToString();
            videoX2Coins += (int)(allCoins * isLuckyWearValue);
        }

        Debug.Log($"====== ------ Finish count coins: {videoX2Coins} ------ ========");

        if (UIDoubleSpeedButton.instance != null)
        {
            if (UIDoubleSpeedButton.instance.countClick == 0)
                PlayerPrefs.SetInt("x2Speed", PlayerPrefs.GetInt("x2Speed") + 1);
            else
                PlayerPrefs.SetInt("x2Speed",0);
        }

        //if (FinishMenu.instance.videoX2Coins > 3200 && !boss)
        //{
        //    //Debug.Log("!btnX2.activeSelf");
        //    _anims[0].enabled = false;
        //    //var gr = mapNext.transform.parent.GetComponent<CanvasGroup>();
        //    //gr.alpha = 1;
        //    //gr.interactable = true;
        //    //gr.gameObject.SetActive(true);
        //    btnX2.SetActive(false);
        //    //btnX2.GetComponent<Button>().interactable = false;
        //}


        while (!uiTotal.initialAnimationComplete)
            yield return new WaitForSecondsRealtime(0.02f / indexSpeed);

        lineCoins[2].text.text = levelGold.ToString();
        yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
        lineCoins[2].panel.GetComponent<Animator>().enabled = true;
        yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
        uiTotal.SetGold(levelGold);

        if (CheckDay()) //Награда за первую победу дня
        {
            AnalyticsController.Instance.LogMyEvent("Player_got_first_win_of_day");

            videoX2Coins += awardWinFirstDay;

            coinsFirstWin.text = awardWinFirstDay.ToString();

            firstWin.SetActive(true);

            var cur = 0;
            var max = awardWinFirstDay;
            var all = awardWinFirstDay;
            var step = (awardWinFirstDay / 20);

            lineCoins[4].text.text = awardWinFirstDay.ToString("F0");

            yield return new WaitForSecondsRealtime(1.3f);
            dayFly.PlayEffect(dayTarget[0].position, lineCoins[4].targetCoins.position);

            for (int i = 0; i < 20; i++)
            {
                cur += step;
                lineCoins[4].text.text = cur.ToString("F0");
                all -= step;
                coinsFirstWin.text = all.ToString("F0");
                coinsAudio.Play();
                yield return new WaitForSecondsRealtime(0.03f);
            }
            coinsFirstWin.text = "0";
            lineCoins[4].text.text = (max).ToString("F0");

            yield return new WaitForSecondsRealtime(0.5f);
            lineCoins[4].panel.GetComponent<Animator>().enabled = true;

            yield return new WaitForSecondsRealtime(0.5f);
            uiTotal.SetGold(max);

            all -= step;
            coinsFirstWin.text = "0";

            var _a = firstWin.GetComponentsInChildren<Animator>();

            foreach (var a in _a)
                a.SetTrigger("Hide");
        }

        if (buffs > 0)
        {
            //Debug.Log("Show GEMS");
            yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
            lineCoins[5].panel.GetComponent<Animator>().enabled = true;
            yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
            uiTotal.SetGold((int)(allCoins * buffs));
        }

        if (isLuckyWearValue > 0)
        {
            //Debug.Log("Show WEAR");
            yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
            lineCoins[6].panel.GetComponent<Animator>().enabled = true;
            yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
            uiTotal.SetGold((int)(allCoins * isLuckyWearValue));
        }

        if (level <= toLevelCrown)
        {
            if (SaveManager.GameProgress.Current.finishCount[level] == 1 && CrownsController.instance.isAward)
            {
                CrownsController.instance.Open();
                victory.GetComponent<Animator>().Play("up");
            }
            while (CrownsController.instance.isWait && CrownsController.instance.isAward || isWaitBag && CrownsController.instance.isAward)
                yield return new WaitForSecondsRealtime(0.02f / indexSpeed);
        }

        //mapNext.SetActive(true);

        FireworksOnWinEffect.PlayLimited(0);

        lineTotal.GetComponent<Animator>().enabled = true;
        if (!boss)
        {
            foreach (var o in _anims)
                o.gameObject.SetActive(isActiveX2);
            _anims[0].enabled = true;
        }

        yield return new WaitForSecondsRealtime(0.4f / indexSpeed);
        if (level <= toLevelCrown)
        {
            if (SaveManager.GameProgress.Current.finishCount[level] == 1 && !CrownsController.instance.isAward)
            {
                if (CrownsController.instance.isTimeToOpen)
                {
                    CrownsController.instance.Open();
                    victory.GetComponent<Animator>().Play("up");
                }
            }
        }
        while (CrownsController.instance.isWait && CrownsController.instance.isAward || isWaitBag && CrownsController.instance.isAward)
            yield return new WaitForSecondsRealtime(0.02f / indexSpeed);

       

        if (boss) /*videoX2Coins < 3200 ||*/
        {
            if (!isWatchedVideo)
                UpdateBtnConnection();

            _anims[0].enabled = true;
            if ((level + 1) % 6 == 0)
            {
                foreach (var o in btnx2Sprites)
                {
                    o.sprite = x2Green;
                    SpriteState ss = new SpriteState();
                    ss.highlightedSprite = x2Green;
                    ss.pressedSprite = x2Green;
                    o.gameObject.GetComponent<Button>().spriteState = ss;
                }
            }
        }
        allFinishPanels = true;
        yield break;
    }

    private bool CheckDay()
    {
        firstWin.SetActive(false);
        DateTime currentDate = DateTime.Now;

        if (String.IsNullOrEmpty(SaveManager.GameProgress.Current.firstDayWinUtc))
        {
            SaveManager.GameProgress.Current.firstDayWinUtc = currentDate.ToString();
            SaveManager.GameProgress.Current.Save();

            lineCoins[4].panel.SetActive(true);

            return true;
        }
        else
        {
            DateTime lastDate;
            try
            {
                lastDate = DateTime.Parse(SaveManager.GameProgress.Current.firstDayWinUtc);
            }
            catch (Exception)
            {
                lastDate = currentDate;
                SaveManager.GameProgress.Current.firstDayWinUtc = lastDate.ToString();
                SaveManager.GameProgress.Current.Save();
            }

            if (currentDate.Date.AddDays(-1) > lastDate.Date)
            {
                SaveManager.GameProgress.Current.firstDayWinUtc = currentDate.ToString();
                SaveManager.GameProgress.Current.Save();

                lineCoins[4].panel.SetActive(true);

                return true;
            }
        }

        lineCoins[4].panel.SetActive(false);
        return false;
    }

    public void Tips()
    {
        foreach (var o in tips)
        {
            o.SetActive(true);
        }
        StartCoroutine(_Tips());
    }

    IEnumerator _Tips()
    {
        yield return new WaitForSecondsRealtime(1.6f);
        foreach (var o in tips)
        {
            o.SetActive(false);
        }
    }

    public void UpdateBtnConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SetSpriteButtonX2(x2Gray);
        }
        else
        {
            SetSpriteButtonX2(x2Default);

            if (!AdsManager.Instance.isAnyVideAdAvailable)
                AdsManager.Instance.Init();
        }
    }

    private void SetSpriteButtonX2(Sprite sprite)
    {
        foreach (var o in btnx2Sprites)
        {
            o.sprite = sprite;
            SpriteState ss = new SpriteState();
            ss.highlightedSprite = sprite;
            ss.pressedSprite = sprite;
            o.gameObject.GetComponent<Button>().spriteState = ss;
        }
    }

    IEnumerator _WaitBossPanel()
    {
        while(panelsBoss[0].activeSelf)
        {
            foreach (var o in _anims)
                o.gameObject.SetActive(false);

            yield return new WaitForSecondsRealtime(0.1f / indexSpeed);
        }

        foreach (var o in _anims)
            o.gameObject.SetActive(true);
    }

    public void CloseCrowns()
    {
        //if (openCoroutine != null)
        //    StopCoroutine(openCoroutine);
        StartCoroutine(_CloseCrowns());
    }

    IEnumerator _CloseCrowns()
    {
        lineCoins[3].text.text = CrownsController.instance.money.ToString();
        isWaitBag = true;
        yield return new WaitForSecondsRealtime(0.8f / indexSpeed);

        var cur = 0;
        var max = CrownsController.instance.money;
        var step = (CrownsController.instance.money / 20);
        for (int i = 0; i < 20; i++)
        {
            cur += step;
            //valueTotalText.text = (cur).ToString("F0");
            lineCoins[3].text.text = cur.ToString("F0");
            coinsAudio.Play();
            yield return new WaitForSecondsRealtime(0.03f / indexSpeed);
        }
        lineCoins[3].text.text = (max).ToString("F0");
        yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
        lineCoins[3].panel.GetComponent<Animator>().enabled = true;
        yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
        uiTotal.SetGold(max);
        //lineCoins[3].panel.SetActive(false);
        //valueTotalText.text = (max).ToString("F0");

        isWaitBag = false;
    }

    public void TakeAward()
    {
        StartCoroutine(_TakeAward());
    }
    IEnumerator _TakeAward()
    {
        btnTake.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("close");
        for (int i = 0; i < 3; i++)
        {
            textBottles[i].transform.parent.transform.parent.gameObject.GetComponent<Animator>().enabled = true;
            //yield return new WaitForSecondsRealtime(0.3f);
        }
        isActiveX2 = true;
        takeAward = true;

        var bottles = BalanceTables.Instance.BottlesWinParameters;
        var bottle = bottles[mainscript.CurrentLvl - 1].GetItems();
        int num = 0;
        foreach (var item in bottle)
        {
            if (GetObjAward(item.name).type == EPrefsKeys.Potions)
                PotionManager.AddPotion(GetPotionType(item.name), item.count);
            else
                ScrollController.Instance.AddScrolls(GetObjAward(item.name).t, item.count);

            imgBottles[num].transform.parent.parent.gameObject.SetActive(true);
            num++;
        }

        PotionManager.Current.RefreshDataAndUpdateUI();

        yield return new WaitForSecondsRealtime(0.5f / indexSpeed);
        panelsBoss[0].SetActive(false);
        foreach (var o in _anims)
            o.enabled = allFinishPanels;

        yield return new WaitForSecondsRealtime(0.7f / indexSpeed);

        foreach (var o in _anims)
            o.gameObject.SetActive(true);
    }

    private PotionManager.EPotionType GetPotionType(string name)
    {
        switch (name)
        {
            case "mana":
                return PotionManager.EPotionType.Mana;
            case "health":
                return PotionManager.EPotionType.Health;
            case "power":
                return PotionManager.EPotionType.Power;
            default:
                return PotionManager.EPotionType.Resurrection;
        }
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
}
