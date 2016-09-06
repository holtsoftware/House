using Microsoft.EntityFrameworkCore;
using Sannel.House.Thermostat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Interfaces
{
	public interface IDataContext : IDisposable
	{
		DbSet<TemperatureEntry> TemperatureEntries { get; set; }

		int SaveChanges();

		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
	}
}
