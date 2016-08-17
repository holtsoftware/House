using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Sannel.House.Client.Exceptions;
using System.Net.Http;

namespace Sannel.House.Client.ViewModels
{
	/// <summary>
	/// Represents the login view model
	/// </summary>
	/// <seealso cref="Sannel.House.Client.Interfaces.ILoginViewModel" />
	public class LoginViewModel : ErrorViewModel, ILoginViewModel
	{
		private ISettings settings;
		private IServerContext context;
		private IUserManager manager;
		public LoginViewModel(IUserManager manager, INavigationService navService, ISettings settings, IServerContext context) : base(navService)
		{
			this.settings = settings;
			this.context = context;
			this.manager = manager;
		}

		public override async void NavigatedTo(object arg)
		{
			base.NavigatedTo(arg);
			if(settings.AuthzCookieValue != null)
			{
				IsBusy = true;
				await getProfileAndRedirectAsync();
				IsBusy = false;
			}
		}

		private async Task getProfileAndRedirectAsync()
		{
			try
			{
				if(await manager.LoadProfileAsync())
				{
					NavigationService.Navigate<IHomeViewModel>();
				}
			}
			catch (NotLoggedInException)
			{
				// Were on the login screen so just catch this so we can reauthenticate
			}
			catch (ServerException)
			{
				ErrorKeys.Add("ErrorConnectingToTheServer");
			}
			catch (HttpRequestException)
			{
				ErrorKeys.Add("ErrorConnectingToTheServer");
			}
		}

		private bool validateMe()
		{
			ErrorKeys.Clear();

			if (!Constants.EmailAddress.IsMatch(Username ?? ""))
			{
				ErrorKeys.Add("UsernameMustBeEmail");
			}

			if (String.IsNullOrWhiteSpace(Password))
			{
				ErrorKeys.Add("PasswordIsRequired");
			}

			return ErrorKeys.Count == 0;
		}

		private async void loginCommand()
		{
			IsBusy = true;
			if (validateMe())
			{
				try
				{
					var results = await context.LoginAsync(Username, Password);
					if (!results.Item1)
					{
						ErrorKeys.Add("InvalidUsernameOrPassword");
						IsBusy = false;
						return;
					}
					ViewModelLocator.User.Name = results.Item2;
				}
				catch (ServerException)
				{
					ErrorKeys.Add("ErrorConnectingToTheServer");
					IsBusy = false;
					return;
				}
				await getProfileAndRedirectAsync();
			}
			IsBusy = false;
		}

		private RelayCommand command;

		/// <summary>
		/// Gets the login command that preforms the login
		/// </summary>
		/// <value>
		/// The login.
		/// </value>
		public ICommand LoginCommand
		{
			get
			{
				return command ?? (command = new RelayCommand(loginCommand));
			}
		}


		private String username;
		/// <summary>
		/// Gets or sets the Username.
		/// </summary>
		/// <value>
		/// The Username
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
		/// Gets or sets the Password.
		/// </summary>
		/// <value>
		/// The Password
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


		private bool stayLoggedIn;
		/// <summary>
		/// Gets or sets the StayLoggedIn.
		/// </summary>
		/// <value>
		/// The StayLoggedIn
		/// </value>
		public bool StayLoggedIn
		{
			get
			{
				return stayLoggedIn;
			}
			set
			{
				Set(ref stayLoggedIn, value);
			}
		}
	}
}
