using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public interface ITemperatureSetting
	{
		long Id { get; set; }

		short? DayOfWeek { get; set; }

		int? Month { get; set; }

		bool IsTimeOnly { get; set; }

		DateTimeOffset? StartTime { get; set; }

		DateTimeOffset? EndTime { get; set; }

		double HeatTemperatureCelsius { get; set; }

		double CoolTemperatureCelsius { get; set; }

		DateTimeOffset DateCreated { get; set; }

		DateTimeOffset DateModified { get; set; }
	}
}
