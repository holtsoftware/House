using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Sannel.House.Client.UWP.Converters
{
	public class TemperatureConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			double v = (double)value;
			return (int)v.CelsiusToFahrenheit();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			int i = (int)value;
			return ((double)i).FahrenheitToCelsius();
		}
	}
}
