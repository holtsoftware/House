using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Server.Interfaces
{
	public interface IApplicationUser
	{
		string Id { get; }

		string UserName { get; set; }

		String DisplayName { get; set; }

		String EmailAddress { get; set; }
	}
}
