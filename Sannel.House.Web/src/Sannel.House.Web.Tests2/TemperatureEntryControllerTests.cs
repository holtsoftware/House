using NUnit.Framework;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Controllers.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests
{
	[TestFixture]
	public class TemperatureEntryControllerTests : TestBase
	{
		[TestCase]
		public void PostTest()
		{
			using(IDataContext context = new Mocks.MockDataContext())
			{
				var controller = new TemperatureEntryController(context);

				var device = new Device();
				device.Name = "TEst";
				context.Devices.Add(device);
				context.SaveChanges();

				var te = new TemperatureEntry();
				te.DeviceId = device.Id;
				te.CreatedDateTime = DateTime.MinValue;
				te.Humidity = 20;
				te.Pressure = 22;
				te.TemperatureCelsius = 0;
				te.Id = Guid.Empty;
				controller.Post(te);

				Assert.AreEqual(1, context.TemperatureEntries.Count());
				var first = context.TemperatureEntries.FirstOrDefault();
				Assert.IsNotNull(first);
				Assert.AreNotEqual(Guid.Empty, first.Id);
				Assert.AreEqual(te.DeviceId, first.DeviceId);
				Assert.AreEqual(te.CreatedDateTime, first.CreatedDateTime);
				Assert.AreEqual(te.Humidity, first.Humidity);
				Assert.AreEqual(te.Pressure, first.Pressure);
				Assert.AreEqual(te.TemperatureCelsius, first.TemperatureCelsius);

				var te2 = new TemperatureEntry();
				te2.DeviceId = device.Id;
				te2.CreatedDateTime = DateTime.Now;
				te2.Humidity = 22;
				te2.Pressure = 321;
				te2.TemperatureCelsius = 32;
				te2.Id = Guid.NewGuid();
				controller.Post(te2);

				Assert.AreEqual(2, context.TemperatureEntries.Count());
				var second = context.TemperatureEntries.Skip(1).FirstOrDefault();
				Assert.IsNotNull(second);
				Assert.AreNotEqual(first.Id, second.Id);
				Assert.AreEqual(te2.Id, second.Id);
				Assert.AreEqual(te2.DeviceId, second.DeviceId);
				Assert.AreEqual(te2.CreatedDateTime, second.CreatedDateTime);
				Assert.AreEqual(te2.Humidity, second.Humidity);
				Assert.AreEqual(te2.Pressure, second.Pressure);
				Assert.AreEqual(te2.TemperatureCelsius, second.TemperatureCelsius);
				
			}
		}
	}
}
