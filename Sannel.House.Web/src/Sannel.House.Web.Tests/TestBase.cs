using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests
{
	public abstract class TestBase
	{
		[TestCleanup]
		public void CleanUp()
		{
			using (IDataContext context = new MockDataContext())
			{
				context.Devices.RemoveRange(context.Devices);
				context.TemperatureSettings.RemoveRange(context.TemperatureSettings);
				context.TemperatureEntries.RemoveRange(context.TemperatureEntries);
				context.ApplicationLogEntries.RemoveRange(context.ApplicationLogEntries);

				context.SaveChanges();
			}
		}
	}
}
