using Newtonsoft.Json;
using Sannel.House.Logging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace Sannel.House.Logging.SDK
{
	public class LoggingManager : IDisposable
	{
		private AppServiceConnection connection;
		private bool isConnected;

		public LoggingManager()
		{
			connection = new AppServiceConnection();
			connection.AppServiceName = "Sannel.House.Logging";
			connection.PackageFamilyName = "Sannel.House.Logging.LocalTest_pjznk8rch33nj";
			connection.ServiceClosed += connectionServiceClosed;
		}

		private void connectionServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
		{
			isConnected = false;
		}

		public bool IsConnected
		{
			get
			{
				return isConnected;
			}
		}

		public async Task<bool> ConnectAsync()
		{
			if(await connection.OpenAsync() == AppServiceConnectionStatus.Success)
			{
				isConnected = true;
				return true;
			}
			isConnected = false;
			return false;
		}

		public async Task<bool> LogApplicationEntry(ApplicationLogEntry entry)
		{
			if(entry == null)
			{
				throw new ArgumentNullException(nameof(entry));
			}

			var vs = new ValueSet();
			vs["MessageType"] = nameof(ApplicationLogEntry);
			vs["Message"] = JsonConvert.SerializeObject(entry);
			var result = await connection.SendMessageAsync(vs);
			if(result.Status == AppServiceResponseStatus.Success)
			{
				bool? v = result.Message["result"] as bool?;
				if (v.HasValue)
				{
					return v.Value;
				}
			}

			return false;
		}

		public void Dispose()
		{
			connection.Dispose();
		}
	}
}
