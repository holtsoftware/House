using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Control.Data;
using Sannel.House.Control.Business;
using Sannel.House.Control.Data.Models;
using Caliburn.Micro;
using Sannel.House.Control.Data.Messages;
using Windows.UI.Xaml;
using Windows.UI.Core;

namespace Sannel.House.Control.ViewModels
{
	public class TemperatureViewModel : SubViewModel, IHandle<TickMessage>, IHandle<HalfHourTickMessage>
	{
		private BME280 bme = new BME280();
		private bool busFound = false;
		private IEventAggregator aggregator;

		public TemperatureViewModel(IEventAggregator agg)
		{
			//this.timer = timer;
			aggregator = agg;
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
					//timer.Tick += Tick;
					//timer.HalfHourTick += HalfHourTick;
					aggregator.Subscribe(this);
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

		public async void Handle(TickMessage message)
		{
			if (busFound)
			{
				float tempC = 0, alt = 0, hum = 0;
				await Task.Run(() =>
				{
					tempC = bme.ReadTemperatureCelsius();
					alt = bme.ReadPressure();
					hum = bme.ReadHumidity();
				});

				Altitude = BME280.PressureAsAltitudeFeet(alt);
				Temperature = BME280.ConvertToFahrenheit(tempC);
				Humidity = BME280.HumidityToRH(hum);
			}
		}

		public void Handle(HalfHourTickMessage message)
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
