using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Sannel.House.ServerSDK
{
	/// <summary>
	/// This class is used to connect and make calls to the server.
	/// </summary>
	public sealed class ServerContext : IServerContext
	{
		private String authCookieName;
		private HttpCookie cookie;
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
		/// Gets a value indicating whether this instance is authenticated.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
		/// </value>
		public bool IsAuthenticated
		{
			get
			{
				return cookie != null;
			}
		}

		/// <summary>
		/// Logins to the server asynchronous.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns>First part of the Tuple is true if authenticated false if unable to authenticate for some reason
		/// The second part of the Tuple is a String the represents the authz token value if we were able to login to the server
		///		or The error message if we were unable to authenticate to the server.</returns>
		public IAsyncOperation<LoginResult> LoginAsync(String username, String password)
		{
			return Task.Run(async () =>
			{
				if (settings.ServerUri == null)
				{
					return new LoginResult(LoginStatus.ServerUriNotSet, "Server Uri is not set");
				}
				if (username == null)
				{
					return new LoginResult(LoginStatus.UsernameIsNull, "Username cannot be null");
				}
				if (password == null)
				{
					return new LoginResult(LoginStatus.PasswordIsNull, "Password cannot be null");
				}
				UriBuilder builder;
				try
				{
					builder = new UriBuilder(settings.ServerUri);
				}
				catch (UriFormatException)
				{
					return new LoginResult(LoginStatus.ServerUriIsNotValid, "Server Uri is not valid");
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
							return new LoginResult(LoginStatus.UnableToConnectToServer, "Unable to connect to server");
						}

						return new LoginResult(LoginStatus.Exception, ce.ToString());
					}
					if (result.StatusCode == HttpStatusCode.Ok)
					{
						var cookies = httpFilter.CookieManager.GetCookies(new Uri($"{builder.Scheme}://{builder.Host}:{builder.Port}"));
						var authz = cookies.FirstOrDefault(i => String.Compare(i.Name, authCookieName) == 0);
						if (authz != null)
						{
							cookie = authz;
							return new LoginResult(LoginStatus.Success, authz.Value);
						}
						else
						{
							return new LoginResult(LoginStatus.Error, "Error Authenticating");
						}
					}
					return new LoginResult(LoginStatus.Error, "Request Error");
				}
			}).AsAsyncOperation();
		}

		public IAsyncOperation<TemperatureEntryResult> PostTemperatureEntryAsync(ITemperatureEntry entry)
		{
			return Task.Run(async () =>
			{
				if(settings.ServerUri == null)
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.ServerUriNotSet, entry, Guid.Empty);
				}

				if (!IsAuthenticated)
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.NotLoggedIn, entry, Guid.Empty);
				}

				UriBuilder builder;
				try
				{
					builder = new UriBuilder(settings.ServerUri);
				}
				catch (UriFormatException)
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.ServerUriIsNotValid, entry, Guid.Empty);
				}

				builder.Path = "/api/TemperatureEntry";

				HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
				httpFilter.CookieManager.SetCookie(cookie);

				using (var client = new HttpClient(httpFilter))
				{
					HttpResponseMessage result = null;
					try
					{
						var obj = new JObject();
						obj.Add(nameof(entry.Id), entry.Id);
						obj.Add(nameof(entry.CreatedDateTime), entry.CreatedDateTime);
						obj.Add(nameof(entry.DeviceId), entry.DeviceId);
						obj.Add(nameof(entry.TemperatureCelsius), entry.TemperatureCelsius);
						obj.Add(nameof(entry.Humidity), entry.Humidity);
						obj.Add(nameof(entry.Pressure), entry.Pressure);

						result = await client.PostAsync(builder.Uri, new HttpStringContent(obj.ToString(), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
					}
					catch (COMException ce)
					{
						if (ce.HResult == -2147012867)
						{
							return new TemperatureEntryResult(TemperatureEntryStatus.UnableToConnectToServer, entry, Guid.Empty);
						}

						return new TemperatureEntryResult(TemperatureEntryStatus.Exception, entry, Guid.Empty);
					}

					if(result.StatusCode == HttpStatusCode.Ok)
					{
						var res = await result.Content.ReadAsStringAsync();
						try
						{
							Guid g = JsonConvert.DeserializeObject<Guid>(res);
							entry.Id = g;

							if (g == Guid.Empty)
							{
								return new TemperatureEntryResult(TemperatureEntryStatus.Error, entry, Guid.Empty);
							}
							else
							{
								return new TemperatureEntryResult(TemperatureEntryStatus.Success, entry, g);
							}
						}
						catch (Exception)
						{
							return new TemperatureEntryResult(TemperatureEntryStatus.Exception, entry, Guid.Empty);
						}
					}
					else
					{
						return new TemperatureEntryResult(TemperatureEntryStatus.Error, entry, Guid.Empty);
					}
				}
			}).AsAsyncOperation();
		}

		/*public IAsyncOperation<Results<bool, string, Guid>> PostTemperatureEntryAsync(ITemperatureEntry entry)
		{
			return Task.Run(async () =>
			{
				if (settings.ServerUri == null)
				{
					return new Results<bool, String, Guid>(false, "Server Uri is not set", Guid.Empty);
				}

				if (String.IsNullOrWhiteSpace(authCookieValue))
				{
					return new Results<bool, String, Guid>(false, "Not Authenticated", Guid.Empty);
				}
				UriBuilder builder = new UriBuilder(settings.ServerUri);
				HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();
				httpFilter.CookieManager.SetCookie(new HttpCookie(authCookieName, $"{builder.Scheme}://{builder.Host}:{builder.Port}", "/")
				{
					Value = authCookieValue
				});

				using (var client = new HttpClient(httpFilter))
				{
					
					await client.GetAsync(builder.Uri);
				}
				return new Results<bool, String, Guid>(false, "", Guid.Empty);
			}).AsAsyncOperation();
		}*/
	}
}
