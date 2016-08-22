using Sannel.House.Client.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Sannel.House.Client.UWP.Converters
{
	public class TimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null)
			{
				var dt = (DateTime)value;
				return new TimeItem()
				{
					Value = new DateTime(1, 1, 1, dt.Hour, dt.Minute, 0)
				};
			}
			else
			{
				return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value != null)
			{
				var dt = (TimeItem)value;
				return dt.Value;
			}
			else
			{
				return null;
			}
		}
	}
}
