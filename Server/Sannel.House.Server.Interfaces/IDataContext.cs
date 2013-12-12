using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public interface IDataContext : IDisposable
	{
		IEnumerable<IRoom> Rooms
		{
			get;
		}

		IEnumerable<ICircuit> Circuits
		{
			get;
		}

		void AddRoom(IRoom room);

		void SaveChanges();
	}
}
