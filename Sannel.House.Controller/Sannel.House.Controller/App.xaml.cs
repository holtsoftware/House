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
limitations under the License.*/
using Caliburn.Micro;
using Sannel.House.Controller.Attributes;
using Sannel.House.Controller.Business;
using Sannel.House.Controller.Interfaces;
using Sannel.House.Controller.Views;
using Sannel.House.LoggingSDK;
using Sannel.House.ThermostatSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Sannel.House.Controller
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	[Bindable]
	sealed partial class App : CaliburnApplication
	{
		public static bool HasBooted = false;
		private WinRTContainer container;
		private static LoggingManager logginManager;
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

		protected override async void Configure()
		{
			container = new WinRTContainer();
			container.RegisterWinRTServices();
			container.Singleton<LoggingManager>();
			container.Singleton<IAppSettings, ApplicationSettings>();
			container.Singleton<TimerService>();
			container.Singleton<ThermostatManager>();

			var types = GetType().GetTypeInfo().Assembly.GetTypes()
				.Where(t => t.Namespace == "Sannel.House.Controller.ViewModels");
			foreach (var type in types)
			{
				var typeInfo = type.GetTypeInfo();
				if (!typeInfo.IsAbstract)
				{
					var sa = typeInfo.GetCustomAttribute<SingletonAttribute>();
					if(sa != null)
					{
						container.RegisterSingleton(type, type.FullName, type);
					}
					else
					{
						container.RegisterPerRequest(type, type.FullName, type);
					}
				}
			}
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override async void OnLaunched(LaunchActivatedEventArgs e)
		{
#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
			{
				this.DebugSettings.EnableFrameRateCounter = true;
			}
#endif
			DisplayRootView<ShellView>();

			var lm = container.GetInstance<LoggingManager>();
			container.GetInstance<TimerService>();
			await lm.ConnectAsync();
			await lm.LogMessageAsync("Controller Launched.");
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
