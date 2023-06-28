using ADs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseController : MonoBehaviour, UI.IOnbackButtonClickListener
{

    public static UIPauseController Instance;

    public enum StateOfPause
    {
        PLAING, PAUSE, SETTINGS, VICTORY, DEFEAT
    }

    [SerializeField]
    private Animator _pauseAnimator;

    public bool pauseCalled = true;

    [SerializeField]
    private GameObject _settings, background;
    [SerializeField]
    private UIControl _controls;

    public StateOfPause currentState = StateOfPause.PLAING;
    public Tutorials.Tutorial_1 tutorObj;

    void Awake()
    {
        Instance = this;
        pauseCalled = false;
        _pauseAnimator.ResetTrigger("game");
        _pauseAnimator.ResetTrigger("pause");
    }

    private void Start()
    {
        UIControl.Current.AddOnBackButtonListener(this);
    }

    public void OnBackButtonClick()
    {
        PlayerPrefs.SetString("EscapePressedFrom", "none");
        switch (currentState)
        {
            case StateOfPause.PLAING:
                Pause();
                break;
            case StateOfPause.PAUSE:
                ContinueFromPause();
                break;
            case StateOfPause.SETTINGS:
                CloseSettings();
                break;
            case StateOfPause.VICTORY:
                _controls.ToShop();
                break;
            case StateOfPause.DEFEAT:
                _controls.ToShop();
                break;
        }
    }

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogWarning("CLICKING BACK OR ESC");
            if (Time.timeScale > 0)
                Pause();
            else
                ContinueFromPause();
        }
        
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus && (GameObject.FindObjectOfType<UIContinueGame>() == null || GameObject.FindObjectOfType<UIContinueGame>().startTimer == false))
            Pause();
    }

    public void Pause()
    {
        //Debug.Log($"Tutorials.TutorialsManager.IsAnyTutorialActive: {Tutorials.TutorialsManager.IsAnyTutorialActive}");
        //Debug.Log($"pauseCalled: {pauseCalled}");
        //Debug.Log($" (UIBlackPatch.Current != null && UIBlackPatch.Current.IsPlaying): { (UIBlackPatch.Current != null && UIBlackPatch.Current.IsPlaying)}");
        if ( pauseCalled || (UIBlackPatch.Current != null && UIBlackPatch.Current.IsPlaying))
            return;

        pauseCalled = true;
        _pauseAnimator.SetTrigger("pause");
        Time.timeScale = 0;
        currentState = StateOfPause.PAUSE;
        SoundController.Instanse.PlayShowPauseSFX();
        SoundController.Instanse.PauseGamePlaySFX();
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.PAUSE, true);
    }

    public void ContinueFromPause()
    {
        pauseCalled = false;
        _pauseAnimator.SetTrigger("game");
        currentState = StateOfPause.PLAING;
        CloseSettings();
        Time.timeScale = LevelSettings.defaultUsedSpeed; 
    }

    public void Settings()
    {
        _pauseAnimator.enabled = false;
        background.SetActive(false);
        RectTransform r = _pauseAnimator.gameObject.GetComponent<RectTransform>();
        r.anchoredPosition = new Vector2(-3000, r.anchoredPosition.y);
    }

    public void CloseSettings()
    {
        RectTransform r = _pauseAnimator.gameObject.GetComponent<RectTransform>();
        r.anchoredPosition = new Vector2(0, r.anchoredPosition.y);
        _pauseAnimator.enabled = true;
        background.SetActive(true);
    }


    public void Continue()
    {
        reCallUnpause();
        Time.timeScale = LevelSettings.Current.usedGameSpeed;
        currentState = StateOfPause.PLAING;
        LevelSettings levelSettings = LevelSettings.Current;
        if (levelSettings.playerController.tutorialObject != null)
            levelSettings.playerController.tutorialObject.GetComponent<Tutorials.Tutorial_1>().ContinueGame(9);
        if (levelSettings == null || !levelSettings.wonFlag)
            SoundController.Instanse.ResumeGamePlaySFX();
    }

    private void reCallUnpause()
    {
        pauseCalled = false;
    }

    void Update()
    {
        if (pauseCalled)
        {
            Time.timeScale = 0;
        }
    }
}
