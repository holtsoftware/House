using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public interface IRoom
	{
		Guid RoomId
		{
			get;
			set;
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

		String Color
		{
			get;
			set;
		}

		ICollection<ICircuit> Circuits
		{
			get;
		}
	}
}
