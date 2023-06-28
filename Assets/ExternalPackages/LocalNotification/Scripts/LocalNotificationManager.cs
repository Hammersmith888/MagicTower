using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace LocalNotification
{

    public class LocalNotificationManager
    {

        static INotificationManager _manager;
        static INotificationManager manager
        {
            get
            {
                if (_manager == null)
                {
#if UNITY_EDITOR
                    _manager = new EditorNotificationManager();
#elif UNITY_IOS
                    _manager = new IOSNotificationManager ();
#elif UNITY_ANDROID
                    _manager = new AndroidNotificationManager ();
#endif
                }
                return _manager;
            }
        }

        public static void SetNotification(string message, int delay, string title = "SET TITLE!")
        {
            manager.SetNotification(message, delay, title);
        }

        public static void CancelAllNotification()
        {
            manager.CancelAllNotification();
        }
    }

    interface INotificationManager
    {
        void SetNotification(string body, int delay, string title);
        void CancelAllNotification();
    }

    class EditorNotificationManager : INotificationManager
    {
        public void SetNotification(string body, int delay, string title)
        {
            Debug.LogWarning("Cannot register localnotification in editor!");
        }

        public void CancelAllNotification()
        {
            Debug.LogWarning("Cannot cancel localnotification in editor!");
        }
    }

#if UNITY_IOS
    class IOSNotificationManager : INotificationManager
    {
        [DllImport("__Internal")]
        private static extern void setNotification(string body, int delay);
        [DllImport("__Internal")]
        private static extern void cancelAllNotification();

        public void SetNotification(string body, int delay, string title)
        {
            if (CanCallMethod())
            {
                setNotification(body, delay);
            }
        }

        public void CancelAllNotification()
        {
            if (CanCallMethod())
            {
                cancelAllNotification();
            }
        }

        bool CanCallMethod()
        {
            return Application.platform != RuntimePlatform.OSXEditor;
        }
    }
#endif

#if UNITY_ANDROID
    class AndroidNotificationManager : INotificationManager
    {

        const int INITIAL_REQUEST_ID_VALUE = 1000;
        const int MAX_LOCAL_NOTIFICATION_NUM = 5;
        static int requestId = INITIAL_REQUEST_ID_VALUE;

        public void SetNotification(string body, int delay, string title)
        {
            if (requestId >= INITIAL_REQUEST_ID_VALUE + MAX_LOCAL_NOTIFICATION_NUM)
                return;
            AndroidJavaClass c = new AndroidJavaClass ("jp.ne.donuts.localnotifications.LocalNotifications");
            c.CallStatic("setLocalNotification", Context(), title, body, requestId, delay);
            requestId++;
        }

        public void CancelAllNotification()
        {
            AndroidJavaClass c = new AndroidJavaClass ("jp.ne.donuts.localnotifications.LocalNotifications");
            AndroidJavaObject context = Context ();
            for (int i = INITIAL_REQUEST_ID_VALUE; i < INITIAL_REQUEST_ID_VALUE + MAX_LOCAL_NOTIFICATION_NUM; i++)
            {
                c.CallStatic("cancelNotifications", context, i);
            }
            requestId = INITIAL_REQUEST_ID_VALUE;
        }

        AndroidJavaObject Context()
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationContext");
        }
    }
#endif
}