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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using WinRTXamlToolkit.IO.Extensions;

namespace Sannel.House.Control.Models
{
	public class HourlyItem : INotifyPropertyChanged
	{
		//public HourlyItem(HourlyWeather weather)
		//{
		//	IconUrl = weather.IconUrl;
		//	FriendlyHour = weather.Hour.ToString("hh tt");
		//	float f = 0;
		//	if (float.TryParse(weather.TempF, out f))
		//	{
		//		TempF = f;
		//	}
		//	Condition = weather.Condition;
		//}


		//private String iconUrl;

		///// <summary>
		///// Gets or sets IconUrl.
		///// </summary>
		///// <value>
		///// The IconUrl.
		///// </value>
		//public String IconUrl
		//{
		//	get { return iconUrl; }
		//	set
		//	{
		//		var v = value;
		//		if (v != null)
		//		{
		//			Set(ref iconUrl, v.GetSmallerLocalIconFromWeb());
		//		}
		//	}
		//}


		//private String friendlyHour;

		///// <summary>
		///// Gets or sets FriendlyHour.
		///// </summary>
		///// <value>
		///// The FriendlyHour.
		///// </value>
		//public String FriendlyHour
		//{
		//	get { return friendlyHour; }
		//	set
		//	{
		//		Set(ref friendlyHour, value);
		//	}
		//}


		//private float tempf;

		///// <summary>
		///// Gets or sets TempF.
		///// </summary>
		///// <value>
		///// The TempF.
		///// </value>
		//public float TempF
		//{
		//	get { return tempf; }
		//	set
		//	{
		//		Set(ref tempf, value);
		//	}
		//}


		//private String condition;

		///// <summary>
		///// Gets or sets Condition.
		///// </summary>
		///// <value>
		///// The Condition.
		///// </value>
		//public String Condition
		//{
		//	get { return condition; }
		//	set
		//	{
		//		Set(ref condition, value);
		//	}
		//}
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
