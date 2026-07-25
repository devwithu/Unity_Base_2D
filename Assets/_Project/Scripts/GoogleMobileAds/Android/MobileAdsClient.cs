using GoogleMobileAds.Common;

namespace GoogleMobileAds.Android
{
	public class MobileAdsClient : IMobileAdsClient
	{
		private static MobileAdsClient instance;

		public static MobileAdsClient Instance
		{
			get
			{
				return null;
			}
		}

		private MobileAdsClient()
		{
		}

		public void Initialize(string appId)
		{
		}

		public void SetApplicationVolume(float volume)
		{
		}

		public void SetApplicationMuted(bool muted)
		{
		}

		public void SetiOSAppPauseOnBackground(bool pause)
		{
		}
	}
}
