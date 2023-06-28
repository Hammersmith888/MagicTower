//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using AdColony;

//namespace ADs
//{
//	public class AdColonyAdsController : IVideoAdsController, IInterstitialAdsController
//	{
//#if UNITY_ANDROID
//		const string VIDEO_AD_ID = "vz44b5923397e94b11bc";
//		const string INTERSTITIAL_AD_ID = "vz98282c3a45c44fc5a0";
//		const string APP_ID = "appf01815a69a154407a1";
//#elif UNITY_IOS
//		const string VIDEO_AD_ID = "vz1164545263b94365be";
//		const string INTERSTITIAL_AD_ID = "vz98282c3a45c44fc5a0";
//		const string APP_ID = "app787c8a38686f4fc687";
//#endif

//		private InterstitialAd videoAd;
//		private InterstitialAd interstitialAd;
//		private System.Action<bool> onVideoAdCompleteEvent;

//		private bool requestingAd;
//		private bool requestingInterstitialAD;

//		public bool isAdAvailable
//		{
//			get {
//				return videoAd != null;
//			}
//		}

//		public bool isInterstitialLoaded
//		{
//			get {
//				return interstitialAd != null;
//			}
//		}

//		public AdColonyAdsController( )
//		{
//			// AppOptions are optional
//			AppOptions appOptions = new AppOptions();
//			appOptions.UserId = "foo";
//			appOptions.AdOrientation = AdOrientationType.AdColonyOrientationAll;

//			string[ ] zoneIds = new string[ ] { VIDEO_AD_ID, INTERSTITIAL_AD_ID };

//			Ads.Configure( APP_ID, appOptions, zoneIds );

//			Ads.OnConfigurationCompleted += OnConfigurationComplete;
//			Ads.OnRequestInterstitial += OnRequestInterstitial;
//			Ads.OnRequestInterstitialFailed += OnRequestInterstitialFailed;
//			Ads.OnRequestInterstitialFailedWithZone += OnRequestInterstitialFailedWithZone;
//			Ads.OnClosed += OnAdClosed;
//			Ads.OnRewardGranted += OnRewardGranted;
//		}

//		public void ShowVideoAD( System.Action<bool> onAdCompleteEvent )
//		{
//			Debug.LogFormat( "AdColony ShowVideoAD isAdAvailable: {0}", isAdAvailable );
//			if( isAdAvailable )
//			{
//				this.onVideoAdCompleteEvent = onAdCompleteEvent;
//				Ads.ShowAd( videoAd );
//			}
//			else
//			{
//				RequestRewardedVideoAd();
//				if( onAdCompleteEvent != null )
//				{
//					onAdCompleteEvent( false );
//					onAdCompleteEvent = null;
//				}
//			}
//		}

//		public void ShowInterstitial( System.Action onCloseCallback = null )
//		{
//			onCloseCallback.InvokeSafely();
//			if( isInterstitialLoaded )
//			{
//				Ads.ShowAd( interstitialAd );
//			}
//			else
//			{
//				RequestInterstitialAD();
//			}
//		}

//		private void RequestRewardedVideoAd( )
//		{
//			if( !requestingAd )
//			{
//				requestingAd = true;
//				videoAd = null;
//				AdOptions adOptions = new AdOptions();
//				adOptions.ShowPrePopup = false;
//				adOptions.ShowPostPopup = false;
//				Ads.RequestInterstitialAd( VIDEO_AD_ID, adOptions );
//			}
//		}

//		private void RequestInterstitialAD( )
//		{
//			if( !requestingInterstitialAD )
//			{
//				requestingInterstitialAD = true;
//				interstitialAd = null;
//				AdOptions adOptions = new AdOptions();
//				adOptions.ShowPrePopup = false;
//				adOptions.ShowPostPopup = false;
//				Ads.RequestInterstitialAd( INTERSTITIAL_AD_ID, adOptions );
//			}
//		}

//#region EVENTS CALLBACKS
//		private void OnConfigurationComplete( List<Zone> zones )
//		{
//			Debug.Log( "AdColony on OnConfigurationComplete" );
//			RequestRewardedVideoAd();
//			RequestInterstitialAD();
//		}

//		private void OnRequestInterstitial( InterstitialAd adResult )
//		{
//			Debug.LogFormat( "AdColony OnRequestInterstitial {0}", adResult.ZoneId );
//			if( adResult.ZoneId == VIDEO_AD_ID )
//			{
//				requestingAd = false;
//				videoAd = adResult;
//			}
//			else
//			{
//				requestingInterstitialAD = false;
//				interstitialAd = adResult;
//			}
//		}

//		private void OnAdClosed( InterstitialAd adResult )
//		{
//			Debug.LogFormat( "AdColony OnAdClosed {0}", adResult.ZoneId );
//			if( adResult.ZoneId == VIDEO_AD_ID )
//			{
//				RequestRewardedVideoAd();
//			}
//			else
//			{
//				RequestInterstitialAD();
//			}
//		}

//		private void OnRequestInterstitialFailed( )
//		{
//			//requestingAd = false;
//			//requestingInterstitialAD = false;
//			Debug.Log( "AdColony OnRequestInterstitialFailed" );
//		}

//		private void OnRequestInterstitialFailedWithZone( string zone )
//		{
			
//			Debug.LogFormat( "AdColony OnRequestInterstitialFailedWithZone: {0}", zone );
//			if( zone == VIDEO_AD_ID )
//			{
//				requestingAd = false;
//			}
//			else
//			{
//				requestingInterstitialAD = false;
//			}
//		}

//		private void OnRewardGranted( string zoneId, bool success, string rewardType, int quantity )
//		{
//			Debug.LogFormat( "AdColony OnRewardGranted: {0} {1}", zoneId, success );
//			if( onVideoAdCompleteEvent != null )
//			{
//				onVideoAdCompleteEvent( success );
//				onVideoAdCompleteEvent = null;
//			}
//			RequestRewardedVideoAd();
//		}
//#endregion
//	}
//}
