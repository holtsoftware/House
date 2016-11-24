using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.Web.Tests
{
	public class DataContextTests : IClassFixture<TestDbContext>
	{

		private TestDbContext testContext;

		public DataContextTests(TestDbContext context)
		{
			this.testContext = context;
		}

		/// <summary>
		/// Used to verify our mock database is setup correctly for testing.
		/// </summary>
		[Fact]
		public void CountTest()
		{
			var context = testContext.DataContext;
			context.Devices.Add(new Device
			{
				Id = 1,
				Name = "Test1",
				Description = "Test 1 Description"
			});
			context.SaveChanges();
			Assert.Equal(1, context.Devices.Count());
		}
	}
}
