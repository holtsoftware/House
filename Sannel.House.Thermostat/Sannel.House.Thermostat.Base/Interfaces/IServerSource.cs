using Sannel.House.Thermostat.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Base.Interfaces
{
	/// <summary>
	/// Represents the communication to the server
	/// </summary>
	public interface IServerSource
	{

		/// <summary>
		/// Gets a value indicating whether this instance is authenticated.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
		/// </value>
		bool IsAuthenticated
		{
			get;
		}

		/// <summary>
		/// Logins the asynchronous.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		Task<LoginStatus> LoginAsync(String username, String password);
	}
}
