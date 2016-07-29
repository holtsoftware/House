using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	/// <summary>
	/// Represents a sensor who returns the current environmental pressure.
	/// </summary>
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.ISensor" />
	public interface IPressureSensor : ISensor
	{
		/// <summary>
		/// Gets the pressure asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<double> GetPressureAsync();
	}
}
