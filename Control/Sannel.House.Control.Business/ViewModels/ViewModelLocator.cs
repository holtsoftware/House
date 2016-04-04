using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Sannel.House.Control.Business.Design;
using Sannel.House.Control.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sannel.House.Control.Business.ViewModels
{
	public class ViewModelLocator
	{
		private static List<IUpdate> toUpdate = new List<IUpdate>();
		private static DispatcherTimer timer = new DispatcherTimer();
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			if (ViewModelBase.IsInDesignModeStatic)
			{
				SimpleIoc.Default.Register<IMainViewModel, DesignMainViewModel>();
			}
			else
			{
				SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();

				toUpdate.Add(Main);
				
				timer.Interval = TimeSpan.FromSeconds(1);
				timer.Tick += Timer_Tick;
				timer.Start();
			}
		}

		private static void Timer_Tick(object sender, object e)
		{
			foreach(var u in toUpdate)
			{
				try
				{
					u.Update();
				}
				catch
				{

				}
			}
		}

		public static IMainViewModel Main
		{
			get
			{
				return SimpleIoc.Default.GetInstance<IMainViewModel>();
			}
		}
	}
}
