using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server
{
	class Program
	{
		static void Main(string[] args)
		{
			using(WebApp.Start<Sannel.House.Server.Web.Startup>("http://+:8333"))
			{
				Console.ReadLine();
			}
		}
	}
}
