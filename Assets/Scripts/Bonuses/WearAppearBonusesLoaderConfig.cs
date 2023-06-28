using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WearAppearBonusesLoaderConfig", menuName = "Custom/WearAppearBonusesLoaderConfig")]
public class WearAppearBonusesLoaderConfig : ScriptableObject
{
    private static WearAppearBonusesLoaderConfig _instance;
    public static WearAppearBonusesLoaderConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<WearAppearBonusesLoaderConfig>("WearAppearBonusesLoaderConfig");
            }
            return _instance;
        }
    }

    [System.Serializable]
    private class WearBonusItemData
    {
        public int itemNumber;
        [ResourceFile(resourcesFolderPath = "Bonuses/Wear")]
        public string itemAdress;

        private GameObject loadedObject;
        public GameObject PrefabObject
        {
            get
            {
                if (loadedObject == null)
                {
                    loadedObject = Resources.Load<GameObject>(itemAdress);
                }
                return loadedObject;
            }
        }
    }

    [SerializeField]
    private List<WearBonusItemData> wearBonusItems = new List<WearBonusItemData>();

    public GameObject GetWearBonusPrefab(int wearItemIdNumber)
    {
        for (int i = 0; i < wearBonusItems.Count; i++)
        {
            if (wearBonusItems[i].itemNumber == wearItemIdNumber)
            {
                return wearBonusItems[i].PrefabObject;
            }
        }

        return new GameObject();
    }

}
