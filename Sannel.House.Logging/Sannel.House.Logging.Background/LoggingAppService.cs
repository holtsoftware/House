using Microsoft.EntityFrameworkCore;
using Sannel.House.Logging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;

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

		private void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
			
		}

		private void TaskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
		{
			deferral?.Complete();
			deferral = null;
		}
	}
}
