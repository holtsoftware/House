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
	public class TemperatureEditViewModel : ErrorViewModel, ITemperatureEditViewModel
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
		} = new ObservableCollection<DateTime>()
		{
			new DateTime(1,1,1,0,0,0)
		};


		private int startTimeIndex;
		/// <summary>
		/// Gets or sets the StartTimeIndex.
		/// </summary>
		/// <value>
		/// The StartTimeIndex
		/// </value>
		public int StartTimeIndex
		{
			get
			{
				return startTimeIndex;
			}
			set
			{
				Set(ref startTimeIndex, value);
				if(TemperatureSetting != null)
				{
					if (StartTimeIndex > -1)
					{
						TemperatureSetting.StartTime = StartTimes[StartTimeIndex];
					}
					else
					{
						TemperatureSetting.StartTime = null;
					}
				}
			}
		}


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
				if (TemperatureSetting.StartTime.HasValue)
				{
					var i = StartTimes.IndexOf(TemperatureSetting.StartTime.Value);
					if (StartTimeIndex != i)
					{
						StartTimeIndex = i;
					}
				}
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
						if(dt == TemperatureSetting?.StartTime)
						{
							StartTimeIndex = StartTimes.Count - 1;
						}
					}
				}
			}
		}

		private void verifyTemperatureSetting()
		{
			ErrorKeys.Clear();
			if(TemperatureSetting.StartTime == null)
			{
				ErrorKeys.Add("StartTimeIsRequired");
			}
			if(TemperatureSetting.EndTime == null)
			{
				ErrorKeys.Add("EndTimeIsRequired");
			}
		}

		/// <summary>
		/// Saves the temperature setting asynchronous.
		/// </summary>
		/// <returns></returns>
		private async Task saveTemperatureSetting(object obj)
		{
			verifyTemperatureSetting();
			if (HasErrors)
			{
				return;
			}
			else
			{
				await TemperatureSettingViewModel.SaveTemperatureSettingAsync(TemperatureSetting);
			}
		}

		private AsyncRelayCommand saveTemperatureSettingCommand;
		
		public AsyncRelayCommand SaveTemperatureSettingCommand
		{
			get
			{
				return saveTemperatureSettingCommand ?? (saveTemperatureSettingCommand = new AsyncRelayCommand(saveTemperatureSetting));
			}
		}
	}
}
