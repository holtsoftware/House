using Microsoft.Data.Entity;
using Sannel.House.Control.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data
{
	public class Context : DbContext
	{
		public DbSet<Temperature> TemperatureLog { get; set; }
		public DbSet<CurrentWeather> CurrentWeather { get; set; }

		public DbSet<HourlyWeather> HourlyWeather { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=Control.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var temp = modelBuilder.Entity<Temperature>();
				temp.Property(i => i.Id)
				.IsRequired();
			temp.Property(i => i.Value).IsRequired();

			modelBuilder.Entity<HourlyWeather>().Ignore(i => i.FriendlyHour);
		}
	}
}
