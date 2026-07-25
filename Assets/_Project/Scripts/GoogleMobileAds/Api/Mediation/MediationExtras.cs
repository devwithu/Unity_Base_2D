using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GoogleMobileAds.Api.Mediation
{
	public abstract class MediationExtras
	{
		public Dictionary<string, string> Extras
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public abstract string AndroidMediationExtraBuilderClassName { get; }

		public abstract string IOSMediationExtraBuilderClassName { get; }

		public MediationExtras()
		{
		}
	}
}
