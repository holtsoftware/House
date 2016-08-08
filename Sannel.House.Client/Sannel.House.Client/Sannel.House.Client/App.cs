using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using Sannel.House.Client.ViewModels;
using Sannel.House.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sannel.House.Client
{
	public class App : FormsApplication
	{
		private readonly SimpleContainer container;

		public App(SimpleContainer container)
		{
			this.container = container;

			container.Singleton<ShellViewModel>();

			Initialize();

			DisplayRootView<ShellView>();
		}

		protected override void PrepareViewFirst(NavigationPage navigationPage)
		{
			container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
		}
	}
}
