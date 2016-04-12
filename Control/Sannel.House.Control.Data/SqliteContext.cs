/*
   Copyright 2016 Adam Holt

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using Microsoft.Data.Entity;
using Sannel.House.Control.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data
{
	public class SqliteContext : DbContext
	{
		public DbSet<WeatherCondition> WeatherConditions { get; set; }
		public DbSet<WeatherAstronomy> WeatherAstronomies { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=Control.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var temp = modelBuilder.Entity<WeatherCondition>();
				temp.Property(i => i.Id)
				.IsRequired();
			modelBuilder.Entity<WeatherAstronomy>().Property(i => i.Id).IsRequired();
		}
	}
}
