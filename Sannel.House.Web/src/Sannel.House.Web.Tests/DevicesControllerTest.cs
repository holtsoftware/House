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
		public void PostTest()
		{
			Device d = new Device();
			d.Id = 500;
			d.Name = "Test1";
			d.Description = "This is my test Description.";
			d.DateCreated = DateTime.MinValue;
			d.DisplayOrder = 50;

			using(IDataContext context = new MockDataContext())
			{
				var controller = new DevicesController(context);
				controller.Post(d);
				Assert.AreEqual(1, context.Devices.Count(), "Device was not added to the database.");

				var actual = context.Devices.FirstOrDefault();
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

				controller.Post(d2);
				actual = context.Devices.Skip(1).FirstOrDefault();
				Assert.AreNotEqual(501, actual.Id, "Device id not generated");
				Assert.AreNotEqual(1, actual.Id, "Device id not generated");
				Assert.AreNotEqual(DateTime.MinValue, actual.DateCreated, "Date Created was not generated");
				Assert.AreEqual(d2.Name, actual.Name, "Name is not the same");
				Assert.AreEqual(d2.Description, actual.Description, "Description is not the same");
				Assert.AreEqual(2, actual.DisplayOrder, "Display Order was not computed correctly");
			}
		}
	}
}
