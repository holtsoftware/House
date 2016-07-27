using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Thermostat.Base.Interfaces;
using Windows.Web.Http.Filters;
using System.Diagnostics;

namespace Sannel.House.Thermostat.ViewModels
{
	public class ConfigureViewModel : BaseViewModel
	{
		private readonly IAppSettings settings;
		private readonly IServerSource server;
		public ConfigureViewModel(IAppSettings settings, IServerSource source, WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
			this.settings = settings;
			serverUrl = settings.ServerUrl;
			username = settings.Username;
			password = settings.Password;
			server = source;
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

		private bool hasError;
		/// <summary>
		/// Gets or sets a value indicating whether this instance has error.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
		/// </value>
		public bool HasError
		{
			get { return hasError; }
			set { Set(ref hasError, value); }
		}

		/// <summary>
		/// Verifies this instance.
		/// </summary>
		public async void Verify()
		{
			IsBusy = true;
			if(await server.LoginAsync(settings.Username, settings.Password) != Base.Enums.LoginStatus.Success)
			{
				HasError = true;
			}
			else
			{
				HasError = false;
			}
			IsBusy = false;
		}
	}
}
