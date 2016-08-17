using Sannel.House.Client.Interfaces;
using Sannel.House.Client.UWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Sannel.House.Client.UWP.Services
{
	public class NavigationService : INavigationService
	{
		private Dictionary<Type, Type> mappings = new Dictionary<Type, Type>();

		public Frame Frame
		{
			get;
			set;
		}

		public void RegisterMapping<IViewModel, TView>()
			where IViewModel : IBaseViewModel
			where TView : BaseView
		{
			mappings[typeof(IViewModel)] = typeof(TView);
		}

		public void Navigate<T>(Object obj) where T : IBaseViewModel
		{
			var type = typeof(T);
			Navigate(type, obj);
		}

		public void Navigate<T>() where T : IBaseViewModel
		{
			Navigate<T>(null);
		}

		public void Navigate(Type t, object parameter)
		{
			if (mappings.ContainsKey(t))
			{
				Frame?.Navigate(mappings[t], parameter);
			}
			else
			{
				throw new Exception($"The type {t} is not mapped and cannot be navigated to.");
			}
		}

		public void Navigate(Type t)
		{
			Navigate(t, null);
		}
	}
}
