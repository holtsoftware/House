using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Models
{
	public class LogEventArgs : EventArgs
	{
		public String Message { get; set; }
	}
}
