
public interface IInterstitialAdsController
{
	bool isInterstitialLoaded
	{
		get;
	}

	void ShowInterstitial( System.Action onCloseCallback = null );
}
