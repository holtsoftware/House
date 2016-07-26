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
		/// Attemps to login to the server
		/// </summary>
		/// <param name="username">The Username</param>
		/// <param name="password">The Password</param>
		/// <returns>true if the app was able to login</returns>
		Task<bool> LoginAsync(String username, String password);
	}
}
