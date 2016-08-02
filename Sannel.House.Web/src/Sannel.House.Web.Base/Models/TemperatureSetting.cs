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
	public class TemperatureSetting
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
		[JsonProperty(nameof(Id))]
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the day of week.
		/// </summary>
		/// <value>
		/// The day of week.
		/// </value>
		[JsonProperty(nameof(DayOfWeek))]
		public DayOfWeek? DayOfWeek
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the month.
		/// </summary>
		/// <value>
		/// The month.
		/// </value>
		[JsonProperty(nameof(Month))]
		public int? Month
		{
			get;
			set;
		}

		[JsonProperty(nameof(StartDate))]
		[Column(TypeName = "bigint")]
		public Date? StartDate { get; set; }

		[JsonProperty(nameof(EndDate))]
		[Column(TypeName = "bigint")]
		public Date? EndDate { get; set; }
		
		[JsonProperty(nameof(HeatTemperatureC))]
		public double HeatTemperatureC { get; set; }

		[JsonProperty(nameof(CoolTemperatureC))]
		public double CoolTemperatureC { get; set; }
	}
}
