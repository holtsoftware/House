using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
	public sealed class ServerContext
	{
		private String authCookieName;
		private HttpCookie cookie;
		private IServerSettings settings;
		private ICreateHelper helper;
		private HttpClient client;
		private HttpBaseProtocolFilter httpFilter = new HttpBaseProtocolFilter();

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerContext"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public ServerContext(IServerSettings settings, ICreateHelper helper)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}
			this.settings = settings;
			authCookieName = "Authz";
			this.helper = helper;
			client = new HttpClient(httpFilter);
		}

		public void Dispose()
		{
			client?.Dispose();
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
			}).AsAsyncOperation();
		}

		#region TemperatureEntry
		public IAsyncOperation<ITemperatureEntry> GetTemperatureEntryAsync(Guid key)
		{
			return Task.Run(async () =>
			{
				if (settings.ServerUri == null)
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.ServerUriNotSet, null, default(Guid));
				}

				if (!IsAuthenticated)
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.NotLoggedIn, null, default(Guid));
				}

				UriBuilder builder;
				try
				{
					builder = new UriBuilder(settings.ServerUri);
				}
				catch (UriFormatException)
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.ServerUriIsNotValid, null, default(Guid));
				}

				builder.Path = "/api/TemperatureEntry";
				HttpResponseMessage result = null;
				try
				{
					result = await client.GetAsync(builder.Uri);
				}
				catch (COMException ce)
				{
					if (ce.HResult == -2147012867)
					{
						return new TemperatureEntryResult(TemperatureEntryStatus.UnableToConnectToServer, null, key, ce);
					}

					return new TemperatureEntryResult(TemperatureEntryStatus.Exception, null, key, ce);
				}

				if (result.StatusCode == HttpStatusCode.Ok)
				{
					var res = await result.Content.ReadAsStringAsync();
					try
					{
						var token = JObject.Parse(res);
						var item = helper.CreateTemperatureEntry();
						if (token.Type == JTokenType.Object)
						{
							item.Id = token.GetPropertyValue<Guid>(nameof(item.Id));
							item.DeviceId = token.GetPropertyValue<Int32>(nameof(item.DeviceId));
							item.TemperatureCelsius = token.GetPropertyValue<Double>(nameof(item.TemperatureCelsius));
							item.Humidity = token.GetPropertyValue<Double>(nameof(item.Humidity));
							item.Pressure = token.GetPropertyValue<Double>(nameof(item.Pressure));
							item.CreatedDateTime = token.GetPropertyValue<DateTimeOffset>(nameof(item.CreatedDateTime));
						}

						return new TemperatureEntryResult(TemperatureEntryStatus.Exception, item, item.Id);
					}
					catch (Exception ex)
					{
						return new TemperatureEntryResult(TemperatureEntryStatus.Exception, null, key, ex);
					}
				}
				else
				{
					return new TemperatureEntryResult(TemperatureEntryStatus.Error, null, key);
				}
			}

			).AsAsyncOperation();
		}
		#endregion

	}
}
