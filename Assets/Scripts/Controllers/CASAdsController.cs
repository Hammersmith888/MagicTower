using UnityEngine;
using System;
using CAS;
//using Utility;

public class CASAdsController : MonoBehaviour
{
    public static CASAdsController Instance;
    private static IMediationManager manager;

    private Action<bool> callbackReward;

    private bool isInited = false;
    private bool adsDisabled = false;

    private bool isShowingAppOpenAd = false;
    private DateTime appOpenAdLoadTime;
    private float appOpenAdLoadAttemptTime = 0.0f;
    private float interstitialCloseTime = 0.0f;
    private int countInterstitial = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        //MobileAds.ValidateIntegration();
        CASInitSettings builder = MobileAds.BuildManager();
        // Any changes CASInitSettings properties
        // Select first Manager Id from list in settings asset
        builder.WithManagerIdAtIndex(0);
        // Add initialize listener
        builder.WithInitListener((success, error) =>
        {
            // CAS manager initialization done
            if (success)
            {
                isInited = true;
                manager.SetAppReturnAdsEnabled(true);
                //manager.LoadAd(AdType.Interstitial);
                //Debug.LogError("aaaaaaasadasdasdas");
                // Executed when the ad is failed to display.
                manager.OnInterstitialAdFailedToShow += OnInterstitialFailedToShow;
                // Executed when the ad is closed.
                manager.OnInterstitialAdClosed += OnInterstitialClosed;
                manager.GetAdView(AdSize.Banner).OnFailed += HandleOnBannerFailedToLoad;
                // The Banner may automatically appear when the Ad is ready again.
                // This will trigger the OnBannerAdShown callback again.
                manager.LoadAd(AdType.Rewarded);
                manager.OnRewardedAdClosed += OnRewardedFailed;
                manager.OnRewardedAdCompleted += OnRewardedComplete;
                manager.OnRewardedAdFailedToShow += OnRewardedFailed;

                // Executed when the ad is displayed.
                manager.OnAppReturnAdShown += () => Debug.Log("App return ad shown");
                // Executed when the ad is failed to display.
                manager.OnAppReturnAdFailedToShow += (error) => Debug.LogError(error);
                // Executed when the user clicks on an Ad.
                manager.OnAppReturnAdClicked += () => Debug.Log("App return ad clicked");
                // Executed when the ad is closed.
                manager.OnAppReturnAdClosed += () => Debug.Log("App return ad closed");
            }
        });
        // Call Initialize method in any case to get IMediationManager instance
        manager = builder.Initialize();
    }

    public void ShowBannerAtPosition(AdPosition position)
    {
        if (!isInited) return;
        IAdView adView = manager.GetAdView(AdSize.Banner);
        adView.position = AdPosition.BottomCenter;
        adView.SetActive(true);
    }

    public void HideBanner()
    {
        manager.GetAdView(AdSize.Banner).SetActive(false);
    }

    private void HandleOnBannerFailedToLoad(IAdView view, AdError error)
    {
        //AnalyticsHandler.singleton.EventBannerFailed();
    }

    public bool IsInterstitialLoaded()
    {
        if (!isInited) return false;
        return manager.IsReadyAd(AdType.Interstitial);
    }

    public bool IsRewardedLoaded()
    {
        return manager.IsReadyAd(AdType.Rewarded);
    }

    public void ShowInterstitial()
    {
        if (!isInited) return;
        if (IsInterstitialLoaded())
        {
            Debug.Log("Load");
            manager.ShowAd(AdType.Interstitial);
        }
        else
        {
            Debug.Log("NotLoad");
        }
    }

    public void ShowRewarded(System.Action<bool> onAdCompleteEvent)
    {
        Debug.Log("ShowRewarded");
        if (!isInited) return;
        Debug.Log("ShowRewarded2");
        if (IsRewardedLoaded())
        {

            Debug.Log("ShowRewarded3");
            callbackReward = onAdCompleteEvent;
            Debug.Log("Load");
            manager.ShowAd(AdType.Rewarded);

        }
        else
        {
            Debug.Log("ShowRewarded4");
            Debug.Log("NotLoad");
        }
    }

    private void OnRewardedFailed(string sender = "")
    {
        callbackReward?.Invoke(false);
    }

    private void OnRewardedFailed()
    {
        callbackReward?.Invoke(false);
    }

    private void OnRewardedComplete()
    {
        callbackReward?.Invoke(true);
    }


    private void OnInterstitialClosed()
    {
        interstitialCloseTime = Time.time;
        //manager.LoadAd(AdType.Interstitial);
    }

    private void OnInterstitialFailedToShow(string sender)
    {
        interstitialCloseTime = Time.time;
        //manager.LoadAd(AdType.Interstitial);

    }


    public void DisableAds()
    {
        if (adsDisabled)
            return;

        adsDisabled = true;
        PlayerPrefs.SetInt("AdsDisabled", 1);
        PlayerPrefs.Save();

        HideBanner();
    }
}