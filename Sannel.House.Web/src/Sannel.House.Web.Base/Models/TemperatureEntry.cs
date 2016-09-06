using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#if THERMOSTAT
namespace Sannel.House.Thermostat.Models
#else
namespace Sannel.House.Web.Base.Models
#endif
{
	public class TemperatureEntry
	{
		[Key]
		[JsonProperty(nameof(Id))]
		public Guid Id { get; set; }

		[JsonProperty(nameof(DeviceId))]
		public int DeviceId { get; set; }

#if !THERMOSTAT
		[JsonIgnore]
		public Device Device { get; set; }
#endif

		[JsonProperty(nameof(TemperatureCelsius))]
		public double TemperatureCelsius { get; set; }

		[JsonProperty(nameof(Humidity))]
		public double Humidity { get; set; }

		[JsonProperty(nameof(Presure))]
		public double Presure { get; set; }

#if THERMOSTAT
		[JsonProperty(nameof(Synced))]
		public bool Synced { get; set; }
#endif

		[JsonProperty(nameof(CreatedDateTime))]
		public DateTimeOffset CreatedDateTime { get; set; }
	}
}
