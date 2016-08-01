using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Thermostat.Base.Messages;

namespace Sannel.House.Thermostat.Business
{
	public class ThermostatService : IThermostatService, IHandle<Timer10SecondsMessage>
	{
		private const double MIN_AC_ON = 29.4;
		private const double MIN_HEAT_ON = 15.6;
		private const double MIN_DIFFERENCE = 4;
		private ITempreatureHumidityPressureSensor temperature;
		private IRelay heat;
		private IRelay cool;
		private IRelay fan;

		private double activateCoolTemp = MIN_AC_ON;
		private double activateHeatTemp = MIN_HEAT_ON;

		public ThermostatService(IEventAggregator eventAggregator)
		{
			eventAggregator.Subscribe(this);
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
		/// Gets the temperature c.
		/// </summary>
		/// <value>
		/// The temperature c.
		/// </value>
		public double TemperatureC
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the fan should be on.
		/// </summary>
		/// <value>
		/// <c>true</c> if [fan on]; otherwise, <c>false</c>.
		/// </value>
		public bool FanOn
		{
			get;
			set;
		}


		/// <summary>
		/// Gets the cool on temperature c.
		/// </summary>
		/// <value>
		/// The cool on temperature c.
		/// </value>
		public double CoolOnTemperatureC
		{
			get;
			private set;
		}


		/// <summary>
		/// Gets the heat on temperature c.
		/// </summary>
		/// <value>
		/// The heat on temperature c.
		/// </value>
		public double HeatOnTemperatureC
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

			HasDevices = true;

			return true;
		}

		private void determanTemps()
		{

		}

		private void setCurrentState()
		{
			if (FanOn && !fan.IsOn)
			{
				fan.TurnOn();
			}
			else if(!FanOn && fan.IsOn)
			{
				fan.TurnOff();
			}
		}

		/// <summary>
		/// Handles the message.
		/// </summary>
		/// <param name="message">The message.</param>
		public async void Handle(Timer10SecondsMessage message)
		{
			if (temperature.IsInitalized)
			{
				var value = await temperature.GetTemperatureCelsiusAsync();
				TemperatureC = value;
				setCurrentState();
				CoolOnTemperatureC = activateCoolTemp;
				HeatOnTemperatureC = activateHeatTemp;
			}
		}
	}
}
