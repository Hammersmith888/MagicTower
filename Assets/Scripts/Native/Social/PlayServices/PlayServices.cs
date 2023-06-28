using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
#if !NO_GPGS
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif

namespace Native
{
    public class PlayServices
    {
        private static PlayServices instance;
        const string FirstRunFlag = "FirstRun";

        public static List<UnityEngine.Events.UnityAction<bool>> callbackLogin = new List<UnityEngine.Events.UnityAction<bool>>();

        private static GameObject panelInfo;

#if UNITY_ANDROID
        /// <summary>
        /// This just indicates that authentication operation completed but it may be not successful
        /// </summary>
        public static bool isAuthenticationCompleted
        {
            get; private set;
        }
#else
		public static bool isAuthenticationCompleted
		{
			get{ return true; }
		}

#endif

        public static void Init()
        {
            //UICloudSaveController.Create(11, 5000);
            instance = new PlayServices();
#if !NO_GPGS
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
                .EnableSavedGames()
                .Build();
            PlayGamesPlatform.InitializeInstance(config);
            //PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
#else
            Debug.Log("--------------- GPGS is not has");
#endif


#if UNITY_ANDROID
            Debug.Log($"----===== Init PlayGamesPlatform");

            PlayGamesPlatform.Instance.Authenticate( ( bool flag ) =>
			{
                Debug.Log($"----===== Init PlayGamesPlatform is login: {flag}");
                if ( flag )
				{
                    GoogleCloudSavesController.Instance.OnUserLoggedIn();
					isAuthenticationCompleted = true;
                    //if (callbackLogin != null)
                    //    callbackLogin(false);
                }
				else
				{
                    isAuthenticationCompleted = true;
                    for (int i = 0; i < PlayServices.callbackLogin.Count; i++)
                        PlayServices.callbackLogin[i](false);
                }
            }, false );
#elif UNITY_IOS
            FirebaseSavesByDeviceController.Instance.Activate();
            UnityEngine.Social.localUser.Authenticate((bool flag) =>
            {
                Debug.Log("Local is authenticated: " + flag);
              
            } );
#endif
        }

        public static void ToggleAuthenticationState()
        {
#if UNITY_EDITOR
            OpenPanel();
#endif
#if UNITY_ANDROID
            if (PlayGamesPlatform.Instance == null)
            {
                Debug.LogError("PlayGamesPlatform.Instance  is null");
                return;
            }
            if (PlayGamesPlatform.Instance.IsAuthenticated())
            {
                OpenPanel();
            }
            else
            {
                isAuthenticationCompleted = false;
                UI.MessageWindow.ToggleSynchronizationWindow(true);
                PlayGamesPlatform.Instance.Authenticate((bool flag) =>
                {
                   UI.MessageWindow.ToggleSynchronizationWindow(false);
                   if (flag)
                   {
                       Debug.Log($"=============== ToggleAuthenticationState: {flag}");
                      
                       GoogleCloudSavesController.Instance.OnUserLoggedIn();
                       //AchievementsChecker.CheckAll();
                   }
                   isAuthenticationCompleted = true;
                   Debug.Log("Local is authenticated: " + flag);
               });
            }
#endif
        }

        private static void OpenPanel()
        {
            panelInfo = (MonoBehaviour.Instantiate(Resources.Load("UI/GoogleLogout")) as GameObject);
            panelInfo.transform.Find("TextEnter").gameObject.GetComponent<Text>().enabled = false;
            //panelInfo.transform.Find("TextExit").gameObject.GetComponent<Text>().enabled = false;
            panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<CanvasGroup>().alpha = 0;
            panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<CanvasGroup>().interactable = false;
            panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
            panelInfo.transform.Find("ButtonClose").gameObject.GetComponent<Button>().onClick.AddListener(() => {
                if (panelInfo != null)
                    MonoBehaviour.Destroy(panelInfo);
            });

#if UNITY_ANDROID || UNITY_IOS

            panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<Button>().onClick.AddListener(() => {
                isAuthenticationCompleted = false;
                UI.MessageWindow.ToggleSynchronizationWindow(true);
                PlayGamesPlatform.Instance.Authenticate((bool flag) =>
                {
                    UI.MessageWindow.ToggleSynchronizationWindow(false);
                    if (flag)
                    {
                        Debug.Log($"=============== ToggleAuthenticationState: {flag}");

                        GoogleCloudSavesController.Instance.OnUserLoggedIn();
                        //AchievementsChecker.CheckAll();
                    }
                    isAuthenticationCompleted = true;
                    Debug.Log("Local is authenticated: " + flag);
                   
                });
                if (panelInfo != null)
                    MonoBehaviour.Destroy(panelInfo);
            });
#endif
            panelInfo.transform.Find("ExitBtn").gameObject.GetComponent<Button>().onClick.AddListener(() => {
                panelInfo.transform.Find("TextEnter").gameObject.GetComponent<Text>().enabled = true;
                panelInfo.transform.Find("TextExit").gameObject.GetComponent<Text>().enabled = false;
                panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<CanvasGroup>().alpha = 1;
                panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<CanvasGroup>().interactable = true;
                panelInfo.transform.Find("EnterBtn").gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
                panelInfo.transform.Find("ExitBtn").gameObject.GetComponent<CanvasGroup>().alpha = 0;
                panelInfo.transform.Find("ExitBtn").gameObject.GetComponent<CanvasGroup>().interactable = false;
                panelInfo.transform.Find("ExitBtn").gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
                SignoutSilently();
            });
        }

        public static void SignoutSilently()
        {
#if UNITY_ANDROID || UNITY_IOS

            PlayGamesPlatform.Instance.SignOut();
            GoogleCloudSavesController.Instance.OnUserLogout();
#endif
        }

        public static void UnlockAchievement(string id, float progress = 1f)
        {
#if UNITY_STANDALONE && !DISABLESTEAMWORKS
			SteamManager.UnlockAchievement(id);
#elif UNITY_ANDROID || UNITY_IOS
            if (UnityEngine.Social.localUser.authenticated)
            {
                UnityEngine.Social.ReportProgress(id, progress * 100f, (bool result) =>
               {
                   Debug.Log(string.Format("UnlockAchievement result: {0}", result));
               });
            }
#endif
        }

    }
}
