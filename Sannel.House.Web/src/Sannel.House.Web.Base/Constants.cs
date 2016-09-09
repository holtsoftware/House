using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sannel.House
{
	public static class Constants
	{
		public static readonly Regex EmailAddress = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

		public static readonly String AuthzCookieName = "Authz";

		public static readonly String DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffffZzzzz";

	}
}
