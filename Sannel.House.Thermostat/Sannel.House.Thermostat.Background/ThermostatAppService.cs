using Sannel.House.Thermostat.Buisness;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace Sannel.House.Thermostat.Background
{
	public sealed class ThermostatAppService : IBackgroundTask
	{
		private BackgroundTaskDeferral deferral;
		private ServiceController controller;

		public void Run(IBackgroundTaskInstance taskInstance)
		{
			taskInstance.Canceled += canceled;
			deferral = taskInstance.GetDeferral();

			var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
			var connection = details.AppServiceConnection;

			controller = new ServiceController(AppSettings.Current);
			connection.RequestReceived += requestReceived;
		}

		private async void requestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
			var lDeferral = args.GetDeferral();
			try
			{
				var message = args.Request.Message;
				var action = message["Action"] as String;
				ValueSet response;
				switch (action)
				{
					case "SetConfiguration":
						Uri i;

						if (!Uri.TryCreate(message["ServerUri"] as String, UriKind.Absolute, out i))
						{
							response = new ValueSet();
							response["Status"] = false;
							response["Message"] = "Invalid Server Uri";
							await args.Request.SendResponseAsync(response);
						}
						else
						{
							var results = await controller.SetConfigurationAsync(i, message["Username"] as String, message["Password"] as String);
							response = new ValueSet();
							response["Status"] = results.Item1;
							response["Message"] = results.Item2;
							await args.Request.SendResponseAsync(response);
						}
						break;

					case "GetConfiguration":
						var result = await controller.GetConfigurationAsync();
						response = new ValueSet();
						response["Status"] = true;
						response["ServerUri"] = result.Item1?.ToString();
						response["Username"] = result.Item2;
						await args.Request.SendResponseAsync(response);
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
			controller = null;
		}
	}
}
