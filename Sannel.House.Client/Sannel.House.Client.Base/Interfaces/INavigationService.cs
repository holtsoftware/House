using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface INavigationService
	{
		void Navigate<T>(Object parameter)
			where T : IBaseViewModel;

		void Navigate<T>()
			where T : IBaseViewModel;

		void Navigate(Type t, Object parameter);

		void Navigate(Type t);

		void ClearHistory();
	}
}
