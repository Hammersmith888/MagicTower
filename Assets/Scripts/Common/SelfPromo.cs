using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfPromo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("SelfPromoCanBeShow")) {
			PlayerPrefs.SetInt ("SelfPromoCanBeShow", 1);
			gameObject.SetActive (false);
		}

        if (PlayerPrefs.GetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 0) == 2)
        {
            //Instantiate(AnyWindowsLoaderConfig.Instance.GetWindowOfType(AnyWindowsLoaderConfig.WindowType.handWithScroll), transform);
            PlayerPrefs.SetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 3);
        }
	}

	public void Open()
	{
#if UNITY_ANDROID
		//Application.OpenURL("https://play.google.com/store/apps/details?id=com.akpublish.magicsiege");
		Application.OpenURL("market://details?id=com.akpublish.magicsiege");
#elif UNITY_IOS
		Application.OpenURL( "https://itunes.apple.com/us/app/magic-siege-defender-hd/id1369002248" );
#endif
	}
}
