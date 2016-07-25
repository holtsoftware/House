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
limitations under the License.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;
using Sannel.House.Thermostat.Base.Interfaces;
using Sannel.House.Thermostat.Base.Messages;

namespace Sannel.House.Thermostat.ViewModels
{
	public class ShellViewModel : BaseViewModel, IHandle<Timer10SecondsMessage>
	{
		private readonly IAppSettings settings;
		private INavigationService navigationService;

		public ShellViewModel(IAppSettings settings,WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
			this.settings = settings;
			Handle((Timer10SecondsMessage)null);
		}

		public void SetupNavigationService(Frame frame)
		{
			if(container.HasHandler(typeof(INavigationService), null))
			{
				container.UnregisterHandler(typeof(INavigationService), null);
			}

			navigationService = container.RegisterNavigationService(frame);

			//if(String.IsNullOrWhiteSpace(settings.Username) ||
			//	String.IsNullOrWhiteSpace(settings.Password) ||
			//	String.IsNullOrWhiteSpace(settings.ServerUrl))
			//{
				navigationService.For<ConfigureViewModel>().WithParam(i => i.IsFirstRun, true).Navigate();
			//}
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			eventAggregator.Subscribe(this);
		}

		protected override void OnDeactivate(bool close)
		{
			base.OnDeactivate(close);
			eventAggregator.Unsubscribe(this);
		}

		public void Handle(Timer10SecondsMessage message)
		{
			var now = DateTime.Now;
			Time = now.ToString("t");
			Date = now.ToString("dd MMM yyyy");

		}

		private String time;
		public String Time
		{
			get
			{
				return time;
			}
			set
			{
				Set(ref time, value);
			}
		}

		private String date;
		public String Date
		{
			get
			{
				return date;
			}
			set
			{
				Set(ref date, value);
			}
		}
	}
}
