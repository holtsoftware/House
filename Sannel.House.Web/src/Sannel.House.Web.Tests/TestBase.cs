using NUnit.Framework;
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
		[TearDown]
		public void CleanUp()
		{
			using(IDataContext context = new MockDataContext())
			{
				foreach(var d in context.Devices)
				{
					context.Devices.Remove(d);
				}

				context.SaveChanges();
			}
		}
	}
}
