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
using Sannel.House.Control.Data;
using Sannel.House.Control.ViewModels;
using Sannel.House.Control.Views;
using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
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
using System.Diagnostics;
using Sannel.House.Control.Http;

namespace Sannel.House.Control
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : CaliburnApplication
	{
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
			using (SqliteContext context = new SqliteContext())
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
			container.RegisterInstance(typeof(HttpServer), null, new HttpServer(8000));
			container.Singleton<TimerViewModel>();
			container.Singleton<MainViewModel>();
			container.Singleton<HomeViewModel>();
			container.Singleton<SettingsViewModel>();
			container.Singleton<WeatherViewModel>();
			container.Singleton<SettingsDevicesViewModel>();
			container.Singleton<SettingsWUndergroundViewModel>();
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
			DisplayRootView<MainView>();
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
