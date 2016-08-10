using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sannel.House.Client
{
	public static class Constants
	{
		public static Regex EmailAddress = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

		public const String AuthzCookieName = "Authz";
	}
}
