using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	public interface IThermostatService
	{
		/// <summary>
		/// Gets a value indicating whether the server is able to connect to the devices it needs.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has devices; otherwise, <c>false</c>.
		/// </value>
		bool HasDevices
		{
			get;
		}

		/// <summary>
		/// Initializes the Thermostat Service asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<bool> InitializeAsync();
	}
}
