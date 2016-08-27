using Microsoft.EntityFrameworkCore;
using Sannel.House.Logging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace Sannel.House.Logging.Background
{
	public sealed class LoggingAppService : IBackgroundTask
	{
		private BackgroundTaskDeferral deferral;

		public void Run(IBackgroundTaskInstance taskInstance)
		{
			taskInstance.Canceled += TaskInstance_Canceled;
			deferral = taskInstance.GetDeferral();

			using (LoggingContext context = new LoggingContext())
			{
				context.Database.Migrate();
			}

			var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
			var connection = details.AppServiceConnection;

			//Listen for incoming app service requests
			connection.RequestReceived += Connection_RequestReceived;
		}

		private async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
			var lDeferral = args.GetDeferral();
			try
			{
				var message = args.Request.Message;
				if(message.ContainsKey("MessageType") && message.ContainsKey("Message"))
				{
					var type = message["MessageType"] as String;
					var mes = message["Message"] as String;
					if(type != null && mes != null)
					{
						using(var lh = new LoggingHelper())
						{
							var result = lh.LogEntry(type, mes);
							var vs = new ValueSet();
							vs["result"] = result;
							await args.Request.SendResponseAsync(vs);
						}
					}
				}
			}
			catch { }
			lDeferral.Complete();	
		}

		private void TaskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
		{
			deferral?.Complete();
			deferral = null;
		}
	}
}
