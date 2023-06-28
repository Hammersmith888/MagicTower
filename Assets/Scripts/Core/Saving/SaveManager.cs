
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public partial class SaveManager : MonoSingleton<SaveManager>
{
    [System.Serializable]
    public class AchieveViewed
    {
        public bool[] viewed;
    }
    [SerializeField]
    private WearLoaderConfig wearloaderConfig;

#if UNITY_EDITOR
    public string cloudUserID;
    public string userID = "T7DWNQK75GWF";
    public bool loadDataByUserID;
    [Space(10f)]
    public bool deleteSavesOnStart = false;
    public bool completeAllTutorials;
    public bool disableCloudSavesByDeviceID;
    public bool setTutorialsStates;
    [SerializeField]
    private bool[] tutorialsStates;
#endif

    private readonly string[] USER_DATA_PREFS_KEYS = new string[]
    {
        "Progress","Spells","Scrolls","Potions","Upgrades","Bonuses","Energy", "AchievemtConditions", "ProfileSettings",
        "SettingsGame",
    "AchievemtConditions",
    "AchievementItems",
    "AchieveViewed",
    "DailyReward",
    "special_offer",
    "auto_helper",
    "GameMetaSave",
    "DailySpin"
    };

    #region STATIC_PROPERTIES
    public static bool IsAdsDisabled
    {
        get
        {
            return PPSerialization.Load(EPrefsKeys.ProfileSettings.ToString(), ProfileSettings.Default).adsDisabled;
        }
    }

    public static bool IntroWasViewed
    {
        get
        {
            return PPSerialization.Load(EPrefsKeys.ProfileSettings.ToString(), ProfileSettings.Default).introWasViewed;
        }
        set
        {
            var profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings);
            profileSettings.introWasViewed = value;
            PPSerialization.Save(EPrefsKeys.ProfileSettings, profileSettings, false);
        }
    }
    #endregion

    override protected void Awake()
    {
        if (isOtherInstanceExists)
        {
            Destroy(this.gameObject);
            return;
        }

#if UNITY_EDITOR
        // Для тестов
        if (deleteSavesOnStart)
        {
            PlayerPrefs.DeleteAll();
        }
#endif
        // Сохранение по умолчанию значений: заклинаний, свитков, зелий, бонусов, улучшений (если их до этого не было)
        new SavesDataValidator().ValidateAll();

#if UNITY_EDITOR

        if (loadDataByUserID && !string.IsNullOrEmpty(cloudUserID))
        {
           // LoadTestSavesDataFromCloud();
        }
#endif
    }

#if UNITY_EDITOR

#endif
    public void LoadRawDataFromCloud(string id, UnityEngine.Events.UnityAction<string> @event)
    {
        //Debug.LogFormat("Loading Test Saves Data by id: <b>{0}</b>", id);
        LoadFromCloudQueue.PutOperationToQueue(() =>
        {
            Native.FirebaseManager.Instance.ReadUserData(id, Native.FirebaseManager.EDBType.USER_ID, (string data, bool isError) =>
            {
                //Debug.LogFormat("RawData: {0}", data);
                @event(data);
            });
        });
    }

    public void SaveToLocalData(string data, bool cloud = true)
    {
        Debug.Log("----------- SaveToLocalData --------- ");
        PlayerPrefs.DeleteAll();
        Hashtable storageData = JSON.JsonDecode(data) as Hashtable;
        OverrideSavesData(storageData, cloud: cloud);
    }

    //public void LoadRawDataFromCloud(string id)
    //{
    //    Debug.LogFormat("Loading Test Saves Data by id: <b>{0}</b>", id);
    //    LoadFromCloudQueue.PutOperationToQueue(() =>
    //    {
    //        Native.FirebaseManager.Instance.ReadUserData(id, Native.FirebaseManager.EDBType.USER_ID, (string data, bool isError) =>
    //        {
    //            Debug.LogFormat("RawData: {0}", data);
    //            if (string.IsNullOrEmpty(data))
    //            {
    //                Debug.LogError("LoadStorageSave: Data is Null");
    //                LoadFromCloudQueue.OnCompleteLoadFromCloud();
    //                return;
    //            }
    //            PlayerPrefs.DeleteAll();
    //            Hashtable storageData = JSON.JsonDecode(data) as Hashtable;
    //            OverrideSavesData(storageData);
    //            LoadFromCloudQueue.OnCompleteLoadFromCloud();
    //        });
    //    });
    //}

    /// <summary>
    /// returns True if save data was overridden by data from cloud storage
    /// </summary>
    public bool OnStorageSaveLoaded(string data, bool isNewFacebookAccount)
    {
        Debug.Log("Is New FB Account: " + isNewFacebookAccount + "\nStorage save " + data);
        Hashtable storageData = JSON.JsonDecode(data) as Hashtable;
        //Если подключились к новому аккаунту или прогресс игрока из облака лучше прогресса сохраненного на устройстве забираем все данные из облака
        if (isNewFacebookAccount || !SaveConflictResolver.DeviceProgressIsBetter(storageData))
        {
            OverrideSavesData(storageData);
            return true;
        }
        return false;
    }

    public void OverrideSavesData(Hashtable storageData, bool resetID = true, bool cloud = true)
    {
        Debug.Log("--<<<b>Overwriting device save data</b>>>--");
        PPSerialization.ClearCachedSavesData();
        PPSerialization.ClearAllPendingSaves();

        DictionaryEntry dicEntry;
        foreach (var entry in storageData)
        {
            dicEntry = (DictionaryEntry)entry;
            //Debug.Log(dicEntry.Key.ToString() + " - " + JSON.JsonEncode(dicEntry.Value));
            PPSerialization.Save(dicEntry.Key.ToString(), JSON.JsonEncode(dicEntry.Value));//!!! Быстрое решение, нужно оптимизировать ( данные декодируеются и снова после кодируються в JSON )
        }
        if (resetID)
        {
            ProfileSettings.Validate();
        }
        OnSavesDataReloaded();
    }

    public static void OnSavesDataReloaded()
    {
        //Energy.ForceReload();
        GameProgress.ForceReload();
        //ADs.AdsManager.CheckAdsEnabledState();
        //if (SoundController.Instanse != null)
        //{
        //    SoundController.Instanse.ReSetVolumes();
        //}
    }

    public void OnFirstFacebookLogin()
    {
        CoinsManager.AddCoinsST(500, true);
        AnalyticsController.Instance.CurrencyAccrual(500, DevToDev.AccrualType.Earned);
        SaveAllToStorage(Native.FirebaseManager.EDBType.USER_ID);
    }

    public void SaveAllToStorage(Native.FirebaseManager.EDBType dbType)
    {
        Debug.Log("------------============== SaveAllToStorage =============-------------");
        //	Dictionary<string, string> allData = new Dictionary<string, string>( USER_DATA_PREFS_KEYS.Length );
        //Hashtable allData = new Hashtable( USER_DATA_PREFS_KEYS.Length );
        string NODE_DATA_FORMAT = "\"{0}\":{1}";
        char coma = ',';

        System.Text.StringBuilder jsonFinalString = new System.Text.StringBuilder();
        jsonFinalString.Append('{');

        for (int i = 0; i < USER_DATA_PREFS_KEYS.Length; i++)
        {
            //	Debug.Log( USER_DATA_PREFS_KEYS[ i ] + "  "+ Encryption.Decrypt( PlayerPrefs.GetString( USER_DATA_PREFS_KEYS[ i ] ) ) );
            var saveDataJsonString = string.Format(NODE_DATA_FORMAT, USER_DATA_PREFS_KEYS[i], Encryption.Decrypt(PlayerPrefs.GetString(USER_DATA_PREFS_KEYS[i])));

            jsonFinalString.Append(saveDataJsonString);
            if (i < USER_DATA_PREFS_KEYS.Length - 1)
            {
                jsonFinalString.Append(coma);
            }
            //Debug.Log( USER_DATA_PREFS_KEYS[ i ]+ ": "+ PlayerPrefs.GetString( USER_DATA_PREFS_KEYS[ i ] ) );
        }
        jsonFinalString.Append('}');

        string id = null;
        if (dbType == Native.FirebaseManager.EDBType.USER_ID)
            id = ProfileSettings.CurrentProfileID;
        else
            id = FirebaseSavesByDeviceController.DEVICE_ID;
        Native.FirebaseManager.Instance.SaveUserData(id, jsonFinalString.ToString(), dbType);
    }

    public void OnPurchaseDone()
    {
        var profileSettings = PPSerialization.Load<ProfileSettings>(EPrefsKeys.ProfileSettings, ProfileSettings.Default);
        profileSettings.adsDisabled = true;
        PPSerialization.Save(EPrefsKeys.ProfileSettings, profileSettings);
    }

    public void ClearSavesData()
    {
        PPSerialization.ClearAllPendingSaves();
        PPSerialization.ClearCachedSavesData();
        for (int i = 0; i < USER_DATA_PREFS_KEYS.Length; i++)
        {
            PlayerPrefs.DeleteKey(USER_DATA_PREFS_KEYS[i]);
        }
        Energy.ForceReload();
        GameProgress.ForceReload();
        new SavesDataValidator().ValidateAll();
    }
}

public static class SaveManagerExtensions
{
    public static int GetBestScoreOnLvL(this SaveManager.GameProgress gameProgress, int lvlIndex)
    {
        if (gameProgress != null && gameProgress.bestScoreOnLevel != null && gameProgress.bestScoreOnLevel.Length > lvlIndex)
        {
            return gameProgress.bestScoreOnLevel[lvlIndex];
        }
        return 0;
    }
}

[System.Serializable]
public class IntArrayWrapper : ArrayInClassWrapper<int>
{
    public IntArrayWrapper(int capacity) : base(capacity) { }
}
