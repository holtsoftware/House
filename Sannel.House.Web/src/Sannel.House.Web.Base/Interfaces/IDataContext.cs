#if !THERMOSTAT
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sannel.House.Web.Base.Models;
#else
using Sannel.House.Thermostat.Base.Models;
#endif
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#if THERMOSTAT
namespace Sannel.House.Thermostat.Base.Interfaces
#else
namespace Sannel.House.Web.Base.Interfaces
#endif
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

#if !THERMOSTAT
		DbSet<ApplicationUser> Users { get; set; }

		DbSet<IdentityRole> Roles { get; set; }
#endif

		int SaveChanges();

		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
	}
}
