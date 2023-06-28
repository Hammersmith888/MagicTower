using ToolShed.Android.Media;
using UnityEngine;

namespace ToolShed.Android.OS
{
    /// <summary>
    /// Vibrator interface for Android that offers more control than UnityEngine.Handheld.Vibrate().
    /// NOTE: Your Android manifest must include android.permission.VIBRATE.
    /// </summary>
    public static class Vibrator
    {
        /// <summary>
        /// Check whether the vibrator has amplitude control. Returns false for Android API 25 and below.
        /// </summary>
        public static bool hasAmplitudeControl { get; private set; }

        /// <summary>
        /// Check whether the hardware has a vibrator. Returns false for Android API 10 and below.
        /// </summary>
        public static bool hasVibrator { get; private set; }

#if UNITY_ANDROID && !UNITY_EDITOR
        private static AndroidJavaObject vibrator;

        static Vibrator()
        {
            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    vibrator = activity.Call<AndroidJavaObject>("getSystemService", "vibrator");
                }
            }
        
            if (Build.Version.api > 25)
            {
                hasAmplitudeControl = vibrator.Call<bool>("hasAmplitudeControl");
            }

            if (Build.Version.api > 10)
            {
                hasVibrator = vibrator.Call<bool>("hasVibrator");
            }
        }
#endif

        /// <summary>
        /// Turn the vibrator off.
        /// </summary>
        public static void Cancel()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            vibrator.Call("cancel");
#endif
        }

        /// <summary>
        /// Vibrate the Android device. For Android API 26 and above, amplitude can be set from 1 to 255 (default: VibrationEffect.DEFAULT_AMPLITUDE).
        /// </summary>
        /// <param name="amplitude">1-255 (Android API 26+)</param>
        public static void Vibrate(long milliseconds, int amplitude = VibrationEffect.DEFAULT_AMPLITUDE)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api < 26)
            {
                vibrator.Call("vibrate", milliseconds);
            }
            else
            {
                vibrator.Call("vibrate", VibrationEffect.CreateNativeObject(milliseconds, amplitude));
            }
#endif
        }

        /// <summary>
        /// Vibrate the Android device.
        /// </summary>
        public static void Vibrate(long[] pattern, int repeat)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api < 26)
            {
                vibrator.Call("vibrate", pattern, repeat);
            }
            else
            {
                vibrator.Call("vibrate", VibrationEffect.CreateNativeObject(pattern, repeat));
            }
#endif
        }

        /// <summary>
        /// Vibrate the Android device. Audio attributes can be defined for Android API 21 and above.
        /// </summary>
        public static void Vibrate(long[] pattern, int repeat, AudioAttributes attributes)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api < 21)
            {
                vibrator.Call("vibrate", pattern, repeat);
            }
            else
            {
                if (Build.Version.api < 26)
                {
                    vibrator.Call("vibrate", pattern, repeat, AudioAttributes.CreateNativeObject(attributes));
                }
                else
                {
                    vibrator.Call("vibrate", VibrationEffect.CreateNativeObject(pattern, repeat), AudioAttributes.CreateNativeObject(attributes));
                }
            }
#endif
        }

        /// <summary>
        /// Vibrate the Android device.
        /// </summary>
        public static void Vibrate(VibrationEffect vibe)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api < 26)
            {
                vibrator.Call("vibrate", vibe.timings, vibe.repeat);
            }
            else
            {
                vibrator.Call("vibrate", VibrationEffect.CreateNativeObject(vibe));
            }
#endif
        }

        /// <summary>
        /// Vibrate the Android device. Audio attributes can be defined for Android API 21 and above.
        /// </summary>
        public static void Vibrate(VibrationEffect vibe, AudioAttributes attributes)
        {
#if UNITY_ANDROID && !UNITY_EDITOR

            if (Build.Version.api < 21)
            {
                vibrator.Call("vibrate", vibe.timings, vibe.repeat);
            }
            else
            {
                if (Build.Version.api < 26)
                {
                    vibrator.Call("vibrate", vibe.timings, vibe.repeat, AudioAttributes.CreateNativeObject(attributes));
                }
                else
                {
                    vibrator.Call("vibrate", VibrationEffect.CreateNativeObject(vibe), AudioAttributes.CreateNativeObject(attributes));
                }
            }
#endif
        }

        /// <summary>
        /// Vibrate the Android device. This overload is provided for when frequently repeated vibrate requests might create a performance concern.
        /// To use this overload, store and pass in the return of VibrationEffect.CreateNativeObject().
        /// This function logs an error on devices at API level 25 and below.
        /// </summary>
        public static void Vibrate(AndroidJavaObject vibe, AndroidJavaObject attributes = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            
            if (Build.Version.api < 26)
            {
                UnityEngine.Debug.LogError("[ToolShed.Android.OS.Vibrator] VibrationEffect requires Android API 26 or higher.");
            }
            else
            {
                if (attributes == null)
                {
                    vibrator.Call("vibrate", vibe);
                }
                else
                {
                    vibrator.Call("vibrate", vibe, attributes);
                }
            }
#endif
        }
    }
}