using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Sannel.House.Web.Data
{
	public class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
	{
		/// <summary>
		/// Gets or sets the devices.
		/// </summary>
		/// <value>
		/// The devices.
		/// </value>
		public DbSet<Device> Devices
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the temperature defaults.
		/// </summary>
		/// <value>
		/// The temperature defaults.
		/// </value>
		public DbSet<TemperatureDefault> TemperatureDefaults
		{
			get;
			set;
		}

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			
		}
	}
}
