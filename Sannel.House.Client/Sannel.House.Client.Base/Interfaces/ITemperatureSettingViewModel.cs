using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sannel.House.Client.Interfaces
{
	public interface ITemperatureSettingViewModel : IErrorViewModel
	{
		/// <summary>
		/// Gets the sunday default.
		/// </summary>
		/// <value>
		/// The sunday default.
		/// </value>
		TemperatureSetting SundayDefault
		{
			get;
		}

		/// <summary>
		/// Gets the monday default.
		/// </summary>
		/// <value>
		/// The monday default.
		/// </value>
		TemperatureSetting MondayDefault
		{
			get;
		}

		/// <summary>
		/// Gets the tuesday default.
		/// </summary>
		/// <value>
		/// The tuesday default.
		/// </value>
		TemperatureSetting TuesdayDefault
		{
			get;
		}

		/// <summary>
		/// Gets the wensday default.
		/// </summary>
		/// <value>
		/// The wensday default.
		/// </value>
		TemperatureSetting WednesdayDefault
		{
			get;
		}

		/// <summary>
		/// Gets the thursday default.
		/// </summary>
		/// <value>
		/// The thursday default.
		/// </value>
		TemperatureSetting ThursdayDefault
		{
			get;
		}

		/// <summary>
		/// Gets the friday default.
		/// </summary>
		/// <value>
		/// The friday default.
		/// </value>
		TemperatureSetting FridayDefault
		{
			get;
		}

		/// <summary>
		/// Gets the saturday default.
		/// </summary>
		/// <value>
		/// The saturday default.
		/// </value>
		TemperatureSetting SaturdayDefault
		{
			get;
		}

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		void Refresh();

		/// <summary>
		/// Gets the update default command.
		/// </summary>
		/// <value>
		/// The update default command.
		/// </value>
		ICommand UpdateDefaultCommand { get; }

		/// <summary>
		/// Saves the temperature setting asynchronous.
		/// </summary>
		/// <param name="temperature">The temperature.</param>
		/// <returns></returns>
		Task SaveTemperatureSettingAsync(TemperatureSetting temperature);

		/// <summary>
		/// Deletes the tempeerature setting asynchronous.
		/// </summary>
		/// <param name="temperature">The temperature.</param>
		/// <returns></returns>
		Task DeleteTemperatureSettingAsync(TemperatureSetting temperature);

		/// <summary>
		/// Creates the new temperature setting.
		/// </summary>
		/// <returns></returns>
		TemperatureSetting CreateNewTemperatureSetting();

		/// <summary>
		/// Gets the settings that start on a spacific day and time and end on that same day.
		/// </summary>
		/// <value>
		/// The day settings.
		/// </value>
		ObservableCollection<TemperatureSetting> DaySettings
		{
			get;
		}
	}
}
