using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Sannel.House.Thermostat.Buisness;
using Sannel.House;
using Sannel.House.Thermostat.Interfaces;
using Sannel.House.ServerSDK;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace Sannel.House.Thermostat
{
	public sealed class StartupTask : IBackgroundTask
	{
		private BackgroundTaskDeferral deferral;
		private DispatcherTimer timer;
		private ThermostatController controller;
		private SimpleContainer container;
		public void Run(IBackgroundTaskInstance taskInstance)
		{
			// 
			// TODO: Insert code to perform background work
			//
			// If you start any asynchronous methods here, prevent the task
			// from closing prematurely by using BackgroundTaskDeferral as
			// described in http://aka.ms/backgroundtaskdeferral
			//
			taskInstance.Canceled += canceled;
			deferral = taskInstance.GetDeferral();
			container = new SimpleContainer();
			container.Singleton<ThermostatController>();
			container.Singleton<IAppSettings, AppSettings>();
			container.Singleton<IServerContext, ServerContext>();

			controller = container.GetInstance<ThermostatController>();

			timer = new DispatcherTimer();
			timer.Tick += timerTick;
			timer.Interval = TimeSpan.FromSeconds(10);
			timer.Start();
		}

		private void canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
		{
			deferral.Complete();
			deferral = null;
			timer.Tick -= timerTick;
			timer = null;
			controller = null;
		}

		private async void timerTick(object sender, object e)
		{
		}
	}
}
