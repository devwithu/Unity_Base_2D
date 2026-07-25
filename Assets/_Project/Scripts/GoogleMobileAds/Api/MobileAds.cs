using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	public class MobileAds
	{
		private static readonly IMobileAdsClient client;

		public static void Initialize(string appId)
		{
		}

		public static void SetApplicationMuted(bool muted)
		{
		}

		public static void SetApplicationVolume(float volume)
		{
		}

		public static void SetiOSAppPauseOnBackground(bool pause)
		{
		}

		private static IMobileAdsClient GetMobileAdsClient()
		{
			return null;
		}
	}
}
