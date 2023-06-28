
using UnityEngine;

public class RateUsWindow : MonoBehaviour
{
    public void OpenStore()
    {
        AnalyticsController.Instance.LogMyEvent("Pup-UpRateUS");
#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.akpublish.magicsiege");
#elif UNITY_IOS
		Application.OpenURL( "https://itunes.apple.com/us/app/magic-siege-defender-hd/id1369002248" );
#endif
        Close();

        var profileSettings = PPSerialization.Load<SaveManager.ProfileSettings>(EPrefsKeys.ProfileSettings.ToString());
        if (!profileSettings.rateUsWindowWasShownAfter15Level)
        {
            profileSettings.rateUsWindowWasShownAfter15Level = true;
            PPSerialization.Save(EPrefsKeys.ProfileSettings.ToString(), profileSettings, true, true);
        }
    }

    void Start()
    {
        UIMap.Current.objsPanels.Add(gameObject);
    }

    private void OnEnable()
    {
        Core.GlobalGameEvents.Instance.AddListenerToEvent(Core.EGlobalGameEvent.TUTORIAL_START, OnTutorialStart);
    }

    private void OnDisable()
    {
        Core.GlobalGameEvents.Instance.RemoveListenerFromEvent(Core.EGlobalGameEvent.TUTORIAL_START, OnTutorialStart);
    }

    private void OnTutorialStart(Core.BaseEventParams eventParams)
    {
        Close();
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
