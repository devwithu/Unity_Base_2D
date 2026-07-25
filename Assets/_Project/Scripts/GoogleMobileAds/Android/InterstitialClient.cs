using System;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class InterstitialClient : AndroidJavaProxy, IInterstitialClient
	{
		private AndroidJavaObject interstitial;

		public event EventHandler<EventArgs> OnAdLoaded
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

		public event EventHandler<EventArgs> OnAdOpening
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

		public event EventHandler<EventArgs> OnAdClosed
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

		public event EventHandler<EventArgs> OnAdLeavingApplication
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

		public InterstitialClient()
			: base((string)null)
		{
		}

		public void CreateInterstitialAd(string adUnitId)
		{
		}

		public void LoadAd(AdRequest request)
		{
		}

		public bool IsLoaded()
		{
			return false;
		}

		public void ShowInterstitial()
		{
		}

		public void DestroyInterstitial()
		{
		}

		public string MediationAdapterClassName()
		{
			return null;
		}

		public void onAdLoaded()
		{
		}

		public void onAdFailedToLoad(string errorReason)
		{
		}

		public void onAdOpened()
		{
		}

		public void onAdClosed()
		{
		}

		public void onAdLeftApplication()
		{
		}
	}
}
