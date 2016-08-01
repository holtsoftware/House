using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	public static class SensorExtensions
	{
		/// <summary>
		/// Converts celsius to fahrenheit.
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="celsius">The celsius.</param>
		/// <returns></returns>
		public static double CelsiusToFahrenheit(this ITemperatureSensor sensor, double celsius)
		{
			return (celsius * 9) / 5 + 32;
		}

		/// <summary>
		/// Converts Fahrenheits to celsius.
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="fehrenheit">The fehrenheit.</param>
		/// <returns></returns>
		public static double FahrenheitToCelsius(this ITemperatureSensor sensor, double fehrenheit)
		{
			return (fehrenheit - 32) * (5 / 9);
		}

		/// <summary>
		/// Converts Pressure to Altitude In Meters
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="pressure">The pressure.</param>
		/// <returns></returns>
		public static double PressureAsAltitudeInMeters(this IPressureSensor sensor, double pressure)
		{
			double heightOutput = 0;

			heightOutput = ((double)-45846.2) * ((double)Math.Pow((pressure / (double)101325), 0.190263) - (double)1);
			return heightOutput;
		}

		/// <summary>
		/// Converts Pressures to altitude in feet.
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="pressure">The pressure.</param>
		/// <returns></returns>
		public static double PressureAsAltitudeInFeet(this IPressureSensor sensor, double pressure)
		{
			return sensor.PressureAsAltitudeInMeters(pressure) * 3.28084;
		}

		/// <summary>
		/// Humidities to relative humidity.
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="humidity">The humidity.</param>
		/// <returns></returns>
		public static double HumidityToRelativeHumidity(this IHumiditySensor sensor, double humidity)
		{
			return humidity / 1024;
		}
	}
}
