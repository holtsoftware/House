using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Models
{
	/// <summary>
	/// Represents the configuration f
	/// </summary>
	public class TemperatureDefault
    {
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
#if !THERMOSTAT
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
#endif
		[Key]
		[JsonProperty("Id")]
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the day of week.
		/// </summary>
		/// <value>
		/// The day of week.
		/// </value>
		[JsonProperty("DayOfWeek")]
		public DayOfWeek DayOfWeek
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the heat temperature c.
		/// </summary>
		/// <value>
		/// The heat temperature c.
		/// </value>
		[JsonProperty(nameof(StartTime))]
		public DateTime StartTime
		{
			get;
			set;
		}

		[JsonProperty(nameof(HeatTemperatureC))]
		public double HeatTemperatureC { get; set; }

		[JsonProperty(nameof(CoolTemperatureC))]
		public double CoolTemperatureC { get; set; }
	}
}
