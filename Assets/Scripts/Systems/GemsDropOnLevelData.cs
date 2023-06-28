
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsDropOnLevelData
{
    private static GemsDropOnLevelData current;

    private int currentLevel;
    private Dictionary<string,int> GemsDropData;

    private GemsDropOnLevelData(int level)
    {
        currentLevel = level;
        GemsDropData = new Dictionary<string, int>();
    }

    public static void Initialize(int level)
    {
        current = new GemsDropOnLevelData(level);
    }

    public static void SendDataToAnalytics()
    {
        try
        {
            if (current.currentLevel >= 0)
            {
                current.SendData();
            }
            current = null;
        }
        catch { }
    }

    public static void GemDropped(GemType gemType, int gemLevel)
    {
        var key = string.Format("{0} {1}", gemType, gemLevel);
        if (current.GemsDropData.ContainsKey(key))
        {
            current.GemsDropData[key]++;
        }
        else
        {
            current.GemsDropData.Add(key, 1);
        }
    }

    private void SendData()
    {
#if UNITY_EDITOR
        var logBuilder = new System.Text.StringBuilder();
        logBuilder.Append(string.Format("<b>Gems Drop On Level {0} Data</b>", currentLevel));
        logBuilder.AppendLine();
        foreach (var pair in GemsDropData)
        {
            logBuilder.Append(pair.Key);
            logBuilder.Append(" = ");
            logBuilder.Append(pair.Value);
            logBuilder.AppendLine();
        }
        Debug.Log(logBuilder.ToString());
#endif
        try
        {
            Analytics.DevToDevAnalytics.instance.LogEvent(string.Format("Gems Drop On Level {0} Data", currentLevel), GemsDropData);
        }
        catch
        {
            Debug.Log($"ERROR GemDropsDATA");
        }
       
    }
}
