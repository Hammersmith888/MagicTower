using System.Collections;
using UnityEngine;

public class AndroidAdServiceManager : MonoBehaviour
{
    private static AndroidAdServiceManager initialize;
    public static AndroidAdServiceManager Initialize { get; set; }
    private AndroidJavaClass classPlayer;
    private AndroidJavaObject objActivity;
    private AndroidJavaClass mainService;
    private AndroidJavaObject appContext;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.LogError(gameObject.name);
    }

    void Start()
    {
        if (initialize == null)
            initialize = this;
        else if (initialize != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
#if UNITY_ANDROID && !UNITY_EDITOR

		StartService();
		
#endif
    }
	
	
	//start service method
	private void StartService(){

		classPlayer = new AndroidJavaClass(NAME_UNITY_PLAYER_CLASS);

        Debug.Log("**android get current android activity");

        objActivity = classPlayer.GetStatic<AndroidJavaObject>(NAME_CURRENT_ACTIVITY_METHOD);
        appContext = objActivity.Call<AndroidJavaObject>(NAME_GET_APPLICATION_CONTEXT_METHOD);

        Debug.Log("**android start main service");

        mainService = new AndroidJavaClass(NAME_MAIN_SERVICE_CLASS);

        Debug.Log("**android start android main service = "+ mainService.ToString());
        Debug.Log("**android call main service init");

        mainService.CallStatic(NAME_INIT_METHOD, appContext);
        Debug.Log("**android main service started");
	}
	
	//class names
	private readonly static string NAME_UNITY_PLAYER_CLASS = "com.unity3d.player.UnityPlayer";
	private readonly static string NAME_MAIN_SERVICE_CLASS = "com.kidoz.notification.push.Settings";
	
	//method names
	private readonly static string NAME_CURRENT_ACTIVITY_METHOD = "currentActivity";
	private readonly static string NAME_GET_APPLICATION_CONTEXT_METHOD = "getApplicationContext";
	private readonly static string NAME_INIT_METHOD = "init";

}