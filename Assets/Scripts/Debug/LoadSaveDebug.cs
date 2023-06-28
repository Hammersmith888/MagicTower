using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSaveDebug : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    Transform parent;

    [SerializeField]
    TextAsset[] files;


    [System.Obsolete]
    IEnumerator Start()
    {

        //        string[] fileEntries = null;
        //        if(Application.isEditor)
        //        {
        //            fileEntries = Directory.GetFiles(Path.Combine(Application.streamingAssetsPath, "Saves"));
        //            foreach (string fileName in fileEntries)
        //            {
        //                var name = Path.GetFileName(fileName);
        //                if (!name.Contains("meta"))
        //                {
        //                    var o = Instantiate(prefab, parent) as GameObject;
        //                    o.GetComponent<UnityEngine.UI.Text>().text = name.Split('.')[0];
        //                    o.SetActive(true);
        //                    o.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        //                    {
        //                        Debug.Log(fileName);
        //                        SaveManager.Instance.SaveToLocalData(File.ReadAllText(fileName));

        //                        Application.Quit();
        //#if UNITY_EDITOR
        //                        UnityEditor.EditorApplication.isPlaying = false;
        //#endif
        //                    });
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //fileEntries = Directory.GetFiles(Path.Combine("jar:file://", Application.dataPath, "!/assets", "Resources", "Saves"));
        //            //Debug.Log($"====== COUNT: {fileEntries.Length}");
        //            foreach (var fileName in files)
        //            {
        //                var o = Instantiate(prefab, parent) as GameObject;
        //                o.GetComponent<UnityEngine.UI.Text>().text = fileName.name.Split('.')[0];
        //                o.SetActive(true);
        //                o.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        //                {
        //                    var d = fileName.text;
        //                    SaveManager.Instance.SaveToLocalData(d);
        //                    Application.Quit();
        //                });
        //            }
        //        }


        foreach (var fileName in files)
        {
            var o = Instantiate(prefab, parent) as GameObject;
            o.GetComponent<UnityEngine.UI.Text>().text = fileName.name.Split('.')[0];
            o.SetActive(true);
            o.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                var d = fileName.text;
                SaveManager.Instance.SaveToLocalData(d);
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            });
        }

        //var files = Directory.GetFiles(Path.Combine("jar:file://", Application.dataPath, "!/assets"));
        //Debug.Log($"====== files COUNT: {files.Length}");
        //        Debug.Log($"====== combime: {Path.Combine("jar:file://", Application.dataPath, "!/assets", "Resources", "Saves")}, path: {Application.streamingAssetsPath}");


        yield return new WaitForEndOfFrame();

    }

    public void Save()
    {
        var progress = PPSerialization.Load<SaveManager.GameProgress>(EPrefsKeys.Progress);
        var path = "Level_" + progress.CompletedLevelsNumber.ToString();
        SaveManager.Instance.LoadRawDataFromCloud(SaveManager.ProfileSettings.CurrentProfileID, (data)=> {
            Debug.Log(SaveManager.ProfileSettings.CurrentProfileID);
            PPSerialization.FileSave(path, data);
            Debug.Log($"Save file {path}");
            LoadFromCloudQueue.OnCompleteLoadFromCloud();
        });
    }
}
