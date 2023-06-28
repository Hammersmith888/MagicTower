#define USE_BOTH
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class PPSerialization : MonoBehaviour
{
    private static List<string> pendingForSavingToCloud = new List<string>();
    private static Dictionary<string, string> cachedData = new Dictionary<string, string>();

    public static bool isCloudSave = false;
    private const int cooldown = 5;
    private static DateTime cooldownTime;

    private static bool IsCloudSavesAvailable
    {
        get
        {
            return ((!string.IsNullOrEmpty(SaveManager.ProfileSettings.CurrentProfileID)) || Native.GoogleCloudSavesController.IsAvailable || FirebaseSavesByDeviceController.IsActivated);
        }
    }

    public static string GetJsonDataFromPrefs(string saveTag)
    {
        string outData;
        if (cachedData.TryGetValue(saveTag, out outData))
        {
            if (!string.IsNullOrEmpty(outData))
            {
                return outData;
            }
        }

        try
        {
            string temp = PlayerPrefs.GetString(saveTag);
            if (string.IsNullOrEmpty(temp))
            {
                return temp;
            }
            return Encryption.Decrypt(temp);
        }
        catch (System.Exception e)
        {
            Debug.Log("GetJsonDataFromPrefs Exception" + e.Message + "  saveTag: " + saveTag);
            return null;
        }
    }

    public static void ClearCachedSavesData()
    {
        cachedData.Clear();
    }

    public static void ClearAllPendingSaves()
    {
        pendingForSavingToCloud.Clear();
    }

    public static void SaveAllPendingSaves()
    {
        int count = pendingForSavingToCloud.Count;
        Debug.Log("SaveAllPendingSaves: " + IsCloudSavesAvailable);
        if (count > 0 && IsCloudSavesAvailable)
        {
#if !USE_BOTH
			bool useFirebase = Social.FacebookManager.Instance.isLoggedIn ;
#endif
            for (int i = 0; i < count; i++)
            {
                string json = GetJsonDataFromPrefs(pendingForSavingToCloud[i]);
                if (!string.IsNullOrEmpty(json))
                {
#if USE_BOTH
                    Native.FirebaseManager.Instance.SaveUserDataByNode(SaveManager.ProfileSettings.CurrentProfileID, pendingForSavingToCloud[i], json, Native.FirebaseManager.EDBType.USER_ID);

                    if (FirebaseSavesByDeviceController.IsActivated)
                    {
                        Native.FirebaseManager.Instance.SaveUserDataByNode(FirebaseSavesByDeviceController.DEVICE_ID, pendingForSavingToCloud[i], json, Native.FirebaseManager.EDBType.DEVICE);
                    }
                    Native.GoogleCloudSavesController.Instance.SaveDataRequest();
#else
                    if ( useFirebase )
					{
						Native.FirebaseManager.Instance.SaveUserDataByNode(SaveManager.ProfileSettings.CurrentProfileID, pendingForSavingToCloud[i], json );
					}
					else
					{
						Native.GoogleCloudSavesController.instance.SaveDataRequest();
					}
#endif
                }
                else
                {
                    Debug.LogErrorFormat("No data for pending save with tag {0}", pendingForSavingToCloud[i]);
                }
            }
            pendingForSavingToCloud.Clear();
        }
    }

    public static void Save<T>(EPrefsKeys prefsKey, T obj, bool toCloud = true)
    {
        Save(prefsKey.ToString(), obj, toCloud);
    }

    /// <summary>
    /// This is obsolete API don't use it this with EPrefsKeys
    /// </summary>
    public static void Save<T>(string saveTag, T obj, bool toCloud = true, bool ignoreCallDown = false)
    {
        string json = JsonUtility.ToJson(obj);

        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("Empty save data json saveTag: " + saveTag);
            Debug.Log("<color=red>Null json</color> " + saveTag);

            return;
        }

        if (cachedData.ContainsKey(saveTag))
        {
            cachedData[saveTag] = json;
        }
        else
        {
            cachedData.Add(saveTag, json);
        }

        if (Application.internetReachability != NetworkReachability.NotReachable && toCloud
#if UNITY_EDITOR
            && Application.isPlaying
#endif
            && IsCloudSavesAvailable && (CheckCooldown() || ignoreCallDown))
        {
            SaveToCloud(saveTag, json);
        }

        // adding encryption here
        json = Encryption.Encrypt(json);
        PlayerPrefs.SetString(saveTag, json);
        PlayerPrefs.Save();
    }

    private static bool CheckCooldown()
    {
        if (cooldownTime == null)
            cooldownTime = DateTime.Now;

        if (cooldownTime > DateTime.Now.AddMinutes(-cooldown))
            return false;

        cooldownTime = DateTime.Now;

        return true;
    }

    private static void SaveToCloud(string saveTag, string json)
    {
        if (!isCloudSave)
            return;
#if USE_BOTH
        try
        {
            Native.FirebaseManager.Instance.SaveUserDataByNode(SaveManager.ProfileSettings.CurrentProfileID, saveTag, json, Native.FirebaseManager.EDBType.USER_ID);

            if (FirebaseSavesByDeviceController.IsActivated)
            {
                Native.FirebaseManager.Instance.SaveUserDataByNode(FirebaseSavesByDeviceController.DEVICE_ID, saveTag, json, Native.FirebaseManager.EDBType.DEVICE);
            }
            Native.GoogleCloudSavesController.Instance.SaveDataRequest();
        }
        catch (System.Exception e)
        {
            Debug.LogErrorFormat("PPSerialization.Save ({0}) Exception_2: {1}", saveTag, e.Message);
        }
#else
		Native.FirebaseManager.Instance.SaveUserDataByNode(SaveManager.ProfileSettings.CurrentProfileID, saveTag, json);
		Native.GoogleCloudSavesController.instance.SaveDataRequest();
#endif
        int count = pendingForSavingToCloud.Count;
        for (int i = 0; i < count; i++)
        {
            if (pendingForSavingToCloud[i] == saveTag)
            {
                pendingForSavingToCloud.RemoveAt(i);
                break;
            }
        }
    }

    /// <summary>
    ///This type of saving will be bypassing saves data caching ( so cached save data will be wrong ).
    ///If it is not desired behaviour call ClearCachedSavesData method after.
    ///Currently used only for direct writing of saves data after loading from cloud.
    /// </summary>
    public static void Save(string saveTag, string jsonString)
    {
        if (cachedData.ContainsKey(saveTag))
        {
            cachedData[saveTag] = jsonString;
        }
        else
        {
            cachedData.Add(saveTag, jsonString);
        }
        string encrypted = Encryption.Encrypt(jsonString);
        PlayerPrefs.SetString(saveTag, encrypted);
        //SaveToCloud(saveTag, encrypted);
    }

    public static T Load<T>(EPrefsKeys prefsKey, T defaultValue = null) where T : class
    {
        return Load<T>(prefsKey.ToString(), defaultValue);
    }

    public static T Load<T>(string saveTag, T defaultValue = null) where T : class
    {
        string outData;
        if (cachedData.TryGetValue(saveTag, out outData))
        {
            if (!string.IsNullOrEmpty(outData))
            {
                //Debug.LogFormat("Loading cached data.  SaveTag: {0}  Data: {1}", saveTag, outData);
                return JsonUtility.FromJson<T>(outData);
            }
        }

        try
        {
            string temp = PlayerPrefs.GetString(saveTag);
            if (string.IsNullOrEmpty(temp))
            {
                //Debug.Log( "No data on load for: "+saveTag );
                return defaultValue;
            }
            temp = Encryption.Decrypt(temp);
            return GetDataWithValidation<T>(temp);
        }
        catch (System.Exception e)
        {
            Debug.LogFormat("Load Exception {0} saveTag: {1}", e.Message, saveTag);
            if (defaultValue == null)
            {
                defaultValue = default(T);
            }
            return defaultValue;
        }
    }

    private static T GetDataWithValidation<T>(string dataString) where T : class
    {
        var result = JsonUtility.FromJson<T>(dataString);
        if (result is ArrayInClassWrapper)
        {
            (result as ArrayInClassWrapper).ValidateInnerArraySize();
        }
        return result;
    }

    public static void FileSave(string name, string data)
    {
        var path = Path.Combine(Application.streamingAssetsPath, "Saves" , name + ".json");
        File.WriteAllText(path , data);
    }

}