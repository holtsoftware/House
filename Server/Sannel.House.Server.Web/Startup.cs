﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Sannel.House.Server.Web.Startup))]

namespace Sannel.House.Server.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
			ConfigureAuth(app);
		}
	}
}
