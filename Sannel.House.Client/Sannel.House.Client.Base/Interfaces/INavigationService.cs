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
			where T : class;
	}
}
