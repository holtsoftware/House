using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Thermostat.Interfaces;
using Sannel.House.Thermostat.Buisness;

namespace Sannel.House.Thermostat.Tests
{
	[TestClass]
	public class ThermostatControllerTest
	{
		[TestMethod]
		public void ProcessSensorsTest()
		{
			double temp = 20;
			double humd = 22.1;
			double pressure = 52.2;
			int deviceId = 23;
			using(var context = new MockContext())
			{
				var sensor = new StubITemperatureSensor();
				sensor.GetTemperatureCelsius(() => temp);
				sensor.GetHumidity(() => humd);
				sensor.GetPressure(() => pressure);

				var appSetting = new StubIAppSettings();
				appSetting.DeviceId_Get(() => deviceId);
				IAppSettings aSett = appSetting;

				var controller = new ThermostatController(context, sensor, appSetting);
				DateTimeOffset before = DateTimeOffset.Now;
				controller.ProcessSensors();
				DateTimeOffset after = DateTimeOffset.Now;

				Assert.AreEqual(1, context.TemperatureEntries.Count());

				var first = context.TemperatureEntries.FirstOrDefault();
				Assert.AreNotEqual(Guid.Empty, first.Id);
				Assert.AreEqual(temp, first.TemperatureCelsius);
				Assert.AreEqual(humd, first.Humidity);
				Assert.AreEqual(pressure, first.Pressure);
				Assert.AreEqual(aSett.DeviceId, first.DeviceId);
				Assert.AreEqual(false, first.Synced);
				Assert.IsTrue(first.CreatedDateTime >= before && first.CreatedDateTime <= after);

			}
		}
	}
}
