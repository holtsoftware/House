using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Http
{
	public abstract class SyncBase : IRought
	{
		public abstract string Path
		{
			get;
		}

		public Task RequestAsync(HttpRequest request, HttpResponse response)
		{
			return Task.Run(() => Request(request, response));
		}

		public abstract void Request(HttpRequest request, HttpResponse response);
	}
}
