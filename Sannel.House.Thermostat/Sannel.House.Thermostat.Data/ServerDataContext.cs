using Sannel.House.Thermostat.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Sannel.House.Thermostat.Data
{
	public class ServerDataContext : IServerSource
	{
		private IAppSettings settings;
		private HttpCookie authz = null;
		/// <summary>
		/// Initializes a new instance of the <see cref="ServerDataContext"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public ServerDataContext(IAppSettings settings)
		{
			this.settings = settings;
		}
		/// <summary>
		/// Gets a value indicating whether this instance is authenticated.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
		/// </value>
		public bool IsAuthenticated
		{
			get
			{
				return authz != null;
			}
		}

		/// <summary>
		/// Attemps to login to the server
		/// </summary>
		/// <param name="username">The Username</param>
		/// <param name="password">The Password</param>
		/// <returns>
		/// true if the app was able to login
		/// </returns>
		public async Task<bool> LoginAsync(string username, string password)
		{
			UriBuilder builder = new UriBuilder(settings.ServerUrl);
			builder.Path = "/Account/Login";

			HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
			
			using (var client = new HttpClient(httpFilter))
			{
				var content = new Windows.Web.Http.HttpFormUrlEncodedContent(new KeyValuePair<String, String>[]
				{
					new KeyValuePair<string, string>("Email", username),
					new KeyValuePair<string, string>("Password", password),
					new KeyValuePair<string, string>("RememberMe", "true")
				});
				var result = await client.PostAsync(builder.Uri, content);
				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var cookies = httpFilter.CookieManager.GetCookies(new Uri("http://localhost:5000"));
					var authz = cookies.FirstOrDefault(i => String.Compare(i.Name, "Authz") == 0);
					if(authz != null)
					{
						this.authz = authz;
						return true;
					}
				}
			}

			return false;
		}
	}
}
