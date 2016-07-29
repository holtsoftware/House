using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	/// <summary>
	/// This interface describes a sensor that can return the temperature
	/// </summary>
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.ISensor" />
	public interface ITemperatureSensor : ISensor
	{
		/// <summary>
		/// Gets the temperature in celsius asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<double> GetTemperatureCelsiusAsync();

		/// <summary>
		/// Gets the temperature in fahrenheit asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<double> GetTemperatureFahrenheitAsync();
	}
}
