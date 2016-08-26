using Microsoft.EntityFrameworkCore;
using Sannel.House.Logging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sannel.House.Logging.Interface
{
	public interface IDbContext : IDisposable
	{
		DbSet<ApplicationLogEntry> ApplicationLogEntries
		{
			get;
			set;
		}

		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
