using System;
using UnityEngine;
using System.Collections.Generic;

namespace Analytics
{
    public class DevToDevAnalytics : IAnalytics
    {
        private static DevToDevAnalytics _instance;
        public static DevToDevAnalytics instance
        {
            get
            {
                if (_instance == null)
                {
                    Initialize();
                }
                return _instance;
            }
        }

        public static void Initialize()
        {

            try
            {
                if (_instance != null)
                {
                    return;
                }
                _instance = new DevToDevAnalytics();
            #if UNITY_ANDROID
                        // <param name="androidAppId"> devtodev App ID for Google Play version of application </param>
                        // <param name="androidAppSecret"> devtodev Secret key for Google Play version of application </param>
                        DevToDev.Analytics.Initialize("5527c8b1-d36a-01c8-a4c1-c549c660af6d", "qpPORCJn5h3doxTXEyIL2utmB4Ffl0Yr");
            #elif UNITY_IOS
                    // <param name="iosAppId"> devtodev App ID for App Store version of application </param>
                    // <param name="iosAppSecret"> devtodev Secret key for App Store version of application </param>
                       DevToDev.Analytics.Initialize("ca856d33-219b-0657-9751-aa62dbbd7d2e", "qGhY8LNeMBaWKz6tdJVcS51H2UAkoE73");
            #elif UNITY_WSA
                        // <param name="winAppId"> devtodev App ID for Windows Store version of application </param>
                        // <param name="winAppSecret"> devtodev Secret key for Windows Store version of application </param>
                        DevToDev.Analytics.Initialize( "4c145c43-2bc3-0f87-9774-e2f6149d172c", "R1sDFP2YKzivaO8h6TrIjGmtVJcSCLZE" );
            #endif
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        public void LogEvent(string eventName)
        {
            try
            {
                DevToDev.Analytics.CustomEvent(eventName);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        public void LogEvent(string eventName, Dictionary<string, string> parameters)
        {
            try
            {
                DevToDev.CustomEventParams devToDevEventParams = new DevToDev.CustomEventParams();
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    devToDevEventParams.AddParam(parameter.Key, parameter.Value);
                }
                DevToDev.Analytics.CustomEvent(eventName, devToDevEventParams);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        public void LogEvent<T>(string eventName, Dictionary<string, T> parameters)
        {
            try
            {
                DevToDev.CustomEventParams devToDevEventParams = new DevToDev.CustomEventParams();
                foreach (KeyValuePair<string, T> parameter in parameters)
                {
                    devToDevEventParams.AddParam(parameter.Key, parameter.Value.ToString());
                }
                DevToDev.Analytics.CustomEvent(eventName, devToDevEventParams);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
