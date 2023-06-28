using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

namespace Core
{
    public class ConfigLoader : MonoBehaviour, IPendingOperation
    {
        private const string ApperateConfigNodeName = "Apperate";
        private const string ProjectConfigFileName = "ConfigLoader.txt";
        private const string StorageUrlFormat = "https://firebasestorage.googleapis.com/v0/b/magic-siege-57930146.appspot.com/o/{0}?alt=media";

        private bool currentlyLoading;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private static ConfigLoader Current;

        public static void LoadConfig()
        {
            if (Current == null)
            {
                Current = new GameObject("---ConfigLoader---").AddComponent<ConfigLoader>();
                DontDestroyOnLoad(Current.gameObject);
            }
            try
            {
                Current.Load();
            }
            catch (Exception) { }
        }

        private void Load()
        {
            if (currentlyLoading)
            {
                Debug.LogFormat("<b>ConfigLoader:</b> ConfigLoaded currently loading data, this load call skipped.");
                return;
            }
            currentlyLoading = true;

            UnityWebRequest webRequest = UnityWebRequest.Get(string.Format(StorageUrlFormat, ProjectConfigFileName));
            StartCoroutine(WaitForRequest(webRequest, OnConfigLoaded));
        }

        private void OnConfigLoaded(string text)
        {
            var json = JsonConvert.DeserializeObject<Config>(text);

            if (Convert.ToBoolean(json.StateUpdateWindow) && Application.version != json.CurrentVersion)
                UpdateWindowController.isShow = true;

            OnLoadSuccessful();
            GameObject.Destroy(this.gameObject);
        }

        private IEnumerator WaitForRequest(UnityWebRequest webRequest, System.Action<string> callback = null)
        {
            yield return webRequest.SendWebRequest();
            currentlyLoading = false;
            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.Log("<color=red>ConfigLoader Error:</color> " + webRequest.error);
                OnLoadFailed();
            }
            else
            {
                try
                {
                    Debug.Log("<color=blue>ConfigLoader</color> ResponceCode: " + webRequest.responseCode);
                    callback.InvokeSafely(webRequest.downloadHandler.text);
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }

        #region PENDING OPERATION RELATED
        private bool registeredAsPendingOperation;
        private System.Action<bool> pendingOperationCompleteionCallback;

        private void OnLoadFailed()
        {
            if (registeredAsPendingOperation)
            {
                pendingOperationCompleteionCallback.InvokeSafely(false);
            }
            else
            {
                registeredAsPendingOperation = true;
                PendingOperationsManager.Instance.AddPendingOperation(this);
            }
        }

        private void OnLoadSuccessful()
        {
            if (registeredAsPendingOperation)
            {
                registeredAsPendingOperation = false;
                pendingOperationCompleteionCallback.InvokeSafely(true);
            }
        }

        public void StartOperation(System.Action<bool> operationCallback)
        {
            pendingOperationCompleteionCallback = operationCallback;
            try
            {
                Current.Load();
            }
            catch (Exception) { }
        }
        #endregion
    }
    
    public class Config
    {
        [JsonProperty(PropertyName = "Apperate")]
        public string Apear { get; set; }
        [JsonProperty(PropertyName = "CurrentAppVersion")]
        public string CurrentVersion { get; set; }
        [JsonProperty(PropertyName = "StateUpdateWindow")]
        public string StateUpdateWindow { get; set; }
    }
}
