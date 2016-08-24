using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Sannel.House.Client.Data;
using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Models;
using Sannel.House.Client.Services;
using Sannel.House.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client
{
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			Container = new Microsoft.Practices.Unity.UnityContainer();

			Container.RegisterInstance<IUser>(User);
			if (ViewModelBase.IsInDesignModeStatic)
			{

			}
			else
			{
				Container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
				Container.RegisterType<ILoginViewModel, LoginViewModel>();
				Container.RegisterType<ISettingsViewModel, SettingsViewModel>(new ContainerControlledLifetimeManager());
				Container.RegisterType<IServerContext, ServerContext>();
				Container.RegisterType<IHomeViewModel, HomeViewModel>();
				Container.RegisterType<ITemperatureSettingViewModel, TemperatureSettingViewModel>();
				Container.RegisterType<ITemperatureEditViewModel, TemperatureEditViewModel>();
			}
			Container.RegisterType<IUserManager, UserManager>(new ContainerControlledLifetimeManager());
		}

		public static User User
		{
			get;
		} = new User();

		public static void SetNavigationService(INavigationService service)
		{
			Container.RegisterInstance<INavigationService>(service);
		}

		public static ITemperatureSettingViewModel TemperatureSettingViewModel
		{
			get
			{
				return Container.Resolve<ITemperatureSettingViewModel>();
			}
		}

		public static ITemperatureEditViewModel TemperatureEditViewModel
		{
			get
			{
				return Container.Resolve<ITemperatureEditViewModel>();
			}
		}

		public static INavigationService NavigationService
		{
			get
			{
				return Container.Resolve<INavigationService>();
			}
		}

		public static IUnityContainer Container
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the login view model.
		/// </summary>
		/// <value>
		/// The login view model.
		/// </value>
		public static ILoginViewModel LoginViewModel
		{
			get
			{
				return Container.Resolve<ILoginViewModel>();
			}
		}


		public static IShellViewModel ShellViewModel
		{
			get
			{
				return Container.Resolve<IShellViewModel>();
			}
		}

		public static ISettingsViewModel SettingsViewModel
		{
			get
			{
				return Container.Resolve<ISettingsViewModel>();
			}
		}

		public static IHomeViewModel HomeViewModel
		{
			get
			{
				return Container.Resolve<IHomeViewModel>();
			}
		}
	}
}
