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
			if (mappings.ContainsKey(type))
			{
				Frame?.Navigate(mappings[type], obj);
			}
			else
			{
				throw new Exception($"The type {type} is not mapped and cannot be navigated to.");
			}
		}

		public void Navigate<T>() where T : IBaseViewModel
		{
			Navigate<T>(null);
		}
	}
}
