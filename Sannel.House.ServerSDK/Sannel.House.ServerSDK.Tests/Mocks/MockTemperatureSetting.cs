using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK.Tests.Mocks
{
	public class MockTemperatureSetting : ITemperatureSetting
	{
		public double CoolTemperatureCelsius
		{
			get;
			set;
		}

		public DateTimeOffset DateCreated
		{
			get;
			set;
		}

		public DateTimeOffset DateModified
		{
			get;
			set;
		}

		public short? DayOfWeek
		{
			get;
			set;
		}

		public DateTimeOffset? EndTime
		{
			get;
			set;
		}

		public double HeatTemperatureCelsius
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public bool IsTimeOnly
		{
			get;
			set;
		}

		public int? Month
		{
			get;
			set;
		}

		public DateTimeOffset? StartTime
		{
			get;
			set;
		}
	}
}
