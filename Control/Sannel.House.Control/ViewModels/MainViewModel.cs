/*
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
using Sannel.House.Control.Http;
using System;
using System.Runtime.CompilerServices;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

namespace Sannel.House.Control.ViewModels
{
	public class MainViewModel : Conductor<ViewModelBase>.Collection.OneActive
	{
		private WinRTContainer container;
		private HttpServer server;
		public MainViewModel(WinRTContainer container, TimerViewModel tvm, HttpServer server)
		{
			this.container = container;
			this.server = server;
			tvm.Tick += Tick;
			HomeViewModel = container.GetInstance<HomeViewModel>();
			SettingsViewModel = container.GetInstance<SettingsViewModel>();
		}

		private async void Tick()
		{
			updateTime();
			// Get a selector string for bus "I2C1"
			//string aqs = I2cDevice.GetDeviceSelector("I2C1");

			//// Find the I2C bus controller with our selector string
			//var dis = await DeviceInformation.FindAllAsync(aqs);
			//if (dis.Count == 0)
			//	return; // bus not found

			//// 0x40 is the I2C device address
			//var settings = new I2cConnectionSettings(0x76);

			//byte[] bits = new byte[1];

			//int t1, t2, t3;

			//// Create an I2cDevice with our selected bus controller and I2C settings
			//using (I2cDevice device = await I2cDevice.FromIdAsync(dis[0].Id, settings))
			//{
			//	var result = device.WriteReadPartial(new byte[] { 0xFA }, bits);
			//	t1 = bits[0] << 12;
			//	result = device.WriteReadPartial(new byte[] { 0xFB }, bits);
			//	t1 |= bits[0] << 4;
			//	result = device.WriteReadPartial(new byte[] { 0xFC }, bits);
			//	t1 |= (bits[0] >> 4) & 0x0f;
			//}
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
			server.StartAsync().Wait();
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
	}
}
