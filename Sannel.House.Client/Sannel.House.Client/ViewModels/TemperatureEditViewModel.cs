using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Client.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Sannel.House.Client.ViewModels
{
	public class TemperatureEditViewModel : BaseViewModel, ITemperatureEditViewModel
	{
		public TemperatureEditViewModel(INavigationService navigationService) : base(navigationService)
		{
		}

		private ITemperatureSettingViewModel temperatureSettingViewModel;
		/// <summary>
		/// Gets or sets the TemperatureSettingViewModel.
		/// </summary>
		/// <value>
		/// The TemperatureSettingViewModel
		/// </value>
		public ITemperatureSettingViewModel TemperatureSettingViewModel
		{
			get
			{
				return temperatureSettingViewModel;
			}
			set
			{
				Set(ref temperatureSettingViewModel, value);
			}
		}

		/// <summary>
		/// Gets the end times.
		/// </summary>
		/// <value>
		/// The end times.
		/// </value>
		public ObservableCollection<DateTime> EndTimes
		{
			get;
		} = new ObservableCollection<DateTime>();

		/// <summary>
		/// Gets the start times.
		/// </summary>
		/// <value>
		/// The start times.
		/// </value>
		public ObservableCollection<DateTime> StartTimes
		{
			get;
		} = new ObservableCollection<DateTime>();


		private TemperatureSetting temperatureSetting;
		/// <summary>
		/// Gets or sets the TemperatureSetting.
		/// </summary>
		/// <value>
		/// The TemperatureSetting
		/// </value>
		public TemperatureSetting TemperatureSetting
		{
			get
			{
				return temperatureSetting;
			}
			set
			{
				if(temperatureSetting != null)
				{
					temperatureSetting.PropertyChanged -= temperatureSetting_PropertyChange;
				}
				Set(ref temperatureSetting, value);
				temperatureSetting.PropertyChanged += temperatureSetting_PropertyChange;
				updateStartTime();
			}
		}


		private void temperatureSetting_PropertyChange(object sender, PropertyChangedEventArgs e)
		{
			if(String.Compare(e.PropertyName, nameof(TemperatureSetting.StartTime)) == 0)
			{
				calculateEndItems();
			}
		}

		private void calculateEndItems()
		{
			var cds = TemperatureSettingViewModel.DaySettings;
			var ts = TemperatureSetting;
			if (cds != null && ts?.StartTime.HasValue == true)
			{
				var end = new DateTime(1, 1, 2, 0, 0, 0);
				var others = cds.Where(i => i.DayOfWeek == TemperatureSetting.DayOfWeek && i != TemperatureSetting).ToList();
				EndTimes.Clear();

				for (DateTime dt = TemperatureSetting.StartTime.Value.AddMinutes(30); dt <= end; dt = dt.AddMinutes(30))
				{
					EndTimes.Add(dt);
					if (others.FirstOrDefault(i => dt >= i.StartTime && dt < i.EndTime) != null)
					{
						break; // stop after first item that would conflict
					}
				}
			}
			else
			{
				EndTimes.Clear();
			}
		}

		private void updateStartTime()
		{
			var cds = TemperatureSettingViewModel.DaySettings;
			var ts = TemperatureSetting;
			if(cds != null && ts != null)
			{
				StartTimes.Clear();
				var others = cds.Where(i => i.DayOfWeek == ts.DayOfWeek && i != TemperatureSetting).ToList();
				var end = new DateTime(1, 1, 2, 0, 0, 0);

				for (DateTime dt = new DateTime(1, 1, 1, 0, 0, 0); dt < end; dt = dt.AddMinutes(30))
				{
					if (others.FirstOrDefault(i => dt >= i.StartTime && dt < i.EndTime) == null)
					{
						StartTimes.Add(dt);
					}
				}

				TemperatureSetting.NotifyPropertyChanged(nameof(TemperatureSetting.StartTime));
			}

		}

		/// <summary>
		/// Navigateds to.
		/// </summary>
		/// <param name="arg">The argument.</param>
		public override void NavigatedTo(object arg)
		{
			base.NavigatedTo(arg);
			if(arg is TemperatureSetting)
			{
				TemperatureSetting = (TemperatureSetting)arg;
			}
		}

		/// <summary>
		/// Saves the temperature setting asynchronous.
		/// </summary>
		/// <returns></returns>
		private async void saveTemperatureSetting()
		{
			await TemperatureSettingViewModel.SaveTemperatureSettingAsync(TemperatureSetting);
		}

		private RelayCommand saveTemperatureSettingCommand;
		
		public ICommand SaveTemperatureSettingCommand
		{
			get
			{
				return saveTemperatureSettingCommand ?? (saveTemperatureSettingCommand = new RelayCommand(saveTemperatureSetting));
			}
		}
	}
}
