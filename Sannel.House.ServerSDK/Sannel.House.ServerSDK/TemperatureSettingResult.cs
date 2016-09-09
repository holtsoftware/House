using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public sealed class TemperatureSettingResult
	{
		public TemperatureSettingStatus Status { get; set; }

		public ITemperatureSetting Setting { get; set; }
	}
}
