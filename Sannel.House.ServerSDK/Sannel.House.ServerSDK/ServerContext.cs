using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// This class is used to connect and make calls to the server.
	/// </summary>
	public sealed class ServerContext
	{
		private String authCookieName;
		private String authCookieValue;
		private IServerSettings settings;
		/// <summary>
		/// Initializes a new instance of the <see cref="ServerContext"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public ServerContext(IServerSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}
			this.settings = settings;
			authCookieName = "Authz";
		}

		/// <summary>
		/// Logins to the server asynchronous.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns>First part of the Tuple is true if authenticated false if unable to authenticate for some reason
		/// The second part of the Tuple is a String the represents the authz token value if we were able to login to the server
		///		or The error message if we were unable to authenticate to the server.</returns>
		public IAsyncOperation<KeyValuePair<bool, String>> LoginAsync(String username, String password)
		{
			return Task.Run<KeyValuePair<bool, String>>(async () =>
			{
				if (settings.ServerUri == null)
				{
					return new KeyValuePair<bool, String>(false, "Server Uri is not set");
				}
				if (username == null)
				{
					return new KeyValuePair<bool, string>(false, "Username cannot be null");
				}
				if (password == null)
				{
					return new KeyValuePair<bool, string>(false, "Password cannot be null");
				}
				UriBuilder builder;
				try
				{
					builder = new UriBuilder(settings.ServerUri);
				}
				catch (UriFormatException)
				{
					return new KeyValuePair<bool, string>(false, "Server Uri is not valid");
				}

				builder.Path = "/Account/LoginFromDevice";

				HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();

				using (var client = new HttpClient(httpFilter))
				{
					var content = new Windows.Web.Http.HttpFormUrlEncodedContent(new KeyValuePair<String, String>[]
					{
					new KeyValuePair<string, string>("Email", username),
					new KeyValuePair<string, string>("Password", password),
					new KeyValuePair<string, string>("RememberMe", "true")
					});
					HttpResponseMessage result = null;
					try
					{
						result = await client.PostAsync(builder.Uri, content);
					}
					catch (COMException ce)
					{
						if (ce.HResult == -2147012867)
						{
							return new KeyValuePair<bool, string>(false, "Unable to connect to server");
						}

						return new KeyValuePair<bool, string>(false, ce.ToString());
					}
					if (result.StatusCode == HttpStatusCode.Ok)
					{
						var cookies = httpFilter.CookieManager.GetCookies(new Uri($"{builder.Scheme}://{builder.Host}:{builder.Port}"));
						var authz = cookies.FirstOrDefault(i => String.Compare(i.Name, authCookieName) == 0);
						if (authz != null)
						{
							authCookieValue = authz.Value;
							return new KeyValuePair<bool, string>(true, authCookieValue);
						}
						else
						{
							return new KeyValuePair<bool, string>(false, "Error Authenticating");
						}
					}

					return new KeyValuePair<bool, string>(false, "Request Error");
				}
			}).AsAsyncOperation();
		}
	}
}
