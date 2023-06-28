using System;
using System.Collections;
using UnityEngine;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi;
#if !NO_GPGS
using GooglePlayGames;
#endif
namespace Native
{
    public partial class GoogleCloudSavesController : MonoSingleton<GoogleCloudSavesController>
    {
        private const string SAVE_FILE_NAME = "SaveFile";
        private const string USERID_PREFS_KEY = "GPGSUserID";
        private const float SAVE_ALL_DATA_INTERVAL = 2f;

        private CloudSaves cloudSaves;
        private GameSave gameSave;
        private string prevSavedJson;

        private bool isNewAccount;
        private bool isInitialized;
        private bool isAnyUnsavedData;
        private bool isRegisteredToLoadingFromCloudQueue;
        private bool waitForSaveCoroutineStarted;
        private bool saveDataAtFrameEndStarted;
        private float lastSaveAllDataTime;

        private static int loadingOperationsNumber;
        private static bool IsAnyLoadOperationRunning { get; set; }

        public static bool IsAvailable => Instance.isInitialized && UnityEngine.Social.localUser.authenticated && !IsAnyLoadOperationRunning;

        private bool IsSaveDataCanBeSaved => Time.unscaledTime - lastSaveAllDataTime > SAVE_ALL_DATA_INTERVAL;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        private void Init()
        {
            try
            {
                if (cloudSaves == null)
                {
                    cloudSaves = new CloudSaves(SAVE_FILE_NAME, ResolveSavesDataConflict);
                    gameSave = new GameSave();
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Init Error: " + e.Message);
            }
        }

        public void OnUserLoggedIn()
        {
            if (isInitialized)
            {
                return;
            }
            Init();
            isInitialized = true;
            isNewAccount = false;

            LoadDataFromCloud();
        }

        public static void LoadDataFromCloud()
        {
            try
            {
    #if !NO_GPGS
                string savedUserID = PlayerPrefs.GetString(USERID_PREFS_KEY, "");
                string currentUserID = PlayGamesPlatform.Instance.GetUserId();
                PlayerPrefs.SetString(USERID_PREFS_KEY, savedUserID);
                bool newAccount = (savedUserID != currentUserID) && !string.IsNullOrEmpty(savedUserID);
                PPSerialization.ClearCachedSavesData();
                if (newAccount)
                {
                    PPSerialization.ClearAllPendingSaves();
                }
                Debug.LogFormat("OnUserLogin newAccount:{0}, oldUserID:{1} currentUserID:{2}", newAccount, savedUserID ?? "null", currentUserID);
    #endif

                Instance.OpenSavedGame(SAVE_FILE_NAME);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        void OpenSavedGame(string filename)
        {
            try
            {
                Debug.Log($"!!!!!!!!!! ===================== OpenSavedGame");
    #if UNITY_ANDROID || UNITY_IOS
                ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                savedGameClient?.OpenWithAutomaticConflictResolution(filename, DataSource.ReadNetworkOnly,
                    ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
    #endif
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        void OnConflict(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData, ISavedGameMetadata unmerged, byte[] unmergedData)
        {
            Debug.Log($"!!!!!!!!!! ===================== OnConflict unmerged: {unmerged.TotalTimePlayed}, lenght: {unmergedData.Length}");
        }

        public void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
        {
            try
            {
                Debug.Log($"!!!!!!!!!! ===================== OnSavedGameOpened");
                if (status == SavedGameRequestStatus.Success)
                {
                    // handle reading or writing of saved game.
                    Debug.Log($"!!!!!!!!!! handle reading or writing of saved game.");
    #if UNITY_ANDROID || UNITY_IOS
                    ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                    savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
    #endif
                }
                else
                {
                    Debug.Log($"!!!!!!!!!! handle ERROR");
                    for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
                        PlayServices.callbackLogin[i](false);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] data)
        {
            Debug.Log($"!!!!!!!!!! ===================== OnSavedGameDataRead: {status}");
            if (status == SavedGameRequestStatus.Success)
            {
                try
                {
                    Debug.Log($"==== loaded data save is null: {(data == null)}");
                    Debug.Log($"==== loaded data save length: {data.Length}");
                    gameSave = JsonUtility.FromJson<GameSave>(data.GetString());
                    SaveManager.GameProgress cloudProgress;
                    if (gameSave == null)
                    {
                        gameSave = new GameSave();
                        cloudProgress = new SaveManager.GameProgress();
                    }
                    else
                    {
                        cloudProgress = gameSave.TryGetParsedData<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString());
                        Debug.Log($"=========== Levels completed from cloud: {cloudProgress.CompletedLevelsNumber} ====================");
                        Debug.Log($"=========== Gold from cloud: {cloudProgress.gold} ====================");
                    }
                    Debug.Log($"=========== Levels completed from device: {SaveManager.GameProgress.Current.CompletedLevelsNumber} ====================");
                    Debug.Log($"=========== Gold from device: {SaveManager.GameProgress.Current.gold} ====================");
                    isNewAccount = cloudProgress.CompletedLevelsNumber == 0 &&
                                   SaveManager.GameProgress.Current.CompletedLevelsNumber == 0;
                    if (isNewAccount)
                    {
                        gameSave.SaveAllDataToPrefs();
                        LoadFromCloudQueue.OnCompleteLoadFromCloud();
                        IsAnyLoadOperationRunning = false;
                        for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
                            PlayServices.callbackLogin[i](false);
                    }
                    else
                    {
                        UICloudSavesResolutionDialog.Create(cloudProgress.CompletedLevelsNumber, cloudProgress.gold, (bool loadDataFromCloud) =>
                        {
                            if (loadDataFromCloud)
                            {
                                gameSave.SaveAllDataToPrefs();
                            }
                            MarkAllLoadOperationsAsCompleted();
                        });
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"++++++++++++++++ OnSavedGameDataLoadAttemptCompleted exception: {e.Message}");
                    MarkAllLoadOperationsAsCompleted();
                    for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
                        PlayServices.callbackLogin[i](false);
                }
            }
            else
            {
                // handle error
                Debug.Log($"!!!!!!!!!! ERROR byte array");
                for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
                    PlayServices.callbackLogin[i](false);
            }
        }


        void DeleteGameData(string filename)
        {
            // Open the file to get the metadata.
#if UNITY_ANDROID || UNITY_IOS

            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
            savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime, DeleteSavedGame);
#endif
        }

        public void DeleteSavedGame(SavedGameRequestStatus status, ISavedGameMetadata game)
        {
            if (status == SavedGameRequestStatus.Success)
            {
#if UNITY_ANDROID || UNITY_IOS

                ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                savedGameClient.Delete(game);
#endif
            }
            else
            {
                // handle error
            }
        }
        
        public void OnUserLogout()
        {
            isInitialized = false;
            isNewAccount = false;
            EnsureUnregisteredFromLoadQueue();
        }

        private void EnsureUnregisteredFromLoadQueue()
        {
            if (isRegisteredToLoadingFromCloudQueue)
            {
                isRegisteredToLoadingFromCloudQueue = false;
                LoadFromCloudQueue.UnregistedFromLoadQueue(LoadDataFromCloud);
            }
        }

        private void MarkAllLoadOperationsAsCompleted()
        {
            LoadFromCloudQueue.OnCompleteLoadFromCloud();
            IsAnyLoadOperationRunning = false;
            //CloudSavesLoadingProcessTracker.Instance.OnProcessCompleted(this.GetType().Name);
        }

#region CONFLICT RESOLVING
        /// <summary>
        /// if returns true select original else select unmerged data
        /// based on recieved data select one of the given data, or create new
        /// </summary>
        private bool ResolveSavesDataConflict(CloudSaves cloudSave, byte[] original, byte[] unmerged)
        {
            if (original == unmerged)
            {
                return true;
            }
#if UNITY_ANDROID || UNITY_IOS

            switch (cloudSave.SaveTag)
            {
                case SAVE_FILE_NAME:
                    GameSave originalSave = JsonUtility.FromJson<GameSave>(original.GetString());
                    GameSave unmergedSave = JsonUtility.FromJson<GameSave>(unmerged.GetString());
                    SaveManager.GameProgress originalProgress = originalSave.TryGetParsedData<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString());
                    IntArrayWrapper originalAchievementConditions = originalSave.TryGetParsedData<IntArrayWrapper>(EPrefsKeys.AchievemtConditions.ToString());

                    SaveManager.GameProgress unmergedProgress = unmergedSave.TryGetParsedData<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString());
                    IntArrayWrapper unmergedAchievementConditions = unmergedSave.TryGetParsedData<IntArrayWrapper>(EPrefsKeys.AchievemtConditions.ToString());

                    return SaveConflictResolver.IsOriginalDataBetter(originalProgress, originalAchievementConditions, unmergedProgress, unmergedAchievementConditions);
            }
#endif
            return false;
        }
#endregion

#region SAVE DATA
        private IEnumerator SaveDataAtEndOfFrame()
        {
            yield return new WaitForEndOfFrame();
            saveDataAtFrameEndStarted = false;
            SaveAllData();
        }

        private IEnumerator WaitForSaveData()
        {
            var waitUntil = new WaitUntil(() =>
           {
               return IsSaveDataCanBeSaved
#if UNITY_ANDROID || UNITY_IOS
               && !cloudSaves.CurrentlySaving
#endif
               ;
           });
            yield return waitUntil;
            waitForSaveCoroutineStarted = false;
            SaveAllData();
        }

        public void SaveDataRequest()
        {
            if (!IsAvailable || loadingOperationsNumber > 0)
            {
                return;
            }
#if UNITY_ANDROID || UNITY_IOS

            if (cloudSaves.CurrentlySaving || !IsSaveDataCanBeSaved)
            {
                isAnyUnsavedData = true;
                Debug.LogFormat("Save data delayed currentlySaving: {0} IsSaveDataCanBeSaved:{1}", cloudSaves.CurrentlySaving, IsSaveDataCanBeSaved);
                if (!waitForSaveCoroutineStarted)
                {
                    StartCoroutine(WaitForSaveData());
                }
            }
            else
            {
                if (!saveDataAtFrameEndStarted)
                {
                    saveDataAtFrameEndStarted = true;
                    StartCoroutine(SaveDataAtEndOfFrame());
                }
                else
                {
                    Debug.Log("Saving data skipped because of SaveDataAtEndOfFrame already started");
                }
            }
#endif
        }

        private void OnSaveDataFailure()
        {
            isAnyUnsavedData = true;
            if (!waitForSaveCoroutineStarted && IsAvailable)
            {
                StartCoroutine(WaitForSaveData());
            }
        }

        private void SaveAllData()
        {
            gameSave.CollectAllData();
            string jsonToSave = JsonUtility.ToJson(gameSave);
            //TODO: надо сделать по другому
            if (prevSavedJson == jsonToSave)
            {
                return;
            }
            
            SaveManager.GameProgress progress = gameSave.TryGetParsedData<SaveManager.GameProgress>(EPrefsKeys.Progress.ToString());
            Debug.Log($"SaveAllData: level: { progress.CompletedLevelsNumber }");
            Debug.Log($"SaveAllData: gold: { progress.gold }");
            
            byte[] dataToSave = jsonToSave.GetBytes();
            lastSaveAllDataTime = Time.unscaledTime;
            isAnyUnsavedData = false;
            cloudSaves.SaveGame(dataToSave, result =>
            {
                if (!result)
                {
                    OnSaveDataFailure();
                }
                else
                {
                    prevSavedJson = jsonToSave;
                }
            });
        }
#endregion

        private bool alreadyReseting= false;
        public static void Reset(System.Action<bool> onReset = null)
        {
#if UNITY_ANDROID || UNITY_IOS

            if (Instance.alreadyReseting || !Instance.isInitialized || Instance.cloudSaves.CurrentlySaving)
            {
                onReset.InvokeSafely(false);
                return;
            }
            Instance.alreadyReseting = true;
            Instance.cloudSaves.Reset(result =>
            {
                Instance.alreadyReseting = false;
                onReset?.Invoke(result);
            });
#endif
        }
    }
}
