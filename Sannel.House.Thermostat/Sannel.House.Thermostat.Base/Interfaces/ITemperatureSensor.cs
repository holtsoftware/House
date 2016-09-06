using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Interfaces
{
	public interface ITemperatureSensor : IDisposable
	{
		double GetTemperatureCelsius();
		double GetHumidity();
		double GetPressure();
	}
}
