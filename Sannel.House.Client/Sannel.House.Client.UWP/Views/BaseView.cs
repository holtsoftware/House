using Sannel.House.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sannel.House.Client.UWP.Views
{
	public abstract class BaseView : Page
	{
		public IBaseViewModel ViewModel
		{
			get
			{
				return DataContext as IBaseViewModel;
			}
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ViewModel?.NavigatedTo(e.Parameter);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			ViewModel?.NavigatedFrom();
		}
	}
}
