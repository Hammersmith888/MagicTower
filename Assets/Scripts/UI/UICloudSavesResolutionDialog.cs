using System;
using Native;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UI;
using UnityEngine.SceneManagement;

public class UICloudSavesResolutionDialog : MonoBehaviour
{
    [SerializeField]
    private Text textLevelDevice, textLevelCloud, textGoldDevice, textGoldCloud;

    [Space(20f)]
    [SerializeField]
    private Button closeButton, closeButton2;
    [SerializeField]
    private Button downloadSavesFromCloudButton;
    
    [Space(10f)]
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    GameObject panelDevice;

    private System.Action<bool> resolutionResultAction;

    public static UICloudSavesResolutionDialog Instance { get; private set; }
    private static GameObject obj;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        AudioListener.pause = false;
    }

    private void OnDestroy()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        AudioListener.pause = false;
        resolutionResultAction = null;

        StopAllCoroutines();
    }

    public static void Create(int level, int gold, System.Action<bool> resolutionResultCallback)
    {
        obj = Instantiate(Resources.Load("UI/CloudSavesResolutionDialogWindow")) as GameObject;
        obj.GetComponent<UICloudSavesResolutionDialog>().Open(level, gold, resolutionResultCallback);
    }

    public void Open(int level, int gold, System.Action<bool> resolutionResultCallback)
    {
        this.resolutionResultAction = resolutionResultCallback;
        closeButton.onClick.AddListener(CloseResolutionWindow);
        closeButton2.onClick.AddListener(KeepLocalSavesAndCloseWindow);
        downloadSavesFromCloudButton.onClick.AddListener(SelectDataFromCloudAndCloseWindow);
        StartCoroutine(OpenRoutine(level, gold));
    }

    private IEnumerator OpenRoutine(int level, int gold)
    {
        //Задержка, чтобы окно показалось на Intro

        while (SceneManager.GetActiveScene().name != "Intro")
            yield return new WaitForSecondsRealtime(0.2f);

        yield return new WaitForSecondsRealtime(1f);

        while (SaveManager.GameProgress.Current == null)
        {
            Debug.Log("SaveManager.GameProgress.Current is null waiting...");
            yield return new WaitForSecondsRealtime(0.2f);
        }
        // Показываем окно конфликта, если локальный уровень меньше, чем уровень в облаке
        Time.timeScale = 0;
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber < level)
        {
            try
            {
                AudioListener.pause = true;
                panel.SetActive(true);
                textLevelDevice.text = TextSheetLoader.Instance.GetString("t_0653") + SaveManager.GameProgress.Current.CompletedLevelsNumber.ToString();
                textGoldDevice.text = SaveManager.GameProgress.Current.gold.ToString();
                textLevelCloud.text = TextSheetLoader.Instance.GetString("t_0653") + level.ToString();
                textGoldCloud.text = gold.ToString();
                panelDevice.SetActive(SaveManager.GameProgress.Current.CompletedLevelsNumber > 0);
                textGoldDevice.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing += 0.01f;
                textGoldCloud.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing += 0.01f;
            }
            catch (Exception e)
            {
               Debug.LogError(e.Message);
            }
        }
        else
        {
            PPSerialization.isCloudSave = true;
            KeepLocalSavesAndCloseWindow();
        }
    }

    private void CloseResolutionWindow()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        if (IntroController.instance != null)
            IntroController.instance.ShowSkipButton();
        Destroy(gameObject);
    }

    private void KeepLocalSavesAndCloseWindow()
    {
        resolutionResultAction?.Invoke(false);

        for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
            PlayServices.callbackLogin[i](false);

        Time.timeScale = 1;
        panel.SetActive(false);
        try
        {
            if (IntroController.instance != null)
                IntroController.instance.ShowSkipButton();
            WhatsNewController.isFirstLoad = true;
        }
        catch (Exception e)
        {
            Debug.LogError("Show Skip Button Error: " + e);
        }

        Destroy(gameObject);
    }

    private void SelectDataFromCloudAndCloseWindow()
    {
        resolutionResultAction?.Invoke(true);

        for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
            PlayServices.callbackLogin[i](true);

        Time.timeScale = 1;
        panel.SetActive(false);
        Destroy(gameObject);
    }
}