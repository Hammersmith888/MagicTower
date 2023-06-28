using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameMetaSave
{
    public string utcSave;
    public int level;
    public int gold;
    public string googleID;
    public string facebookID;
    public string iosID;

    public static GameMetaSave Load()
    {
        var s = PPSerialization.Load<GameMetaSave>("GameMetaSave");
        if (s == null)
            s = new GameMetaSave();
        return s;
    }

    public static void SetData(int coins, int level)
    {
        var s = Load();
        s.gold = coins;
        s.level = level;
        DateTime newD = DateTime.UtcNow;
        Int32 unixNext = (Int32)(newD.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        s.utcSave = unixNext.ToString();
        PPSerialization.Save<GameMetaSave>("GameMetaSave", s);
    }
}
