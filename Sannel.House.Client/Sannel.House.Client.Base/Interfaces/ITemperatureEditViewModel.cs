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
	public interface ITemperatureEditViewModel : IErrorViewModel, IBaseViewModel
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
		/// Gets or sets the start index of the time.
		/// </summary>
		/// <value>
		/// The start index of the time.
		/// </value>
		int StartTimeIndex
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the end index of the time.
		/// </summary>
		/// <value>
		/// The end index of the time.
		/// </value>
		int EndTimeIndex
		{
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is new.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
		/// </value>
		bool IsEdit
		{
			get;
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
		AsyncRelayCommand SaveTemperatureSettingCommand
		{
			get;
		}

		/// <summary>
		/// Gets the delete temperature setting command.
		/// </summary>
		/// <value>
		/// The delete temperature setting command.
		/// </value>
		AsyncRelayCommand DeleteTemperatureSettingCommand
		{
			get;
		}
	}
}
