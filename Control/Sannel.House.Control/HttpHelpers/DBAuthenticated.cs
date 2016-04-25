using Sannel.House.Control.Data;
using Sannel.House.Control.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.HttpHelpers
{
	public abstract class DBAuthenticated : BasicAuthenticationRought
	{
		public override async Task<bool> IsValidAsync(string username, string password)
		{
			using (var context = new SqliteContext())
			{
				return await Task.Run(() => context.Users.FirstOrDefault(i => i.Username == username && i.Password == password && i.IsEnabled) != null);
			}
		}
	}
}
