using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Tests
{
	public class TestBase
	{
		[TestCleanup]
		public virtual void CleanUp()
		{
			using(var context = new MockContext())
			{
				context.TemperatureEntries.RemoveRange(context.TemperatureEntries);
				context.SaveChanges();
			}
		}
	}
}
