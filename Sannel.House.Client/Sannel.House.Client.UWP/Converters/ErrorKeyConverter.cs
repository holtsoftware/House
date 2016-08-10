using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Sannel.House.Client.UWP.Converters
{
	public class ErrorKeyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var key = value as String;
			return MM.M.GetString(key);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
