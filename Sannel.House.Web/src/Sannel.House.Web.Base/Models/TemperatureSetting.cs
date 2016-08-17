using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#if CLIENT

namespace Sannel.House.Client.Models
#else
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sannel.House.Web.Base.Models
#endif
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
#if !CLIENT
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
#endif
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

		[JsonProperty(nameof(Month))]
		public int? Month
		{
			get;
			set;
		}

		[JsonProperty(nameof(IsStartOnly))]
		public bool IsStartOnly { get; set; }

		[JsonProperty(nameof(IsEndOnly))]
		public bool IsEndOnly { get; set; }

		[JsonProperty(nameof(Start))]
		public DateTime? Start { get; set; }

		[JsonProperty(nameof(End))]
		public DateTime? End { get; set; }

		[JsonProperty(nameof(HeatTemperatureC))]
		public double HeatTemperatureC { get; set; }

		[JsonProperty(nameof(CoolTemperatureC))]
		public double CoolTemperatureC { get; set; }

		[JsonProperty(nameof(DateCreated))]
		public DateTime DateCreated { get; set; } = DateTime.Now;

		[JsonProperty(nameof(DateModified))]
		public DateTime DateModified { get; set; } = DateTime.Now;
	}
}
