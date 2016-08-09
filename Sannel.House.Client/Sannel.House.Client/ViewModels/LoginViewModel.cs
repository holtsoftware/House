﻿using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Sannel.House.Client.ViewModels
{
	/// <summary>
	/// Represents the login view model
	/// </summary>
	/// <seealso cref="Sannel.House.Client.Interfaces.ILoginViewModel" />
	public class LoginViewModel : BaseViewModel, ILoginViewModel
	{
		private ISettings settings;
		public LoginViewModel(ISettings settings)
		{
			this.settings = settings;
			if(settings.ServerUrl == null)
			{
				ErrorKeys.Add("ServerUrlNotConfigured");
				HasErrors = false;
			}
		}

		/// <summary>
		/// Gets the error keys for the current errors.
		/// </summary>
		/// <value>
		/// The error keys.
		/// </value>
		public ObservableCollection<string> ErrorKeys
		{
			get;
			private set;
		} = new ObservableCollection<String>();


		private bool hasErrors;
		/// <summary>
		/// Gets or sets the HasErrors.
		/// </summary>
		/// <value>
		/// The HasErrors
		/// </value>
		public bool HasErrors
		{
			get
			{
				return hasErrors;
			}
			set
			{
				Set(ref hasErrors, value);
			}
		}

		private RelayCommand command = new RelayCommand(() =>
		{

		});

		/// <summary>
		/// Gets the login command that preforms the login
		/// </summary>
		/// <value>
		/// The login.
		/// </value>
		public ICommand Login
		{
			get
			{
				return command;
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
