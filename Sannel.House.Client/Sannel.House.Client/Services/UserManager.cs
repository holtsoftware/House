using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

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
				IconKey = "Setting",
				Groups=new String[]
				{
					"TempSettings",
					"Admin"
				}
			}.SetNavigationType<ITemperatureSettingViewModel>(),
			new MenuItem
			{
				TextKey = "Settings",
				IconKey = "Setting",
				IsBottom = true,
				Groups = new string[]
				{
					"All"
				}
			}.SetNavigationType<ISettingsViewModel>(),
			new MenuItem
			{
				TextKey = "LogOff",
				IconKey = "LogOffIcon",
				IsBottom = true,
				Groups = new String[]
				{
					"All"
				},
				Click = async ()=>
				{
					await ViewModelLocator.Container.Resolve<IUserManager>().LogoffAsync();
				}
			}
		};

		public UserManager(IUser user, IServerContext server)
		{
			this.user = user as User;
			this.server = server;
		}

		public async Task<bool> LoadProfileAsync()
		{
			var result = await server.GetProfileAsync();
			if (result != null)
			{
				user.IsLoggedIn = true;
				user.Name = result.Name;
				user.Groups.Clear();
				user.MenuTop.Clear();
				foreach (var g in result.Roles)
				{
					user.Groups.Add(g);
				}

				// Seams like this can be refactered to be faster
				foreach (var mi in allMenuItems)
				{
					if (mi.Groups.Contains("All"))
					{
						if (mi.IsBottom)
						{
							user.MenuBottom.Add(mi);
						}
						else
						{
							user.MenuTop.Add(mi);
						}
					}
					else
					{
						foreach (var g in mi.Groups)
						{
							if (user.Groups.Contains(g))
							{
								if (mi.IsBottom)
								{
									user.MenuBottom.Add(mi);
								}
								else
								{
									user.MenuTop.Add(mi);
								}
								break;
							}
						}
					}
				}
				return true;
			}
			return false;
		}

		public async Task LogoffAsync()
		{
			user.MenuTop.Clear();
			user.MenuBottom.Clear();
			user.IsLoggedIn = false;
			user.Name = "";
			try
			{
				await server.LogOffAsync();
			}
			catch (Exception)
			{
			}
			ViewModelLocator.NavigationService.Navigate<ILoginViewModel>();
			ViewModelLocator.NavigationService.ClearHistory();	
		}
	}
}
