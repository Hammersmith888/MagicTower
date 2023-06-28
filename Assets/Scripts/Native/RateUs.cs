using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rate
{

    public class RateUs : MonoBehaviour
    {
        const string pluginName = "com.cwgtech.unity.MyPlugin";

        class AlertViewCallback : AndroidJavaProxy
        {
            private System.Action<int> alertHandler;

            public AlertViewCallback(System.Action<int> alertHandlerIn) : base(pluginName + "$AlertViewCallback")
            {
                alertHandler = alertHandlerIn;
            }
            public void onButtonTapped(int index)
            {
                Debug.Log("Button tapped: " + index);
                if (alertHandler != null)
                    alertHandler(index);
            }
        }

        static AndroidJavaClass _pluginClass;
        static AndroidJavaObject _pluginInstance;

        public static AndroidJavaClass PluginClass
        {
            get
            {
                if (_pluginClass == null)
                {
                    _pluginClass = new AndroidJavaClass(pluginName);
                    AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                    AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                    _pluginClass.SetStatic<AndroidJavaObject>("mainActivity", activity);
                }
                return _pluginClass;
            }
        }

        public static AndroidJavaObject PluginInstance
        {
            get
            {
                if (_pluginInstance == null)
                {
                    _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
                }
                return _pluginInstance;
            }
        }


        double getElapsedTime()
        {
            if (Application.platform == RuntimePlatform.Android)
                return PluginInstance.Call<double>("getElapsedTime");
            Debug.LogWarning("Wrong platform");
            return 0;
        }

        public static void showAlertDialog(string[] strings, System.Action<int> handler = null)
        {
            if (strings.Length < 3)
            {
                Debug.LogError("AlertView requires at least 3 strings");
                return;
            }

            if (Application.platform == RuntimePlatform.Android)
                PluginInstance.Call("showAlertView", new object[] { strings, new AlertViewCallback(handler) });
            else
                Debug.LogWarning("AlertView not supported on this platform");
        }
    }
}
