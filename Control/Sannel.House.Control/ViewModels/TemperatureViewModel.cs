using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Control.Data;
using Sannel.House.Control.Business;
using Sannel.House.Control.Data.Models;

namespace Sannel.House.Control.ViewModels
{
	public class TemperatureViewModel : SubViewModel
	{
		private BME280 bme = new BME280();
		private bool busFound = false;
		private TimerViewModel timer;

		public TemperatureViewModel(TimerViewModel timer)
		{
			this.timer = timer;
			
		}

		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			if (BME280.IsSupported)
			{
				if (!bme.IsSetup)
				{
					busFound = await bme.SetupAsync();
				}
				if (busFound)
				{
					timer.Tick += Tick;
					timer.HalfHourTick += HalfHourTick;
				}
			}
			if (!busFound)
			{
				Temperature = -9999;
				Humidity = -9999;
				Altitude = -9999;
			}
		}

		public void Tick()
		{
			if (busFound)
			{
				var tempC = bme.ReadTemperatureCelsius();
				Temperature = BME280.ConvertToFahrenheit(tempC);
				var alt = bme.ReadPressure();
				Altitude = BME280.PressureAsAltitudeFeet(alt);
				var hum = bme.ReadHumidity();
				Humidity = BME280.HumidityToRH(hum);
			}
		}

		public async void HalfHourTick()
		{
			using (var context = new SqliteContext())
			{
				var temp = new Temperature();
				temp.StoredDeviceId = AppSettings.Current.DeviceId;
				temp.Value = bme.ReadTemperatureCelsius();
				context.Temperatures.Add(temp);
				await context.SaveChangesAsync();
			}
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
