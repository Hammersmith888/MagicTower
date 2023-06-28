using System.Collections;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class WhatsNewController : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject[] panels;

    // Increase if you want to show new Update
    private int currentPatchNoteVersion = 1;
    private int activePanelIndex = 0;

    [SerializeField] bool show = false;
    private bool CheckCurrentLevel => SaveManager.GameProgress.Current.CompletedLevelsNumber > 0;
    private bool LocalSave => PlayerPrefs.GetInt("LastViewedPatchNoteVersion", 0) < currentPatchNoteVersion;
    private bool GoogleSave => SaveManager.GameProgress.Current.currentPatchNoteVersion < currentPatchNoteVersion;
    public static bool isFirstLoad = false;
    private void Start()
    {
        if (isFirstLoad)
        {
            isFirstLoad = false;
            StartCoroutine(ShowNewContentInfo(((LocalSave && GoogleSave) && CheckCurrentLevel) || show));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ShowNewContentInfo(bool hasShowInfoPanel)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        //while (TutorialsManager.IsAnyTutorialActive)
        //{
        //    yield return new WaitForSecondsRealtime(1f);
        //}

        if (hasShowInfoPanel)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            AddControllListeners();
            UpdateContent();
            MarkLastViewedPatchNoteVersion();
        }
        else
        {
            MarkLastViewedPatchNoteVersion();
            gameObject.SetActive(false);
        }
    }

    private void MarkLastViewedPatchNoteVersion()
    {
        PlayerPrefs.SetInt("LastViewedPatchNoteVersion", currentPatchNoteVersion);
        SaveManager.GameProgress.Current.currentPatchNoteVersion = this.currentPatchNoteVersion;
        SaveManager.GameProgress.Current.Save();
        PlayerPrefs.Save();
    }

    private void UpdateContent()
    {
        if (activePanelIndex == 0)
        {
            leftButton.gameObject.SetActive(false);
        }
        else if (activePanelIndex == panels.Length - 1)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(true);
        }

        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        panels[activePanelIndex].SetActive(true);
    }

    private void ShowNext()
    {
        activePanelIndex++;
        UpdateContent();
    }

    private void ShowPrevious()
    {
        activePanelIndex--;
        UpdateContent();
    }

    private void CloseAll()
    {
        gameObject.SetActive(false);
    }

    private void AddControllListeners()
    {
        leftButton.onClick.AddListener(ShowPrevious);
        rightButton.onClick.AddListener(ShowNext);
        closeButton.onClick.AddListener(CloseAll);
    }
}
