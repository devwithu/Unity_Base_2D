using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class AdLoaderClient : AndroidJavaProxy, IAdLoaderClient
	{
		private AndroidJavaObject adLoader;

		private Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateCallbacks
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public AdLoaderClient(AdLoader unityAdLoader)
			: base((string)null)
		{
		}

		public void LoadAd(AdRequest request)
		{
		}

		public void onCustomTemplateAdLoaded(AndroidJavaObject ad)
		{
		}

		private void onAdFailedToLoad(string errorReason)
		{
		}

		public void onCustomClick(AndroidJavaObject ad, string assetName)
		{
		}
	}
}
