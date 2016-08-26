using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sannel.House.Logging.Interface;
using Sannel.House.Logging.Models;
using System.Threading;

namespace Sannel.House.Logging.Tests.Mocks
{
	public class DbContextMock : DbContext, IDbContext
	{
		public DbSet<ApplicationLogEntry> ApplicationLogEntries
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
