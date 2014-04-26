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

		public EntityContext() : base("DefaultConnection")
		{

		}
		
		IEnumerable<IRoom> IDataContext.Rooms
		{
			get { return this.Rooms; }
		}

		IEnumerable<ICircuit> IDataContext.Circuits
		{
			get
			{
				return this.Circuits;
			}
		}

		public void AddRoom(IRoom room)
		{
			var eroom = room as Room;
			if(eroom != null)
			{
				room.RoomId = Guid.NewGuid();
			}
			else
			{
				eroom = new Room();
				room.CopyTo(eroom);
				eroom.RoomId = Guid.NewGuid();
			}

			Rooms.Add(eroom);
		}

		void IDataContext.SaveChanges()
		{
			this.SaveChanges();
		}
	}
}
