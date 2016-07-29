using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	public interface ISensor : IDisposable
	{
		/// <summary>
		/// Gets a value indicating whether this instance is initalized.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is initalized; otherwise, <c>false</c>.
		/// </value>
		bool IsInitalized
		{
			get;
		}

		/// <summary>
		/// Initializes the sensor asynchronous.
		/// </summary>
		/// <returns>true if the device was Initialize false if not (may be missing)</returns>
		Task<bool> InitializeAsync();
	}
}
