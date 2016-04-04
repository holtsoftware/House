using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Business.Interfaces
{
	public interface IMainViewModel : IUpdate
	{

		String Time
		{
			get;
			set;
		}

		String Date
		{
			get;
			set;
		}
	}
}
