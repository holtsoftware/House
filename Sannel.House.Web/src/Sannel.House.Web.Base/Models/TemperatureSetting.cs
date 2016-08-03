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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
		/// Gets or sets the long start date.
		/// </summary>
		/// <value>
		/// The long start date.
		/// </value>
		[JsonIgnore]
		public long? LongStartDate { get; set; }

		/// <summary>
		/// Gets or sets the start date.
		/// </summary>
		/// <value>
		/// The start date.
		/// </value>
		[JsonProperty(nameof(StartDate))]
		[NotMapped]
		public Date? StartDate
		{
			get
			{
				return LongStartDate;
			}
			set
			{
				LongStartDate = value;
			}
		}

		/// <summary>
		/// Gets or sets the long end date.
		/// </summary>
		/// <value>
		/// The long end date.
		/// </value>
		[JsonIgnore]
		public long? LongEndDate { get; set; }

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		/// <value>
		/// The end date.
		/// </value>
		[JsonProperty(nameof(EndDate))]
		[NotMapped]
		public Date? EndDate
		{
			get
			{
				return LongEndDate;
			}
			set
			{
				LongEndDate = value;
			}
		}

		/// <summary>
		/// Gets or sets the time start.
		/// </summary>
		/// <value>
		/// The time start.
		/// </value>
		[JsonIgnore]
		public int? ShortTimeStart { get; set; }

		/// <summary>
		/// Gets or sets the start time.
		/// </summary>
		/// <value>
		/// The start time.
		/// </value>
		[NotMapped]
		public Time? StartTime
		{
			get
			{
				return ShortTimeStart;
			}
			set
			{
				ShortTimeStart = value;
			}
		}

		/// <summary>
		/// Gets or sets the short end time.
		/// </summary>
		/// <value>
		/// The short end time.
		/// </value>
		[JsonIgnore]
		public int? ShortEndTime { get; set; }

		/// <summary>
		/// Gets or sets the end time.
		/// </summary>
		/// <value>
		/// The end time.
		/// </value>
		[NotMapped]
		public Time? EndTime
		{
			get
			{
				return ShortEndTime;
			}
			set
			{
				ShortEndTime = value;
			}
		}

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
