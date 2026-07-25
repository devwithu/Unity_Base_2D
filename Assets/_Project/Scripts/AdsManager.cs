using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
	public typeADS yourTypeADS;

	private bool IsShowADM;

	private bool IsShowUnity;

	[HideInInspector]
	public int numOpenLevel;

	[HideInInspector]
	public int keyBonues;

	private const string idADSUnityReward = "rewardedVideo";

	private const string idADSUnity5s = "video";

	private string gameId;

	private Dictionary<string, object> tempdic;

	private InterstitialAd interstitial;

	private bool justShowAdmob;

	private RewardBasedVideoAd rewardBasedVideo;

	private BannerView bannerView;

	private string appId;

	private string adUnitId;

	private string adUnitIdRw;

	private string adBaner;

	private static AdsManager instance;

	public static AdsManager Instance
	{
		get
		{
			return null;
		}
	}

	private void Start()
	{
	}

	private void Awake()
	{
	}

	private void SettupInfor()
	{
	}

	private void InitUnity()
	{
	}

	public void ShowRewardVideo()
	{
	}

	public void ShowFull()
	{
	}

	private void BonuesVideosADS()
	{
	}

	private IEnumerator Delaytime()
	{
		return null;
	}

	private void ShowUnityAdsReward()
	{
	}

	private void ShowUnityAds5s()
	{
	}

	public bool CheckLoadRewardUNITY()
	{
		return false;
	}

	//private void HandleShowResult(ShowResult result)
	//{
	//}

	public void ShowRewardVideoUnity()
	{
	}

	private void ShowVIdeoADSunity()
	{
	}

	private void RequestInterstitial()
	{
	}

	private void RequestBanner()
	{
	}

	private void ShowBaner()
	{
	}

	private void Interstitial_OnAdOpening(object sender, EventArgs e)
	{
	}

	private void Interstitial_OnAdClosed(object sender, EventArgs e)
	{
	}

	private AdRequest CreateAdRequest()
	{
		return null;
	}

	private void ShowInterstital()
	{
	}

	private void ShowAdmobInterstitial()
	{
	}

	private void RequestRewardBasedVideo()
	{
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
	}

	public void ShowRewardAdmob()
	{
	}
}
