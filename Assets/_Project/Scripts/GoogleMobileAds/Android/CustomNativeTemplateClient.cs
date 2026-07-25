using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	internal class CustomNativeTemplateClient : ICustomNativeTemplateClient
	{
		private AndroidJavaObject customNativeAd;

		public CustomNativeTemplateClient(AndroidJavaObject customNativeAd)
		{
		}

		public List<string> GetAvailableAssetNames()
		{
			return null;
		}

		public string GetTemplateId()
		{
			return null;
		}

		public byte[] GetImageByteArray(string key)
		{
			return null;
		}

		public string GetText(string key)
		{
			return null;
		}

		public void PerformClick(string assetName)
		{
		}

		public void RecordImpression()
		{
		}
	}
}
