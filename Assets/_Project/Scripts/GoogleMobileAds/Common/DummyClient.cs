using System;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	public class DummyClient : IBannerClient, IInterstitialClient, IRewardBasedVideoAdClient, IAdLoaderClient, IMobileAdsClient
	{
		public string UserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public void Initialize(string appId)
		{
		}

		public void SetApplicationMuted(bool muted)
		{
		}

		public void SetApplicationVolume(float volume)
		{
		}

		public void SetiOSAppPauseOnBackground(bool pause)
		{
		}

		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
		}

		public void CreateBannerView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
		}

		public void LoadAd(AdRequest request)
		{
		}

		public void ShowBannerView()
		{
		}

		public void HideBannerView()
		{
		}

		public void DestroyBannerView()
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

		public void CreateInterstitialAd(string adUnitId)
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

		public void CreateRewardBasedVideoAd()
		{
		}

		public void SetUserId(string userId)
		{
		}

		public void LoadAd(AdRequest request, string adUnitId)
		{
		}

		public void DestroyRewardBasedVideoAd()
		{
		}

		public void ShowRewardBasedVideoAd()
		{
		}

		public void CreateAdLoader(AdLoader.Builder builder)
		{
		}

		public void Load(AdRequest request)
		{
		}

		public void SetAdSize(AdSize adSize)
		{
		}

		public string MediationAdapterClassName()
		{
			return null;
		}
	}
}
