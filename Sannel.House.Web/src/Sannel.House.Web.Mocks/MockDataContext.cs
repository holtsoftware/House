using Microsoft.EntityFrameworkCore;
using Sannel.House.Web.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sannel.House.Web.Base.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

		public DbSet<IdentityRole> Roles
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public DbSet<ApplicationUser> Users
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseInMemoryDatabase();
		}
	}
}
