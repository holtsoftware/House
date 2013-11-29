using Microsoft.AspNet.Identity.EntityFramework;
using Sannel.House.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Data
{
	public class EntityContext : IdentityDbContext<ApplicationUser>, IDataContext
	{
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Circuit> Circuits { get; set; }
		public DbSet<Device> Devices { get; set; }
		public DbSet<Temperature> Temperatures { get; set; }

		IEnumerable<IRoom> IDataContext.Rooms
		{
			get { return this.Rooms; }
		}

		public void AddRoom(IRoom room)
		{
		}

		void IDataContext.SaveChanges()
		{
			this.SaveChanges();
		}
	}
}
