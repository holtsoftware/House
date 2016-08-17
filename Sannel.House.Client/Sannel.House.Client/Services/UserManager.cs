using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Services
{
	public class UserManager : IUserManager
	{
		private User user;
		private IServerContext server;
		private IList<MenuItem> allMenuItems = new List<MenuItem>()
		{
			new MenuItem
			{
				TextKey = "Home",
				IconKey = "Home",
				Groups=new String[]
				{
					"All"
				}
			}.SetNavigationType<IHomeViewModel>(),
			new MenuItem
			{
				TextKey = "TempSetting",
				IconKey = "TempSetting",
				Groups=new String[]
				{
					"TempSettings",
					"Admin"
				}
			}.SetNavigationType<ITemperatureSettingViewModel>(),
			new MenuItem
			{
				TextKey = "Settings",
				IconKey = "Settings",
				Groups = new string[]
				{
					"All"
				}
			}.SetNavigationType<ISettingsViewModel>()
		};

		public UserManager(IUser user, IServerContext server)
		{
			this.user = user as User;
			this.server = server;
		}

		public async Task<bool> LoadProfileAsync()
		{
			var result = await server.GetProfileAsync();
			if(result != null)
			{
				user.IsLoggedIn = true;
				user.Name = result.Name;
				user.Groups.Clear();
				user.Menu.Clear();
				foreach(var g in result.Roles)
				{
					user.Groups.Add(g);
				}

				// Seams like this can be refactered to be faster
				foreach(var mi in allMenuItems)
				{
					if (mi.Groups.Contains("All"))
					{
						user.Menu.Add(mi);
					}
					else
					{
						foreach(var g in mi.Groups)
						{
							if (user.Groups.Contains(g))
							{
								user.Menu.Add(mi);
								break;
							}
						}
					}
				}
				return true;
			}
			return false;
		}

		public Task<bool> Logoff()
		{
			return null;
		}
	}
}
