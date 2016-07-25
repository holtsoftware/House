using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;
using System.Net;
using System.Net.Http;

namespace Sannel.House.Thermostat.ViewModels
{
	public class ConfigureViewModel : BaseViewModel
	{
		private readonly IAppSettings settings;
		public ConfigureViewModel(IAppSettings settings, WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
			this.settings = settings;
			serverUrl = settings.ServerUrl;
			username = settings.Username;
			password = settings.Password;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is first run.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is first run; otherwise, <c>false</c>.
		/// </value>
		public bool IsFirstRun { get; private set; } = false;

		private String serverUrl;
		/// <summary>
		/// Gets or sets the server URL.
		/// </summary>
		/// <value>
		/// The server URL.
		/// </value>
		public String ServerUrl
		{
			get
			{
				return serverUrl;
			}
			set
			{
				Set(ref serverUrl, value);
				settings.ServerUrl = value;
			}
		}

		private String username;
		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		public String Username
		{
			get
			{
				return username;
			}
			set
			{
				Set(ref username, value);
				settings.Username = value;
			}
		}

		private String password;
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		public String Password
		{
			get
			{
				return password;
			}
			set
			{
				Set(ref password, value);
				settings.Password = value;
			}
		}

		/// <summary>
		/// Verifies this instance.
		/// </summary>
		public async void Verify()
		{
			UriBuilder builder = new UriBuilder(ServerUrl);
			builder.Path = "/Account/Login";


			var request = HttpWebRequest.Create(builder.Uri);
			request.Method = "POST";
			var response = await request.GetResponseAsync();
			//response.

			CookieContainer cookies = new CookieContainer();
			HttpClientHandler handler = new HttpClientHandler();
			handler.CookieContainer = cookies;

			using (var client = new System.Net.Http.HttpClient(handler))
			{
				var content = new System.Net.Http.FormUrlEncodedContent(new KeyValuePair<String, String>[]
				{
					new KeyValuePair<string, string>("Email", username),
					new KeyValuePair<string, string>("Password", password),
					new KeyValuePair<string, string>("RememberMe", "true")
				});

				var result = await client.GetAsync(builder.Uri);
				result.EnsureSuccessStatusCode();

				result = await client.PostAsync(builder.Uri, content);
				result.EnsureSuccessStatusCode();
				var data = await result.Content.ReadAsStringAsync();
				
				var cc = cookies.GetCookies(builder.Uri);
			}
		}
	}
}
