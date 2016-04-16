/*
   Copyright 2016 Adam Holt

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using Sannel.House.Control.Data.Models;
using Sannel.House.WUnderground.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Sannel.House.WUnderground;

namespace Sannel.House.Control.Models
{
	public class HourlyItem : INotifyPropertyChanged
	{
		public HourlyItem(WeatherHourly hourly)
		{
			if(hourly == null)
			{
				throw new ArgumentNullException(nameof(hourly));
			}
			Key = hourly.Date;
			DisplayTime = hourly.Date.ToString("hh tt");
			IconUrl = hourly.IconUrl;
			Condition = hourly.WX;
			Temperature = hourly.TemperatureFahrenheit.ToString();
			Humidity = hourly.Humidity.ToString("P0");
		}

		private DateTime key;
		public DateTime Key
		{
			get { return key; }
			set { Set(ref key, value); }
		}
		private string humidity;
		public String Humidity
		{
			get { return humidity; }
			set { Set(ref humidity, value); }
		}

		private String displayTime;
		public String DisplayTime
		{
			get { return displayTime; }
			set { Set(ref displayTime, value); }
		}

		private String condition;
		public String Condition
		{
			get { return condition; }
			set { Set(ref condition, value); }
		}

		private String temperature;
		public String Temperature
		{
			get { return temperature; }
			set { Set(ref temperature, value); }
		}

		private String iconUrl;
		public String IconUrl
		{
			get { return iconUrl; }
			set { Set(ref iconUrl, value.GetSmallerLocalIconFromWeb()); }
		}

		public override bool Equals(object obj)
		{
			var hi = obj as HourlyItem;
			if(hi != null)
			{
				return hi.Key == Key;
			}
			return false;
		}

		public static bool operator ==(HourlyItem hi1, HourlyItem hi2)
		{
			return hi1?.Key == hi2?.key;
		}
		public static bool operator !=(HourlyItem hi1, HourlyItem hi2)
		{
			return hi1?.Key != hi2?.key;
		}

		public override int GetHashCode()
		{
			return Key.GetHashCode();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void Set<T>(ref T dest, T source, [CallerMemberName]String propName = null)
		{
			if (!Object.Equals(dest, source))
			{
				dest = source;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
			}
		}
	}
}
