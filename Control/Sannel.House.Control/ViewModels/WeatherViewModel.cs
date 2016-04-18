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
using Sannel.House.WUnderground;
using Sannel.House.WUnderground.Models;
using System.Collections.ObjectModel;

namespace Sannel.House.Control.ViewModels
{
	public class WeatherViewModel : SubViewModel
	{
		private ObservableCollection<HourlyItem> hourlyItems = new ObservableCollection<HourlyItem>();
		public WeatherViewModel(TimerViewModel tvm)
		{
			tvm.Tick += tick;
			tvm.HalfHourTick += halfHourTick;
			tvm.HourTick += hourTick;
			tvm.DayTick += dayTick;
			using (SqliteContext context = new SqliteContext())
			{
				updateCurrentConditions(context.WeatherConditions.OrderByDescending(i => i.CreatedDate).FirstOrDefault());
				updateAstronomy(context.WeatherAstronomies.OrderBy(i => i.CreatedDate).FirstOrDefault());
				var now = DateTime.Now;
				updateHourly(context.WeatherHourlies.Where(i => i.Date >= now).OrderBy(i => i.Date).Take(4).ToList());
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
		}

		private void tick()
		{
		}

		private void halfHourTick()
		{
			pullHourlyForcast();
			pullCurrentConditions();
		}

		private void hourTick()
		{
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
						var w = await client.GetCurrentConditionsAsync(AppSettings.Current);
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

		private async void pullHourlyForcast()
		{
			if (AppSettings.Current.WUndergroundSetup())
			{
				try
				{
					WUnderground.WModels.Hourly hourly;
					using (var client = new HttpClient())
					{
						hourly = await client.GetHourly(AppSettings.Current);
					}
					if(hourly?.hourly_forecast != null)
					{
						using (SqliteContext context = new SqliteContext())
						{
							foreach(var hf in hourly.hourly_forecast)
							{
								var dt = hf.FCTTIME.ToDateTime();
								var item = context.WeatherHourlies.FirstOrDefault(i => i.Date == dt);
								if(item == null)
								{
									item = new WeatherHourly();
									context.WeatherHourlies.Add(item);
								}
								hf.CopyTo(item);
							}
							await context.SaveChangesAsync();
							var now = DateTime.Now;
							updateHourly(context.WeatherHourlies.Where(i => i.Date >= now).OrderBy(i => i.Date).Take(4).ToList());
						}

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
						var w = await client.GetAstronomyAsync(AppSettings.Current);
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

		private void updateHourly(List<WeatherHourly> items)
		{
			var hitems = items.Select(i => new HourlyItem(i)).ToList();
			var toRemove = new List<HourlyItem>();
			var toAdd = new List<HourlyItem>();
			foreach(var hi in hitems)
			{
				if (!hourlyItems.Contains(hi))
				{
					toAdd.Add(hi);
				}
			}
			foreach(var hi in hourlyItems)
			{
				if (!hitems.Contains(hi))
				{
					toRemove.Add(hi);
				}
			}
			foreach(var hi in toRemove)
			{
				hourlyItems.Remove(hi);
			}
			foreach(var hi in toAdd)
			{
				hourlyItems.Add(hi);
			}
		}

		private void updateCurrentConditions(WeatherCondition cw)
		{
			if(cw != null)
			{
				IconUrl = cw.IconUrl.GetLocalIconFromWeb();
				Conditions = cw.Weather;
				Temperature = $"{cw.TempratureFahrenheit:00.0}";
				Humidity = cw.RelativeHumidity.ToString("p0");
				UpdatedTime = cw.LocalTime.ToString("hh:mm tt");
			}
		}

		private void updateAstronomy(WeatherAstronomy wa)
		{
			if(wa != null)
			{
				Sunrise = wa.Sunrise.ToString("hh:mm tt");
				Sunset = wa.Sunset.ToString("hh:mm tt");
				PercentIlluminated = $"{wa.PercentIlluminated:P0}";
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

		private string updatedTime;
		public String UpdatedTime
		{
			get { return updatedTime; }
			set { Set(ref updatedTime, value); }
		}

		private String temperature;
		public String Temperature
		{
			get { return temperature; }
			set { Set(ref temperature, value); }
		}

		private String humidity;
		public String Humidity
		{
			get { return humidity; }
			set { Set(ref humidity, value); }
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

		public ObservableCollection<HourlyItem> HourlyItems
		{
			get
			{
				return hourlyItems;
			}
		}
	}
}
