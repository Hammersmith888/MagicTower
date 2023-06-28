namespace ToolShed.Android.OS
{
    public class VibrationEffect
    {
        /// <summary>
        /// https://developer.android.com/reference/android/os/VibrationEffect.html#DEFAULT_AMPLITUDE
        /// </summary>
        public const int DEFAULT_AMPLITUDE = -1;

        public long[] timings { get; private set; }
        public int[] amplitudes { get; private set; }
        public int repeat { get; private set; }

        private static UnityEngine.AndroidJavaClass vibrationEffectClass;

        static VibrationEffect()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api > 25)
            {
                vibrationEffectClass = new UnityEngine.AndroidJavaClass("android.os.VibrationEffect");
            }
#endif
        }

        /// <summary>
        /// https://developer.android.com/reference/android/os/VibrationEffect.html#createOneShot(long,%20int)
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to vibrate. This must be a positive number.</param>
        /// <param name="amplitude">The strength of the vibration. This must be a value between 1 and 255, or DEFAULT_AMPLITUDE.</param>
        /// <returns>The desired effect.</returns>
        public static VibrationEffect CreateOneShot(long milliseconds, int amplitude)
        {
            VibrationEffect vibrationEffect = new VibrationEffect()
            {
                timings = new long[] { milliseconds },
                amplitudes = new int[] { amplitude },
                repeat = -1
            };

            return vibrationEffect;
        }

        /// <summary>
        /// https://developer.android.com/reference/android/os/VibrationEffect.html#createWaveform(long[],%20int[],%20int)
        /// </summary>
        /// <param name="timings">The timing values of the timing / amplitude pairs. Timing values of 0 will cause the pair to be ignored.</param>
        /// <param name="amplitudes">The amplitude values of the timing / amplitude pairs. Amplitude values must be between 0 and 255, or equal to defaultAmplitude. An amplitude value of 0 implies the motor is off.</param>
        /// <param name="repeat">The index into the timings array at which to repeat, or -1 if you you don't want to repeat.</param>
        /// <returns>The desired effect.</returns>
        public static VibrationEffect CreateWaveform(long[] timings, int[] amplitudes, int repeat)
        {
            VibrationEffect vibrationEffect = new VibrationEffect()
            {
                timings = timings,
                amplitudes = amplitudes,
                repeat = repeat
            };

            return vibrationEffect;
        }

        /// <summary>
        /// https://developer.android.com/reference/android/os/VibrationEffect.html#createWaveform(long[],%20int)
        /// </summary>
        /// <param name="timings">The pattern of alternating on-off timings, starting with off. Timing values of 0 will cause the timing / amplitude pair to be ignored.</param>
        /// <param name="repeat">The index into the timings array at which to repeat, or -1 if you you don't want to repeat.</param>
        /// <returns>The desired effect.</returns>
        public static VibrationEffect CreateWaveform(long[] timings, int repeat)
        {
            int[] amplitudes = new int[timings.Length];
            for (int i = 0; i < amplitudes.Length; i++)
            {
                amplitudes[i] = 128;
            }

            VibrationEffect vibrationEffect = new VibrationEffect()
            {
                timings = timings,
                amplitudes = amplitudes,
                repeat = repeat
            };

            return vibrationEffect;
        }

        /// <summary>
        /// Creates a native Android VibrationEffect instance using the given arguments. Returns null on Android API 25 and below.
        /// </summary>
        public static UnityEngine.AndroidJavaObject CreateNativeObject(long milliseconds, int amplitude)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api > 25)
            {
                return vibrationEffectClass.CallStatic<UnityEngine.AndroidJavaObject>("createOneShot", milliseconds, amplitude);
            }
            else
            {
                UnityEngine.Debug.LogError("[ToolShed.Android.OS.VibrationEffect] VibrationEffect requires Android API 26 or higher.");
            }
#endif
            return null;
        }

        /// <summary>
        /// Creates a native Android VibrationEffect instance using the given arguments. Returns null on Android API 25 and below.
        /// </summary>
        public static UnityEngine.AndroidJavaObject CreateNativeObject(long[] timings, int repeat)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api > 25)
            {
                return vibrationEffectClass.CallStatic<UnityEngine.AndroidJavaObject>("createWaveform", timings, repeat);
            }
            else
            {
                UnityEngine.Debug.LogError("[ToolShed.Android.OS.VibrationEffect] VibrationEffect requires Android API 26 or higher.");
            }
#endif
            return null;
        }

        /// <summary>
        /// Creates a native Android VibrationEffect instance using the given arguments. Returns null on Android API 25 and below.
        /// </summary>
        public static UnityEngine.AndroidJavaObject CreateNativeObject(long[] timings, int[] amplitudes, int repeat)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api > 25)
            {
                return vibrationEffectClass.CallStatic<UnityEngine.AndroidJavaObject>("createWaveform", timings, amplitudes, repeat);
            }
            else
            {
                UnityEngine.Debug.LogError("[ToolShed.Android.OS.VibrationEffect] VibrationEffect requires Android API 26 or higher.");
            }
#endif
            return null;
        }

        /// <summary>
        /// Creates a native Android instance of the given VibrationEffect object. Returns null on Android API 25 and below.
        /// </summary>
        public static UnityEngine.AndroidJavaObject CreateNativeObject(VibrationEffect vibe)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Build.Version.api > 25)
            {
                return vibrationEffectClass.CallStatic<UnityEngine.AndroidJavaObject>("createWaveform", vibe.timings, vibe.amplitudes, vibe.repeat);
            }
            else
            {
                UnityEngine.Debug.LogError("[ToolShed.Android.OS.VibrationEffect] VibrationEffect requires Android API 26 or higher.");
            }
#endif
            return null;
        }
    }
}