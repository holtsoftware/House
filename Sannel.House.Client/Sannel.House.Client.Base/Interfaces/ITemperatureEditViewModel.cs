using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Sannel.House.Client.Interfaces
{
	public interface ITemperatureEditViewModel : IBaseViewModel
	{
		/// <summary>
		/// Gets the start times.
		/// </summary>
		/// <value>
		/// The start times.
		/// </value>
		ObservableCollection<DateTime> StartTimes
		{
			get;
		}

		/// <summary>
		/// Gets the end times.
		/// </summary>
		/// <value>
		/// The end times.
		/// </value>
		ObservableCollection<DateTime> EndTimes
		{
			get;
		}

		/// <summary>
		/// Sets the current day settings used to removed used starttimes and determan the last end times.
		/// </summary>
		/// <value>
		/// The current day settings.
		/// </value>
		ICollection<TemperatureSetting> CurrentDaySettings
		{
			set;
		}

		/// <summary>
		/// Gets or sets the temperature setting.
		/// </summary>
		/// <value>
		/// The temperature setting.
		/// </value>
		TemperatureSetting TemperatureSetting
		{
			get;
			set;
		}

		/// <summary>
		/// Saves the temperature setting asynchronous.
		/// </summary>
		/// <returns></returns>
		Task SaveTemperatureSettingAsync();
	}
}
