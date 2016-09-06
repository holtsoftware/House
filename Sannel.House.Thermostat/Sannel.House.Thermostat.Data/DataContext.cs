using Microsoft.EntityFrameworkCore;
using Sannel.House.Thermostat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Thermostat.Models;

namespace Sannel.House.Thermostat.Data
{
	public class DataContext : DbContext, IDataContext
	{
		public DbSet<TemperatureEntry> TemperatureEntries
		{
			get;
			set;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlite("Filename=Thermostat.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
