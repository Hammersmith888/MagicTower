using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELocalPrefsKey
{
    ShopHighlightingData
}

public static class LocalPrefsKeyExtensions
{
    public static void Save<T>(this ELocalPrefsKey key, T data)
    {
        string json = JsonUtility.ToJson(data);

        if (string.IsNullOrEmpty(json))
        {
            Debug.Log("<color=red>Null json</color> " + key);
            return;
        }
        PlayerPrefs.SetString(key.ToString(), json);
    }

    public static T Load<T>(this ELocalPrefsKey key, T defaultValue = null) where T : class, new()
    {
        T result = null;
        try
        {
            string savedJsonString = PlayerPrefs.GetString(key.ToString());
            if (!string.IsNullOrEmpty(savedJsonString))
            {
                result = JsonUtility.FromJson<T>(savedJsonString);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogFormat("Local data load Exception {0} saveTag: {1}. Default data will be loaded.", e.Message, key);
        }

        if (result == null)
        {
            if (defaultValue == null)
            {
                result = new T();
            }
            else
            {
                result = defaultValue;
            }
        }

        var validatable = result as IValidatable;
        if (validatable != null)
        {
            validatable.Validate();
        }
        return result;
    }
}
