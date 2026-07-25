namespace GoogleMobileAds.Api
{
	public class AdSize
	{
		private bool isSmartBanner;

		private int width;

		private int height;

		public static readonly AdSize Banner;

		public static readonly AdSize MediumRectangle;

		public static readonly AdSize IABBanner;

		public static readonly AdSize Leaderboard;

		public static readonly AdSize SmartBanner;

		public static readonly int FullWidth;

		public int Width
		{
			get
			{
				return 0;
			}
		}

		public int Height
		{
			get
			{
				return 0;
			}
		}

		public bool IsSmartBanner
		{
			get
			{
				return false;
			}
		}

		public AdSize(int width, int height)
		{
		}

		private AdSize(bool isSmartBanner)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(AdSize a, AdSize b)
		{
			return false;
		}

		public static bool operator !=(AdSize a, AdSize b)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
