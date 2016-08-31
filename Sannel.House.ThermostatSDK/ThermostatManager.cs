using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace Sannel.House.ThermostatSDK
{
	public class ThermostatManager : IDisposable
	{
		private AppServiceConnection connection;
		private bool isConnected;

		public ThermostatManager()
		{
			connection = new AppServiceConnection();
			connection.AppServiceName = "Sannel.House.Thermostat";
			connection.ServiceClosed += connectionClosed;
		}

		private void connectionClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
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
			if(result == AppServiceConnectionStatus.Success)
			{
				isConnected = true;
				return true;
			}
			isConnected = false;
			return false;
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
			valueSet["ServerUri"] = serverUri;
			valueSet["Username"] = username;
			valueSet["Password"] = password;

			var result = await connection.SendMessageAsync(valueSet);
			if(result.Status == AppServiceResponseStatus.Success)
			{
				if(String.Compare(result.Message["result"] as String, "success", true) == 0)
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

		public void Dispose()
		{
			connection?.Dispose();
		}
	}
}
