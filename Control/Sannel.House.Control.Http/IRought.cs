using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Http
{
	public interface IRought
	{
		String Path
		{
			get;
		}

		void Request(HttpRequest request, HttpResponse response);
	}
}
