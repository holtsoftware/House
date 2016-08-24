using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Client.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sannel.House.Client.ViewModels
{
	public class TemperatureEditViewModel : BaseViewModel, ITemperatureEditViewModel
	{
		public TemperatureEditViewModel(INavigationService navigationService) : base(navigationService)
		{
		}

		private ICollection<TemperatureSetting> currentDaySettings;
		/// <summary>
		/// Sets the current day settings used to removed used starttimes and determan the last end times.
		/// </summary>
		/// <value>
		/// The current day settings.
		/// </value>
		public ICollection<TemperatureSetting> CurrentDaySettings
		{
			private get
			{
				return currentDaySettings;
			}
			set
			{
				Set(ref currentDaySettings, value);
				updateStartTime();
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
			}
		}

		private void temperatureSetting_PropertyChange(object sender, PropertyChangedEventArgs e)
		{
		}

		private void updateStartTime()
		{
			var cds = CurrentDaySettings;
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
		public async Task SaveTemperatureSettingAsync()
		{
			await Task.Delay(1);
		}
	}
}
