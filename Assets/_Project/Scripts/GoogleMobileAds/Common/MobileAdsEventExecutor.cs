using System;
using System.Collections.Generic;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	public class MobileAdsEventExecutor : MonoBehaviour
	{
		private static MobileAdsEventExecutor instance;

		private static List<Action> adEventsQueue;

		private static bool adEventsQueueEmpty;

		public static void Initialize()
		{
		}

		public static bool IsActive()
		{
			return false;
		}

		public void Awake()
		{
		}

		public static void ExecuteInUpdate(Action action)
		{
		}

		public void Update()
		{
		}

		public void OnDisable()
		{
		}
	}
}
