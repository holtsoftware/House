using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Models
{
	public class User : BasePropertyChange
	{

		private bool isLoggedIn;
		/// <summary>
		/// Gets or sets the IsLoggedIn
		/// </summary>
		/// <value>
		/// The IsLoggedIn
		/// </value>
		public bool IsLoggedIn
		{
			get
			{
				return isLoggedIn;
			}
			set
			{
				Set(ref isLoggedIn, value);
			}
		}

		private String name;
		/// <summary>
		/// Gets or sets the Name
		/// </summary>
		/// <value>
		/// The Name
		/// </value>
		public String Name
		{
			get
			{
				return name;
			}
			set
			{
				Set(ref name, value);
			}
		}


		private IList<String> roles;
		/// <summary>
		/// Gets or sets the Roles
		/// </summary>
		/// <value>
		/// The Roles
		/// </value>
		public IList<String> Roles
		{
			get
			{
				return roles;
			}
			set
			{
				Set(ref roles, value);
			}
		}

		/// <summary>
		/// Determines whether the user is in [the specified role].
		/// </summary>
		/// <param name="role">The role.</param>
		/// <returns>
		///   <c>true</c> if the user is in [the specified role]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsInRole(String role)
		{
			return Roles?.Contains(role) ?? false;
		}

		/// <summary>
		/// Logouts this instance.
		/// </summary>
		public void Logout()
		{
			IsLoggedIn = false;
			Roles = new List<string>();
			Name = String.Empty;
		}
	}
}
