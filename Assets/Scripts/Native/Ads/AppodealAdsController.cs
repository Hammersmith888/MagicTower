//using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;

namespace ADs
{
    public class AppodealAdsController : MonoBehaviour, IVideoAdsController//, IInterstitialAdsController, IVideoAdsController/*, IInterstitialAdListener, IRewardedVideoAdListener, INonSkippableVideoAdListener*/
    {
        public bool isVideoAdAvailable
        {
            get
            {
                return CASAdsController.Instance.IsRewardedLoaded();
                // return rewardedAd.IsLoaded();
                //return (rewardedInterstitialAd != null);
            }
        }

        //public bool isInterstitialLoaded
        //{
        //    get
        //    {
        //        ///return interstitial.IsLoaded();
        //    }
        //}

        private  System.Action<bool> onVideoAdComplete;
        private  System.Action onInterstitialADClosed;

        private bool videoWasWatched;
        private bool videoShowResult;
        private bool interstitialWasShown;
        public bool isShowingInter = false;
        private int currentVideoID, lastWatchedVideoID;

        public static AppodealAdsController _instance;

        //private InterstitialAd interstitial;
        //private RewardedAd rewardedAd;
        //private RewardedInterstitialAd rewardedInterstitialAd;
        private bool playerIsRaward = false;

        public static AppodealAdsController Create()
        {
            if (_instance == null)
            {
                _instance = new GameObject("AppodealAdsController").AddComponent<AppodealAdsController>();
                DontDestroyOnLoad(_instance.gameObject);

                // Initialize the Google Mobile Ads SDK.
                _instance.Init();
            }
            return _instance;
        }

        private void Init()
        {
            //MobileAds.Initialize(initStatus =>
            //{
            //    RequestInterstitial();
            //    //RequestRewardedAd();
            //    Debug.LogError(gameObject.name);
            //    AppOpenAdManager.Instance.LoadAd();
            //    AppStateEventNotifier.AppStateChanged += AppOpenAdManager.Instance.OnAppStateChanged;
               
            //    RequestVideoAd();
            //});
        }

        private void RequestInterstitial()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-5824283751508805/8205227738";//"ca-app-pub-3940256099942544/5354046379";//"ca-app-pub-5824283751508805/8205227738";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#endif
            //// Initialize an InterstitialAd.
            //interstitial = new InterstitialAd(adUnitId);

            //// Called when the ad is closed.
            //interstitial.OnAdClosed += onInterstitialClosed;

            //// Create an empty ad request.
            //AdRequest request = new AdRequest.Builder().Build();
            //// Load the interstitial with the request.
            //interstitial.LoadAd(request);
        }
        
        private void RequestRewardedAd()
        {
            string adUnitId;
#if UNITY_ANDROID
            adUnitId = "ca-app-pub-5824283751508805/5681105543";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
#endif

            //rewardedAd = new RewardedAd(adUnitId);

            //// Called when an ad request failed to load.
            //rewardedAd.OnAdFailedToLoad += onRewardedVideoFailedToLoad;
            //// Called when the user should be rewarded for interacting with the ad.
            //rewardedAd.OnUserEarnedReward += onRewardedVideoFinished;
            //// Called when the ad is closed.
            //rewardedAd.OnAdClosed += onRewardedVideoClosed;

            //// Create an empty ad request.
            //AdRequest request = new AdRequest.Builder().Build();
            //// Load the rewarded ad with the request.
            //rewardedAd.LoadAd(request);
        }

        private void RequestVideoAd()
        {
            string adUnitId;
#if UNITY_ANDROID
            adUnitId = "ca-app-pub-5824283751508805/9344200142";//"ca-app-pub-3940256099942544/5354046379";//"ca-app-pub-5824283751508805/9344200142";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

            //// Create an empty ad request.
            //AdRequest request = new AdRequest.Builder().Build();
            //// Load the rewarded ad with the request.
            //RewardedInterstitialAd.LoadAd(adUnitId, request, adLoadCallback);
        }

        //private void adLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
        //{
        //    if (error == null)
        //    {
        //        rewardedInterstitialAd = ad;
        //        rewardedInterstitialAd.OnAdDidDismissFullScreenContent += HandleAdDidDismiss;
        //    }
        //}

        private void LateUpdate()
        {
            if (videoWasWatched)
            {
                videoWasWatched = false;
                if (currentVideoID != lastWatchedVideoID)
                {
                    lastWatchedVideoID = currentVideoID;
                    AudioListener.pause = false;
                    onVideoAdComplete.InvokeSafely(videoShowResult);
                }
            }
            if (interstitialWasShown)
            {
                interstitialWasShown = false;
                OnInterstitialClosedCall();
            }
        }

        public void ShowRewardedInterstitialAd(System.Action<bool> onAdCompleteEvent)
        {
            //if (rewardedInterstitialAd != null)
            //{
            //    onVideoAdComplete = onAdCompleteEvent;
            //    rewardedInterstitialAd.Show(userEarnedRewardCallback);
            //}
            //else
            //{
            //    RequestInterstitial();
            //}
        }

        //private void userEarnedRewardCallback(Reward reward)
        //{
        //    onVideoAdComplete.InvokeSafely(true);
        //    RequestVideoAd();
        //}

        public void ShowInterstitial(System.Action onCloseCallback = null)
        {
            //onInterstitialADClosed = onCloseCallback;
           
            //if (isInterstitialLoaded)
            //{
            //    interstitial.Show();
            //    isShowingInter = true;
            //}
               
        }

        public void ShowVideoAD(System.Action<bool> onAdCompleteEvent)
        {
            //if (rewardedInterstitialAd != null)
            //{
            //    onVideoAdComplete = onAdCompleteEvent;
            //    rewardedInterstitialAd.Show(userEarnedRewardCallback);
            //}
            //else
            //{
            //    onVideoAdComplete.InvokeSafely(false);
            //    RequestVideoAd();
            //}
            //onVideoAdComplete = onAdCompleteEvent;
            //if (isVideoAdAvailable)
            //{
            //    AudioListener.pause = true;
            //    videoWasWatched = videoShowResult = false;
            //    currentVideoID++;
            //    rewardedAd.Show();
            //}
            //else
            //{
            //    onVideoAdComplete.InvokeSafely(false);
            //    Debug.Log("Appodeal video ad not available");
            //}
        }
        private void HandleAdDidDismiss(object sender, EventArgs args)
        {
            onVideoAdComplete.InvokeSafely(false);
            RequestVideoAd();
        }
        private void OnVideoFinished(bool showResult)
        {
            if (!videoWasWatched)
            {
                videoWasWatched = true;
                videoShowResult = showResult;
            }
        }

        #region IInterstitialAdListener IMPLEMENTATION

        public void onInterstitialClosed(object sender, EventArgs args)
        {
            Debug.Log("APPODEAL onInterstitialClosed");
            UIBlackPatch.Current.LoadPendingScene();
            StartCoroutine(UnlockAppOpenAd());
            interstitialWasShown = true;
            RequestInterstitial();
        }

        private IEnumerator UnlockAppOpenAd()
        {
            yield return new WaitForSeconds(0.2f);
            isShowingInter = false;
        }
        private void OnInterstitialClosedCall()
        {
            onInterstitialADClosed.InvokeSafely();
            onInterstitialADClosed = null;

        }
        #endregion

        #region IRewardedVideoAdListener IMPLEMENTATION

        //public void onRewardedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        //{
        //    Debug.Log("APPODEAL onRewardedVideoFailedToLoad");
        //    if (AdsManager.Instance != null)
        //        AdsManager.Instance.Init();
        //}

        //public void onRewardedVideoFinished(object sender, Reward args)
        //{
        //    playerIsRaward = true;
        //}

        public void onRewardedVideoClosed(object sender, EventArgs args)
        {
            if (MapAds.instance != null && playerIsRaward)
            {
                if (MapAds.instance.isShow)
                {
                    MapAds.instance.Finish();
                    return;
                }
            }
            _instance.OnVideoFinished(playerIsRaward);

            playerIsRaward = false;

            RequestRewardedAd();
        }
        #endregion

        #region Non Skippable Video callback handlers
        public void onNonSkippableVideoLoaded(bool c)
        {
            Debug.Log("NonSkippable Video loaded");
        }

        public void onNonSkippableVideoFailedToLoad()
        {
            Debug.Log("NonSkippable Video failed to load");
            if (AdsManager.Instance != null)
                AdsManager.Instance.Init();
        }
        public void onNonSkippableVideoShown()
        {
            Debug.Log("NonSkippable Video opened");
        }
        public void onNonSkippableVideoClosed(bool isFinished)
        {
            if(MapAds.instance != null)
            {
                if(MapAds.instance.isShow && isFinished)
                {
                    MapAds.instance.Finish();
                    return;
                }
            }
            OnVideoFinished(isFinished);
            Debug.Log("NonSkippable Video, finished:" + isFinished);
            //onVideoAdComplete.InvokeSafely( isFinished );
        }
        public void onNonSkippableVideoFinished()
        {
            OnVideoFinished(true);
            Debug.Log("NonSkippable Video finished");
            //onVideoAdComplete.InvokeSafely( true );
        }

        public void onInterstitialExpired()
        {
            throw new System.NotImplementedException();
        }

        public void onRewardedVideoExpired()
        {
            throw new System.NotImplementedException();
        }

        public void onRewardedVideoClicked()
        {
            throw new System.NotImplementedException();
        }

        public void onNonSkippableVideoExpired()
        {
            throw new System.NotImplementedException();
        }
        public void onNonSkippableVideoShowFailed()
        {
            //throw new System.NotImplementedException();
        }
        #endregion

    }
}
