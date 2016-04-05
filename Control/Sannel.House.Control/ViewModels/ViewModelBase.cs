using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.ViewModels
{
	public class ViewModelBase : Screen
	{
		protected readonly INavigationService PageNavigationService;

		protected ViewModelBase(INavigationService pageNavigationService)
		{
			PageNavigationService = pageNavigationService;
		}

		public bool CanGoBack
		{
			get
			{
				return PageNavigationService.CanGoBack;
			}
		}

		protected void NavigateTo<T>()
		{
			PageNavigationService.Navigate<T>();
		}

		public void GoBack()
		{
			PageNavigationService.GoBack();
		}

		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName=null)
		{
			if(!Object.Equals(dest, source))
			{
				dest = source;
				NotifyOfPropertyChange(propName);
			}
		}
	}
}
