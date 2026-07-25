using System;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	public class RewardBasedVideoAdClient : AndroidJavaProxy, IRewardBasedVideoAdClient
	{
		private AndroidJavaObject androidRewardBasedVideo;

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

		public event EventHandler<EventArgs> OnAdStarted
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

		public event EventHandler<Reward> OnAdRewarded
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

		public event EventHandler<EventArgs> OnAdCompleted
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

		public RewardBasedVideoAdClient()
			: base((string)null)
		{
		}

		public void CreateRewardBasedVideoAd()
		{
		}

		public void LoadAd(AdRequest request, string adUnitId)
		{
		}

		public bool IsLoaded()
		{
			return false;
		}

		public void ShowRewardBasedVideoAd()
		{
		}

		public void SetUserId(string userId)
		{
		}

		public void DestroyRewardBasedVideoAd()
		{
		}

		public string MediationAdapterClassName()
		{
			return null;
		}

		private void onAdLoaded()
		{
		}

		private void onAdFailedToLoad(string errorReason)
		{
		}

		private void onAdOpened()
		{
		}

		private void onAdStarted()
		{
		}

		private void onAdClosed()
		{
		}

		private void onAdRewarded(string type, float amount)
		{
		}

		private void onAdLeftApplication()
		{
		}

		private void onAdCompleted()
		{
		}
	}
}
