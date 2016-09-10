using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public sealed class TemperatureSettingResults
	{
		public TemperatureSettingResults(TemperatureSettingStatus status, IList<ITemperatureSetting> settings)
		{
			Status = status;
			Settings = settings;
		}
		public TemperatureSettingStatus Status { get; set; }
		public IList<ITemperatureSetting> Settings { get; set; }
		public Exception Exception { get; set; }
	}
}
