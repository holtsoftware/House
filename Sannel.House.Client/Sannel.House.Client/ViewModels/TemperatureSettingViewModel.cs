﻿using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Client;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Sannel.House.Client.ViewModels
{
	public class TemperatureSettingViewModel : ErrorViewModel, ITemperatureSettingViewModel
	{
		private IServerContext server;
		private TemperatureSetting defaultTemperatureSetting;

		public TemperatureSettingViewModel(IServerContext server, INavigationService navigationService) : base(navigationService)
		{
			this.server = server;
		}


		private int defaultCool =80;
		/// <summary>
		/// Gets or sets the DefaultCool.
		/// </summary>
		/// <value>
		/// The DefaultCool
		/// </value>
		public int DefaultCool
		{
			get
			{
				return defaultCool;
			}
			set
			{
				Set(ref defaultCool, value);
				if (defaultHeat >= defaultCool - 4)
				{
					defaultHeat = defaultCool - 4;
					NotifyPropertyChanged(nameof(DefaultHeat));
				}
			}
		}


		private int defaultHeat = 65;


		/// <summary>
		/// Gets or sets the DefaultHeat.
		/// </summary>
		/// <value>
		/// The DefaultHeat
		/// </value>
		public int DefaultHeat
		{
			get
			{
				return defaultHeat;
			}
			set
			{
				Set(ref defaultHeat, value);
				if(defaultCool <= defaultHeat + 4)
				{
					defaultCool = DefaultHeat + 4;
					NotifyPropertyChanged(nameof(DefaultCool));
				}
			}
		}

		private async void updateDefaultCommandAction()
		{
			IsBusy = true;
			defaultTemperatureSetting.CoolTemperatureC = ((double)DefaultCool).FahrenheitToCelsius();
			defaultTemperatureSetting.HeatTemperatureC = ((double)DefaultHeat).FahrenheitToCelsius();
			await server.PutTemperatureSettingsAsync(defaultTemperatureSetting);
			IsBusy = false;
			Refresh();
		}

		private RelayCommand updateDefaultCommand;

		/// <summary>
		/// Gets the update default command.
		/// </summary>
		/// <value>
		/// The update default command.
		/// </value>
		public ICommand UpdateDefaultCommand
		{
			get
			{
				return updateDefaultCommand ?? (updateDefaultCommand = new RelayCommand(updateDefaultCommandAction));
			}
		}


		private TemperatureSetting sundayDefault;
		/// <summary>
		/// Gets or sets the SundayDefault.
		/// </summary>
		/// <value>
		/// The SundayDefault
		/// </value>
		public TemperatureSetting SundayDefault
		{
			get
			{
				return sundayDefault;
			}
			set
			{
				Set(ref sundayDefault, value);
			}
		}


		private TemperatureSetting mondayDefault;
		/// <summary>
		/// Gets or sets the MondayDefault.
		/// </summary>
		/// <value>
		/// The MondayDefault
		/// </value>
		public TemperatureSetting MondayDefault
		{
			get
			{
				return mondayDefault;
			}
			set
			{
				Set(ref mondayDefault, value);
			}
		}


		private TemperatureSetting tuesdayDefault;
		/// <summary>
		/// Gets or sets the TuesdayDefault.
		/// </summary>
		/// <value>
		/// The TuesdayDefault
		/// </value>
		public TemperatureSetting TuesdayDefault
		{
			get
			{
				return tuesdayDefault;
			}
			set
			{
				Set(ref tuesdayDefault, value);
			}
		}


		private TemperatureSetting wensdayDefault;
		/// <summary>
		/// Gets or sets the WensdayDefault.
		/// </summary>
		/// <value>
		/// The WensdayDefault
		/// </value>
		public TemperatureSetting WensdayDefault
		{
			get
			{
				return wensdayDefault;
			}
			set
			{
				Set(ref wensdayDefault, value);
			}
		}


		private TemperatureSetting thursdayDefault;
		/// <summary>
		/// Gets or sets the ThursdayDefault.
		/// </summary>
		/// <value>
		/// The ThursdayDefault
		/// </value>
		public TemperatureSetting ThursdayDefault
		{
			get
			{
				return thursdayDefault;
			}
			set
			{
				Set(ref thursdayDefault, value);
			}
		}


		private TemperatureSetting fridayDefault;
		/// <summary>
		/// Gets or sets the FridayDefault.
		/// </summary>
		/// <value>
		/// The FridayDefault
		/// </value>
		public TemperatureSetting FridayDefault
		{
			get
			{
				return fridayDefault;
			}
			set
			{
				Set(ref fridayDefault, value);
			}
		}


		private TemperatureSetting saturdayDefault;
		/// <summary>
		/// Gets or sets the SaturdayDefault.
		/// </summary>
		/// <value>
		/// The SaturdayDefault
		/// </value>
		public TemperatureSetting SaturdayDefault
		{
			get
			{
				return saturdayDefault;
			}
			set
			{
				Set(ref saturdayDefault, value);
			}
		}

		public async void Refresh()
		{
			IsBusy = true;
			var temperatureSettings = await server.GetTemperatureSettingsAsync();
			defaultTemperatureSetting = temperatureSettings.First(i => i.DayOfWeek == null
											&& i.Month == null
											&& i.Start == null
											&& i.End == null);
			temperatureSettings.Remove(defaultTemperatureSetting);
			DefaultCool = (int)defaultTemperatureSetting.CoolTemperatureC.CelsiusToFahrenheit();
			DefaultHeat = (int)defaultTemperatureSetting.HeatTemperatureC.CelsiusToFahrenheit();
			IsBusy = false;
		}

		public override void NavigatedTo(object arg)
		{
			Refresh();
		}
	}
}
