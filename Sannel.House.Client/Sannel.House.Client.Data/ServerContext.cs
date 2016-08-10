using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Data
{
	public class ServerContext : IServerContext
	{
		private ISettings settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerContext"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public ServerContext(ISettings settings)
		{
			this.settings = settings;
		}
		public void Dispose()
		{
		}

		/// <summary>
		/// Logins the asynchronous.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public async Task<bool> LoginAsync(string username, string password)
		{
			var clientHandler = new HttpClientHandler();
			clientHandler.UseCookies = true;

			using(HttpClient client = new HttpClient(clientHandler))
			{
				var uri = new UriBuilder(settings.ServerUrl);
				uri.Path = "/Account/Login";
				var values = new Dictionary<String, String>();
				values["Email"] = username;
				values["Password"] = password;
				values["RememberMe"] = "true";
				var content = new FormUrlEncodedContent(values);
				var result = await client.PostAsync(uri.Uri, content);
				var s = await result.Content.ReadAsStringAsync();

				return false;
			}
		}
	}
}
