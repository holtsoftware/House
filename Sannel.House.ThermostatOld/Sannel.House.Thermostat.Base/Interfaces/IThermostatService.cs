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

		/// <summary>
		/// Gets the temperature c.
		/// </summary>
		/// <value>
		/// The temperature c.
		/// </value>
		double TemperatureC
		{
			get;
		}


		/// <summary>
		/// Gets the cool on temperature c.
		/// </summary>
		/// <value>
		/// The cool on temperature c.
		/// </value>
		double CoolOnTemperatureC
		{
			get;
		}


		/// <summary>
		/// Gets the heat on temperature c.
		/// </summary>
		/// <value>
		/// The heat on temperature c.
		/// </value>
		double HeatOnTemperatureC
		{
			get;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the fan should be on.
		/// </summary>
		/// <value>
		///   <c>true</c> if [fan on]; otherwise, <c>false</c>.
		/// </value>
		bool FanOn
		{
			get;
			set;
		}
	}
}
