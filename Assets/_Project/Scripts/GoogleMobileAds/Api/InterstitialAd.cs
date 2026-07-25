using System;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	public class InterstitialAd
	{
		private IInterstitialClient client;

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

		public InterstitialAd(string adUnitId)
		{
		}

		public void LoadAd(AdRequest request)
		{
		}

		public bool IsLoaded()
		{
			return false;
		}

		public void Show()
		{
		}

		public void Destroy()
		{
		}

		public string MediationAdapterClassName()
		{
			return null;
		}
	}
}
