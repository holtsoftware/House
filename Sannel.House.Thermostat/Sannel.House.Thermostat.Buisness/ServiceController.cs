using Sannel.House.ServerSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Buisness
{
	public class ServiceController
	{
		private IAppSettings settings;
		public ServiceController(IAppSettings settings)
		{
			this.settings = settings;
		}

		/// <summary>
		/// Sets the configuration asynchronous.
		/// </summary>
		/// <param name="serverUri">The server URI.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public async Task<Tuple<bool, String>> SetConfigurationAsync(Uri serverUri, String username, String password)
		{
			if(serverUri == null)
			{
				return new Tuple<bool, string>(false, "ServerUri cannot be null");
			}

			if(username == null)
			{
				return new Tuple<bool, string>(false, "Username cannot be null");
			}

			if(password == null)
			{
				return new Tuple<bool, string>(false, "Password cannot be null");
			}

			settings.ServerUri = serverUri;
			settings.Username = username;
			settings.Password = password;

			var serverContext = new ServerContext(settings);
			var result = await serverContext.LoginAsync(settings.Username, settings.Password);
			if (result.Key)
			{
				return new Tuple<bool, string>(true, "Success");
			}
			else
			{
				return new Tuple<bool, string>(false, "Error verifying with server");
			}
		}

		/// <summary>
		/// Gets the configuration asynchronous.
		/// Does not include password that can only be set not retreaved
		/// </summary>
		/// <returns></returns>
		public Task<Tuple<Uri, String>> GetConfigurationAsync()
		{
			return Task.Run(() => new Tuple<Uri, String>(settings.ServerUri, settings.Username));
		}
	}
}
