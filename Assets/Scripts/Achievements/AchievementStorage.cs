using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement_Items : ArrayInClassWrapper<AchievementItem>
{
    protected override int ValidArraySize
    {
        get
        {
            return AchievementItem.TotalItemsNumber;
        }
    }

    public Achievement_Items() { }
    public Achievement_Items(int capacity) : base(capacity) { }
}
    [System.Serializable]
    public class AchievementItem
    {
        public const int TotalItemsNumber = 38;
        public const int TotalItemsNumberView = 37;
        public AchievmentState currentState;
        public AchievementItem()
        {
            SetNonSerializedParameters();
        }

        public virtual void SetNonSerializedParameters()
        {

        }
    }
    public static class AchievementStorage
    {
    private static Achievement_Items storage;
    private static IntArrayWrapper serializeData = null;

    //используется для отображения.Чтобы изменять порядок отображения ачивок в UI.
    private static Achievement_Items storageView;


    private static bool StorageIsEmpty()
    {
        return storage == null || storage.getInnerArray.IsNullOrEmpty();
    }

    private static void LoadStorage()
    {
        storage = PPSerialization.Load<Achievement_Items>(EPrefsKeys.AchievementItems);
    }

    private static void InitStorage()
    {
        LoadStorage();
        if (!StorageIsEmpty())
        {
            
        }
        else
        {
            
        }

        SaveStorage();
    }

  
    public static void SaveStorage(bool toCloud = true)
    {
        PPSerialization.Save(EPrefsKeys.AchievementItems.ToString(), storage, toCloud, true);
    }

    public static void LoadSerializeData()
    {
        serializeData = PPSerialization.Load<IntArrayWrapper>(EPrefsKeys.AchievemtConditions.ToString());
    }
}