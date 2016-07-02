using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sannel.House.Web.Base.Models;

namespace Sannel.House.Web.Mocks
{
	public class MockDataContext : DbContext, IDataContext
	{
		/// <summary>
		/// Gets or sets the devices.
		/// </summary>
		/// <value>
		/// The devices.
		/// </value>
		public DbSet<Device> Devices
		{
			get; set;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseInMemoryDatabase();
		}
	}
}
