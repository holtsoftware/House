using Sannel.House.Client.Interfaces;
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
		public Frame Frame
		{
			get;
			set;
		}

		public void Navigate<T>(Object obj) where T : class
		{
			Frame?.Navigate(typeof(T), obj);
		}
	}
}
