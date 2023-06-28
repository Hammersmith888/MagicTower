using System;
using System.Collections;
using Tutorials;
using UI;
using UnityEngine;
using UnityEngine.UI;
using static UIAutoHelpersWindow;

public class UIAutoHelperButton : MonoBehaviour
{

    public Button autoHelperButton;
    private Image buttonImage;
    public Animator _anim;
    public GameObject active;
    public Text textTimer;

    public static UIAutoHelperButton instance;
    bool tutorial = false;
    bool isHowTut;

    private UIPauseController pause;

    [SerializeField] private GameObject lockText;
    [SerializeField] private Font[] fonts;

    public static bool panelIsOpen = false;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator Start()
    {
        pause = FindObjectOfType<UIPauseController>();

        UIAutoHelpersWindow.saveData = PPSerialization.Load<SaveData>("auto_helper");
        if (UIAutoHelpersWindow.saveData == null)
            UIAutoHelpersWindow.saveData = new UIAutoHelpersWindow.SaveData();
        autoHelperButton.enabled = true;
        textTimer.transform.parent.gameObject.SetActive(false);
        _anim.gameObject.SetActive(!SaveManager.GameProgress.Current.tutorialEasy);
        StartCoroutine(_Timer());
        if (PPSerialization.Load<UIAutoHelpersWindow.SaveData>("auto_helper") != null)
            UIAutoHelpersWindow.saveData = PPSerialization.Load<UIAutoHelpersWindow.SaveData>("auto_helper");

        if (String.IsNullOrEmpty(UIAutoHelpersWindow.saveData.auto_help_timer))
            UIAutoHelpersWindow.saveData.auto_help_timer = "0";

        if (mainscript.CurrentLvl == 15 && mainscript.level15restart >= 1 && !LevelPlayerHelpersLoader.Current.spellUse && UIAutoHelpersWindow.saveData.auto_pick_purchase == "")
        {
            Debug.Log($"Open Easy mode level 15 ======");
            SetPause();
            transform.GetChild(0).gameObject.SetActive(true);
            Tutorial.Open(target: gameObject, focus: new Transform[] { transform.GetChild(0) }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(60, 30), waiting: 2f, keyText: "");
        }

        if ((mainscript.CurrentLvl - PlayerPrefs.GetInt("LevelEasyMod")) >= 5 && mainscript.level15restart >= 1 && !LevelPlayerHelpersLoader.Current.spellUse && UIAutoHelpersWindow.saveData.auto_pick_purchase == "")
        {
            SetPause();
            transform.GetChild(0).gameObject.SetActive(true);
            Tutorial.Open(target: gameObject, focus: new Transform[] { transform.GetChild(0) }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(60, 30), waiting: 2f, keyText: "t_0638");
            Debug.Log($"Open Easy mode ======: {Tutorial.duplicates.Count}");
        }

        active.SetActive(UIAutoHelpersWindow.IsActive());

        yield return new WaitForSecondsRealtime(1f);
    }

    private void SetPause()
    {
        if (pause != null)
        {
            pause.pauseCalled = true;
            pause.Pause();
        }
    }

    IEnumerator _Timer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            TimeSpan t = TimeSpan.FromSeconds(UIAutoHelpersWindow.saveData.auto_timer);

            string s = (t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2"));

            if (UIAutoHelperButton.instance != null)
            {
                UIAutoHelperButton.instance.textTimer.transform.parent.gameObject.SetActive(t.TotalSeconds > 0);
                UIAutoHelperButton.instance.textTimer.text = s;
            }

        }
    }

    Coroutine timer;

    private void Update()
    {
        active.SetActive(UIAutoHelpersWindow.IsActive());
        if (UIAutoHelpersWindow.saveData.auto_pick_purchase == "1")
            return;

        if (UIAutoHelpersWindow.saveData.auto_timer < 5 && UIAutoHelpersWindow.saveData.auto_timer > 1
            && !isHowTut && !UIPauseController.Instance.pauseCalled 
            && UIAutoHelpersWindow.saveData.auto_help_status == "2" && !GameObject.FindObjectOfType<ReplicaUI>() 
            && !GameObject.Find("PanelEasy") && !ReplicaUI.IsAnyActive && Time.timeScale >= 1 
            && GameObject.FindObjectOfType<UIBlackPatch>().isOuted )
        {
            textTimer.transform.parent.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            Tutorial.Open(target: gameObject, focus: new Transform[] { transform.GetChild(0) }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(60, 30), waiting: 0f, keyText: "");
            Time.timeScale = 0;
            tutorial = true;
            isHowTut = true;
        }

        if (timer == null)
            timer = StartCoroutine(TimerAutoHelper());
        


        if (UIAutoHelpersWindow.saveData.auto_timer < 0 && UIAutoHelpersWindow.saveData.auto_help_status != "1")
        {
            if (timer != null)
            {
                StopCoroutine(timer);
                timer = null;
            }
            UIAutoHelpersWindow.saveData.auto_timer = -1;
            UIAutoHelpersWindow.saveData.auto_help_status = "1";
            LevelPlayerHelpersLoader.Current.spellUse = false;
            PlayerPrefs.SetInt(GameConstants.SaveIds.AutoUseSpellSave, 0);
            LevelPlayerHelpersLoader.Current._Update();
            active.SetActive(UIAutoHelpersWindow.IsActive());
            PPSerialization.Save<UIAutoHelpersWindow.SaveData>("auto_helper", UIAutoHelpersWindow.saveData);

            Debug.Log($"Disabel easy");
        }

    }

    private IEnumerator TimerAutoHelper()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            if (Time.timeScale < 1 && !panelIsOpen)
                continue;

            UIAutoHelpersWindow.saveData.auto_timer -= 1;
        }
    }

    private void OnDestroy()
    {
        PPSerialization.Save<UIAutoHelpersWindow.SaveData>("auto_helper", UIAutoHelpersWindow.saveData);
    }

    public void Click()
    {
        if (CantUseHelpers)
        {
            _anim.Play(0);

            GameObject.FindGameObjectWithTag("PlayerArmature").layer = 8;

            lockText.GetComponent<Text>().font = PlayerPrefs.GetString("CurrentLanguage") == "English" ? fonts[0] : fonts[1];
            lockText.GetComponent<LocalTextLoc>().parameters.fontsize = PlayerPrefs.GetString("CurrentLanguage") == "English" ? 10 : 20;

            lockText.SetActive(true);
            this.CallActionAfterDelayWithCoroutine(3f, () => lockText.SetActive(false));

            return;
        }
        StartCoroutine(_Click2());
    }

    IEnumerator _Click2()
    {
        yield return new WaitForEndOfFrame();
        if (mainscript.level15restart >= 1 && mainscript.CurrentLvl == 15 && UIAutoHelpersWindow.saveData.auto_pick_purchase == "")
        {
            Tutorial.Close();
            mainscript.level15restart = 0;
            if (UIAutoHelpersWindow.instance == null)
            {
                Instantiate(LevelPlayerHelpersLoaderConfig.Instance.DoublePopupWindowObject, LevelSettings.Current.pauseObj.transform.parent);
            }
            Tutorial.OpenBlock(timer: 1.3f);
            UIAutoHelpersWindow.instance.btnClose.SetActive(false);
            UIAutoHelpersWindow.instance.isFree = true;
            UIAutoHelpersWindow.instance.btnFree.gameObject.SetActive(true);

            var o = Tutorial.Open(target: UIAutoHelpersWindow.instance.btnFree.gameObject, focus: new Transform[] { UIAutoHelpersWindow.instance.btnFree.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(60, 30), waiting: 1f, keyText: "");
            o.disableAnimation = true;
            o.dublicateObj = false;
            o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            UIAutoHelpersWindow.instance.btnFree.GetComponent<Button>().onClick.AddListener(() => {
                Tutorial.Close();
                UIAutoHelpersWindow.instance.btnClose.SetActive(true);
                UIAutoHelpersWindow.instance.isFree = false;
            });
        }
        if (mainscript.level15restart >= 1)
        {
            Tutorial.Close();
            mainscript.level15restart = 0;
            PlayerPrefs.SetInt("LevelEasyMod", mainscript.CurrentLvl);
        }
        if (tutorial)
        {
            Tutorial.Close();
            tutorial = false;
        }
    }


    public bool CantUseHelpers
    {
        get
        {
            return (!SaveManager.GameProgress.Current.tutorialEasy && _anim.gameObject.activeSelf) && EndlessMode.EndlessModeManager.Current == null;
        }
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dtDateTime;
    }

}