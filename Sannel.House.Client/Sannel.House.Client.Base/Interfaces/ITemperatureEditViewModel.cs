using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
		/// Gets or sets the temperature setting view model.
		/// </summary>
		/// <value>
		/// The temperature setting view model.
		/// </value>
		ITemperatureSettingViewModel TemperatureSettingViewModel
		{
			get;
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
		/// Gets the save temperature setting command.
		/// </summary>
		/// <value>
		/// The save temperature setting command.
		/// </value>
		ICommand SaveTemperatureSettingCommand
		{
			get;
		}
	}
}
