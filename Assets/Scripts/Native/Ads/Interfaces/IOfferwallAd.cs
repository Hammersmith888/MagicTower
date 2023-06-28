public interface IOfferwallAd
{
	bool isOfferwallAvailable
	{
		get;
	}

	void CheckPendingCredits( );

	void ShowOfferwall( );
}
