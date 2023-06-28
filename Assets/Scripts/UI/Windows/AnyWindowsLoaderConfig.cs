using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnyWindowsLoaderConfig", menuName = "Custom/AnyWindowsLoaderConfig")]
public class AnyWindowsLoaderConfig : ScriptableObject {

    private static AnyWindowsLoaderConfig _instance;
    public static AnyWindowsLoaderConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<AnyWindowsLoaderConfig>("AnyWindowsLoaderConfig");
                ClearPrefabsOnStart();
            }
            return _instance;
        }
    }

    public enum WindowType { none, endgameWindow, handWithScroll, microInfoResist }

    [System.Serializable]
    public class WindowData
    {
        public WindowType windowType;
        [ResourceFile(resourcesFolderPath = "UI")]
        public string prefabName;
        [HideInInspector]
        public GameObject loadedObject;
    }

    [SerializeField]
    private List<WindowData> windowDatas = new List<WindowData>();

    public GameObject GetWindowOfType(WindowType windowType)
    {
        for (int i = 0; i < windowDatas.Count; i++)
        {
            Debug.Log(windowDatas[i].windowType + " / " + windowDatas[i].prefabName);
            if (windowDatas[i].windowType == windowType)
            {
                if (windowDatas[i].loadedObject == null)
                {
                    windowDatas[i].loadedObject = Resources.Load<GameObject>(windowDatas[i].prefabName);
                }

                if (windowDatas[i].loadedObject != null)
                {
                    return windowDatas[i].loadedObject;
                }
                break;
            }
        }
        return new GameObject();
    }

    private static void ClearPrefabsOnStart()
    {
        for (int i = 0; i < _instance.windowDatas.Count; i++)
        {
            _instance.windowDatas[i].loadedObject = null;
        }

    }
}
