using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	internal class Utils
	{
		public const string AdListenerClassName = "com.google.android.gms.ads.AdListener";

		public const string AdRequestClassName = "com.google.android.gms.ads.AdRequest";

		public const string AdRequestBuilderClassName = "com.google.android.gms.ads.AdRequest$Builder";

		public const string AdSizeClassName = "com.google.android.gms.ads.AdSize";

		public const string AdMobExtrasClassName = "com.google.android.gms.ads.mediation.admob.AdMobExtras";

		public const string PlayStorePurchaseListenerClassName = "com.google.android.gms.ads.purchase.PlayStorePurchaseListener";

		public const string MobileAdsClassName = "com.google.android.gms.ads.MobileAds";

		public const string BannerViewClassName = "com.google.unity.ads.Banner";

		public const string InterstitialClassName = "com.google.unity.ads.Interstitial";

		public const string RewardBasedVideoClassName = "com.google.unity.ads.RewardBasedVideo";

		public const string NativeAdLoaderClassName = "com.google.unity.ads.NativeAdLoader";

		public const string UnityAdListenerClassName = "com.google.unity.ads.UnityAdListener";

		public const string UnityRewardBasedVideoAdListenerClassName = "com.google.unity.ads.UnityRewardBasedVideoAdListener";

		public const string UnityAdLoaderListenerClassName = "com.google.unity.ads.UnityAdLoaderListener";

		public const string PluginUtilsClassName = "com.google.unity.ads.PluginUtils";

		public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";

		public const string BundleClassName = "android.os.Bundle";

		public const string DateClassName = "java.util.Date";

		public static AndroidJavaObject GetAdSizeJavaObject(AdSize adSize)
		{
			return null;
		}

		public static AndroidJavaObject GetAdRequestJavaObject(AdRequest request)
		{
			return null;
		}
	}
}
