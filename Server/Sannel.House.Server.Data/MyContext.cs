using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Data
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class MyContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<StoredDevice> StoredDevices { get; set; }

		public MyContext() : base("MyContext", throwIfV1Schema: false)
		{
			Database.SetInitializer(new MySqlInitializer());
		}

		public static MyContext Create()
		{
			return new MyContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
