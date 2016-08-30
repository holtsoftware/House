using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Enums
{
	public enum LoginStatus
	{
		Unknown=0,
		Success=1,
		InvalidServerUrl=2,
		UnableToConnectToServer=3,
		ErrorAuthenticating=4,
		Error = 5
	}
}
