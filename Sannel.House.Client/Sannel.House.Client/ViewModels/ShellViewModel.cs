using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.ViewModels
{
	public class ShellViewModel : BaseViewModel, IShellViewModel
	{
		private ISettings settings;
		public ShellViewModel(ISettings settings, INavigationService navigationService) : base(navigationService)
		{
			this.settings = settings;
		}


		private bool isPaneOpen;
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

	}
}
