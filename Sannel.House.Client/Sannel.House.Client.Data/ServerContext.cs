using Newtonsoft.Json;
using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Client.Exceptions;

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

		public Task<IList<string>> GetRolesAsync()
		{
			if(settings.AuthzCookieValue == null)
			{
				throw new NotLoggedInException("Please login.");
			}
			return null;
		}

		/// <summary>
		/// Logins the asynchronous.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public async Task<bool> LoginAsync(string username, string password)
		{
			if (username == null)
			{
				throw new ArgumentNullException(nameof(username));
			}
			if(password == null)
			{
				throw new ArgumentNullException(nameof(password));
			}
			var clientHandler = new HttpClientHandler();
			clientHandler.UseCookies = true;

			using(HttpClient client = new HttpClient(clientHandler))
			{
				var uri = new UriBuilder(settings.ServerUrl);
				uri.Path = "/Account/LoginFromDevice";
				var values = new Dictionary<String, String>();
				values["Email"] = username;
				values["Password"] = password;
				values["RememberMe"] = "true";
				var sentContent = new FormUrlEncodedContent(values);
	
				var response = await client.PostAsync(uri.Uri, sentContent);
				response.EnsureSuccessStatusCode();
				var content = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<bool>(content);

				if (result)
				{
					var cookies = clientHandler.CookieContainer.GetCookies(settings.ServerUrl);

					var c = cookies[Constants.AuthzCookieName];
					if(c != null)
					{
						settings.AuthzCookieValue = c.Value;
						return true;
					}
				}

				return false;
			}
		}
	}
}
