using Newtonsoft.Json;
using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Client.Exceptions;
using System.Net;
using Sannel.House.Client.Models;

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
		/// Gets the default temperature setting.
		/// </summary>
		/// <returns></returns>
		public async Task<IList<TemperatureSetting>> GetTemperatureSettingsAsync()
		{
			if(settings.AuthzCookieValue == null)
			{
				throw new NotLoggedInException("Please login.");
			}

			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));
			using (HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = "/api/TemperatureSettings";
				var response = await client.GetAsync(builder.Uri);
				if (!response.IsSuccessStatusCode)
				{
					throw new ServerException("Error from server", (int)response.StatusCode);
				}

				var data = await response.Content.ReadAsStringAsync();
				var dts = JsonConvert.DeserializeObject<IList<TemperatureSetting>>(data);
				return dts;
			}
		}

		/// <summary>
		/// Gets the profile for the user who is current logged in
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotLoggedInException">
		/// Please login.
		/// or
		/// Please login again.
		/// </exception>
		/// <exception cref="ServerException">Error from server</exception>
		public async Task<ClientProfile> GetProfileAsync()
		{
			if(settings.AuthzCookieValue == null)
			{
				throw new NotLoggedInException("Please login.");
			}

			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));
			using(HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = "/Account/GetProfile";
				var response = await client.GetAsync(builder.Uri);
				if (!response.IsSuccessStatusCode)
				{
					throw new ServerException("Error from server", (int)response.StatusCode);
				}
				if(response.RequestMessage.RequestUri != builder.Uri)
				{
					throw new NotLoggedInException("Please login again.");
				}
				var data = await response.Content.ReadAsStringAsync();
				var profile = JsonConvert.DeserializeObject<ClientProfile>(data);
				return profile;
			}
		}

		public async Task<IList<string>> GetRolesAsync()
		{
			if(settings.AuthzCookieValue == null)
			{
				throw new NotLoggedInException("Please login.");
			}

			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));
			using(HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = "/Account/GetRoles";
				var response = await client.GetAsync(builder.Uri);
				if (!response.IsSuccessStatusCode)
				{
					throw new ServerException("Error from server", (int)response.StatusCode);
				}
				if(response.RequestMessage.RequestUri != builder.Uri)
				{
					throw new NotLoggedInException("Please login again.");
				}
				var data = await response.Content.ReadAsStringAsync();
				var list = JsonConvert.DeserializeObject<IList<String>>(data);
				return list;
			}
		}

		/// <summary>
		/// Logins asynchronously.
		/// Returns true and the name of the user if successfull
		/// Returns false and null if the user is not logged in
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">
		/// Username or Password is null
		/// </exception>
		/// <exception cref="ServerException">
		/// Error logging in
		/// or
		/// Server Unavailable;503
		/// </exception>
		public async Task<Tuple<bool, String>> LoginAsync(string username, string password)
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

				try
				{
					var response = await client.PostAsync(uri.Uri, sentContent);
					if (!response.IsSuccessStatusCode)
					{
						throw new ServerException("Error logging in", (int)response.StatusCode);
					}
					var content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<LoginResults>(content);

					if (result.Success)
					{
						var cookies = clientHandler.CookieContainer.GetCookies(settings.ServerUrl);

						var c = cookies[Constants.AuthzCookieName];
						if (c != null)
						{
							settings.AuthzCookieValue = c.Value;
							return new Tuple<bool, string>(result.Success, result.Name);
						}
					}

					return new Tuple<bool, string>(false, null);
				}
				catch(WebException we)
				{
					throw new ServerException(we.Message, 500,we);
				}
				catch(HttpRequestException re)
				{
					throw new ServerException("Server Unavailable", 503, re);
				}
			}
		}

		/// <summary>
		/// Logs the user off.
		/// </summary>
		/// <returns></returns>
		public async Task LogOffAsync()
		{
			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));
			settings.AuthzCookieValue = null;	

			using (HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = "/Account/LogOff";
				var response = await client.PostAsync(builder.Uri, new FormUrlEncodedContent(new KeyValuePair<String, String>[] { }));
			}
		}

		/// <summary>
		/// Puts the temperature settings asynchronous.
		/// </summary>
		/// <param name="setting"></param>
		/// <returns></returns>
		public async Task PutTemperatureSettingAsync(TemperatureSetting setting)
		{
			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));

			using (HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = $"/api/TemperatureSettings/{setting.Id}";
				var result = await client.PutAsync(builder.Uri, new StringContent(JsonConvert.SerializeObject(setting), Encoding.UTF8, "application/json"));
				if(!result.IsSuccessStatusCode)
				{
					throw new ServerException("Server Error", (int)result.StatusCode);
				}
			}
		}

		/// <summary>
		/// Posts the temperature setting asynchronous.
		/// </summary>
		/// <param name="setting">The setting.</param>
		/// <returns></returns>
		/// <exception cref="ServerException">Server Error</exception>
		public async Task<long> PostTemperatureSettingAsync(TemperatureSetting setting)
		{
			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));

			using (HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = "/api/TemperatureSettings";
				var result = await client.PostAsync(builder.Uri, new StringContent(JsonConvert.SerializeObject(setting), Encoding.UTF8, "application/json"));
				if(!result.IsSuccessStatusCode)
				{
					throw new ServerException("Server Error", (int)result.StatusCode);
				}
				var data = await result.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<long>(data);
			}
		}

		/// <summary>
		/// Deletes the temperature setting asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task DeleteTemperatureSettingAsync(long id)
		{
			var clientHandler = new HttpClientHandler();
			clientHandler.CookieContainer.Add(settings.ServerUrl, new System.Net.Cookie(Constants.AuthzCookieName, settings.AuthzCookieValue));

			using (HttpClient client = new HttpClient(clientHandler))
			{
				var builder = new UriBuilder(settings.ServerUrl);
				builder.Path = $"/api/TemperatureSettings/{id}";
				var result = await client.DeleteAsync(builder.Uri);
				if(!result.IsSuccessStatusCode)
				{
					throw new ServerException("Server Error", (int)result.StatusCode);
				}
			}
		}
	}
}
