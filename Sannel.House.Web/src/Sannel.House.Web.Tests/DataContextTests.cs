using NUnit.Framework;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests
{
	[TestFixture]
	public class DataContextTests
	{
		/// <summary>
		/// Used to verify our mock database is setup correctly for testing.
		/// </summary>
		[Test]
		public void CountTest()
		{
			using (IDataContext context = new MockDataContext())
			{
				context.Devices.Add(new Device
				{
					Id = 1,
					Name = "Test1",
					Description = "Test 1 Description"
				});
				context.SaveChanges();
				Assert.AreEqual(1, context.Devices.Count());
			}
		}
	}
}
