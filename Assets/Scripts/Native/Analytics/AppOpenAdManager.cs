using System;
//using GoogleMobileAds.Api;
//using GoogleMobileAds.Common;
using UnityEngine;

public class AppOpenAdManager: MonoBehaviour
{
//#if UNITY_ANDROID
//    private const string AD_UNIT_ID = "ca-app-pub-5824283751508805/1508254027";
//#elif UNITY_IOS
//    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5662855259";
//#else
//    private const string AD_UNIT_ID = "unexpected_platform";
//#endif

//    private static AppOpenAdManager instance;

//    private AppOpenAd ad;

//    private bool isShowingAd = false;

//    public static AppOpenAdManager Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = new AppOpenAdManager();
//            }

//            return instance;
//        }
//    }

//    private bool IsAdAvailable
//    {
//        get
//        {
//            return ad != null;
//        }
//    }

//    public void OnAppStateChanged(AppState state)
//    {
//        // Display the app open ad when the app is foregrounded.
//        UnityEngine.Debug.Log("App State is " + state);

//        // OnAppStateChanged is not guaranteed to execute on the Unity UI thread.
//        MobileAdsEventExecutor.ExecuteInUpdate(() =>
//        {
//            if (state == AppState.Foreground)
//            {
//                //if (AdsManager._isRewardShowing) return;
//                ShowAdIfAvailable();
//            }
//        });
//    }

//    public void ShowAdIfAvailable()
//    {
//        Debug.LogError("aaaa"+ !IsAdAvailable+ ADs.AppodealAdsController._instance.isShowingInter);
//        if (!IsAdAvailable || ADs.AppodealAdsController._instance.isShowingInter)
//        {
//            ADs.AppodealAdsController._instance.isShowingInter = false;
//            return;
//        }

//        ad.Show();
//    }


//    public void LoadAd()
//    {

//        AdRequest request = new AdRequest.Builder().Build();
//        AppOpenAd.LoadAd(AD_UNIT_ID, ScreenOrientation.Landscape, request, ((appOpenAd, error) =>
//        {
//            if (error != null)
//            {
//                Debug.LogFormat("Failed to load the ad. (reason: {0})", error.LoadAdError.GetMessage());
//                return;
//            }

//            ad = appOpenAd;
//        }));
//    }
}