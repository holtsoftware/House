using Sannel.House.ServerSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Interfaces
{
	/// <summary>
	/// Represents the settings for this app.
	/// </summary>
	public interface IAppSettings : IServerSettings
	{
		/// <summary>
		/// Gets or sets the username used to login to the server
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		String Username
		{
			get;set;
		}

		/// <summary>
		/// Gets or sets the password used to login to the server
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		String Password
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the device identifier.
		/// </summary>
		/// <value>
		/// The device identifier.
		/// </value>
		int DeviceId
		{
			get;set;
		}
	}
}
