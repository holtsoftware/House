using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace Sannel.House.ThermostatSDK
{
	public class ThermostatManager : IDisposable
	{
		private AppServiceConnection connection;
		private bool isConnected;
		private SemaphoreSlim semaphoreSlim;

		public ThermostatManager()
		{
			semaphoreSlim = new SemaphoreSlim(1);
			setupConnection();
		}

		private void setupConnection()
		{
			connection = new AppServiceConnection();
			connection.AppServiceName = "Sannel.House.Thermostat";
			connection.ServiceClosed += connectionClosed;
		}

		private void connectionClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
		{
			semaphoreSlim.Wait();
			isConnected = false;
			connection?.Dispose();
			setupConnection();
			semaphoreSlim.Release();
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
			await semaphoreSlim.WaitAsync();
			try
			{
				if (isConnected)
				{
					return true;
				}
				if (String.IsNullOrWhiteSpace(connection.PackageFamilyName))
				{
					var asp = await Windows.ApplicationModel.AppService.AppServiceCatalog.FindAppServiceProvidersAsync(connection.AppServiceName);
					var first = asp.FirstOrDefault(i => i.PackageFamilyName.StartsWith("Sannel.House"));
					if (first != null)
					{
						connection.PackageFamilyName = first.PackageFamilyName;
					}
					else
					{
						connection.PackageFamilyName = "Unknown";
					}
				}
				var result = await connection.OpenAsync();
				if (result == AppServiceConnectionStatus.Success)
				{
					isConnected = true;
					return true;
				}
				isConnected = false;
				return false;
			}
			finally
			{
				semaphoreSlim.Release();
			}
		}

		/// <summary>
		/// Sets the configuration asynchronous.
		/// </summary>
		/// <param name="serverUri">The server URI.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// </exception>
		public async Task<bool> SetConfigurationAsync(Uri serverUri, String username, String password)
		{
			if(serverUri == null)
			{
				throw new ArgumentNullException(nameof(serverUri));
			}

			if(username == null)
			{
				throw new ArgumentNullException(nameof(username));
			}

			if(password == null)
			{
				throw new ArgumentNullException(nameof(password));
			}

			var valueSet = new ValueSet();
			valueSet["Action"] = "SetConfiguration";
			valueSet["ServerUri"] = serverUri?.ToString();
			valueSet["Username"] = username;
			valueSet["Password"] = password;

			var result = await connection.SendMessageAsync(valueSet);
			if(result.Status == AppServiceResponseStatus.Success)
			{
				var status = result.Message.GetValue<bool?>("Status");
				if(status == true)
				{
					return true;
				}
				return false;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Gets the configuration asynchronous.
		/// Retreaves the url and the Username from the AppService
		/// </summary>
		/// <returns></returns>
		public async Task<Tuple<Uri, String>> GetConfigurationAsync()
		{
			var request = new ValueSet();
			request["Action"] = "GetConfiguration";

			var result = await connection.SendMessageAsync(request);
			if(result.Status == AppServiceResponseStatus.Success)
			{
				var message = result.Message;
				Uri i = null;
				Uri.TryCreate(message.GetValue<String>("ServerUri"), UriKind.Absolute, out i);
				return new Tuple<Uri, string>(i, message.GetValue<String>("Username"));
			}

			return new Tuple<Uri, string>(null, null);
		}

		public void Dispose()
		{
			connection?.Dispose();
		}
	}
}
