﻿/*
   Copyright 2016 Adam Holt

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using Caliburn.Micro;
using Sannel.House.Control.Data;
using Sannel.House.Control.Data.Messages;
using System;
using System.Runtime.CompilerServices;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using Windows.UI.Xaml;

namespace Sannel.House.Control.ViewModels
{
	public class MainViewModel : Conductor<ViewModelBase>.Collection.OneActive, IHandle<TickMessage>
	{
		private WinRTContainer container;
		public MainViewModel(WinRTContainer container, IEventAggregator agg)
		{
			this.container = container;
			HomeViewModel = container.GetInstance<HomeViewModel>();
			SettingsViewModel = container.GetInstance<SettingsViewModel>();
		}
		
		private HomeViewModel homeViewModel;
		public HomeViewModel HomeViewModel
		{
			get
			{
				return homeViewModel;
			}
			set
			{
				Set(ref homeViewModel, value);
			}
		}
		private SettingsViewModel settingsViewModel;
		public SettingsViewModel SettingsViewModel
		{
			get
			{
				return settingsViewModel;
			}
			set
			{
				Set(ref settingsViewModel, value);
			}
		}

		private float temprature;
		public float Temprature
		{
			get { return temprature; }
			set { Set(ref temprature, value); }
		}

		private String time;
		public String Time
		{
			get { return time; }
			set { Set(ref time, value); }
		}

		private String date;
		public String Date
		{
			get { return date; }
			set { Set(ref date, value); }
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			updateTime();
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			HomeAction();
		}

		private void updateTime()
		{
			var dt = DateTime.Now;
			Date = $"{dt:d}";
			Time = $"{dt:h:mm tt}";
		}

		public void SettingsAction()
		{
			ActivateItem(container.GetInstance<SettingsViewModel>());
		}

		public void HomeAction()
		{
			ActivateItem(container.GetInstance<HomeViewModel>());
		}

		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
		{
			if (!Object.Equals(dest, source))
			{
				dest = source;
				NotifyOfPropertyChange(propName);
			}
		}

		public async void Handle(TickMessage message)
		{
			await Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, updateTime);
		}
	}
}
