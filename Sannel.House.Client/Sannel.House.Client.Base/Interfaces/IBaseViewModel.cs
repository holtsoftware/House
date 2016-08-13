using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IBaseViewModel : INotifyPropertyChanged
	{
		bool IsBusy
		{
			get;
		}

		void NavigatedTo(Object arg);

		void NavigatedFrom();
	}
}
