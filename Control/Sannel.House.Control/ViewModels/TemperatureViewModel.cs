using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Control.Data;

namespace Sannel.House.Control.ViewModels
{
	public class TemperatureViewModel : SubViewModel
	{
		private BME280 bme = new BME280();
		public TemperatureViewModel(TimerViewModel timer)
		{
			timer.Tick += Tick;
			timer.HalfHourTick += HalfHourTick;
		}

		public async void Tick()
		{
			if (!bme.IsSetup)
			{
				await bme.SetupAsync();
			}

			var tempC = bme.ReadTemperatureCelsius();
			Temperature = BME280.ConvertToFahrenheit(tempC);
			var alt = bme.ReadPressure();
			Altitude = BME280.PressureAsAltitudeFeet(alt);
			var hum = bme.ReadHumidity();
			Humidity = BME280.HumidityToRH(hum);
		}

		public void HalfHourTick()
		{

		}

		private float temperature;

		public float Temperature
		{
			get { return temperature; }
			set { Set(ref temperature, value); }
		}

		private float humidity;

		public float Humidity
		{
			get { return humidity; }
			set { Set(ref humidity, value); }
		}

		private float altitude;

		public float Altitude
		{
			get { return altitude; }
			set { Set(ref altitude, value); }
		}


	}
}
