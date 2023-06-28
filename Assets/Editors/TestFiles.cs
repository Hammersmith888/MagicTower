
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestFiles : MonoBehaviour
{
#if UNITY_EDITOR_WIN
    public GameObject levelsPrefab;
    public bool LoadTestLevelFiles = true;
    // Use this for initialization
#if LEVEL_EDITOR
    private void Start()
    {
        if (!LoadTestLevelFiles)
        {
            return;
        }
        LevelWavesPrefab allLevelWaves = levelsPrefab.GetComponent<LevelWavesPrefab>();

        string _path = Application.dataPath + "/Levels/";
        DirectoryInfo dir = new DirectoryInfo(_path);
        allLevelWaves.waves.Clear();
        var newAllLevelWaves = gameObject.AddComponent<LevelWavesPrefab>();
        newAllLevelWaves.waves = new List<LevelWaves>();
        foreach (var item in dir.GetFiles())
        {
            string thisName = item.Name;
            if (thisName.IndexOf(".dat") == thisName.Length - 4)
            {
                thisName = thisName.Substring(0, thisName.IndexOf(".dat"));
                //print(thisName);
                List<EnemyWave> waves = FileSerialization.Load(thisName) as List<EnemyWave>;
                LevelWaves nextLevel = new LevelWaves();
                nextLevel.waves = waves;
                nextLevel.fileName = thisName;
                allLevelWaves.waves.Add(nextLevel);
                newAllLevelWaves.waves.Add(nextLevel);
            }
        }
    }
#endif
#endif
}
