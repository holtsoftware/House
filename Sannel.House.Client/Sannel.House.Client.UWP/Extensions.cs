using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sannel.House.Client.UWP
{
	public static class Extensions
	{
		public static Object TryFindResource(this FrameworkElement cur, String key)
		{
			if (Application.Current.Resources.ContainsKey(key))
			{
				return Application.Current.Resources[key];
			}

			FrameworkElement current = cur;
			while (current != null)
			{
				if (current.Resources.ContainsKey(key))
				{
					return current.Resources[key];
				}
				current = current.Parent as FrameworkElement;
			}

			return null;
		}
	}
}
