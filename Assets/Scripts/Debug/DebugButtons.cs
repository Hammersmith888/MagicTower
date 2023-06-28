using Achievement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugButtons : MonoBehaviour
{
    public Button toggleDebugButtons;
    public GameObject debugButtonsParent, debugPanel, panelLog, panelLoadLevel;
    [Space(5f)]
    public Button notifyButton;
    public Button socialLoginBtn;
    public Button unlockAchievementBtn;
    public Button interstitialAdButton;
    public Button unityAdsButton;
    public Button facebookLoginBtn;
    public GameObject fpsCounter;

    public Text FacebookIDLabel, UpdatingStateLabel;

    public bool dontDestroyOnLoad = true;
    public bool disableButtonsAtStart = true;

    public static DebugButtons Instance;

    private void Awake()
    {
        Instance = this;
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
        notifyButton.onClick.AddListener(Notify);
        socialLoginBtn.onClick.AddListener(SocialLoginBtn);
        unlockAchievementBtn.onClick.AddListener(UnlockAchievement);
        interstitialAdButton.onClick.AddListener(ShowInterstitialAd);
        unityAdsButton.onClick.AddListener(ShowVideoAd);
        facebookLoginBtn.onClick.AddListener(FacebookLogin);

        toggleDebugButtons.onClick.AddListener(ToggleDebugButtons);
        debugButtonsParent.SetActive(!disableButtonsAtStart);

        StartCoroutine(SetFacebookUserID());
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (debugPanel != null)
        {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }

        if (PPSerialization.GetJsonDataFromPrefs("debug_coins") == "")
        {
            // CoinsManager.AddCoinsST(50000);
            PPSerialization.Save("debug_coins", "1");
        }

       while(true)
        {
            panelLog.SetActive(true);
            yield return new WaitForSecondsRealtime(1);
        }
       
    }

    private IEnumerator SetFacebookUserID()
    {
        yield return new WaitUntil(() =>
        {
            return Social.FacebookManager.Instance.isLoggedIn;
        });
        FacebookIDLabel.text = "FbID: " + Social.FacebookManager.Instance.User.id;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioListener.pause = !AudioListener.pause;
        }

        for (int i = (int)KeyCode.Alpha1; i < (int)KeyCode.Alpha9; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                var spellType = (Spell.SpellType)(i - (int)KeyCode.Alpha1);
                Debug.LogFormat("Test SetSpellForHighlighting: {0}", spellType);
                ShopSpellItemSettings.SetSpellForHighlighting(spellType);
            }
        }
        fpsCounter.SetActive(debugButtonsParent.gameObject.activeSelf);
    }

    private void ToggleDebugButtons()
    {
        debugButtonsParent.SetActive(!debugButtonsParent.activeSelf);
        if (debugPanel != null)
        {
            debugPanel.SetActive(!debugPanel.activeSelf);
        }
    }

    private void UnlockAchievement()
    {
        
    }

    private void SocialLoginBtn()
    {
        UnityEngine.Social.localUser.Authenticate(result =>
        {
            Debug.Log("Auth result: " + result);
        });
    }

    private void Notify()
    {
        Debug.Log("Notify clicked");
        //Notifications.LocalNotificationsController.S("Test", "Message", 8);
    }

    private bool adVisible;
    public void ShowInterstitialAd()
    {
        ADs.AdsManager.RequestAndShowInterstitial(onInterstitialComplete: () =>
         {
             Debug.Log("Post function call");
         });
    }

    public void LoadLevelOpen()
    {
        panelLoadLevel.SetActive(!panelLoadLevel.activeSelf);
    }

    public void AddCrystals()
    {
        var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
        for (int i = 0; i < 10; i++)
        {
            int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Red, i);
            gemItems[gem1Id].count = 999;
        }
        for (int i = 0; i < 10; i++)
        {
            int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Yellow, i);
            gemItems[gem1Id].count = 999;
        }
        for (int i = 0; i < 10; i++)
        {
            int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Blue, i);
            gemItems[gem1Id].count = 999;
        }
        for (int i = 0; i < 10; i++)
        {
            int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.White, i);
            gemItems[gem1Id].count = 999;
        }
        PPSerialization.Save(EPrefsKeys.Gems, gemItems);
    }

    private int operationsCounter;
    public void ResetAllProgress()
    {
        LoadFromCloudQueue.PutOperationToQueue(() =>
       {
           UI.MessageWindow.ToggleSynchronizationWindow(true);

           if (Social.FacebookManager.Instance.User != null)
           {
               operationsCounter++;

               Native.FirebaseManager.Instance.DeleteUserData(Social.FacebookManager.Instance.User.id, Native.FirebaseManager.EDBType.USER_ID, result =>
              {
                  operationsCounter--;
                  Debug.LogFormat("Data for user {0} deleted with result: {1}", Social.FacebookManager.Instance.User.id, result);
              });
           }

           operationsCounter++;
           Native.FirebaseManager.Instance.DeleteUserData(SaveManager.ProfileSettings.CurrentProfileID, Native.FirebaseManager.EDBType.USER_ID, result =>
           {
               operationsCounter--;
               Debug.LogFormat("Data for user {0} deleted with result: {1}", Social.FacebookManager.Instance.User.id, result);
           });

           if (FirebaseSavesByDeviceController.IsActivated)
           {
               operationsCounter++;
               Native.FirebaseManager.Instance.DeleteUserData(FirebaseSavesByDeviceController.DEVICE_ID, Native.FirebaseManager.EDBType.DEVICE, result =>
               {
                   operationsCounter--;
                   Debug.LogFormat("Data for Device {0} deleted with result: {1}", FirebaseSavesByDeviceController.DEVICE_ID, result);
               });
           }

           operationsCounter++;
           Native.GoogleCloudSavesController.Reset(_result =>
           {
               operationsCounter--;
               Debug.LogFormat("Google cloud data deleted with result: {0}", _result);
           });

           StartCoroutine(WaitUntilPredicateAndExecute(() =>
          {
              return operationsCounter <= 0;
          }, ClearPrefsAndQuit));
       });
    }

    private IEnumerator WaitUntilPredicateAndExecute(System.Func<bool> predicate, System.Action onComplete)
    {
        yield return new WaitUntil(predicate);
        onComplete();
    }

    public void ClearPrefsAndQuit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void TestBtn()
    {
        //Bugsnag.Notify(new System.InvalidOperationException("Test error"));
        //Native.GoogleCloudSavesController.Instance.CollecAllDataTest();
        UI.MessageWindow.ToggleSynchronizationWindow(false);
        UI.UIDialogWindow.Show("t_0661", "GooglePlay Services", onCloseAction: yesClicked =>
        {
            Debug.LogFormat("Result: {0}", yesClicked);
            if (yesClicked)
            {
                SaveManager.Instance.ClearSavesData();
            }
        });
    }

    private void ShowVideoAd()
    {
        ADs.AdsManager.ShowVideoAd(result =>
       {
           Debug.Log("Show video ad: " + result);
       });
    }

    private void FacebookLogin()
    {
        Social.FacebookManager.Instance.Login();
    }

    public void OnFBInviteClick()
    {
        UI.MessageWindow.Show(UI.MessageWindow.EMessageWindowType.FRIENDS_INVITE);
    }

    public void SendAnalyticsEvent()
    {
        AnalyticsController.Instance.LogMyEvent("TestEvent", new Dictionary<string, string>() { { "TestParameterName", "TestParameterValue" } });
    }

    public void ValidateIronSourceSdk()
    {
        //Debug.Log("ValidateIronSourceSdk Click");
        //IronSource.Agent.validateIntegration();
        //Debug.LogFormat("IronSource Advertiser ID: {0}", IronSource.Agent.getAdvertiserId());
        //IronSource.Agent.getOfferwallCredits();
    }

    public void AddGold()
    {
        CoinsManager.AddCoinsST(100000);
    }

    public void TestEffectBtn()
    {
        GameObject testEffect = Resources.Load("TestEffect") as GameObject;
        Instantiate(testEffect, testEffect.transform.position, testEffect.transform.rotation);
    }

    public void ShowIntro()
    {
        if (UIBlackPatch.Current != null && !UIBlackPatch.Current.IsPlaying)
        {
            UIBlackPatch.Current.Appear("Intro");
        }
    }

    public void UpdateDeviceBalance()
    {
        PlayBalanceSaver playBalanceSaver = GetComponent<PlayBalanceSaver>();
        if (playBalanceSaver == null)
        {
            playBalanceSaver = gameObject.AddComponent<PlayBalanceSaver>();
        }
        playBalanceSaver.TryUpdate(UpdatingStateLabel);
    }

    #region DEBUG_GAME_EVENTS
    public void Map_CompleteLevel()
    {
#if DEBUG_MODE

#endif
        Core.DebugGameEventsMono.DebugEvents.LaunchEvent(Core.DebugGameEvents.EDebugEvent.MAP_COMPLETE_LVL);
    }
    #endregion

    public void AddAchieve()
    {
        //AchievementController.SetAchievementDone(21, true, true);
    }
    
}
