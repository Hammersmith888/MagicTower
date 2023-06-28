
using System.Collections.Generic;
using UnityEngine;

namespace Native
{
    public partial class GoogleCloudSavesController
    {
        [System.Serializable]
        private class GameSave
        {
            public List<string> keys;
            public List<string> values;

            public GameSave()
            {
                keys = new List<string>();
                values = new List<string>();
            }

            public T TryGetParsedData<T>(string prefsKey)
            {
                int indexOf = keys.IndexOf(prefsKey);
                if (indexOf >= 0)
                {
                    string jsonData = values[indexOf];
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        return JsonUtility.FromJson<T>(jsonData);
                    }
                }
                return default(T);
            }

            //public void AddOrUpdateData( string tag, string data )
            //{
            //	int dataIndex =	keys.IndexOf( tag );
            //	if( dataIndex < 0 )
            //	{
            //		keys.Add( tag );
            //		values.Add( data );
            //	}
            //	else
            //	{
            //		values[ dataIndex ] = data;
            //	}
            //}

            public void SaveAllDataToPrefs()
            {
                PPSerialization.ClearCachedSavesData();
                PPSerialization.ClearAllPendingSaves();

                int count = keys.Count;
                for (int i = 0; i < count; i++)
                {
                    if (!string.IsNullOrEmpty(values[i]))
                    {
                        PPSerialization.Save(keys[i], values[i]);
                    }
#if DEBUG_MODE
                    else
                    {
                        Debug.LogFormat($"SaveAllDataToPrefs data is null by <b>{keys[i]}</b>");
                    }
#endif
                }
                SaveManager.OnSavesDataReloaded();
            }

            public void CollectAllData()
            {
                int prefsNumber = System.Enum.GetValues(typeof(EPrefsKeys)).Length;
                for (int i = 0; i < prefsNumber; i++)
                {
                    if (!keys.Contains(((EPrefsKeys)i).ToString()))
                    {
                        keys.Add(((EPrefsKeys)i).ToString());
                        values.Add(PPSerialization.GetJsonDataFromPrefs(keys[i]));
                    }
                    else
                    {
                        values[i] = PPSerialization.GetJsonDataFromPrefs(keys[i]);
                    }
                }
            }

            public void ClearAllData()
            {
                keys.Clear();
                values.Clear();
            }
        }

    }
}
