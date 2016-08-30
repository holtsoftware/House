using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;
using Sannel.House.Thermostat.Base.Messages;
using Sannel.House.Thermostat.Base;

namespace Sannel.House.Thermostat.ViewModels
{
	public class HomeViewModel : BaseViewModel, IHandle<Timer10SecondsMessage>
	{
		private readonly IThermostatService service;

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="service">The service.</param>
		/// <param name="container">The container.</param>
		/// <param name="nav">The nav.</param>
		/// <param name="eventAggregator">The event aggregator.</param>
		public HomeViewModel(IThermostatService service, WinRTContainer container, INavigationService nav, IEventAggregator eventAggregator) : base(container, nav, eventAggregator)
		{
			this.service = service;
		}

		private bool sensorMissing;
		/// <summary>
		/// Gets or sets a value indicating whether the sensor is missing
		/// </summary>
		/// <value>
		///   <c>true</c> if sensor is missing; otherwise, <c>false</c>.
		/// </value>
		public bool SensorMissing
		{
			get
			{
				return sensorMissing;
			}
			set
			{
				Set(ref sensorMissing, value);
			}
		}

		private String currentTemperaturec;
		/// <summary>
		/// Gets or sets the current tempreature.
		/// </summary>
		/// <value>
		/// The current tempreature.
		/// </value>
		public String CurrentTemperatureC
		{
			get
			{
				return currentTemperaturec;
			}
			set
			{
				Set(ref currentTemperaturec, value);
			}
		}

		private String currentTemperatureF;
		/// <summary>
		/// Gets or sets the current temperature f.
		/// </summary>
		/// <value>
		/// The current temperature f.
		/// </value>
		public String CurrentTemperatureF
		{
			get
			{
				return currentTemperatureF;
			}
			set
			{
				Set(ref currentTemperatureF, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [fan on].
		/// </summary>
		/// <value>
		///   <c>true</c> if [fan on]; otherwise, <c>false</c>.
		/// </value>
		public bool FanOn
		{
			get
			{
				return service.FanOn;
			}
			set
			{
				service.FanOn = value;
				NotifyOfPropertyChange(nameof(FanOn));
			}
		}


		private String heatOnTemp;
		/// <summary>
		/// Gets or sets the HeatOnTemp
		/// </summary>
		/// <value>
		/// The HeatOnTemp
		/// </value>
		public String HeatOnTemp
		{
			get
			{
				return heatOnTemp;
			}
			set
			{
				Set(ref heatOnTemp, value);
			}
		}


		private String coolOnTemp;
		/// <summary>
		/// Gets or sets the CoolOnTemp
		/// </summary>
		/// <value>
		/// The CoolOnTemp
		/// </value>
		public String CoolOnTemp
		{
			get
			{
				return coolOnTemp;
			}
			set
			{
				Set(ref coolOnTemp, value);
			}
		}
		

		/// <summary>
		/// Handles the message.
		/// </summary>
		/// <param name="message">The message.</param>
		public void Handle(Timer10SecondsMessage message)
		{
			if (service.HasDevices)
			{
				SensorMissing = false;
				CurrentTemperatureC = service.TemperatureC.ToString("0.0");
				CurrentTemperatureF = service.TemperatureC.CelsiusToFahrenheit().ToString("0.0");
				HeatOnTemp = service.HeatOnTemperatureC.CelsiusToFahrenheit().ToString("0.0");
				CoolOnTemp = service.CoolOnTemperatureC.CelsiusToFahrenheit().ToString("0.0");
			}
			else
			{
				SensorMissing = true;
			}
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			eventAggregator.Subscribe(this);
		}

		protected override void OnDeactivate(bool close)
		{
			base.OnDeactivate(close);
			eventAggregator.Unsubscribe(this);
		}
	}
}
