using System;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	public class BannerView
	{
		private IBannerClient client;

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

		public BannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
		}

		public BannerView(string adUnitId, AdSize adSize, int x, int y)
		{
		}

		public void LoadAd(AdRequest request)
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		public void Destroy()
		{
		}

		public float GetHeightInPixels()
		{
			return 0f;
		}

		public float GetWidthInPixels()
		{
			return 0f;
		}

		public void SetPosition(AdPosition adPosition)
		{
		}

		public void SetPosition(int x, int y)
		{
		}

		private void ConfigureBannerEvents()
		{
		}

		public string MediationAdapterClassName()
		{
			return null;
		}
	}
}
