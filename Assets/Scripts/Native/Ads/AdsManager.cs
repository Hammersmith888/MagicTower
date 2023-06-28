#define DEBUG_MODE
#if !UNITY_STANDALONE && !UNITY_WSA
#define ADMOB
#endif
#define ONLY_APPODEAL_VIDEO
#define _ONLY_UNITY_VIDEO
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ADs
{
    public class AdsManager : MonoSingleton<AdsManager>
    {
        private class OfferwallAdShowData
        {
            public IOfferwallAd OfferwallAdProvider;
            private int NumberToShowInARow;
            private int ShowNumber;

            public OfferwallAdShowData(IOfferwallAd offerwallAdProvider, int numberToShowInARow)
            {
                OfferwallAdProvider = offerwallAdProvider;
                NumberToShowInARow = numberToShowInARow;
            }

            public bool OnShow()
            {
                ShowNumber++;
                if (ShowNumber == NumberToShowInARow)
                {
                    ShowNumber = 0;
                    return true;
                }
                return false;
            }
        }

        #region VARIABLES
        private const float WAIT_FOR_INTERSTITIAL_TIME = 0f;
        private static bool noAds;

        private IVideoAdsController currentVideoAdsController;

        private IInterstitialAdsController[] interstitialAds;
        private OfferwallAdShowData[] offerWallADs;
        private AppodealAdsController appodealAds;
        private int currentOfferwallAdIndex;

        //private static int videoAdCounter;
        //const int UNITY_AD_NUMBER = 5;
        //private bool unityAdSelected;

        const float CHECK_OFFERWALL_REWARD_INTERVAL = 5f;
        private readonly string[] levelsToCheckOfferwallRewards= new string[2] { "Map","Shop" };
        private bool offerwallRewardsCheckingActive;

        private  Action _interstitialCompleteAction;

        private static AdsManager _instance;
        #endregion
        public void OnApplicationPause(bool paused)
        {
            // Display the app open ad when the app is foregrounded.
            if (!paused)
            {
                CASAdsController.Instance.ShowInterstitial();
                // ShowAppOpenAd();
            }
        }
        public bool isAnyVideAdAvailable
        {
            get
            {
//#if UNITY_EDITOR
//                return true;
//#else
                try
                {
                    //return appodealAds.isVideoAdAvailable;
                    return CASAdsController.Instance.IsRewardedLoaded();
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);
                    return false;
                }
//#endif
            }
        }

        public void Init()
        {
            //appodealAds = AppodealAdsController.Create();
            //currentVideoAdsController = appodealAds;

            //interstitialAds = new IInterstitialAdsController[]
            //{
            //    appodealAds
            //};

            try
            {
                CheckAdsEnabledState();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public static void CheckAdsEnabledState()
        {
            noAds = SaveManager.GameProgress.Current.disableAds;
            Debug.Log("AdsManager CheckAds: " + noAds);
        }

        public static bool CheckAdsState()
        {
            return noAds;
        }

        public static void OnNoAdsBought()
        {
            Debug.Log("OnNoAdsBought");
            noAds = true;
        }

        override protected void Awake()
        {
            if (s_Instance != null && s_Instance.GetInstanceID() != this.GetInstanceID())
            {
                Destroy(this.gameObject);
                return;
            }

#if UNITY_STANDALONE
            offerWallADs = new OfferwallAdShowData[0];
#else
      
            offerWallADs = new OfferwallAdShowData[0];
#endif
            currentOfferwallAdIndex = 0;

            Init();

            Debug.Log("AdsManager init adsDisabled: " + SaveManager.IsAdsDisabled);
            //DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

#region OFFERWALL
        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            //Debug.LogFormat( "<color=blue>SceneManager_sceneLoaded {0}</color>", arg0.name );
            for (int i = 0; i < levelsToCheckOfferwallRewards.Length; i++)
            {
                if (levelsToCheckOfferwallRewards[i] == arg0.name)
                {
                    ToggleOfferwallRewardsChecking(true);
                    return;
                }
            }
            ToggleOfferwallRewardsChecking(false);
        }

        private void SetNextOfferWallIndex(int nextIndex)
        {
            currentOfferwallAdIndex = nextIndex;
            if (currentOfferwallAdIndex >= offerWallADs.Length)
            {
                currentOfferwallAdIndex = 0;
            }
        }

        public void ShowOfferwall(bool preview = false)
        {
            Debug.Log("ShowOfferwall");

            if (offerWallADs.IsNullOrEmpty())
            {
                return;
            }
            StartCoroutine(_Show(preview));
        }

        IEnumerator _Show(bool preview)
        {
            Debug.Log("ShowOfferwall _Show");

            if (Application.isEditor)
            {
                if (AdsPreview.instance != null && preview)
                {
                    AdsPreview.instance.Open();
                    while (AdsPreview.instance.isShow)
                        yield return null;
                }
            }

            RequestAndShowInterstitial();
        }



        public void ToggleOfferwallRewardsChecking(bool enable)
        {
            if (offerwallRewardsCheckingActive != enable)
            {
                offerwallRewardsCheckingActive = enable;
                if (enable)
                {
                    StartCoroutine(CheckOfferwallRewardCycle());
                }
                else
                {
                    StopCoroutine(CheckOfferwallRewardCycle());
                }
            }
        }

        private IEnumerator CheckOfferwallRewardCycle()
        {
            while (true)
            {
                if (offerwallRewardsCheckingActive)
                {
                    for (int i = 0; i < offerWallADs.Length; i++)
                    {
                        offerWallADs[i].OfferwallAdProvider.CheckPendingCredits();
                    }
                }
                else
                {
                    yield break;
                }
                yield return new WaitForSecondsRealtime(CHECK_OFFERWALL_REWARD_INTERVAL);
            }
        }
#endregion


#if ADMOB

#region INTERSTITIAL
        private IInterstitialAdsController GetReadyInterstitialAd()
        {
            for (int i = 0; i < interstitialAds.Length; i++)
            {
                if (interstitialAds[i] != null)
                {
                    if (interstitialAds[i].isInterstitialLoaded)
                    {
                        return interstitialAds[i];
                    }
                }
            }
            return null;
        }


        public static void RequestAndShowInterstitial(Action onInterstitialComplete = null)
        {
            //if (noAds)
            //{
            //    if (onInterstitialComplete != null)
            //    {
            //        onInterstitialComplete();
            //    }
            //    return;
            //}
            //Instance._interstitialCompleteAction = onInterstitialComplete;
            Instance.ShowInterstital();
           // CASAdsController.Instance.ShowInterstitial();
        }

        private void ShowInterstital()
        {
            StartCoroutine(ShowInterstitalRoutine());
        }

        private IEnumerator ShowInterstitalRoutine()
        {
            if (AdsPreview.instance != null)
            {
                AdsPreview.instance.Open();
                while (AdsPreview.instance.isShow)
                    yield return null;

                if (AdsPreview.instance.disabledAds)
                    yield break;
            }
            CASAdsController.Instance.ShowInterstitial();
            float waitingTime = Time.unscaledTime;
           // IInterstitialAdsController currentInterstitialAd = GetReadyInterstitialAd();
            //while (currentInterstitialAd == null)
            //{
            //    currentInterstitialAd = GetReadyInterstitialAd();
            //    if (currentInterstitialAd == null && Time.unscaledTime - waitingTime > WAIT_FOR_INTERSTITIAL_TIME)
            //    {
            //        Debug.Log("ShowInterstitalRoutine out of time");
            //        ExecuteOnAdClosedAction();
            //        yield break;
            //    }
            //    yield return null;
            //}

            //ExecuteOnAdClosedAction();
            //Debug.Log($"ShowInterstitalRoutine -----------========  is null : {(currentInterstitialAd == null)}");
            //if (currentInterstitialAd != null)
            //{
            //    currentInterstitialAd.ShowInterstitial();
            //}

            
        }

        private void ExecuteOnAdClosedAction()
        {
            if (_interstitialCompleteAction != null)
            {
                Debug.Log("_interstitialCompleteAction != null");
                _interstitialCompleteAction();
                _interstitialCompleteAction = null;
            }
            else
            {
                Debug.Log("_interstitialCompleteAction == null");
            }
        }

#endregion

#region VideoAds
        public static void ShowVideoAd(Action<bool> onViewed)
        {
            //#if UNITY_EDITOR && ONLY_APPODEAL_VIDEO
            //            onViewed(true);
            //            return;
            //#endif
            //            if (Instance.currentVideoAdsController.isVideoAdAvailable)
            //            {
            //                Instance.currentVideoAdsController.ShowVideoAD(onViewed);
            //            }
            //#if !ONLY_APPODEAL_VIDEO && !ONLY_UNITY_VIDEO
            //			else if( Instance.appodealAds.isVideoAdAvailable )
            //			{
            //				Instance.appodealAds.ShowVideoAD( onViewed );
            //			}
            //#endif
            //if(Application.isEditor)
            //{
            //    onViewed(true);
            //    return;
            //}
            if (CASAdsController.Instance.IsRewardedLoaded())
            {
                CASAdsController.Instance.ShowRewarded(onViewed);
            }
            //if (Instance.currentVideoAdsController.isVideoAdAvailable)
               // Instance.currentVideoAdsController.ShowVideoAD(onViewed);
        }
#endregion
#else
		//public static void Init( )
		//{}

		public static void ToggleBanner(bool visible){}

		public static void ShowInterstitialByCounter(){}

		public static void RequestInterstitial( bool show = true, System.Action onInterstitialComplete = null )
		{
			if( onInterstitialComplete != null )
			{
				onInterstitialComplete();
			}
		}

        public static void RequestAndShowInterstitial(Action onInterstitialComplete = null)
        {
            if (onInterstitialComplete != null)
            {
                onInterstitialComplete();
            }
        }

        public static void RequestOrRefreshBanner( ){}

		public static void ShowVideoAd( Action<bool> onViewed )
        {
#if UNITY_EDITOR
            onViewed(true);
            return;
#endif
        }
#endif
    }
}
