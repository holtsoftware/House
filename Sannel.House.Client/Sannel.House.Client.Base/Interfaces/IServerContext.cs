using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IServerContext
	{
		/// <summary>
		/// Logins asynchronously.
		/// Returns true and the name of the user if successfull
		/// Returns false and null if the user is not logged in
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		Task<Tuple<bool, String>> LoginAsync(String username, String password);

		/// <summary>
		/// Logs the user off.
		/// </summary>
		/// <returns></returns>
		Task LogOffAsync();

		/// <summary>
		/// Gets the roles asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<IList<String>> GetRolesAsync();

		/// <summary>
		/// Gets the profile for the user who is current logged in
		/// </summary>
		/// <returns></returns>
		Task<ClientProfile> GetProfileAsync();

		/// <summary>
		/// Gets the default temperature setting.
		/// </summary>
		/// <returns></returns>
		Task<IList<TemperatureSetting>> GetTemperatureSettingsAsync();

		/// <summary>
		/// Puts the temperature settings asynchronous.
		/// </summary>
		/// <returns></returns>
		Task PutTemperatureSettingsAsync(TemperatureSetting setting);
	}
}
