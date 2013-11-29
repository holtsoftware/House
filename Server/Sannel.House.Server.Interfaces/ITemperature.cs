using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public interface ITemperature
	{
		Guid TemperatureId
		{
			get;
			set;
		}

		Guid DeviceId
		{
			get;
			set;
		}

		IDevice Device
		{
			get;
		}

		DateTime Date
		{
			get;
			set;
		}

		double Value
		{
			get;
			set;
		}
	}
}
