//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using GoogleMobileAds.Api;

//public class AdMobAds : IInterstitialAdsController
//{
//	public bool isInterstitialLoaded
//	{
//		get {

//			bool isLoaded = _interstitial != null && _interstitial.IsLoaded();
//			if( !isLoaded )
//			{
//				LoadInterstitial();
//			}
//			return isLoaded;
//		}
//	}

//	private  InterstitialAd _interstitial;
//	private  Action _onCloseCallback;

//	public AdMobAds( )
//	{
//		MobileAds.Initialize( "ca-app-pub-5824283751508805~3719666748" );
//		LoadInterstitial();
//	}

//	private  Action _interstitialCompleteAction;

//	private void LoadInterstitial( )
//	{
//		if( _interstitial == null )
//		{
//#if UNITY_EDITOR
//			string adUnitId = "unused";
//#elif UNITY_ANDROID
//				string adUnitId = "ca-app-pub-5824283751508805/5843649041";//"ca-app-pub-5824283751508805/8205227738";
//#elif UNITY_IOS
//                string adUnitId = "ca-app-pub-7814749540601690/9057831321";
//#else
//                string adUnitId = "unexpected_platform";
//#endif
//			_interstitial = new InterstitialAd( adUnitId );   // Initialize an InterstitialAd.
//			_interstitial.OnAdClosed += Interstitial_OnAdClosed;
//			//_interstitial.OnAdFailedToLoad += Interstitial_OnAdFailedToLoad;
//			_interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
//		}
//		//Debug.Log( "RequestInterstitial isLoaded: " + _interstitial.IsLoaded() );
//		// Create an empty ad request.
//		AdRequest request = new AdRequest.Builder().Build();
//		// Load the interstitial with the request.
//		_interstitial.LoadAd( request );
//	}

//	public void ShowInterstitial( Action onCloseCallback = null )
//	{
//		_interstitialCompleteAction = onCloseCallback;
//		if( isInterstitialLoaded )
//		{
//			_interstitial.Show();
//		}
//		else
//		{
//			LoadInterstitial();
//		}
//	}

//	private void ExecuteOnAdClosedAction( )
//	{
//		if( _interstitialCompleteAction != null )
//		{
//			//Debug.Log( "_interstitialCompleteAction != null" );
//			_interstitialCompleteAction();
//			_interstitialCompleteAction = null;
//		}
//		//else
//		//{
//		//	Debug.Log( "_interstitialCompleteAction == null" );
//		//}
//	}

//	#region CALLBACKS
//	private void Interstitial_OnAdClosed( object sender, EventArgs e )
//	{
//		Debug.Log( "AdMob Interstitial_OnAdClosed " );
//		ExecuteOnAdClosedAction();
//		LoadInterstitial();
//	}

//	private void Interstitial_OnAdLoaded( object sender, EventArgs e )
//	{
//		Debug.Log( "AdMob Interstitial ad loaded" );
//	}

//	private void Interstitial_OnAdFailedToLoad( object sender, AdFailedToLoadEventArgs e )
//	{
//		ExecuteOnAdClosedAction();
//		LoadInterstitial();
//		Debug.Log( "AdMob Failed to load  Interstitial " + e.Message );
//	}
//	#endregion
//}
