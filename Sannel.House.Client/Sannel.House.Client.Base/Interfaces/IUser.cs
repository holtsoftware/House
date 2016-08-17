using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IUser : System.ComponentModel.INotifyPropertyChanged
	{
		bool IsLoggedIn
		{
			get;
		}

		String Name
		{
			get;
		}

		ObservableCollection<String> Groups
		{
			get;
		}

		ObservableCollection<MenuItem> MenuTop
		{
			get;
		}

		ObservableCollection<MenuItem> MenuBottom
		{
			get;
		}
	}
}
