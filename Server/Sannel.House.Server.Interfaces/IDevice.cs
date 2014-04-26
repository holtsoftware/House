using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public interface IDevice
	{
		Guid DeviceId
		{
			get;
			set;
		}

		Guid CircuitId
		{
			get;
			set;
		}

		ICircuit Circuit
		{
			get;
		}

		String Name
		{
			get;
			set;
		}

		String Key
		{
			get;
			set;
		}

		String Description
		{
			get;
			set;
		}
	}
}
