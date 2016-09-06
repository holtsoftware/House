using Sannel.House.Thermostat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.LocalTest
{
	public class TemperatureSensor : PropertyChangeBase, ITemperatureSensor
	{
		public void Dispose()
		{
		}


		private double humidity;
		/// <summary>
		/// Gets or sets the Humidity.
		/// </summary>
		/// <value>
		/// The Humidity
		/// </value>
		public double Humidity
		{
			get
			{
				return humidity;
			}
			set
			{
				Set(ref humidity, value);
			}
		}

		public double GetHumidity()
		{
			return Humidity;
		}


		private double pressure;
		/// <summary>
		/// Gets or sets the Pressure.
		/// </summary>
		/// <value>
		/// The Pressure
		/// </value>
		public double Pressure
		{
			get
			{
				return pressure;
			}
			set
			{
				Set(ref pressure, value);
			}
		}

		public double GetPressure()
		{
			return Pressure;
		}


		private double temperatureCelsius;
		/// <summary>
		/// Gets or sets the TemperatureCelsius.
		/// </summary>
		/// <value>
		/// The TemperatureCelsius
		/// </value>
		public double TemperatureCelsius
		{
			get
			{
				return temperatureCelsius;
			}
			set
			{
				Set(ref temperatureCelsius, value);
			}
		}

		public double GetTemperatureCelsius()
		{
			return TemperatureCelsius;
		}
	}
}
