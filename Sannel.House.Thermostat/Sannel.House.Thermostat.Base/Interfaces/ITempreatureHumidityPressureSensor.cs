using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	/// <summary>
	/// Represents a sensor who contains Temperature, Humidity and Pressure
	/// </summary>
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.ITemperatureSensor" />
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.IHumiditySensor" />
	/// <seealso cref="Sannel.House.Thermostat.Base.Interfaces.IPressureSensor" />
	public interface ITempreatureHumidityPressureSensor : ITemperatureSensor, IHumiditySensor, IPressureSensor
	{
	}
}
