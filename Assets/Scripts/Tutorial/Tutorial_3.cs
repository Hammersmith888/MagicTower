using UnityEngine;
using System.Collections;

public class Tutorial_3 : MonoBehaviour {

    void Awake () {
        // Если туториал (часть 3) еще не пройден
        //progress.tutorial[2] = false; // Для тестов

        if (!SaveManager.GameProgress.Current.tutorial[2])
        {
            this.CallActionAfterDelayWithCoroutine(3f, ShowMessage);
        }
    }

    private void ShowMessage()
    {
        Time.timeScale = 0f;
        GetComponent<Animator>().enabled = true;
        SaveManager.GameProgress.Current.tutorial[2] = true;
        SaveManager.GameProgress.Current.Save();
    }

    public void ContinueGame()
    {
        if (LevelSettings.Current == null)
        {
            Time.timeScale = LevelSettings.defaultUsedSpeed;
        }
        else
        {
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }
        Destroy(gameObject);
    }
}