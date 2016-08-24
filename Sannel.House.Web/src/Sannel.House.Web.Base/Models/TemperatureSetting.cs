using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
#if CLIENT
		: System.ComponentModel.INotifyPropertyChanged
#endif
	{
		private long id;
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
		public long Id
		{
			get
			{
				return id;
			}
			set
			{
				Set(ref id, value);
			}
		}

		private DayOfWeek? dayOfWeek;
		/// <summary>
		/// Gets or sets the day of week.
		/// </summary>
		/// <value>
		/// The day of week.
		/// </value>
		[JsonProperty(nameof(DayOfWeek))]
		public DayOfWeek? DayOfWeek
		{
			get
			{
				return dayOfWeek;
			}
			set
			{
				Set(ref dayOfWeek, value);
			}
		}

		private int? month;

		[JsonProperty(nameof(Month))]
		public int? Month
		{
			get
			{
				return month;
			}
			set
			{
				Set(ref month, value);
			}
		}

		private bool isTimeOnly;
		/// <summary>
		/// Gets or sets the IsTimeOnly
		/// </summary>
		/// <value>
		/// The IsTimeOnly
		/// </value>
		[JsonProperty(nameof(IsTimeOnly))]
		public bool IsTimeOnly
		{
			get
			{
				return isTimeOnly;
			}
			set
			{
				Set(ref isTimeOnly, value);
			}
		}


		private DateTime? startTime;
		/// <summary>
		/// Gets or sets the Start
		/// </summary>
		/// <value>
		/// The Start
		/// </value>
		[JsonProperty(nameof(StartTime))]
		public DateTime? StartTime
		{
			get
			{
				return startTime;
			}
			set
			{
				Set(ref startTime, value);
			}
		}

		private DateTime? endTime;
		/// <summary>
		/// Gets or sets the End
		/// </summary>
		/// <value>
		/// The End
		/// </value>
		[JsonProperty(nameof(EndTime))]
		public DateTime? EndTime
		{
			get
			{
				return endTime;
			}
			set
			{
				Set(ref endTime, value);
			}
		}


		private double heatTemperatureC;
		/// <summary>
		/// Gets or sets the HeatTemperatureC
		/// </summary>
		/// <value>
		/// The HeatTemperatureC
		/// </value>
		[JsonProperty(nameof(HeatTemperatureC))]
		public double HeatTemperatureC
		{
			get
			{
				return heatTemperatureC;
			}
			set
			{
				if (value > 29.5)
				{
					Set(ref heatTemperatureC, 29.5);
				}
				else
				{
					Set(ref heatTemperatureC, value);
				}
				if(coolTemperatureC < heatTemperatureC + 2.22222222)
				{
					coolTemperatureC = heatTemperatureC + 2.22222222;
					NotifyPropertyChanged(nameof(CoolTemperatureC));
				}
			}
		}


		private double coolTemperatureC;
		/// <summary>
		/// Gets or sets the CoolTemperatureC
		/// </summary>
		/// <value>
		/// The CoolTemperatureC
		/// </value>
		[JsonProperty(nameof(CoolTemperatureC))]
		public double CoolTemperatureC
		{
			get
			{
				return coolTemperatureC;
			}
			set
			{
				if (value < 15.5555556)
				{
					Set(ref coolTemperatureC, 15.5555556);
				}
				else
				{
					Set(ref coolTemperatureC, value);
				}
				if(heatTemperatureC > coolTemperatureC - 2.22222222)
				{
					heatTemperatureC = coolTemperatureC - 2.22222222;
					NotifyPropertyChanged(nameof(HeatTemperatureC));
				}
			}
		}

		private DateTime dateCreated;
		/// <summary>
		/// Gets or sets the DateCreated
		/// </summary>
		/// <value>
		/// The DateCreated
		/// </value>
		[JsonProperty(nameof(DateCreated))]
		public DateTime DateCreated
		{
			get
			{
				return dateCreated;
			}
			set
			{
				Set(ref dateCreated, value);
			}
		}


		private DateTime dateModified;
		/// <summary>
		/// Gets or sets the DateModified
		/// </summary>
		/// <value>
		/// The DateModified
		/// </value>
		[JsonProperty(nameof(DateModified))]
		public DateTime DateModified
		{
			get
			{
				return dateModified;
			}
			set
			{
				Set(ref dateModified, value);
			}
		}

#if CLIENT

		public event PropertyChangedEventHandler PropertyChanged;
		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
		{

			if (!Object.Equals(dest, source))
			{
				dest = source;
				NotifyPropertyChanged(propName);
			}
		}
		public void NotifyPropertyChanged([CallerMemberName]String memberName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}
#else
		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
		{

			if (!Object.Equals(dest, source))
			{
				dest = source;
			}
		}
		protected void NotifyPropertyChanged([CallerMemberName]String memberName = null)
		{
		}
#endif
	}
}
