using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Api
{
	public class CustomNativeTemplateAd
	{
		private ICustomNativeTemplateClient client;

		internal CustomNativeTemplateAd(ICustomNativeTemplateClient client)
		{
		}

		public List<string> GetAvailableAssetNames()
		{
			return null;
		}

		public string GetCustomTemplateId()
		{
			return null;
		}

		public Texture2D GetTexture2D(string key)
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
