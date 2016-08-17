using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IShellViewModel : IBaseViewModel
	{
		new bool IsBusy
		{
			get;
			set;
		}
		bool IsPaneOpen
		{
			get;
			set;
		}

		IUser User
		{
			get;
		}

		ObservableCollection<MenuItem> Menu
		{
			get;
		}

		void MenuItemSelected(MenuItem item);
	}
}
