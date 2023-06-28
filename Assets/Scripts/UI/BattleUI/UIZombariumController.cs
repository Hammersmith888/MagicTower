
#define _ZOMBARIUM_LOG
using UnityEngine;
using System.Collections.Generic;

public class UIZombariumController : MonoBehaviour
{
    [System.Serializable]
    private class ZombariumStatus
    {
        public int lastOpenedEnemyTypeID;
        public List<int> notViewedInfoIds;

        public ZombariumStatus()
        {
            lastOpenedEnemyTypeID = -1;
            notViewedInfoIds = new List<int>();
        }
    }

    private const string ZombariumStatusPrefsKey = "ZombariumStatus";

    #region VARIABLES
    private int currentActivePanel;

    [SerializeField]
    private GameObject[] infoPanelsGameObjects;

    [SerializeField]
    private GameObject nextBtn;

    [SerializeField]
    private GameObject prewBtn;

    [SerializeField]
    private GameObject infoBtn;

    [SerializeField]
    private InfoCallScript infoCallScript;

    private ZombariumStatus zombariumStatus;

    private UIInfoAnimation infoButtonAnimation;
    private bool infoWindowOpened;
    private bool waitingForSavingToCloud;

    private static UIZombariumController m_Current;
    public static UIZombariumController Current
    {
        get
        {
            if (m_Current == null)
            {
                m_Current = FindObjectOfType<UIZombariumController>();
            }
            return m_Current;
        }
    }
    #endregion

    private void Awake()
    {
        m_Current = this;
        if (infoBtn != null)
        {
            infoButtonAnimation = infoBtn.GetComponent<UIInfoAnimation>();
        }
        Load();
    }

    private void OnEnable()
    {
        if (infoCallScript != null)
        {
            infoCallScript.OnEnemyInfoViewed += OnEnemyInfoViewed;
        }
    }

    private void OnDisable()
    {
        if (infoCallScript != null)
        {
            infoCallScript.OnEnemyInfoViewed -= OnEnemyInfoViewed;
        }
        SaveSetings();
    }

    private void LateUpdate()
    {
        if (infoWindowOpened && !infoCallScript.IsOpened)
        {
            SaveSetings();
            infoWindowOpened = false;
        }
    }

    private void SaveSetings()
    {
        PPSerialization.Save(ZombariumStatusPrefsKey, zombariumStatus, false);
        if (!waitingForSavingToCloud)
        {
            waitingForSavingToCloud = true;
            SaveSettingsToCloud();
        }
    }

    private void OnEnemyInfoViewed(EnemyType enemyType)
    {
        if (zombariumStatus.notViewedInfoIds.Contains((int)enemyType))
        {
            Log("OnEnemyInfoViewed <b>{0}</b>", enemyType);
            zombariumStatus.notViewedInfoIds.Remove((int)enemyType);
            PPSerialization.Save(ZombariumStatusPrefsKey, zombariumStatus, false);
            if (zombariumStatus.notViewedInfoIds.Count == 0 && infoButtonAnimation != null)
            {
                infoButtonAnimation.StopAnimation();
            }
        }
    }

    private void SaveSettingsToCloud()
    {
        waitingForSavingToCloud = false;
        PPSerialization.Save(ZombariumStatusPrefsKey, zombariumStatus, true, true);
    }

    private void Load()
    {
        //zombariumStatus = PPSerialization.Load<ZombariumStatus>(ZombariumStatusPrefsKey);
        //if (zombariumStatus == null)
        //{
        //    zombariumStatus = new ZombariumStatus();
        //    SaveSetings();
        //}
        //else
        //{
        //    if (zombariumStatus.notViewedInfoIds == null)
        //    {
        //        zombariumStatus.notViewedInfoIds = new List<int>();
        //    }
        //}
        //InfoLoaderConfig.Instance.maxOpenedLevel = mainscript.CurrentLvl - 1;
        ////var enemyTypesOnLevel = InfoLoaderConfig.Instance.GetEnemyTypesOnLevel(mainscript.CurrentLvl, true);
        ////if (!enemyTypesOnLevel.IsNullOrEmpty())
        ////{
        ////    var isAnyChange = false;
        ////    for (int i = 0; i < enemyTypesOnLevel.Count; i++)
        ////    {
        ////        isAnyChange |= UnlockNewEnemyInfo(enemyTypesOnLevel[i]);
        ////    }
        ////    if (isAnyChange)
        ////    {
        ////        SaveSetings();
        ////    }
        ////}

        //if (zombariumStatus.notViewedInfoIds.Count > 0)
        //{
        //    currentActivePanel = zombariumStatus.notViewedInfoIds[0];
        //    if (infoButtonAnimation != null)
        //    {
        //        infoButtonAnimation.AnimateButton();
        //    }
        //}
        //else
        //{
        //    currentActivePanel = 0;
        //    if (zombariumStatus.lastOpenedEnemyTypeID >= 0)
        //    {
        //        currentActivePanel = zombariumStatus.lastOpenedEnemyTypeID;
        //    }
        //    if (infoButtonAnimation != null)
        //    {
        //        infoButtonAnimation.StopAnimation();
        //    }
        //}

        zombariumStatus = PPSerialization.Load<ZombariumStatus>(ZombariumStatusPrefsKey);
        if (zombariumStatus == null)
        {
            zombariumStatus = new ZombariumStatus();
            SaveSetings();
        }
        else
        {
            if (zombariumStatus.notViewedInfoIds == null)
            {
                zombariumStatus.notViewedInfoIds = new List<int>();
            }
        }
        InfoLoaderConfig.Instance.maxOpenedLevel = mainscript.CurrentLvl - 1;
        var enemyTypesOnLevel = InfoLoaderConfig.Instance.GetEnemyTypesOnLevel(mainscript.CurrentLvl, true);
        if (!enemyTypesOnLevel.IsNullOrEmpty())
        {
            var isAnyChange = false;
            for (int i = 0; i < enemyTypesOnLevel.Count; i++)
            {
                isAnyChange |= UnlockNewEnemyInfo(enemyTypesOnLevel[i]);
            }
            if (isAnyChange)
            {
                SaveSetings();
            }
        }

        if (zombariumStatus.notViewedInfoIds.Count > 0)
        {
            currentActivePanel = zombariumStatus.notViewedInfoIds[0];
            if (infoButtonAnimation != null)
            {
                infoButtonAnimation.AnimateButton();
            }
        }
        else
        {
            currentActivePanel = 0;
            if (zombariumStatus.lastOpenedEnemyTypeID >= 0)
            {
                currentActivePanel = zombariumStatus.lastOpenedEnemyTypeID;
            }
            if (infoButtonAnimation != null)
            {
                infoButtonAnimation.StopAnimation();
            }
        }
    }

    private bool UnlockNewEnemyInfo(EnemyType enemyType)
    {
        var enemyId = (int)enemyType;
        Log("<color=magenta>AddNewInfoPanel</color> {0}. In Not Viewed List: {1}",
            enemyType, zombariumStatus.notViewedInfoIds.Contains(enemyId));
        if (zombariumStatus.notViewedInfoIds.Contains(enemyId))
        {
            return false;
        }
        if (zombariumStatus.lastOpenedEnemyTypeID >= 0)
        {
            var newEnemyInfoUnlockIndex = enemyType.GetInfoUnlockOrderIndex();
            var currentEnemyInfoUnlockIndex = ((EnemyType)zombariumStatus.lastOpenedEnemyTypeID).GetInfoUnlockOrderIndex();
            if (newEnemyInfoUnlockIndex <= currentEnemyInfoUnlockIndex)
            {
                Log("<color=orange>{0}</color>. Was Already Unlocked.", enemyType);
                return false;
            }
        }
        Log("<color=green><size=15>{0}</size></color>  <b>Info Unlocked</b>", enemyType);
        zombariumStatus.lastOpenedEnemyTypeID = enemyId;
        zombariumStatus.notViewedInfoIds.Add(enemyId);
        return true;
    }

    public void OnInfoButtonClick()
    {
        bool onTutor = false;
        if (!SaveManager.GameProgress.Current.tutorial[12] && mainscript.CurrentLvl == 5)
        {
            UnlockNewEnemyInfo(EnemyType.zombie_murderer);
            currentActivePanel = (int)EnemyType.zombie_murderer;
            onTutor = true;
        }
        else
        {
            if (zombariumStatus.notViewedInfoIds.Count > 0)
            {
                currentActivePanel = zombariumStatus.notViewedInfoIds[0];
                Debug.Log("notViewedInfoIds: " + currentActivePanel);
            }
            else
            {
                currentActivePanel = 0;
                //if (zombariumStatus.lastOpenedEnemyTypeID >= 0)
                //{
                //    currentActivePanel = zombariumStatus.lastOpenedEnemyTypeID;
                //    Debug.Log("lastOpenedEnemyTypeID: " + currentActivePanel);
                //}
            }
        }

        SaveManager.GameProgress.Current.tutorial[12] = true;
        SaveManager.GameProgress.Current.Save();

        if (currentActivePanel >= 0)
        {
            Log("OnInfoButtonClick: {0}", (EnemyType)currentActivePanel);
            Time.timeScale = 0;
            infoWindowOpened = true;
            infoCallScript.showWhileTutor = onTutor;
            infoCallScript.ShowEnemyScreen(currentActivePanel);
        }
    }

    [System.Diagnostics.Conditional("ZOMBARIUM_LOG")]
    private void Log(string message, params object[] args)
    {
        if (args.Length > 0)
        {
            Debug.LogFormat(message, args);
        }
        else
        {
            Debug.Log(message);
        }
    }

#if UNITY_EDITOR
    [SerializeField]
    [Header("EditorVariables")]
    private bool resetZombarium;

    private void OnDrawGizmosSelected()
    {
        if (resetZombarium)
        {
            resetZombarium = false;
            if (zombariumStatus == null)
            {
                zombariumStatus = PPSerialization.Load<ZombariumStatus>(ZombariumStatusPrefsKey);
            }
            zombariumStatus = new ZombariumStatus();
            PPSerialization.Save(ZombariumStatusPrefsKey, zombariumStatus, false);
            Debug.Log("Zombarium reseted");
        }
    }
#endif
}
