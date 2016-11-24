using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Sannel.House.Web.Tests
{
	public class TestDbContext : IDisposable
	{
		public IDataContext DataContext
		{
			get;
			private set;
		}
		public TestDbContext()
		{
			DataContext = new MockDataContext();
		}
		public void Dispose()
		{
			var type = DataContext.GetType();
			foreach(var prop in type.GetRuntimeProperties())
			{
				if (prop.PropertyType.Name.StartsWith("DbSet"))
				{
					// Lets cheat and use dynamic to reference the RemoveRange method.
					dynamic d = prop.GetValue(DataContext);
					d.RemoveRange(d);	
				}
			}
			DataContext.SaveChanges();
			DataContext?.Dispose();
		}
	}
}
