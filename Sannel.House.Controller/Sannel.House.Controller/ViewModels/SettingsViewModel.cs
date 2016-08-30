using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Sannel.House.Controller.Interfaces;

namespace Sannel.House.Controller.ViewModels
{
	public class SettingsViewModel : ErrorViewModel
	{
		private IAppSettings settings;
		public SettingsViewModel(IAppSettings settings, WinRTContainer container, INavigationService service, IEventAggregator eventAggregator) : base(container, service, eventAggregator)
		{
			this.settings = settings;
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
		public void Verify()
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

			}
			IsBusy = false;
		}

	}
}
