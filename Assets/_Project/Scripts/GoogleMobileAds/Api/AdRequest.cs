using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GoogleMobileAds.Api.Mediation;

namespace GoogleMobileAds.Api
{
	public class AdRequest
	{
		public class Builder
		{
			internal List<string> TestDevices
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal HashSet<string> Keywords
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal DateTime? Birthday
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal Gender? Gender
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal bool? ChildDirectedTreatmentTag
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal Dictionary<string, string> Extras
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal List<MediationExtras> MediationExtras
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public Builder AddKeyword(string keyword)
			{
				return null;
			}

			public Builder AddTestDevice(string deviceId)
			{
				return null;
			}

			public AdRequest Build()
			{
				return null;
			}

			public Builder SetBirthday(DateTime birthday)
			{
				return null;
			}

			public Builder SetGender(Gender gender)
			{
				return null;
			}

			public Builder AddMediationExtras(MediationExtras extras)
			{
				return null;
			}

			public Builder TagForChildDirectedTreatment(bool tagForChildDirectedTreatment)
			{
				return null;
			}

			public Builder AddExtra(string key, string value)
			{
				return null;
			}
		}

		public const string Version = "3.15.1";

		public const string TestDeviceSimulator = "SIMULATOR";

		public List<string> TestDevices
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public HashSet<string> Keywords
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public DateTime? Birthday
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Gender? Gender
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool? TagForChildDirectedTreatment
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Dictionary<string, string> Extras
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public List<MediationExtras> MediationExtras
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		private AdRequest(Builder builder)
		{
		}
	}
}
