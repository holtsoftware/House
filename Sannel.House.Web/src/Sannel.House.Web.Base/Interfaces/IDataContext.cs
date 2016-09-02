using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sannel.House.Web.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Interfaces
{
	public interface IDataContext : IDisposable
	{
		/// <summary>
		/// Gets or sets the devices.
		/// </summary>
		/// <value>
		/// The devices.
		/// </value>
		DbSet<Device> Devices { get; set; }


		/// <summary>
		/// Gets or sets the temperature settings.
		/// </summary>
		/// <value>
		/// The temperature settings.
		/// </value>
		DbSet<TemperatureSetting> TemperatureSettings { get; set; }

		DbSet<ApplicationUser> Users { get; set; }

		DbSet<IdentityRole> Roles { get; set; }

		DbSet<TemperatureEntry> TemperatureEntries { get; set; }

		int SaveChanges();

		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
	}
}
