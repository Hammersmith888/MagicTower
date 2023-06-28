using System.Collections.Generic;
using UnityEngine;
using Analytics;
using Debug = UnityEngine.Debug;
using System.Linq;

#if !USE_FLURRY
using DevToDev;

public interface IAnalytics
{
    void LogEvent(string eventName);
    void LogEvent(string eventName, Dictionary<string, string> parameters);
}
#endif

public class AnalyticsController : MonoSingleton<AnalyticsController>
{
    private readonly Dictionary<string, object> _eventAMParameters = new Dictionary<string, object>();
    //[HideInInspector]
    private static IAnalytics service;
    private const string IAPKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkogBM1KyBJUe0H4zsk4gBxRCj9QjQ2WE2OLMtnaOdknSIlLlpYkU0ydERtYFqXTphqPHzEtnDP95b/waLSEfexuNgjvx4aSRLFwkBj44H7feE5m86KnQrstjX2JMB4hbJ8PN0qtfURmS0aGmwAgkrOX7jMA91o3ypI1sBJaBQBtRGH6LDqb8mp6UT1Si2j1P+vwA/FPSIAytv5dvH2RpUduxKITRfaaNCzARF/fsfMzqnyNKWliftMrrRSybfODoqeVPDHI/HYohD7/Yb2CDhhIB9S1IBtX/9UhpdpsZidbrOA6ZFAjjMnPjl6y/fZbEdqgUBnOCRMxZb6fmvM+5eQIDAQAB";
    override protected void Awake()
    {
        service = DevToDevAnalytics.instance;

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            base.Awake();
        }
        if (isOtherInstanceExists)
        {
            return;
        }
    }

    public void LogMyEvent(string _event)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            service.LogEvent(_event);
            Firebase.Analytics.FirebaseAnalytics
               .LogEvent(
                 Firebase.Analytics.FirebaseAnalytics.ParameterContent,
                 Firebase.Analytics.FirebaseAnalytics.ParameterGroupId,
                _event
               );
            AppMetrica.Instance.ReportEvent(_event);
        }
    }

    public void LogMyEvent(string _event, Dictionary<string, string> parameters)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            service.LogEvent(_event, parameters);
            Firebase.Analytics.Parameter[] LevelUpParameters = new Firebase.Analytics.Parameter[parameters.Count];
            var keys = new List<string>(parameters.Keys);
            for (int i = 0; i < LevelUpParameters.Length; i++)
                LevelUpParameters[i] = new Firebase.Analytics.Parameter(keys[i], parameters[keys[i]]);

            AppMetrica.Instance.ReportEvent(_event,parameters.ToDictionary(pair => pair.Key, pair => (object)pair.Value));
        }
    }

#if !USE_FLURRY
    private UnityEngine.Purchasing.PurchaseEventArgs purchaseEventArgs;
    public void RealPayment(UnityEngine.Purchasing.PurchaseEventArgs args)
    {
        try
        {
            DevToDev.AntiCheat.VerifyReceipt(args.purchasedProduct.ToString(), IAPKey, onReceiptVerifyCallback);
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex);
        }

        purchaseEventArgs = args;
    }
    public void onReceiptVerifyCallback(DevToDev.ReceiptVerificationStatus status)
    {
        if (status == ReceiptVerificationStatus.ReceiptValid)
        {
            if (purchaseEventArgs != null)
            {
                DevToDev.Analytics.RealPayment(purchaseEventArgs.purchasedProduct.transactionID, (float)purchaseEventArgs.purchasedProduct.metadata.localizedPrice, purchaseEventArgs.purchasedProduct.definition.id, purchaseEventArgs.purchasedProduct.metadata.isoCurrencyCode);
                //GameAnalytics.NewBusinessEventGooglePlay(args.purchasedProduct.metadata.isoCurrencyCode, (int)args.purchasedProduct.metadata.localizedPrice, args.purchasedProduct.metadata.localizedTitle, args.purchasedProduct.metadata.localizedTitle, "_", "_", "_");
                Firebase.Analytics.FirebaseAnalytics
                    .LogEvent(
                    Firebase.Analytics.FirebaseAnalytics.EventPresentOffer,
                    Firebase.Analytics.FirebaseAnalytics.ParameterPrice,
                    purchaseEventArgs.purchasedProduct.metadata.localizedPriceString
                    );
                AppMetrica.Instance.ReportEvent("buy_product"+ purchaseEventArgs.purchasedProduct.metadata.localizedPriceString);
            }
        }
        Debug.Log("Verification status" + status);
    }

    public void CurrencyAccrual(int amount, DevToDev.AccrualType accrualType)
    {
        DevToDev.Analytics.CurrencyAccrual(amount, "Coins", accrualType);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tutorialNumber">Starts from 1</param>
    /// <param name="step">0 indicates tutorial start</param>
    public void Tutorial(int tutorialNumber, int step)
    {
        //Debug.LogFormat("<color=blue>Analytics</color> tutorial {0} step {1}  {2}", tutorialNumber, step, (100 * tutorialNumber + step));
        //DevToDev.Analytics.Tutorial(100 * tutorialNumber + step);
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Tutorial "+ 100*tutorialNumber+step);
        //Firebase.Analytics.FirebaseAnalytics
        //  .LogEvent(
        //    Firebase.Analytics.FirebaseAnalytics.EventTutorialBegin,
        //    Firebase.Analytics.FirebaseAnalytics.ParameterGroupId,
        //   (100 * tutorialNumber + step)
        //  );
    }

    public void LevelUp(int lvl)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            DevToDev.Analytics.LevelUp(lvl);
            Firebase.Analytics.FirebaseAnalytics
             .LogEvent(
               Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
               Firebase.Analytics.FirebaseAnalytics.ParameterSuccess,
              lvl
             );
        }
    }

    private bool isProgressionStarted;
    public void StartProgressionEvent(int levelNumber)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Debug.LogFormat("StartProgressionEvent (IsCounted: <color=red>{0}</color>)  {1}", !isProgressionStarted, levelNumber);
            //if (!isProgressionStarted)
            //{
            //    isProgressionStarted = true;
            //    LocationEventParams locationParams = new LocationEventParams();
            //    locationParams.SetDifficulty(1);
            //    // Before entering this location gamer passed the third location on the map “Village” (optional).
            //    locationParams.SetSource("Level " + levelNumber);

            //    DevToDev.Analytics.StartProgressionEvent("Level " + levelNumber, locationParams);
            //    Firebase.Analytics.FirebaseAnalytics
            //        .LogEvent(
            //          Firebase.Analytics.FirebaseAnalytics.EventLevelStart,
            //          Firebase.Analytics.FirebaseAnalytics.ParameterSuccess,
            //         levelNumber
            //        );
            //}
            //isProgressionStarted = true;

            LocationEventParams locationParams = new LocationEventParams();
            locationParams.SetDifficulty(1);
            // Before entering this location gamer passed the third location on the map “Village” (optional).
            locationParams.SetSource("Level " + levelNumber);
            DevToDev.Analytics.StartProgressionEvent("Level " + levelNumber, locationParams);
            Firebase.Analytics.FirebaseAnalytics
                .LogEvent(
                  Firebase.Analytics.FirebaseAnalytics.EventLevelStart,
                  Firebase.Analytics.FirebaseAnalytics.ParameterSuccess,
                 levelNumber
                );
            AppMetrica.Instance.ReportEvent("StartLevel " + levelNumber);
            AppMetrica.Instance.SendEventsBuffer();
            AnalyticsController.Instance.LogMyEvent("Start Level ", new Dictionary<string, string>() {
            { "level", levelNumber.ToString() },
        });
        }
    }

    public void EndProgressionEvent(int levelNumber, int coinsEarned, bool successfulCompletion)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (isProgressionStarted)
            {
                isProgressionStarted = false;
                LocationEventParams locationParams = new LocationEventParams();

                locationParams.SetDifficulty(1);
                locationParams.SetSource("Level " + levelNumber);
                locationParams.SetEarned(new Dictionary<string, int>() { { "Coins", coinsEarned } });
                locationParams.SetSuccessfulCompletion(successfulCompletion);
                _eventAMParameters.Clear();
                _eventAMParameters["coins_earned"] = coinsEarned;
                _eventAMParameters["successfull_Completion"] = successfulCompletion;
                AppMetrica.Instance.ReportEvent("FinishLevel " + levelNumber, _eventAMParameters);
                AppMetrica.Instance.SendEventsBuffer();
                DevToDev.Analytics.StartProgressionEvent("Level " + levelNumber, locationParams);
                Firebase.Analytics.FirebaseAnalytics
                    .LogEvent(
                      Firebase.Analytics.FirebaseAnalytics.EventLevelEnd,
                      Firebase.Analytics.FirebaseAnalytics.ParameterSuccess,
                     levelNumber
                    );
            }
        }
    }
#else
	public void RealPayment( UnityEngine.Purchasing.PurchaseEventArgs args )
	{
	}

	public void CurrencyAccrual( int amount, DevToDev.AccrualType accrualType )
	{
	}

	public void Tutorial( int tutorialIndex, int step )
	{
	}

	public void LevelUp( int lvl )
	{
	}

	public void StartProgressionEvent( int levelNumber )
	{
	}

	public void EndProgressionEvent( int levelNumber, int coinsEarned, bool successfulCompletion )
	{
	}
#endif
}
