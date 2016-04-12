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
using Sannel.House.Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Control;
using Sannel.House.Control.Data;
using Windows.Web.Http;

namespace Sannel.House.Control.ViewModels
{
	public class WeatherViewModel : SubViewModel
	{
		public WeatherViewModel(TimerViewModel tvm)
		{
			tvm.Tick += tick;
			tvm.HourTick += hourTick;
			tvm.DayTick += dayTick;
			using (SqliteContext context = new SqliteContext())
			{
				updateCurrentConditions(context.WeatherConditions.OrderByDescending(i => i.CreatedDate).FirstOrDefault());
				updateAstronomy(context.WeatherAstronomies.OrderBy(i => i.CreatedDate).FirstOrDefault());
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			
		}

		private void tick()
		{
		}

		private void hourTick()
		{
			pullCurrentConditions();
		}

		private void dayTick()
		{
			pullAstronomy();
		}

		private async void pullCurrentConditions()
		{
			if (AppSettings.Current.WUndergroundSetup())
			{
				WeatherCondition cw;
				try
				{
					using (var client = new HttpClient())
					{
						var w = await client.GetCurrentConditionsAsync();
						cw = w.ToWeatherCondition();
					}
					if (cw != null)
					{
						using (SqliteContext context = new SqliteContext())
						{
							context.WeatherConditions.Add(cw);
							await context.SaveChangesAsync();
						}
						updateCurrentConditions(cw);
					}
				}
				catch { }
			}
		}

		private async void pullAstronomy()
		{
			if (AppSettings.Current.WUndergroundSetup())
			{
				try
				{
					WeatherAstronomy wa;
					using(var client = new HttpClient())
					{
						var w = await client.GetAstronomyAsync();
						wa = w.ToWeatherAstronomy();
					}
					if(wa != null)
					{
						using (SqliteContext context = new SqliteContext())
						{
							context.WeatherAstronomies.Add(wa);
							await context.SaveChangesAsync();
						}
						updateAstronomy(wa);
					}
				}
				catch { }
			}
		}

		private void updateCurrentConditions(WeatherCondition cw)
		{
			if(cw != null)
			{
				IconUrl = cw.IconUrl.GetLocalIconFromWeb();
				Conditions = cw.Weather;
				Temperature = $"{cw.TempratureFahrenheit:00.0}";
			}
		}

		private void updateAstronomy(WeatherAstronomy wa)
		{
			if(wa != null)
			{
				Sunrise = wa.Sunrise.ToString("hh:mm tt");
				Sunset = wa.Sunset.ToString("hh:mm tt");
				PercentIlluminated = $"{wa.PercentIlluminated:P}";
				AgeOfMoon = $"{wa.AgeOfMoon}";
			}
		}

		private String iconUrl;
		/// <summary>
		/// Gets or sets the icon URL.
		/// </summary>
		/// <value>
		/// The icon URL.
		/// </value>
		public String IconUrl
		{
			get
			{
				return iconUrl;
			}
			set
			{
				Set(ref iconUrl, value);
			}
		}

		private String conditions;
		public String Conditions
		{
			get
			{
				return conditions;
			}
			set
			{
				Set(ref conditions, value);
			}
		}

		private String temperature;
		public String Temperature
		{
			get { return temperature; }
			set { Set(ref temperature, value); }
		}

		private String sunrise;
		public String Sunrise
		{
			get { return sunrise; }
			set { Set(ref sunrise, value); }
		}

		private String sunset;
		public String Sunset
		{
			get { return sunset; }
			set { Set(ref sunset, value); }
		}

		private String percentIlluminated;
		public String PercentIlluminated
		{
			get { return percentIlluminated; }
			set { Set(ref percentIlluminated, value); }
		}

		private String ageOfMoon;
		public String AgeOfMoon
		{
			get { return ageOfMoon; }
			set { Set(ref ageOfMoon, value); }
		}
	}
}
