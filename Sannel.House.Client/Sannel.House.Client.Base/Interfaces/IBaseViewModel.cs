using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IBaseViewModel
	{
		bool IsBusy
		{
			get;
		}

		void NavigatedTo(Object arg);

		void NavigatedFrom();
	}
}
