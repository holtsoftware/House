using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	public interface IServerContext
	{
		Task<LoginResult> LoginAsync(String username, String password);

		bool IsAuthenticated
		{
			get;
		}
	}
}
