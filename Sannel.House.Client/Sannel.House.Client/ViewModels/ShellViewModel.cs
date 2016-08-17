using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Client.Models;
using System.Collections.ObjectModel;

namespace Sannel.House.Client.ViewModels
{
	public class ShellViewModel : BaseViewModel, IShellViewModel
	{
		private ISettings settings;
		private IUser user;
		public ShellViewModel(IUser user, ISettings settings, INavigationService navigationService) : base(navigationService)
		{
			this.settings = settings;
			this.user = user;
		}


		private bool isPaneOpen = true;
		/// <summary>
		/// Gets or sets the IsPaneOpen
		/// </summary>
		/// <value>
		/// The IsPaneOpen
		/// </value>
		public bool IsPaneOpen
		{
			get
			{
				return isPaneOpen;
			}
			set
			{
				Set(ref isPaneOpen, value);
			}
		}


		private bool isBusy;
		/// <summary>
		/// Gets or sets the IsBusy
		/// </summary>
		/// <value>
		/// The IsBusy
		/// </value>
		public new bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				Set(ref isBusy, value);
			}
		}

		/// <summary>
		/// Gets the menu.
		/// </summary>
		/// <value>
		/// The menu.
		/// </value>
		public ObservableCollection<MenuItem> MenuTop
		{
			get
			{
				return user.MenuTop;
			}
		}

		/// <summary>
		/// Gets the menu bottom.
		/// </summary>
		/// <value>
		/// The menu bottom.
		/// </value>
		public ObservableCollection<MenuItem> MenuBottom
		{
			get
			{
				return user.MenuBottom;
			}
		}

		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <value>
		/// The user.
		/// </value>
		public IUser User
		{
			get
			{
				return user;
			}
		}

		public override void NavigatedTo(object arg)
		{
			// navigationService on the Shell is pointed to the content frame in the split panel so were not navigating away from this page
			base.NavigatedTo(arg);
			if(settings.ServerUrl == null)
			{
				NavigationService.Navigate<ISettingsViewModel>();
			}
			else
			{
				NavigationService.Navigate<ILoginViewModel>();
			}
		}

		public void MenuItemClick(MenuItem item)
		{
			if(item != null)
			{
				if (item.Click != null)
				{
					item.Click();
				}
				else
				{
					item.NavigateTo(NavigationService);
				}
			}
		}
	}
}
