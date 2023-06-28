
namespace ADs
{
	public interface IVideoAdsController
	{
		bool isVideoAdAvailable
		{
			get;
		}

		void ShowVideoAD( System.Action<bool> onAdCompleteEvent );
	}
}
