using Sannel.House.Thermostat.Interfaces;
using Sannel.House.Thermostat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Buisness
{
	public class ThermostatController
	{
		private IDataContext context;
		private ITemperatureSensor sensor;
		private IAppSettings settings;
		private TemperatureEntry entry;

		public ThermostatController(IDataContext context, ITemperatureSensor sensor, IAppSettings settings)
		{
			this.context = context;
			this.sensor = sensor;
			this.settings = settings;
		}

		public void ProcessSensors()
		{
			var entry = new TemperatureEntry();
			entry.Id = Guid.NewGuid();
			entry.CreatedDateTime = DateTime.Now;
			entry.DeviceId = settings.DeviceId;
			entry.TemperatureCelsius = sensor.GetTemperatureCelsius();
			entry.Humidity = sensor.GetHumidity();
			entry.Pressure = sensor.GetPressure();
			entry.Synced = false;
			context.TemperatureEntries.Add(entry);
			context.SaveChanges();
			this.entry = entry;
		}

		public Task PushEntriesAsync()
		{
			return null;
		}
	}
}
