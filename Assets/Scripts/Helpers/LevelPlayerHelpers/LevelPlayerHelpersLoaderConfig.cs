using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPlayerHelpersLoaderConfig", menuName = "Custom/LevelPlayerHelpersLoaderConfig")]
public class LevelPlayerHelpersLoaderConfig : ScriptableObject
{
    private static LevelPlayerHelpersLoaderConfig _instance;
    public static LevelPlayerHelpersLoaderConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<LevelPlayerHelpersLoaderConfig>("LevelPlayerHelpersLoaderConfig");
            }
            return _instance;
        }
    }

    public enum HelperType { none, waveData, doubleSpeedButton, doublePopupButton, doublePopupWindow}

    [System.Serializable]
    public class HelperData
    {
        public HelperType helperType;

        [ResourceFile(resourcesFolderPath = "LevelPlayerHelpers")]
        public string helperId;
        public GameObject loadedObject;
    }

    [SerializeField]
    private HelperData[] helpersData;

    public Sprite speedDoubleSprite, speedOriginalSprite;

    public GameObject WaveDataObject
    {
        get
        {
            for (int i = 0; i < helpersData.Length; i++)
            {
                if (helpersData[i].helperType == HelperType.waveData)
                {
                    if (helpersData[i].loadedObject == null)
                    {
                        helpersData[i].loadedObject = Resources.Load(helpersData[i].helperId) as GameObject;
                    }
                    return helpersData[i].loadedObject;
                }
            }

            return null;
        }
    }

    public GameObject DoubleSpeedButtonObject
    {
        get
        {
            for (int i = 0; i < helpersData.Length; i++)
            {
                if (helpersData[i].helperType == HelperType.doubleSpeedButton)
                {
                    if (helpersData[i].loadedObject == null)
                    {
                        helpersData[i].loadedObject = Resources.Load(helpersData[i].helperId) as GameObject;
                    }
                    return helpersData[i].loadedObject;
                }
            }

            return null;
        }
    }

    public GameObject DoublePopupButtonObject
    {
        get
        {
            for (int i = 0; i < helpersData.Length; i++)
            {
                if (helpersData[i].helperType == HelperType.doublePopupButton)
                {
                    if (helpersData[i].loadedObject == null)
                    {
                        helpersData[i].loadedObject = Resources.Load(helpersData[i].helperId) as GameObject;
                    }
                    return helpersData[i].loadedObject;
                }
            }

            return null;
        }
    }

    public GameObject DoublePopupWindowObject
    {
        get
        {
            for (int i = 0; i < helpersData.Length; i++)
            {
                if (helpersData[i].helperType == HelperType.doublePopupWindow)
                {
                    if (helpersData[i].loadedObject == null)
                    {
                        helpersData[i].loadedObject = Resources.Load(helpersData[i].helperId) as GameObject;
                    }
                    return helpersData[i].loadedObject;
                }
            }

            return null;
        }
    }

}
