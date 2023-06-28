using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationsByLevelConfig", menuName = "Custom/LocationsByLevelConfig")]
public class LocationsByLevelConfig : ScriptableObject
{
    [System.Serializable]
    private class LevelToChangeLocation
    {
        public int levelNumber;
        [ResourceFile(resourcesFolderPath ="Locations")]
        public string locationName;
    }

    [SerializeField]
    [ResourceFile(resourcesFolderPath ="Locations")]
    private string defaultLocation;
    [SerializeField]
    private LevelToChangeLocation[] levelsToChangeLocation;


    public string GetLocationByLevel(int levelNumber)
    {
        if(levelNumber == 15)
        {
            return levelsToChangeLocation[0].locationName;
        }

        if (levelsToChangeLocation.IsNullOrEmpty())
        {
            return defaultLocation;
        }
        for (int i = 0; i < levelsToChangeLocation.Length; i++)
        {
            if (levelsToChangeLocation[i].levelNumber == levelNumber)
            {
                return levelsToChangeLocation[i].locationName;
            }
            else if (levelsToChangeLocation[i].levelNumber > levelNumber)
            {
                return i > 0 ? levelsToChangeLocation[i - 1].locationName : levelsToChangeLocation[i].locationName;
            }
            else if (i == levelsToChangeLocation.Length - 1)
            {
                return levelsToChangeLocation[i].locationName;
            }
        }
        return defaultLocation;
    }
}
