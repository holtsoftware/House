using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sannel.House.Client.Interfaces
{
	/// <summary>
	/// What the login form needs
	/// </summary>
	public interface ILoginViewModel : IBaseViewModel
	{
		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>
		/// The username.
		/// </value>
		String Username
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		String Password
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to [stay logged in].
		/// </summary>
		/// <value>
		///   <c>true</c> if [stay logged in]; otherwise, <c>false</c>.
		/// </value>
		bool StayLoggedIn
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the login command that preforms the login
		/// </summary>
		/// <value>
		/// The login.
		/// </value>
		ICommand Login
		{
			get;
		}

		/// <summary>
		/// Gets the error keys for the current errors.
		/// </summary>
		/// <value>
		/// The error keys.
		/// </value>
		ObservableCollection<String> ErrorKeys
		{
			get;
		}

		/// <summary>
		/// Gets a value indicating whether this instance has errors.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
		/// </value>
		bool HasErrors
		{
			get;
		}
	}
}
