using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public interface ICircuit
	{
		Guid CircuitId
		{
			get;
			set;
		}

		Guid RoomId
		{
			get;
			set;
		}

		IRoom Room
		{
			get;
		}

		String Name
		{
			get;
			set;
		}

		String Description
		{
			get;
			set;
		}

		int Order
		{
			get;
			set;
		}

		ICollection<IDevice> Devices
		{
			get;
		}
	}
}
