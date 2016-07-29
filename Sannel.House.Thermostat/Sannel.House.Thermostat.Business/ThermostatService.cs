using Sannel.House.Thermostat.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Business
{
	public class ThermostatService : IThermostatService
	{
		private ITempreatureHumidityPressureSensor temperature;
		private IRelay heat;
		private IRelay cool;
		private IRelay fan;

		public ThermostatService()
		{
			temperature = new BME280Sensor();
			heat = new BeefcakeRelay(17);
			cool = new BeefcakeRelay(18);
			fan = new BeefcakeRelay(22);
		}

		/// <summary>
		/// Gets a value indicating whether the server is able to connect to the devices it needs.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has devices; otherwise, <c>false</c>.
		/// </value>
		public bool HasDevices
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes the Thermostat Service asynchronous.
		/// </summary>
		/// <returns>false means on the devices failed to initialize</returns>
		public async Task<bool> InitializeAsync()
		{
			if(!await temperature.InitializeAsync())
			{
				HasDevices = false;
				return false;
			}
			if(!await heat.InitializeAsync())
			{
				temperature.Dispose();
				HasDevices = false;
				return false;
			}
			if(!await cool.InitializeAsync())
			{
				temperature.Dispose();
				heat.Dispose();
				HasDevices = false;
				return false;
			}
			if(!await fan.InitializeAsync())
			{
				temperature.Dispose();
				heat.Dispose();
				cool.Dispose();
				HasDevices = false;
				return false;
			}

			return true;
		}
	}
}
