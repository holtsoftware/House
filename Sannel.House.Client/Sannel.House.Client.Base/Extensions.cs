using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client
{
	public static class Extensions
	{
		public static double CelsiusToFahrenheit(this double celsius)
		{
			return (celsius * 1.8f) + 32;
		}

		public static double FahrenheitToCelsius(this double fahrenheit)
		{
			return (fahrenheit - 32f) / 1.8f;
		}
	}
}
