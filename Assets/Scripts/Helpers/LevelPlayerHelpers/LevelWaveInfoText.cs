using I2.Loc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWaveInfoText : MonoBehaviour {

    public static LevelWaveInfoText Current;

    [SerializeField]
    private UnityEngine.UI.Text waveDataText;
    [SerializeField]
    Font enFont, otherFont;
    string level, wave, allWaves;

    private void Awake()
    {
        Current = this;
    }


    public void UpdateWaveInfo(string levelId, int waveNumber, int totalWaves)
    {
        waveDataText.font = PlayerPrefs.GetString("CurrentLanguage") == "English" ? enFont : otherFont;
        waveDataText.text = TextSheetLoader.Instance.GetString("t_0546") + " " + levelId + "  " + TextSheetLoader.Instance.GetString("t_0547") + " " + waveNumber.ToString() + " / " + totalWaves;
        level = levelId;
        wave = waveNumber.ToString();
        allWaves = totalWaves.ToString();
    }

    public void UpdateFont()
    {
        waveDataText.font = PlayerPrefs.GetString("CurrentLanguage") == "English" ? enFont : otherFont;
        waveDataText.text = TextSheetLoader.Instance.GetString("t_0546") + " " + level + "  " + TextSheetLoader.Instance.GetString("t_0547") + " " + wave.ToString() + " / " + allWaves;
    }

    public void ShowSomethingInstead(string content)
    {
        waveDataText.font = PlayerPrefs.GetString("CurrentLanguage") == "English" ? enFont : otherFont;
        waveDataText.text = content;
    }
}
