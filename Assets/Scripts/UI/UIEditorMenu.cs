using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;

public class UIEditorMenu : MonoBehaviour {

    [SerializeField] private GameObject levelPrefab;

    public static string loadedFile = "1";
    public Dropdown ddLevelFiles;
    public Button playBtn;

    private int fileCount;

    public static int LastChoosenDropDownID;

	public static bool EditorWasLoaded = false;

    [SerializeField]
    private InputField startAsLvlNumberField;
    private int customLvlNumber;



    void Awake()
    {
#if UNITY_ANDROID
        if (!PlayerPrefs.HasKey("LevelEditorAPK"))
        {
            var levels = levelPrefab.GetComponent<LevelWavesPrefab>();
            if (!Directory.Exists(FileSerialization.LevelsPath()))
                Directory.CreateDirectory(FileSerialization.LevelsPath());
            
            foreach (var levelWave in levels.waves)
            {
                FileSerialization.Save(levelWave.waves, levelWave.fileName);
            }
            PlayerPrefs.SetInt("LevelEditorAPK",0);
            PlayerPrefs.Save();
        }

#else
        if (!Directory.Exists("Levels"))
            Directory.CreateDirectory("Levels");
#endif
    }

    void Start()
    {
		EditorWasLoaded = true;
        ddLevelFiles.options.Clear();
        List<string> lvls = new List<string>();
#if UNITY_ANDROID
        foreach (string file in Directory.GetFiles(FileSerialization.LevelsPath()))
        {
            if (file.Contains(".dat"))
            {
                fileCount++;
                string fileName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).LastIndexOf(".dat"));
                lvls.Add(fileName);
            }
        }
#else
        foreach (string file in Directory.GetFiles("Levels/"))
        {
            fileCount++;
            string fileName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).LastIndexOf(".dat"));
            lvls.Add(fileName);
        }
#endif
        var comparer = new StringNumberComparer();
        lvls.Sort(comparer);
        foreach (var o in lvls)
            ddLevelFiles.options.Add(new Dropdown.OptionData() { text = o });

        LastChoosenDropDownID = PlayerPrefs.GetInt("LastChoosenDropDownID");
        LastChoosenDropDownID = ddLevelFiles.options.Count < LastChoosenDropDownID ? 0 : LastChoosenDropDownID;

        if (fileCount == 0)
        {
            playBtn.interactable = false;
        }
        ddLevelFiles.value = LastChoosenDropDownID;

        if (startAsLvlNumberField != null)
        {
            startAsLvlNumberField.onEndEdit.AddListener(SetLvlNumber);
        }
    }
    public static bool isEditorStart = false;
    public void PlayLevel()
    {
        if (customLvlNumber != 0)
        {
            mainscript.CurrentLvl = customLvlNumber;
        }
        isEditorStart = true;
        SetupLastID();
        loadedFile = ddLevelFiles.options[LastChoosenDropDownID].text.ToString();
        SceneManager.LoadScene("Level");
    }

    public void OpenLevelEditor()
    {
        SetupLastID();
        SceneManager.LoadScene("LevelEditor");
    }

    public void OpenShopEditor()
    {
        SceneManager.LoadScene("ShopEditor");
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MenuEditor");
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    private void SetupLastID()
    {
        LastChoosenDropDownID = ddLevelFiles.value;
        PlayerPrefs.SetInt("LastChoosenDropDownID", LastChoosenDropDownID);
    }

	public void CheatMoney()
	{
		if (SaveManager.GameProgress.Current.gold < 1000000000)
            SaveManager.GameProgress.Current.gold += 1000000;
        SaveManager.GameProgress.Current.Save();

    }

    private void SetLvlNumber(string inputText)
    {
        int.TryParse(inputText, out customLvlNumber);
    }
}