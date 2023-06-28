//#define ATC_SUPPORT_ENABLED

using UnityEngine;
using System.IO;
using System.Collections.Generic;

#if ATC_SUPPORT_ENABLED
using CodeStage.AntiCheat.ObscuredTypes;
#endif

#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
#endif



public class AndroidNativeSettings : ScriptableObject
{
	//ATC:
	public bool EnableATCSupport = false;

	//APIs:
	//public bool LocalNotificationsAPI = true; 
	//public bool ImmersiveModeAPI = true;
	//public bool ApplicationInformationAPI = true;
	//public bool ExternalAppsAPI = true;
	//public bool PoupsandPreloadersAPI = true;
	//public bool CheckAppLicenseAPI = true;
	//public bool NetworkStateAPI = false;

	//public bool InAppPurchasesAPI = true;


	//public bool GooglePlayServicesAPI = true;
	//public bool PlayServicesAdvancedSignInAPI = true;
	//public bool GoogleButtonAPI = true;
	//public bool AnalyticsAPI = true;
	//public bool GoogleCloudSaveAPI = true;
	//public bool PushNotificationsAPI = true;
	//public bool GoogleMobileAdAPI = true;
	
	public string GCM_SenderId = "YOUR_SENDER_ID_HERE";


	public string GooglePlayServiceAppID = "0";


	#if ATC_SUPPORT_ENABLED
	public  ObscuredString base64EncodedPublicKey = "REPLACE_WITH_YOUR_PUBLIC_KEY";
	#else
	public  string base64EncodedPublicKey = "REPLACE_WITH_YOUR_PUBLIC_KEY";
	#endif
	
	public List<string> InAppProducts = new List<string>();

	public bool ShowWhenAppIsForeground = true;
	public bool EnableVibrationLocal = false;
	public string LocalNotificationIcon = null;
	public string LocalNotificationLargeIcon = null;
	public string LocalNotificationSound = null;

	public bool UseGameThrivePushNotifications = false;
	public string GameThriveAppID = "YOUR_ONESIGNAL_APP_ID";

	public bool UseParsePushNotifications = false;
	public string ParseAppId = "YOUR_PARSE_APP_ID";
	public string DotNetKey = "YOUR_PARSE_DOT_NET_KEY";

	public bool ReplaceOldNotificationWithNew = false;
	public bool ShowPushWhenAppIsForeground = true;
	public bool EnableVibrationPush = false;
	public Texture2D PushNotificationIcon = null;
	public AudioClip PushNotificationSound = null;

	public const string ANSettingsAssetName = "AndroidNativeSettings";
	public const string ANSettingsPath = "Extensions/AndroidNative/Resources";
	public const string ANSettingsAssetExtension = ".asset";

	private static AndroidNativeSettings instance = null;

	
	public static AndroidNativeSettings Instance {
		
		get {
			if (instance == null) {
				instance = Resources.Load(ANSettingsAssetName) as AndroidNativeSettings;
				
				if (instance == null) {
					
					// If not found, autocreate the asset object.
					instance = CreateInstance<AndroidNativeSettings>();
					#if UNITY_EDITOR
					//string properPath = Path.Combine(Application.dataPath, ANSettingsPath);

					FileStaticAPI.CreateFolder(ANSettingsPath);

					/*
					if (!Directory.Exists(properPath)) {
						AssetDatabase.CreateFolder("Extensions/", "AndroidNative");
						AssetDatabase.CreateFolder("Extensions/AndroidNative", "Resources");
					}
					*/
					
					string fullPath = Path.Combine(Path.Combine("Assets", ANSettingsPath),
					                               ANSettingsAssetName + ANSettingsAssetExtension
					                               );
					
					AssetDatabase.CreateAsset(instance, fullPath);
					#endif
				}
			}
			return instance;
		}
	}

	public bool IsBase64KeyWasReplaced {
		get {
			if(base64EncodedPublicKey.Equals("REPLACE_WITH_YOUR_PUBLIC_KEY")) {
				return false;
			} else {
				return true;
			}
		}
	}



}
