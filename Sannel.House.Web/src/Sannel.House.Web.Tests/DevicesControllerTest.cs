using NUnit.Framework;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Controllers;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests
{
	[TestFixture]
	public class DevicesControllerTest : TestBase
	{
		[Test]
		public async Task PostTest()
		{
			Device d = new Device();
			d.Id = 500;
			d.Name = "Test1";
			d.Description = "This is my test Description.";
			d.DateCreated = DateTime.MinValue;
			d.DisplayOrder = 50;

			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new DevicesController(context))
				{
					var result = await controller.Post(d);
					Assert.IsTrue(result > 0, "Id needs to be greater then 0");
					Assert.AreEqual(1, context.Devices.Count(), "Device was not added to the database.");

					var actual = context.Devices.FirstOrDefault(i => i.Id == result);
					Assert.AreNotEqual(500, actual.Id, "Device id not generated");
					Assert.AreNotEqual(DateTime.MinValue, actual.DateCreated, "Date Created was not generated");
					Assert.AreEqual(d.Name, actual.Name, "Name is not the same");
					Assert.AreEqual(d.Description, actual.Description, "Description is not the same");
					Assert.AreEqual(1, actual.DisplayOrder, "Display Order was not computed correctly");

					var d2 = new Device();
					d2.Id = 501;
					d2.Name = "Test2";
					d2.Description = "This is my test Description 2";
					d2.DateCreated = DateTime.MinValue;
					d2.DisplayOrder = 1000;

					result = await controller.Post(d2);
					Assert.IsTrue(result > 0, "Id needs to be greater then 0");
					actual = context.Devices.FirstOrDefault(i => i.Id == result);
					Assert.AreNotEqual(501, actual.Id, "Device id not generated");
					Assert.AreNotEqual(1, actual.Id, "Device id not generated");
					Assert.AreNotEqual(DateTime.MinValue, actual.DateCreated, "Date Created was not generated");
					Assert.AreEqual(d2.Name, actual.Name, "Name is not the same");
					Assert.AreEqual(d2.Description, actual.Description, "Description is not the same");
					Assert.AreEqual(2, actual.DisplayOrder, "Display Order was not computed correctly");
				}
			}
		}

		[Test]
		public async Task PutTest()
		{
			var device = new Device()
			{
				Name = "Device 1",
				Description = "Device Description",
				DisplayOrder = 1,
				DateCreated = DateTime.Now,
			};

			var device2 = new Device()
			{
				Name = "Device 2",
				Description = "Device Description",
				DisplayOrder = 2,
				DateCreated = DateTime.Now
			};
			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new DevicesController(context))
				{
					context.Devices.Add(device);
					context.Devices.Add(device2);
					await context.SaveChangesAsync();

					var newDevice = new Device()
					{
						Id = device.Id,
						Name = "Test Device 1",
						Description = "Test Description 1",
						DisplayOrder = 3,
						DateCreated = DateTime.Now.AddDays(-200)
					};
					await controller.Put(newDevice);

					var actual = context.Devices.FirstOrDefault(i => i.Id == device.Id);
					Assert.AreEqual(newDevice.Name, actual.Name, "Name was not updated");
					Assert.AreEqual(newDevice.Description, actual.Description, "Description was not updated");
					Assert.AreEqual(newDevice.DisplayOrder, actual.DisplayOrder, "Display Order was not updated");
					Assert.AreEqual(device.DateCreated, actual.DateCreated, "DateCreated was updated and should not have been");

					newDevice = new Device()
					{
						Id = device2.Id,
						Name = "Test Device2",
						Description = "Test Description 2",
						DisplayOrder = 1,
						DateCreated = DateTime.Now.AddDays(-201)
					};
					await controller.Put(newDevice);
					actual = context.Devices.FirstOrDefault(i => i.Id == device2.Id);
					Assert.AreEqual(newDevice.Name, actual.Name, "Name was not updated");
					Assert.AreEqual(newDevice.Description, actual.Description, "Description was not updated.");
					Assert.AreEqual(newDevice.DisplayOrder, actual.DisplayOrder, "Display Order was not updated.");
					Assert.AreEqual(device2.DateCreated, actual.DateCreated, "DateCreated was updated and should not have been");

					newDevice = new Device()
					{
						Id = 500,
						Name = "Failed Update",
						Description = "Failed Update"
					};
					Assert.ThrowsAsync<KeyNotFoundException>(async () => await controller.Put(newDevice));
				}
			}
		}

		[Test]
		public async Task GetTest()
		{
			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new DevicesController(context))
				{
					var device1 = new Device()
					{
						Name = "device1",
						Description = "Desc 1",
						DisplayOrder = 2,
						DateCreated = DateTime.Now
					};
					var device2 = new Device()
					{
						Name = "device2",
						Description = "Desc 2",
						DisplayOrder = 1,
						DateCreated = DateTime.Now
					};
					context.Devices.Add(device1);
					context.Devices.Add(device2);
					await context.SaveChangesAsync();

					var items = controller.Get().ToList();
					Assert.AreEqual(2, items.Count, "Count is off");
					var actual = items[0];
					Assert.IsNotNull(actual);
					Assert.AreEqual(device2.Name, actual.Name, "Name does not match");
					Assert.AreEqual(device2.Description, actual.Description, "Description does not match");
					Assert.AreEqual(device2.DisplayOrder, actual.DisplayOrder, "DisplayOrder does not match");
					Assert.AreEqual(device2.DateCreated, actual.DateCreated, "DateCreated does not match");
					actual = items[1];
					Assert.IsNotNull(actual);
					Assert.AreEqual(device1.Name, actual.Name, "Name does not match");
					Assert.AreEqual(device1.Description, actual.Description, "Description does not match");
					Assert.AreEqual(device1.DisplayOrder, actual.DisplayOrder, "DisplayOrder does not match");
					Assert.AreEqual(device1.DateCreated, actual.DateCreated, "DateCreated does not match");
				}
			}
		}

		[Test]
		public async Task GetByIdTest()
		{
			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new DevicesController(context))
				{
					var device1 = new Device()
					{
						Name = "Device 1",
						Description = "Desc 1",
						DisplayOrder = 1,
						DateCreated = DateTime.Now
					};
					var device2 = new Device()
					{
						Name = "Device 2",
						Description = "Desc 2",
						DisplayOrder = 2,
						DateCreated = DateTime.Now
					};
					context.Devices.Add(device1);
					context.Devices.Add(device2);
					await context.SaveChangesAsync();

					var actual = controller.Get(device1.Id);
					Assert.IsNotNull(actual);
					Assert.AreEqual(device1.Name, actual.Name, "Name does not match");
					Assert.AreEqual(device1.Description, actual.Description, "Description does not match");
					Assert.AreEqual(device1.DisplayOrder, actual.DisplayOrder, "Display Order does not match");
					Assert.AreEqual(device1.DateCreated, actual.DateCreated, "DateCreated does not match");

					actual = controller.Get(device2.Id);
					Assert.IsNotNull(actual);
					Assert.AreEqual(device2.Name, actual.Name, "Name does not match");
					Assert.AreEqual(device2.Description, actual.Description, "Description does not match");
					Assert.AreEqual(device2.DisplayOrder, actual.DisplayOrder, "Display Order does not match");
					Assert.AreEqual(device2.DateCreated, actual.DateCreated, "DateCreated does not match");
				}
			}
		}

		[Test]
		public async Task DeleteTest()
		{
			using (IDataContext context = new MockDataContext())
			{
				using (var controller = new DevicesController(context))
				{
					var device1 = new Device()
					{
						Name = "Device 1",
						Description = "Desc 1",
						DisplayOrder = 1,
						DateCreated = DateTime.Now
					};
					var device2 = new Device()
					{
						Name = "Device 2",
						Description = "Desc 2",
						DisplayOrder = 2,
						DateCreated = DateTime.Now
					};
					context.Devices.Add(device1);
					context.Devices.Add(device2);
					await context.SaveChangesAsync();

					await controller.Delete(device1.Id);
					Assert.AreEqual(1, context.Devices.Count(), "Item was not deleted");
					var actual = context.Devices.FirstOrDefault();
					Assert.AreEqual(device2.Name, actual.Name, "Appears the wrong device was deleted");

					Assert.ThrowsAsync<KeyNotFoundException>(async () => await controller.Delete(500));
				}
			}
		}
	}
}
