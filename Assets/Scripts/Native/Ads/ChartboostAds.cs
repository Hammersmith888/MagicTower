//using UnityEngine;
//using ChartboostSDK;
//using System;

//namespace ADs
//{
//	public class ChartboostAds : IInterstitialAdsController
//	{

//		public bool isInterstitialLoaded
//		{
//			get {
//				return Chartboost.isInitialized() && Chartboost.hasInterstitial( CBLocation.Default );
//			}
//		}

//		private  Action _onCloseCallback;

//		const bool MANUL_CACHING = true;

//		public ChartboostAds( )
//		{
//#if UNITY_ANDROID
//			Chartboost.CreateWithAppId( "5a2bc80455fbf70b8d779534", "473c550c26cd7104ef0458049c99d1f0b4dd3d0f" );
//#elif UNITY_IOS
//			Chartboost.CreateWithAppId( "5a5604753e33910dbc31fd4e", "3a662c0e56348872cdb3a8a85d38f4789dc3b4f2" );
//#endif
//			Chartboost.setAutoCacheAds( !MANUL_CACHING );
//			Chartboost.didInitialize += DidInitialize;
//			Chartboost.didCloseInterstitial += DidCloseInterstitial;
//			Chartboost.didDismissInterstitial += DidDismissInterstitial;
//			Chartboost.didCacheInterstitial += DidCacheInterstitial;
//			Chartboost.didFailToLoadInterstitial += DidFailToLoadInterstitial;
//		}

//		public void ShowInterstitial( Action onCloseCallback = null )
//		{
//			Debug.LogFormat( "Chartboost ShowInterstitial {0} {1}", Chartboost.isInitialized(), Chartboost.hasInterstitial( CBLocation.Default ) );
//			_onCloseCallback = onCloseCallback;
//			if( isInterstitialLoaded )
//			{
//				Chartboost.showInterstitial( CBLocation.Default );
//			}
//			else
//			{
//				CacheInterstitial();
//			}
//		}

//		private void ExecuteOnAdClosedAction( )
//		{
//			CacheInterstitial();
//			if( _onCloseCallback != null )
//			{
//				_onCloseCallback();
//				_onCloseCallback = null;
//			}
//		}

//		private void CacheInterstitial( )
//		{
//			if( MANUL_CACHING )
//			{
//				Chartboost.cacheInterstitial( CBLocation.Default );
//			}
//		}

//#region Callbakcs
//		private void DidInitialize( bool result )
//		{
//			Debug.LogFormat( "Chartboost DidInitialize ({0})", result );
//			CacheInterstitial();
//		}

//		private void DidCloseInterstitial( CBLocation cbLocation )
//		{
//			Debug.LogFormat( "Chartboost DidCloseInterstitial {0}", cbLocation );
//			ExecuteOnAdClosedAction();
//		}

//		private void DidDismissInterstitial( CBLocation cbLocation )
//		{
//			Debug.LogFormat( "Chartboost DidDismissInterstitial {0}", cbLocation );
//			ExecuteOnAdClosedAction();
//		}

//		private void DidCacheInterstitial( CBLocation cbLocation )
//		{
//			Debug.LogFormat( "Chartboost DidCacheInterstitial {0}", cbLocation );
//		}

//		private void DidFailToLoadInterstitial( CBLocation cbLocation, CBImpressionError error )
//		{
//			CacheInterstitial();
//			Debug.LogFormat( "Chartboost DidFailToLoadInterstitial {0} error: {1}", cbLocation, error.ToString() );
//		}
//#endregion

//	}
//}
