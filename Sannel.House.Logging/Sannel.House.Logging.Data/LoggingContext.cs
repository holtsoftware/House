﻿using Microsoft.EntityFrameworkCore;
using Sannel.House.Logging.Interface;
using Sannel.House.Logging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Logging.Data
{
	public class LoggingContext : DbContext, IDbContext
	{
		public DbSet<ApplicationLogEntry> ApplicationLogEntries
		{
			get;
			set;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=Logging.db");
		}
	}
}
