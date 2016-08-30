using Sannel.House.Thermostat.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	public interface ISyncService
	{
		/// <summary>
		/// Occurs when [log message].
		/// </summary>
		event EventHandler<LogEventArgs> LogMessage;

		/// <summary>
		/// Logges into all services this sync service requres
		/// </summary>
		/// <returns></returns>
		Task<bool> LoginAsync();

		/// <summary>
		/// Synchronizes the devices asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<bool> SyncDevicesAsync();
	}
}
