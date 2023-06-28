namespace ToolShed.Android.Media
{
    /// <summary>
    /// https://developer.android.com/reference/android/media/AudioAttributes.html
    /// </summary>
    public class AudioAttributes
    {
        public enum ContentType
        {
            Unknown = 0,
            Speech = 1,
            Music = 2,
            Movie = 3,
            Sonification = 4
        }

        public enum Flag
        {
            AudibilityEnforced = 1,
            HwAvSync = 16
        }

        public enum Usage
        {
            Unknown = 0,
            Media = 1,
            VoiceCommunication = 2,
            VoiceCommunicationSignalling = 3,
            Alarm = 4,
            Notification = 5,
            NotificationRingtone = 6,
            NotificationCommunicationRequest = 7,
            NotificationCommunicationInstant = 8,
            NotificationCommunicationDelayed = 9,
            NotificationEvent = 10,
            AssistanceAccessibility = 11,
            AssistanceNavigationGuidance = 12,
            AssistanceSonification = 13,
            Game = 14,
            Assistant = 16
        }

        public ContentType contentType { get; private set; }
        public Flag flags { get; private set; }
        public Usage usage { get; private set; }

        public static UnityEngine.AndroidJavaObject CreateNativeObject(AudioAttributes attributes)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (OS.Build.Version.api > 20)
            {
                UnityEngine.AndroidJavaObject builder = new UnityEngine.AndroidJavaObject("android.media.AudioAttributes$Builder");
                builder.Call<UnityEngine.AndroidJavaObject>("setContentType", (int)attributes.contentType);
                builder.Call<UnityEngine.AndroidJavaObject>("setFlags", (int)attributes.flags);
                builder.Call<UnityEngine.AndroidJavaObject>("setUsage", (int)attributes.usage);
                return builder.Call<UnityEngine.AndroidJavaObject>("build");
            }
#endif
            return null;
        }

        public class Builder
        {
            private ContentType contentType;
            private Flag flags;
            private Usage usage;

            public AudioAttributes Build()
            {
                AudioAttributes attributes = new AudioAttributes()
                {
                    contentType = contentType,
                    flags = flags,
                    usage = usage
                };

                return attributes;
            }

            public Builder SetContentType(ContentType contentType)
            {
                this.contentType = contentType;
                return this;
            }

            public Builder SetFlags(Flag flags)
            {
                this.flags = flags;
                return this;
            }

            public Builder SetUsage(Usage usage)
            {
                this.usage = usage;
                return this;
            }
        }
    }
}