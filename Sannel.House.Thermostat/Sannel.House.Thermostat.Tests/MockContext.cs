using Microsoft.EntityFrameworkCore;
using Sannel.House.Thermostat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Thermostat.Models;

namespace Sannel.House.Thermostat.Tests
{
	public class MockContext : DbContext, IDataContext
	{
		public DbSet<TemperatureEntry> TemperatureEntries
		{
			get;
			set;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseInMemoryDatabase();
		}
	}
}
