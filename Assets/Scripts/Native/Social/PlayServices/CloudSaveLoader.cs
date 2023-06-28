using Achievement;
using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using static Achievement.AchievementController;
using static SaveManager;
using static UISettingsPanel;

namespace Native
{
    public class CloudSaveLoader : MonoBehaviour
    {
        public static CloudSaveLoader instance;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
#if !UNITY_WSA
            PlayServices.Init();
#endif
            //ProfileSettings.Validate();
            PPSerialization.isCloudSave = true;
        }

        public bool isCloudSave = false;
        public bool isWaiting = false;
        public int isWaitingSetID = 0;
        public bool isGetData = false;
        public bool isGetDataGoogleID = false;

        [Header("EDITOR")]
        //public bool isTest = false;
        public string googleID;
        public string facebookID;
        public string iosID;

        public void SaveID(string id)
        {
            GameMetaSave save = GameMetaSave.Load();
            if (save == null)
                save = new GameMetaSave();
            save.googleID = id;
            Debug.Log($"Save google ID: {id}");
            PPSerialization.Save<GameMetaSave>("GameMetaSave", save, true, true);
        }

        public void LoadSave(string id = "")
        {
            Debug.Log($"LoadSave: {id}");
            if (id != "")
            {
                isGetData = false;
                isWaiting = true;
                FirebaseApp app = FirebaseApp.DefaultInstance;
                var database = FirebaseDatabase.GetInstance(app, "https://magic-siege-57930146.firebaseio.com/");
                Dictionary<Int32, string> dt = new Dictionary<Int32, string>();
                Dictionary<Int32, DataSnapshot> snap = new Dictionary<Int32, DataSnapshot>();
                List<Int32> u = new List<Int32>();

                database
                    .GetReference(Application.isEditor ? "users_editor" : "users")
                    .OrderByChild("GameMetaSave/googleID")
                    .EqualTo(id).ValueChanged += (s,e) => {
                        if (isGetData)
                            return;
                        foreach (var o in e.Snapshot.Children)
                        {
                            if(e.Snapshot.Child(o.Key + "/GameMetaSave/utcSave").Value.ToString() != "")
                            {
                                Int32 utc = Int32.Parse(e.Snapshot.Child(o.Key + "/GameMetaSave/utcSave").Value.ToString());
                                u.Add(utc);
                                dt.Add(utc, o.Key);
                                snap.Add(utc, o);
                            }
                            else
                            {
                                database.GetReference(Application.isEditor ? "users_editor" : "users").Child(o.Key).SetValueAsync(null);
                            }
                        }
                        if (u.Count > 1)
                        {
                            u.Sort();
                            u.Reverse();
                            u.RemoveAt(0);
                            foreach (var o in u)
                                database.GetReference(Application.isEditor ? "users_editor" : "users").Child(dt[o]).SetValueAsync(null);
                        }
                        if (u.Count > 0)
                        {
                            if (SaveManager.ProfileSettings.CurrentProfileID.ToString() != dt[u[0]].ToString())
                            {
                                Debug.Log("change id in database");
                                database.GetReference((Application.isEditor ? "users_editor" : "users")).Child(SaveManager.ProfileSettings.CurrentProfileID.ToString()).SetRawJsonValueAsync(snap[u[0]].GetRawJsonValue());
                                database.GetReference((Application.isEditor ? "users_editor" : "users")).Child(dt[u[0]]).SetValueAsync(null);
                            }
                        }
                        Debug.Log($"e.Snapshot.ChildrenCount: {e.Snapshot.ChildrenCount}");
                        Debug.Log($" u.Count: { u.Count}");
                        Debug.Log($"GameMetaSave: {e.Snapshot.Child(SaveManager.ProfileSettings.CurrentProfileID + "/GameMetaSave").ChildrenCount}");
                        if (e.Snapshot.ChildrenCount > 0 || u.Count == 0) //&& e.Snapshot.Child(SaveManager.ProfileSettings.CurrentProfileID + "/GameMetaSave/").ChildrenCount > 0
                        {
                            isGetDataGoogleID = false;
                            database
                            .GetReference(Application.isEditor ? "users_editor" : "users")
                            .OrderByChild(SaveManager.ProfileSettings.CurrentProfileID)
                            .ValueChanged += (x, p) =>
                            {
                                if (isGetDataGoogleID)
                                    return;
                                Debug.Log($"meta : {p.Snapshot.Child(SaveManager.ProfileSettings.CurrentProfileID + "/GameMetaSave").ChildrenCount}");
                                if (p.Snapshot.Child(SaveManager.ProfileSettings.CurrentProfileID + "/GameMetaSave").ChildrenCount > 0)
                                {
                                    string cID = p.Snapshot.Child(SaveManager.ProfileSettings.CurrentProfileID + "/GameMetaSave/googleID").Value.ToString();
                                    Debug.Log($"googleID: {cID}");
                                    if (cID != id && id != "" && cID != "")
                                    {
                                        PPSerialization.ClearCachedSavesData();
                                        PPSerialization.ClearAllPendingSaves();
                                        PlayerPrefs.DeleteAll();
                                        PlayerPrefs.SetInt(IntroController.WAS_WATCHED_PREFS_KEY, 0);
                                        string pp = ProfileIDGenerator.GenerateID();
                                        PPSerialization.isCloudSave = true;
                                        ProfileSettings.SetProfileID(pp);
                                        InitSaves(false);
                                        var defaultSettings = PPSerialization.Load<ProfileSettings>(EPrefsKeys.ProfileSettings);
                                        SaveID(id);
                                        Debug.Log($"profile ID: {defaultSettings.ProfileID}");
                                        Debug.Log($"create new user");
                                        if (IntroController.instance != null)
                                            IntroController.instance.OnSkipClick();
                                        else
                                        {
                                            PPSerialization.isCloudSave = false;
                                            GameProgress.ForceReload();
                                            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
                                            LoadSave(id);
                                            return;
                                        }
                                       
                                    }
                                    else if (cID == "")
                                    {
                                        PPSerialization.isCloudSave = true;
                                        SaveID(id);
                                        PPSerialization.isCloudSave = false;
                                        Debug.Log($"save ID");
                                    }
                                }
                                isGetDataGoogleID = true;
                            };
                        }
                        if(e.Snapshot.ChildrenCount > 0 || u.Count == 0)
                        {
                            Debug.Log($"start to load");
                            //isWaiting = false;
                            StartCoroutine(_WaitResponse());
                        }
                        isGetData = true;
                    };
            }
            else
                isWaiting = false;
            StartCoroutine(_Load(id));
        }
      
        IEnumerator _WaitResponse()
        {
            while (!isGetDataGoogleID)
                yield return new WaitForSecondsRealtime(0.1f);

            Debug.Log($"_WaitResponse() end");
            isWaiting = false;
        }

        IEnumerator _Load(string id)
        {
            while(isWaiting)
                yield return new WaitForSecondsRealtime(0.1f);
            
            Debug.Log($"Start Load cloud, current ID: {SaveManager.ProfileSettings.CurrentProfileID}");
            SaveManager.Instance.LoadRawDataFromCloud(SaveManager.ProfileSettings.CurrentProfileID, (data) => {
                LitJson.JsonData storageData = null;
                bool isNewUser = false;
                try
                {
                    storageData = LitJson.JsonMapper.ToObject(data);
                    var x = storageData["GameMetaSave"]["gold"];
                    isNewUser = false;
                }
                catch
                {
                    isNewUser = true;
                }
                if (isNewUser)
                {
                    isGetDataGoogleID = true;
                    PPSerialization.isCloudSave = true;
                    InitSaves();
                    LoadFromCloudQueue.OnCompleteLoadFromCloud();
                    if(id != "")
                        SaveID(id);
                    Debug.Log($"Create new user");
                    return;
                }
                if (storageData == null)
                {
                    PPSerialization.isCloudSave = true;
                    LoadFromCloudQueue.OnCompleteLoadFromCloud();
                    return;
                }
                Debug.Log($"meta gold: {storageData["GameMetaSave"]["gold"].ToString()}, level: {storageData["GameMetaSave"]["level"].ToString()}");
                UICloudSavesResolutionDialog.Create(int.Parse(storageData["GameMetaSave"]["level"].ToString()),
                    int.Parse(storageData["GameMetaSave"]["gold"].ToString()), (bool loadDataFromCloud) =>
                    {
                        if (loadDataFromCloud)
                        {
                            Debug.Log($"defore level: {SaveManager.GameProgress.Current.CompletedLevelsNumber}");
                            Debug.Log("Rewrite saves");
                            SaveManager.Instance.SaveToLocalData(data, false);
                            Debug.Log($"after level: {SaveManager.GameProgress.Current.CompletedLevelsNumber}");
                            if (IntroController.instance != null)
                                IntroController.instance.OnSkipClick();
                            else
                                UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
                        }
                        PPSerialization.isCloudSave = true;

                    });
                LoadFromCloudQueue.OnCompleteLoadFromCloud();
            });
        }

        void InitSaves(bool prSetting = true)
        {
            SettingsGame settings = new SettingsGame();
            PPSerialization.Save<SettingsGame>(EPrefsKeys.SettingsGame, settings);

            SaveAchievements achieve = new SaveAchievements();
            PPSerialization.Save<SaveAchievements>(EPrefsKeys.AchievementSave, achieve);

            DailyReward reward = new DailyReward();
            PPSerialization.Save<DailyReward>(EPrefsKeys.DailyReward, reward);

            SpecialOffer offer = new SpecialOffer();
            PPSerialization.Save<SpecialOffer>(EPrefsKeys.special_offer, offer);

            UIAutoHelpersWindow.SaveData data = new UIAutoHelpersWindow.SaveData();
            PPSerialization.Save<UIAutoHelpersWindow.SaveData>(EPrefsKeys.auto_helper, data);

            GameMetaSave meta = new GameMetaSave();
            PPSerialization.Save<GameMetaSave>(EPrefsKeys.GameMetaSave, meta);

            UIDailySpin spin = new UIDailySpin();
            PPSerialization.Save<UIDailySpin>(EPrefsKeys.DailySpin, spin);

            SavesDataValidator valid = new SavesDataValidator();
            valid.ValidateAll(prSetting);
        }
        private void Update()
        {
            isCloudSave = PPSerialization.isCloudSave;
        }
    }
}
