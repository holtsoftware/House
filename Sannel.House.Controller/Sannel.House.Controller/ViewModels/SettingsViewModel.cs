using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Controller.Interfaces;
using Sannel.House.ThermostatSDK;

namespace Sannel.House.Controller.ViewModels
{
	public class SettingsViewModel : ErrorViewModel
	{
		private ThermostatManager tmanager;

		public SettingsViewModel(ThermostatManager tmanager, WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) : base(container, service, eventAggregator)
		{
			this.tmanager = tmanager;
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
			}
		}

		/// <summary>
		/// Verifies this instance.
		/// </summary>
		public async void Verify()
		{
			IsBusy = true;
			Errors.Clear();
			Uri i;
			if(!Uri.TryCreate(serverUrl, UriKind.RelativeOrAbsolute, out i))
			{
				Errors.Add("InvalidServerUrl");
			}
			if(!Constants.EmailAddress.IsMatch(Username ?? ""))
			{
				Errors.Add("InvalidEmailAddress");
			}
			if (String.IsNullOrEmpty(Password))
			{
				Errors.Add("PasswordIsRequired");
			}

			if(!HasErrors)
			{
				if (!tmanager.IsConnected)
				{
					if(!await tmanager.ConnectAsync())
					{
						Errors.Add("ErrorConnectingToThermostatManager");
					}
				}
				if (tmanager.IsConnected)
				{
					var result = await tmanager.SetConfigurationAsync(i, Username, Password);
					if (!result)
					{
						Errors.Add("ErrorSettingThermostatManager");
					}
				}
			}
			IsBusy = false;
		}

	}
}
