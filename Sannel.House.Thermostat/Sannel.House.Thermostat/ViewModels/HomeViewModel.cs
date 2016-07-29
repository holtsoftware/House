using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;
using Sannel.House.Thermostat.Base.Messages;

namespace Sannel.House.Thermostat.ViewModels
{
	public class HomeViewModel : BaseViewModel, IHandle<Timer10SecondsMessage>
	{
		private readonly ITempreatureHumidityPressureSensor sensor;
		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="service">The service.</param>
		/// <param name="eventAggregator">The event aggregator.</param>
		public HomeViewModel(ITempreatureHumidityPressureSensor sensor, WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) : base(container, service, eventAggregator)
		{
			this.sensor = sensor;
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
		/// Handles the message.
		/// </summary>
		/// <param name="message">The message.</param>
		public async void Handle(Timer10SecondsMessage message)
		{
			if (!SensorMissing)
			{
				double temp = await sensor.GetTemperatureCelsiusAsync();
				CurrentTemperatureC = $"{temp:00.0}°";
				CurrentTemperatureF = $"{sensor.ConvertToFahrenheit(temp):00.0}°";
			}
		}

		protected override async void OnActivate()
		{
			base.OnActivate();
			SensorMissing = true;
			if (!sensor.IsInitalized)
			{
				if(await sensor.InitializeAsync())
				{
					SensorMissing = false;
				}
			}
		}
	}
}
