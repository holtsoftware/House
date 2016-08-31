using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;

namespace Sannel.House.Thermostat.Background
{
	public sealed class ThermostatAppService : IBackgroundTask
	{
		private BackgroundTaskDeferral deferral;

		public void Run(IBackgroundTaskInstance taskInstance)
		{
			taskInstance.Canceled += canceled;
			deferral = taskInstance.GetDeferral();

			var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
			var connection = details.AppServiceConnection;

			connection.RequestReceived += requestReceived;
		}

		private void requestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
			var lDeferral = args.GetDeferral();
			try
			{
				var action = args.Request.Message["Action"] as String;
				switch (action)
				{
					case "SetConfiguration":
						break;
				}
			}
			finally
			{
				lDeferral.Complete();
			}
		}

		private void canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
		{
			deferral?.Complete();
		}
	}
}
