using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Interfaces
{
	public interface IServerContext
	{
		Task<bool> LoginAsync(String username, String password);

		Task<IList<String>> GetRolesAsync();
	}
}
