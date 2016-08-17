using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sannel.House.Client.Models
{
	public class User : BasePropertyChange, IUser
	{
		/// <summary>
		/// Gets the groups.
		/// </summary>
		/// <value>
		/// The groups.
		/// </value>
		public ObservableCollection<string> Groups
		{
			get;
		} = new ObservableCollection<string>();

		/// <summary>
		/// Gets the menu.
		/// </summary>
		/// <value>
		/// The menu.
		/// </value>
		public ObservableCollection<MenuItem> Menu
		{
			get;
		} = new ObservableCollection<MenuItem>();


		private String name;
		/// <summary>
		/// Gets or sets the Name.
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
			internal set
			{
				Set(ref name, value);
			}
		}


		private bool isLoggedIn;
		/// <summary>
		/// Gets or sets the IsLoggedIn.
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
	}
}
