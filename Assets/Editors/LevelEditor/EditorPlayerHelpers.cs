using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorPlayerHelpers : MonoBehaviour {

    public LevelEditorController levelEditorScript;

    public LevelPlayerHelpers levelPlayerHelpers = new LevelPlayerHelpers();
    public InputField minesCounter;
    public List<Transform> barriers = new List<Transform>();
    [SerializeField]
    private GameObject barrierObj;


    // Use this for initialization
    void Start () {
        minesCounter.onEndEdit.AddListener(AutoUpdateMines);
	}

    public void AutoUpdateMines(string inputValue)
    {
        int counter = int.Parse(inputValue);

        levelPlayerHelpers.minesNumber = counter;
        SaveSettingsToWave();
    }

    private void SaveSettingsToWave()
    {
        levelEditorScript.SaveCurrentWave("playerHelpers");
    }
	
    public void SetHelpers(LevelPlayerHelpers newHelpers)
    {
        levelPlayerHelpers.barriersPositions = newHelpers.barriersPositions;
        levelPlayerHelpers.minesNumber = newHelpers.minesNumber;
        minesCounter.text = levelPlayerHelpers.minesNumber.ToString();
    }

    public void AddBarrier(Transform barrier)
    {
        LevelPlayerHelpers.BarrierPosition barrierPosition = new LevelPlayerHelpers.BarrierPosition() { spawnPointX = barrier.position.x, spawnPointY = barrier.position.y , spawnPointZ = barrier.position.z };
        if (barriers.Contains(barrier))
        {
            for (int i = 0; i < barriers.Count; i++)
            {
                if (barriers[i] == barrier)
                {
                    levelPlayerHelpers.barriersPositions[i] = barrierPosition;
                }
            }
        } else
        {
            barriers.Add(barrier);
            levelPlayerHelpers.barriersPositions.Add(barrierPosition);
        }
        SaveSettingsToWave();
    }

    public void RemoveBarrier(Transform barrier)
    {
        if (barriers.Contains(barrier))
        {
            for (int i = 0; i < barriers.Count; i++)
            {
                if (barriers[i] == barrier)
                {
                    barriers.RemoveAt(i);
                    levelPlayerHelpers.barriersPositions.RemoveAt(i);
                    break;
                }
            }
        }
        SaveSettingsToWave();
    }

    public void PlaceHelpers()
    {
        if (barrierObj == null)
        {
            return;
        }

        for (int i = 0; i < levelPlayerHelpers.barriersPositions.Count; i++)
        {
            Vector3 barrierPosition = new Vector3(levelPlayerHelpers.barriersPositions[i].spawnPointX, levelPlayerHelpers.barriersPositions[i].spawnPointY, levelPlayerHelpers.barriersPositions[i].spawnPointZ); 
            GameObject newBarrier = Instantiate(barrierObj, barrierPosition, barrierObj.transform.rotation) as GameObject;

            EditorBarrier editorBarrier = newBarrier.GetComponent<EditorBarrier>();
            editorBarrier.editorPlayerHelpers = this;

            barriers.Add(newBarrier.transform);
        }
    }
}
