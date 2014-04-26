using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Sannel.House.Server.Startup))]

namespace Sannel.House.Server
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();

			var config = new HttpConfiguration()
		}
	}
}
