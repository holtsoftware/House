using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Sannel.House.Client.Interfaces;
using Sannel.House.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client
{
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			var ioc = Container;
			if (ViewModelBase.IsInDesignModeStatic)
			{

			}
			else
			{
				ioc.Register<IShellViewModel, ShellViewModel>();
			}
		}

		public static void SetNavigationService(INavigationService service)
		{
			Container.Register<INavigationService>(() => service, true);
		}

		public static INavigationService NavigationService
		{
			get
			{
				return Container.GetInstance<INavigationService>();
			}
		}

		public static ISimpleIoc Container
		{
			get
			{
				return SimpleIoc.Default;
			}
		}


		public static IShellViewModel ShellViewModel
		{
			get
			{
				return SimpleIoc.Default.GetInstance<IShellViewModel>();
			}
		}
	}
}
