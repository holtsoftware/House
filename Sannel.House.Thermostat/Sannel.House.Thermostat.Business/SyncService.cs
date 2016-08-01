using Sannel.House.Thermostat.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Thermostat.Base.Models;

namespace Sannel.House.Thermostat.Business
{
	public class SyncService : ISyncService
	{
		public readonly IAppSettings settings;
		public readonly IServerSource server;
		public readonly IDataContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="SyncService"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <param name="context">The context.</param>
		public SyncService(IAppSettings settings, IServerSource server, IDataContext context)
		{
			this.settings = settings;
			this.server = server;
			this.context = context;
		}

		/// <summary>
		/// Adds the log item.
		/// </summary>
		/// <param name="message">The message.</param>
		private void addLogItem(String message)
		{
			LogMessage?.Invoke(this, new LogEventArgs
			{
				Message = message
			});
		}

		/// <summary>
		/// Occurs when they sync service logs a task.
		/// </summary>
		public event EventHandler<LogEventArgs> LogMessage;

		/// <summary>
		/// Logges into all services this sync service requires
		/// </summary>
		/// <returns></returns>
		public async Task<bool> LoginAsync()
		{
			addLogItem("Loggining into server");
			var result = await server.LoginAsync(settings.Username, settings.Password);
			if (result != Base.Enums.LoginStatus.Success)
			{
				addLogItem($"Unable to login to server. Error: {result}");
				return false;
			}
			addLogItem("Logged into server");

			return true;
		}

		/// <summary>
		/// Synchronizes the devices asynchronous.
		/// </summary>
		/// <returns></returns>
		public async Task<bool> SyncDevicesAsync()
		{
			var devices = await server.GetDevicesAsync();
			if(devices == null)
			{
				addLogItem("Unable to get devices from server");
			}
			else
			{
				if(devices.Count > 0)
				{
					addLogItem("Processing devices from server");
					foreach(var device in devices)
					{
						addLogItem($"Processing device {device.Id}");
						var localDevice = context.Devices.FirstOrDefault(i => i.Id == device.Id);
						if(localDevice != null)
						{
							addLogItem($"Updating device {device.Id} with data from server.");
							localDevice.Name = device.Name;
							localDevice.Description = device.Description;
							localDevice.DisplayOrder = device.DisplayOrder;
							localDevice.IsReadOnly = device.IsReadOnly;
							await context.SaveChangesAsync();
						}
						else
						{
							addLogItem($"Adding new device {device.Id} from server");
							context.Devices.Add(device);
							await context.SaveChangesAsync();
						}
					}

					await Task.Delay(2000);

					return true;
				}
				else
				{
					addLogItem("No devices returned from server");
				}
			}
			return false;
		}
	}
}
