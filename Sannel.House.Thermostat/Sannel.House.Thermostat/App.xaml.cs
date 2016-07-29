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
using Microsoft.EntityFrameworkCore;
using Sannel.House.Thermostat.Base.Interfaces;
using Sannel.House.Thermostat.Business;
using Sannel.House.Thermostat.Data;
using Sannel.House.Thermostat.ViewModels;
using Sannel.House.Thermostat.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Sannel.House.Thermostat
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	[Bindable]
	sealed partial class App : CaliburnApplication
	{
		public static bool HasBooted = false;
		private WinRTContainer container;
		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
#if CODE_ANALYSIS
			//Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
			//	Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
			//	Microsoft.ApplicationInsights.WindowsCollectors.Session);
#endif
			this.InitializeComponent();
			this.Suspending += OnSuspending;
			this.UnhandledException += App_UnhandledException;

			using(LocalDataContext context = new LocalDataContext())
			{
				context.Database.Migrate();
			}
		}

		private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
#if DEBUG
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
#endif
		}

		protected override void Configure()
		{
			container = new WinRTContainer();
			container.RegisterWinRTServices();

			var bme280 = new BME280Sensor();
			container.Instance<ITemperatureSensor>(bme280);
			container.Instance<IHumiditySensor>(bme280);
			container.Instance<IPressureSensor>(bme280);
			container.Instance<ITempreatureHumidityPressureSensor>(bme280);

			container.Singleton<IAppSettings, ApplicationSettings>();
			container.PerRequest<IDataContext, LocalDataContext>();
			container.Singleton<TimerService>();
			container.Singleton<IServerSource, ServerDataContext>();
			container.PerRequest<ISyncService, SyncService>();


			// ViewModels
			container.Singleton<ShellViewModel>();
			container.PerRequest<ConfigureViewModel>();
			container.PerRequest<BootViewModel>();
			container.PerRequest<HomeViewModel>();

			//container.Singleton<MainViewModel>();
			//container.Singleton<HomeViewModel>();
			//container.Singleton<SettingsViewModel>();
			//container.Singleton<WeatherViewModel>();
			//container.Singleton<SettingsDevicesViewModel>();
			//container.Singleton<SettingsWUndergroundViewModel>();
			//container.Singleton<TemperatureViewModel>();
			//container.Singleton<TimerService>();
			//container.Singleton<SyncService>();
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
			{
				this.DebugSettings.EnableFrameRateCounter = true;
			}
#endif
			DisplayRootView<ShellView>();

			container.GetInstance<TimerService>();
		}

		/// <summary>
		/// Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		protected override void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}

		protected override void PrepareViewFirst(Frame rootFrame)
		{
			container.RegisterNavigationService(rootFrame);
		}

		protected override object GetInstance(Type service, string key)
		{
			return container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			container.BuildUp(instance);
		}
	}
}
