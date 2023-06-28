
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using GameProgress = SaveManager.GameProgress;

public static class SaveConflictResolver
{
    public static bool DeviceProgressIsBetter(GameProgress alternativeProgress, IntArrayWrapper alternativeAchievementConditions)
    {
        var currentGameProgress = PPSerialization.Load<GameProgress>(EPrefsKeys.Progress.ToString());
        var currentAchievementsData = PPSerialization.Load<IntArrayWrapper>(EPrefsKeys.AchievemtConditions.ToString());
        return IsOriginalDataBetter(currentGameProgress, currentAchievementsData, alternativeProgress, alternativeAchievementConditions);
    }

    public static bool DeviceProgressIsBetter(Hashtable storageData)
    {
        var alterntaiveGameProgress = GetStorageSinglePref<GameProgress>(storageData, EPrefsKeys.Progress.ToString());
        var alternativeAchievementsConditions = GetStorageSinglePref<IntArrayWrapper>(storageData, EPrefsKeys.AchievemtConditions.ToString());
        return DeviceProgressIsBetter(alterntaiveGameProgress, alternativeAchievementsConditions);
    }

    public static bool IsOriginalDataBetter(GameProgress originalProgress, IntArrayWrapper origionalAchievementConditions, GameProgress alternativeProgress, IntArrayWrapper alternativeAchievementConditions)
    {
        if (alternativeProgress == null && (alternativeAchievementConditions == null || alternativeAchievementConditions.getInnerArray.IsNullOrEmpty()))
        {
            Debug.Log("Alternative save data is null selecting original data");
            return true;
        }

        if (origionalAchievementConditions != null && !origionalAchievementConditions.getInnerArray.IsNullOrEmpty())
        {
            if (origionalAchievementConditions[0] != alternativeAchievementConditions[0])
            {
                Debug.LogFormat("Selected {0} progress. Unmerged Total gold: {1}  OriginalTotalGold: {2}", 
                                (alternativeAchievementConditions[0] < origionalAchievementConditions[0] ? "Original" : "Unmerged"),
                                alternativeAchievementConditions[0], origionalAchievementConditions[0]);
                return origionalAchievementConditions[0] > alternativeAchievementConditions[0];//Compare total gold count accured by player
            }
        }

        if (alternativeProgress == null)
        {
            Debug.Log("Alternative progress data is null selecting original data");
            return true;
        }

        if (originalProgress != null)
        {
            int openedLevelsNumber = originalProgress.finishCount.Count(i => i > 0);
            int openedLevelsNumberAlternative = alternativeProgress.finishCount.Count(i => i > 0);
            if (openedLevelsNumber != openedLevelsNumberAlternative)
            {
                Debug.LogFormat("Selected {0} progress. Unmerged levels: {1}  OriginlLevels: {2}",
                    (openedLevelsNumberAlternative < openedLevelsNumber ? "Original" : "Unmerged"), 
                    openedLevelsNumberAlternative, openedLevelsNumber);
                return openedLevelsNumber > openedLevelsNumberAlternative;
            }
            else
            {
                Debug.LogFormat("Selected {0} progress. StorageGold: {1}  OrigionalGold: {2}", 
                    (originalProgress.gold > alternativeProgress.gold ? "Original" : "Unmerged"), 
                    alternativeProgress.gold, originalProgress.gold);
                return originalProgress.gold > alternativeProgress.gold;
            }
        }
        else
        {
            Debug.Log("No progress on device selecting alternative");
            return false;
        }
    }

    public static T GetStorageSinglePref<T>(Hashtable storageData, string name)
    {
        DictionaryEntry dicEntry;
        string temp = string.Empty;
        foreach (var entry in storageData)
        {
            dicEntry = (DictionaryEntry)entry;
            if (dicEntry.Key.ToString() == name)
            {
                temp = JSON.JsonEncode(dicEntry.Value);
                break;
            }
        }
        if (string.IsNullOrEmpty(temp))
        {
            return default(T);
        }
        return JsonUtility.FromJson<T>(temp);
    }
}
