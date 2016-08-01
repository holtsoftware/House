using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base
{
	public static class DoubleExtensions
	{
		/// <summary>
		/// Celsiuses to fahrenheit.
		/// </summary>
		/// <param name="celsius">The celsius.</param>
		/// <returns></returns>
		public static double CelsiusToFahrenheit(this double celsius)
		{
			return (celsius * 9) / 5 + 32;
		}

		/// <summary>
		/// Fahrenheits to celsius.
		/// </summary>
		/// <param name="fahrenheit">The fahrenheit.</param>
		/// <returns></returns>
		public static double FahrenheitToCelsius(this double fahrenheit)
		{
			return (fahrenheit - 32) * (5 / 9);
		}
	}
}
