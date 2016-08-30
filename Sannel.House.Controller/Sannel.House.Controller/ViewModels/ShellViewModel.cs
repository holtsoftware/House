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
using Caliburn.Micro;
using Sannel.House.Controller.Attributes;
using Sannel.House.Controller.Interfaces;
using Sannel.House.Controller.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Sannel.House.Controller.ViewModels
{
	[Singleton]
	public class ShellViewModel : Screen, IHandle<Timer10SecondsMessage>
	{
		private IAppSettings settings;
		private WinRTContainer container;
		private INavigationService navigationService;
		private IEventAggregator eventAggregator;

		public ShellViewModel(IAppSettings settings, WinRTContainer container, INavigationService service, IEventAggregator eventAggregator)
		{
			this.settings = settings;
			this.container = container;
			this.navigationService = service;
			this.eventAggregator = eventAggregator;
			Handle((Timer10SecondsMessage)null);
		}

		public void SetupNavigationService(Frame frame)
		{
			if (container.HasHandler(typeof(INavigationService), null))
			{
				container.UnregisterHandler(typeof(INavigationService), null);
			}

			navigationService = container.RegisterNavigationService(frame);

			navigationService.Navigated += NavigationService_Navigated;

			if (String.IsNullOrWhiteSpace(settings.Username) ||
				String.IsNullOrWhiteSpace(settings.Password) ||
				String.IsNullOrWhiteSpace(settings.ServerUrl))
			{
				CanHomeAction = false;
				CanSettingsAction = false;
				navigationService.For<SettingsViewModel>().WithParam(i => i.IsFirstRun, true).Navigate();
				//navigationService.For<ConfigureViewModel>().WithParam(i => i.IsFirstRun, true).Navigate();
			}
			else
			{
				//navigationService.For<BootViewModel>().Navigate();
			}
		}

		private void NavigationService_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
		{
			if(e.Uri != null)
			{

			}
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


		private bool canHomeAction;
		/// <summary>
		/// Gets or sets the CanHomeAction
		/// </summary>
		/// <value>
		/// The CanHomeAction
		/// </value>
		public bool CanHomeAction
		{
			get
			{
				return canHomeAction;
			}
			set
			{
				Set(ref canHomeAction, value);
			}
		}

		public void HomeAction()
		{
			if (App.HasBooted)
			{
				//navigationService.For<HomeViewModel>().Navigate();
			}
		}


		private bool canSettingsAction;
		/// <summary>
		/// Gets or sets the CanSettingsAction
		/// </summary>
		/// <value>
		/// The CanSettingsAction
		/// </value>
		public bool CanSettingsAction
		{
			get
			{
				return canSettingsAction;
			}
			set
			{
				Set(ref canSettingsAction, value);
			}
		}

		public void SettingsAction()
		{
			if (App.HasBooted)
			{
				//navigationService.For<ConfigureViewModel>().Navigate();
			}
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
