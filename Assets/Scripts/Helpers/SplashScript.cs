using Native;
using System;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IWaitInitializationFlagHolder
{
    bool isInitialized
    {
        get;
    }
}

public class SplashScript : MonoBehaviour
{
    private const float MAX_TIME_WAIT_FOR_INITIALIZATION = 6f;
    private const float MAX_TIME_WAIT_FOR_CLOUD_LOAD_OPERATIONS_INITIALIZATION = 7f;

    private const string MenuScenePrefabPathInResources = "Scenes/Menu";

    public UIBlackPatch BlackScreen;
    public float delay;
    public float delayForInitializationComponents;

    public GameObject gameSystems;

    private float startTime;

    private bool onAllCloudSavesProcessesCompleted;
    private bool blackScreenFullyFadedIn;
    private ResourceRequest resourcesRequest;

    private bool IsAllCloudOperationsCompleted
    {
        get
        {
            return !LoadFromCloudQueue.IsAnyLoadFromCloudOperationActive || Time.unscaledTime - startTime > MAX_TIME_WAIT_FOR_CLOUD_LOAD_OPERATIONS_INITIALIZATION;
        }
    }

    public bool IsAllLoadingOperationsCompleted
    {
        get
        {
           // return Native.PlayServices.isAuthenticationCompleted && isAllCloudOperationsCompleted && ((resourcesRequest != null && resourcesRequest.isDone) || !UI.IntroController.IntroWasWatched);
            return ((resourcesRequest != null && resourcesRequest.isDone) || (!UI.IntroController.IntroWasWatched && IsAllCloudOperationsCompleted));
        }
    }

    public bool IntroWasViewed
    {
        get
        {
            return (UI.IntroController.IntroWasWatched || SaveManager.IntroWasViewed) && PlayerPrefs.HasKey("IntroWasViewed");
        }
    }

//#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
//	private void Awake( )
//	{
//		GameObject bugsnagObject = new GameObject( "BUGSNAG" );
//		GameObject.DontDestroyOnLoad( bugsnagObject );
//		Bugsnag.createBugsnagInstance( bugsnagObject, "4837267b15cf162582c104b12333416f" );
//	}
//#endif

    void Start()
    {
        if(String.IsNullOrEmpty(SaveManager.GameProgress.Current.first_enter_date))
        {
            SaveManager.GameProgress.Current.first_enter_date = DateTime.UtcNow.ToString();
            SaveManager.GameProgress.Current.Save(false);
        }
        else
        {
            var s = (DateTime.UtcNow - DateTime.Parse(SaveManager.GameProgress.Current.first_enter_date)).TotalDays;
            Debug.Log($"first start: {s}");
            if(s == 2)
                AnalyticsController.Instance.LogMyEvent("StartGameDay2");
            if (s == 7)
                AnalyticsController.Instance.LogMyEvent("StartGameDay7");
            if (s == 14)
                AnalyticsController.Instance.LogMyEvent("StartGameDay14");
            if (s == 28)
                AnalyticsController.Instance.LogMyEvent("StartGameDay28");
        }


        StartCoroutine(BlackScreen.FadeOutColorAnimation(null));
//#if !DEBUG_MODE && !UNITY_EDITOR
//        Debug.unityLogger.logEnabled = false;
//        Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
//        Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
//        Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
//#endif

#if UNITY_EDITOR || UNITY_WSA
        ResolutionChangeMonitor.CreateInstanceIfNone();
#endif
        startTime = Time.unscaledTime;

        gameSystems.SetActive(true);
        DontDestroyOnLoad(gameSystems);
        StartCoroutine(ShowBlackScreenAfterDelay(BlackScreen.processTime + delay));
        if (delayForInitializationComponents >= delay)
        {
            Debug.LogErrorFormat("delayForInitializationComponents ({0}) must be lower then delay({1})", delayForInitializationComponents, delay);
            delayForInitializationComponents = delay / 2f;
        }
        Core.ConfigLoader.LoadConfig();

        if (IntroWasViewed)
        {
            Debug.Log($"Waiting OnAllCloudSavesProcessCompleted");
            if (!Application.isEditor)
                PlayServices.callbackLogin.Add(OnAllCloudSavesProcessCompleted);
            else
                OnAllCloudSavesProcessCompleted(true);
        }
        else
        {
            PotionManager.AddPotion(PotionManager.EPotionType.Mana, 10);
            //завершение инициализации облака и показ окна выбора прогресса произойдет во время INTRO
            onAllCloudSavesProcessesCompleted = true;
        }
        StartCoroutine(WaitForInitializationAndStartTheGame());
    }

    private void OnAllCloudSavesProcessCompleted(bool value)
    {
        Debug.Log($"<b>OnAllCloudSavesProcessCompleted</b> IntroWasViewed: {IntroWasViewed}");
        PlayServices.callbackLogin.Remove(OnAllCloudSavesProcessCompleted);
        if (value)
        {
            onAllCloudSavesProcessesCompleted = true;
            resourcesRequest = Resources.LoadAsync(MenuScenePrefabPathInResources);
        }
    }

    private IEnumerator WaitForInitializationAndStartTheGame()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            int deltaTime = 15;
            while (true)
            {
                if (onAllCloudSavesProcessesCompleted && blackScreenFullyFadedIn)
                {
                    if (resourcesRequest != null)
                    {
                        if (resourcesRequest.isDone)
                        {
                            break;
                        }
                    }
                }

                yield return new WaitForSecondsRealtime(1f);
                deltaTime--;
                if (deltaTime < 0)
                {
                    break;
                }
            }
        }
        else
            yield return new WaitForSecondsRealtime(MAX_TIME_WAIT_FOR_INITIALIZATION);

        StartGame();
    }

    private void StartGame()
    {
        SaveApplicationLaunchCountData();

        Debug.Log($"Starting game. Intro Was Viewed:{IntroWasViewed}");

        if (BlackScreen == null)
        {
            BlackScreen = FindObjectOfType<UIBlackPatch>();
        }

        var hasBeenPlaying = "HasBeenPlaying";
        if (IntroWasViewed)
        {
            if (!PlayerPrefs.HasKey(hasBeenPlaying))
            {
                if (resourcesRequest != null)
                    Instantiate(resourcesRequest.asset);
               
                BlackScreen.StartDissapear();
                //Resources.UnloadUnusedAssets();
                PlayerPrefs.SetString(hasBeenPlaying, hasBeenPlaying);
                PlayerPrefs.Save();
                Destroy(gameObject);
            }
            else
            {
                BlackScreen.StartDissapear();
                //Resources.UnloadUnusedAssets();
                SceneManager.LoadScene("Map");
                Destroy(gameObject);
            }
        }
        else
        {
            PlayerPrefs.SetString(hasBeenPlaying, hasBeenPlaying);
            PlayerPrefs.SetInt("IntroWasViewed", 0);
            PlayerPrefs.Save();

            try
            {
                AnalyticsController.Instance.LogMyEvent("StartedWatchingIntro");
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            IntroController.ShowIntro();
        }
    }

    private void SaveApplicationLaunchCountData()
    {
        string applicationLaunchCountPrefsKey = "Application_launch";
        if (!PlayerPrefs.HasKey(applicationLaunchCountPrefsKey))
        {
            PlayerPrefs.SetInt(applicationLaunchCountPrefsKey, 0);
            UIDailyRewardController.ResetVideoLimits();
        }
        else if (PlayerPrefs.GetInt(applicationLaunchCountPrefsKey) != 0)
        {
            PlayerPrefs.SetInt(applicationLaunchCountPrefsKey, PlayerPrefs.GetInt(applicationLaunchCountPrefsKey) + 1);
            if (PlayerPrefs.GetInt(applicationLaunchCountPrefsKey) > 6)
            {
                PlayerPrefs.SetInt(applicationLaunchCountPrefsKey, 1);
            }
        }
    }

    //private IEnumerator DelayedInitialization()
    //{
    //    yield return new WaitForSeconds(delayForInitializationComponents);
    //    for (int i = 0; i < delayedInitializationComponents.Length; i++)
    //    {
    //        delayedInitializationComponents[i].SetActive(true);
    //    }
    //}

    private IEnumerator ShowBlackScreenAfterDelay(float delay)
    {
        var startTime = Time.unscaledTime;
        //Debug.Log("<size=18>ShowBlackScreenAfterDelay start</size>");
        yield return new WaitForSecondsRealtime(delay);
        //Debug.Log("<size=18>ShowBlackScreenAfterDelay End</size> "+ (Time.unscaledTime - startTime));
       
        Debug.Log($"waiting components .        BlackScreen.Appear(BlackScreenFullyFadedIn, true); ..............");
        BlackScreen.Appear(BlackScreenFullyFadedIn, true);
    }

    private void BlackScreenFullyFadedIn()
    {
        blackScreenFullyFadedIn = true;
    }
}
