using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	/// <summary>
	/// Represents a Sensor that returns the Humidity
	/// </summary>
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.ISensor" />
	public interface IHumiditySensor : ISensor
	{
		/// <summary>
		/// Gets the humidity asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<double> GetHumidityAsync();
	}
}
