using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public interface ITemperatureEntry
	{
		[JsonProperty(nameof(Id))]
		Guid Id
		{
			get;
			set;
		}

		[JsonProperty(nameof(DeviceId))]
		int DeviceId
		{
			get;
			set;
		}

		[JsonProperty(nameof(TemperatureCelsius))]
		double TemperatureCelsius
		{
			get;
			set;
		}

		[JsonProperty(nameof(Humidity))]
		double Humidity
		{
			get;
			set;
		}

		[JsonProperty(nameof(Pressure))]
		double Pressure
		{
			get;
			set;
		}

		[JsonProperty(nameof(CreatedDateTime))]
		DateTimeOffset CreatedDateTime
		{
			get;
			set;
		}
	}
}
