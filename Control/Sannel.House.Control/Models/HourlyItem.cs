using Sannel.House.Control.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WinRTXamlToolkit.IO.Extensions;

namespace Sannel.House.Control.Models
{
	public class HourlyItem : INotifyPropertyChanged
	{
		public HourlyItem(HourlyWeather weather)
		{
			IconUrl = weather.IconUrl;
			FriendlyHour = weather.Hour.ToString("hh tt");
			float f = 0;
			if(float.TryParse(weather.TempF, out f))
			{
				TempF = f;
			}
			Condition = weather.Condition;
		}


		private String iconUrl;

		/// <summary>
		/// Gets or sets IconUrl.
		/// </summary>
		/// <value>
		/// The IconUrl.
		/// </value>
		public String IconUrl
		{
			get { return iconUrl; }
			set
			{
				var v = value;
				if(v != null)
				{
					Set(ref iconUrl, v.GetCachedIconAsync().Result);
				}
			}
		}


		private String friendlyHour;

		/// <summary>
		/// Gets or sets FriendlyHour.
		/// </summary>
		/// <value>
		/// The FriendlyHour.
		/// </value>
		public String FriendlyHour
		{
			get { return friendlyHour; }
			set
			{
				Set(ref friendlyHour, value);
			}
		}


		private float tempf;

		/// <summary>
		/// Gets or sets TempF.
		/// </summary>
		/// <value>
		/// The TempF.
		/// </value>
		public float TempF
		{
			get { return tempf; }
			set
			{
				Set(ref tempf, value);
			}
		}


		private String condition;

		/// <summary>
		/// Gets or sets Condition.
		/// </summary>
		/// <value>
		/// The Condition.
		/// </value>
		public String Condition
		{
			get { return condition; }
			set
			{
				Set(ref condition, value);
			}
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
