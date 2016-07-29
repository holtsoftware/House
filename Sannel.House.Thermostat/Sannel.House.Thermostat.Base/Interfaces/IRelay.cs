using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	public interface IRelay : ISmallDevice
	{
		/// <summary>
		/// Gets a value indicating whether the relay is on.
		/// </summary>
		/// <value>
		///   <c>true</c> if the relay is on; otherwise, <c>false</c>.
		/// </value>
		bool IsOn
		{
			get;
		}

		/// <summary>
		/// Turns the Relay on.
		/// </summary>
		void TurnOn();

		/// <summary>
		/// Turns the Relay off.
		/// </summary>
		void TurnOff();
	}
}
