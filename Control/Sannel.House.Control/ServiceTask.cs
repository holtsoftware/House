using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;

namespace Sannel.House.Control
{
	public sealed class ServiceTask : IBackgroundTask
	{
		private AppServiceConnection appServiceConnection;

		public void Run(IBackgroundTaskInstance taskInstance)
		{
			var deferal = taskInstance.GetDeferral();
			var appService = taskInstance.TriggerDetails as AppServiceTriggerDetails;
			if (appService != null &&
				appService.Name == "App2AppComService")
			{
				appServiceConnection = appService.AppServiceConnection;
				appServiceConnection.RequestReceived += onRequestReceived;
			}
		}

		private void onRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
		{
		}
	}
}
