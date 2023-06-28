using System.Collections;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class UIDoubleSpeedButton : MonoBehaviour {

    public Button speedButton;
    public Image buttonImage;
    public Animator _anim;

    public bool requiredEnable = false;

    public static UIDoubleSpeedButton instance;
    public int countClick = 0;

    public Animator _animShow;

    [SerializeField] private GameObject lockText;
    [SerializeField] private Font[] fonts;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator Start()
    {
        //Time.timeScale = LevelSettings.Current.increasedUsedSpeed = LevelSettings.defaultUsedSpeed;
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        _anim.gameObject.SetActive(false);
        if (speedButton != null)
        {
            //buttonImage = speedButton.GetComponent<Image>();

            // Disable double speed until level 3
            if (CantUseDoubleSpeed)
            {
                //buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0.5f);
                _anim.gameObject.SetActive(true);
                LevelSettings.Current.usedGameSpeed = LevelSettings.defaultUsedSpeed;
                buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedOriginalSprite;

                PlayerPrefs.SetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0);
            }

            else if (PlayerPrefs.GetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0) == 1)
            {
                buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedDoubleSprite;
                LevelSettings.Current.usedGameSpeed = LevelSettings.Current.increasedUsedSpeed;
            }


            speedButton.onClick.AddListener(OnButtonHit);
        }

        if (SaveManager.GameProgress.Current.tutorial.Length >= 15 && !SaveManager.GameProgress.Current.tutorialx2Speed && CantUseDoubleSpeed)
        {
           _anim.gameObject.SetActive(true);
        }
        if(!SaveManager.GameProgress.Current.tutorial[(int)Tutorials.ETutorialType.DOUBLE_SPEED_BUTTON])
            _anim.gameObject.SetActive(true);
        else
        {
            _anim.gameObject.SetActive(false);
        }

        yield return new WaitForSecondsRealtime(0.1f);
        if(PlayerPrefs.GetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0) == 1)
        {
            LevelSettings.Current.usedGameSpeed = LevelSettings.Current.increasedUsedSpeed;
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }
    }

    public void PlayShow()
    {
        Debug.Log($"----------- ============== PlayShow X@");
        _animShow.gameObject.SetActive(true);
        StartCoroutine(_S());
    }

    IEnumerator _S()
    {
        yield return new WaitForSeconds(3);
        _animShow.gameObject.SetActive(false);
    }

    private void OnButtonHit()
    {
        if (_anim.gameObject.activeSelf)
        {
            _anim.Play(0);

            GameObject.FindGameObjectWithTag("PlayerArmature").layer = 8;

            lockText.GetComponent<Text>().font = PlayerPrefs.GetString("CurrentLanguage") == "English" ? fonts[0] : fonts[1];
            lockText.GetComponent<LocalTextLoc>().parameters.fontsize = PlayerPrefs.GetString("CurrentLanguage") == "English" ? 10 : 22;

            lockText.SetActive(true);
            this.CallActionAfterDelayWithCoroutine(3f, () => lockText.SetActive(false));

            return;
        }

        bool nowUsedDefaultGameSpeed = Time.timeScale == LevelSettings.Current.usedGameSpeed;

        if (PlayerPrefs.GetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0) == 0)
        {
            LevelSettings.Current.usedGameSpeed = LevelSettings.Current.increasedUsedSpeed;
            buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedDoubleSprite;
            if(SaveManager.GameProgress.Current.tutorialx2Speed)
                AnalyticsController.Instance.LogMyEvent("PressX2_On");
            PlayerPrefs.SetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 1);

            SaveManager.GameProgress.Current.tutorialx2Speed = true;
            SaveManager.GameProgress.Current.Save();
        }
        else
        {
            LevelSettings.Current.usedGameSpeed = LevelSettings.defaultUsedSpeed;
            buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedOriginalSprite;
            AnalyticsController.Instance.LogMyEvent("PressX2_Off");
            PlayerPrefs.SetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0);
        }


        //Debug.Log($"OnButtonHit: {Time.timeScale},  { LevelSettings.defaultUsedSpeed}");



        //if (Time.timeScale <= LevelSettings.defaultUsedSpeed)
        //{
        //    LevelSettings.Current.usedGameSpeed = LevelSettings.Current.increasedUsedSpeed;
        //    buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedDoubleSprite;
        //    SaveManager.GameProgress.Current.tutorialx2Speed = true;
        //    SaveManager.GameProgress.Current.Save();
        //    countClick++;
        //}
        //else
        //{
        //    LevelSettings.Current.usedGameSpeed = LevelSettings.defaultUsedSpeed;
        //    buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedOriginalSprite;
        //}
        //if (requiredEnable)
        //{
        //    LevelSettings.Current.usedGameSpeed = LevelSettings.Current.increasedUsedSpeed;
        //    buttonImage.sprite = LevelPlayerHelpersLoaderConfig.Instance.speedDoubleSprite;
        //    requiredEnable = false;
        //}

        Time.timeScale = LevelSettings.Current.usedGameSpeed;
        if (nowUsedDefaultGameSpeed)
        {
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }
    }

    private bool CantUseDoubleSpeed
    {
        get
        {
            return mainscript.CurrentLvl < 3 && EndlessMode.EndlessModeManager.Current == null;
        }
    }
}
