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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sannel.House.Control.Data.Models;
using Sannel.House.Control.Models;
using Sannel.House.Control.Models.WUnderground;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;
using WinRTXamlToolkit.Async;
using WinRTXamlToolkit.IO.Extensions;
using WinRTXamlToolkit.Imaging;
using Windows.Graphics.Imaging;

namespace Sannel.House.Control
{
	public static class WUndergroundExtensions
	{
		public static bool WUndergroundSetup(this AppSettings set)
		{
			if(set == null)
			{
				return false;
			}

			return !String.IsNullOrWhiteSpace(set.WUndergroundApiKey) && !string.IsNullOrWhiteSpace(set.WUndergroundCity) && !String.IsNullOrWhiteSpace(set.WUndergroundState);
		}
		public static async Task<Conditions> GetCurrentConditionsAsync(this HttpClient client)
		{
			var set = AppSettings.Current;
			var result = await client.GetStringAsync(new Uri($"http://api.wunderground.com/api/{set.WUndergroundApiKey}/conditions/q/{set.WUndergroundState}/{set.WUndergroundCity}.json"));

			try
			{
				return JsonConvert.DeserializeObject<Conditions>(result);
			}
			catch
			{
				return null;
			}
		}

		public static async Task<Hourly> GetHourly(this HttpClient client)
		{
			var set = AppSettings.Current;
			var result = await client.GetStringAsync(new Uri($"http://api.wunderground.com/api/{set.WUndergroundApiKey}/hourly/q/{set.WUndergroundState}/{set.WUndergroundCity}.json"));
			try
			{
				return JsonConvert.DeserializeObject<Hourly>(result);
			}
			catch
			{
				return null;
			}
		}

		public static async Task<Astronomy> GetAstronomyAsync(this HttpClient client)
		{
			var set = AppSettings.Current;
			var result = await client.GetStringAsync(new Uri($"http://api.wunderground.com/api/{set.WUndergroundApiKey}/astronomy/q/{set.WUndergroundState}/{set.WUndergroundCity}.json"));
			try
			{
				return JsonConvert.DeserializeObject<Astronomy>(result);
			}
			catch
			{
				return null;
			}
		}

		public static WeatherAstronomy ToWeatherAstronomy(this Astronomy astronomy)
		{
			if(astronomy == null)
			{
				return null;
			}
			var wa = new WeatherAstronomy();
			astronomy.CopyTo(wa);
			return wa;
		}

		public static void CopyTo(this Astronomy astronomy, WeatherAstronomy wa)
		{
			if(astronomy != null && wa != null)
			{
				var mp = astronomy.moon_phase;
				if(mp != null)
				{
					var current = DateTime.Now;
					int h, m;
					if(int.TryParse(mp.sunrise?.hour, out h) && int.TryParse(mp.sunrise?.minute, out m))
					{
						wa.Sunrise = new DateTime(current.Year, current.Month, current.Day, h, m, 0);
					}
					if(int.TryParse(mp.sunset?.hour, out h) && int.TryParse(mp.sunset?.minute, out m))
					{
						wa.Sunset = new DateTime(current.Year, current.Month, current.Day, h, m, 0);
					}
					float f;
					if(float.TryParse(mp.percentIlluminated, out f))
					{
						wa.PercentIlluminated = f / 100.0f;
					}
					if(float.TryParse(mp.ageOfMoon, out f))
					{
						wa.AgeOfMoon = f;
					}
				}
			}
		}

		public static WeatherCondition ToWeatherCondition(this Conditions conditions)
		{
			if(conditions == null)
			{
				return null;
			}
			var wc = new WeatherCondition();
			conditions.CopyTo(wc);
			return wc;
		}

		public static void CopyTo(this Conditions conditions, WeatherCondition wc)
		{
			if(conditions != null && wc != null)
			{
				if(conditions.current_observation != null)
				{
					var co = conditions.current_observation;
					wc.DewPointCelsius = co.dewpoint_c;
					wc.DewPointFahrenheit = co.dewpoint_f;
					float f;
					if(float.TryParse(co.feelslike_c, out f))
					{
						wc.FeelsLikeCelsius = f;
					}
					if(float.TryParse(co.feelslike_f, out f))
					{
						wc.FeelsLikeFahrenheit = f;
					}
					if(float.TryParse(co.heat_index_c, out f))
					{
						wc.HeatIndexCelsius = f;
					}
					if(float.TryParse(co.heat_index_f, out f))
					{
						wc.HeatIndexFahrenheit = f;
					}
					wc.Icon = co.icon;
					wc.IconUrl = co.icon_url;
					long l;
					if(long.TryParse(co.local_epoch, out l))
					{
						wc.LocalEpoch = l;
					}
					DateTime dt;
					if(DateTime.TryParse(co.local_time_rfc822, out dt))
					{
						wc.LocalTime = dt;
					}
					if(float.TryParse(co.precip_1hr_in, out f))
					{
						wc.Precipitation1HourInches = f;
					}
					if(float.TryParse(co.precip_1hr_metric, out f))
					{
						wc.Precipitation1HourMetric = f;
					}
					if(float.TryParse(co.precip_today_in, out f))
					{
						wc.PrecipitationTodayInches = f;
					}
					if(float.TryParse(co.precip_today_metric, out f))
					{
						wc.PrecipitationTodayMetric = f;
					}
					if(float.TryParse(co.pressure_in, out f))
					{
						wc.PresureInches = f;
					}
					if(float.TryParse(co.pressure_mb, out f))
					{
						wc.PresureMillibar = f;
					}
					wc.PresureTrending = co.pressure_trend;
					if(float.TryParse(co.relative_humidity?.Replace("%",""), out f))
					{
						wc.RelativeHumidity = f;
					}
					wc.SolarRadiation = co.solarradiation;
					wc.StationId = co.station_id;
					wc.TempratureCelsius = co.temp_c;
					wc.TempratureFahrenheit = co.temp_f;
					if(float.TryParse(co.UV, out f))
					{
						wc.UV = f;
					}
					if(float.TryParse(co.visibility_mi, out f))
					{
						wc.VisibilityMiles = f;
					}
					if(float.TryParse(co.visibility_km, out f))
					{
						wc.VisibilityKilometers = f;
					}
					wc.Weather = co.weather;
					if(float.TryParse(co.windchill_f, out f))
					{
						wc.WindChillFahrenheit = f;
					}
					if(float.TryParse(co.windchill_c, out f))
					{
						wc.WindChillCelsius = f;
					}
					wc.WindDegrees = co.wind_degrees;
					wc.WindDirection = co.wind_dir;
					if(float.TryParse(co.wind_gust_mph, out f))
					{
						wc.WindGustMilesPerHour = f;
					}
					if(float.TryParse(co.wind_gust_kph, out f))
					{
						wc.WindGustKilometersPerHour = f;
					}
					wc.WindKilometerPerHour = co.wind_kph;
					wc.WindMilesPerHour = co.wind_mph;
				}
			}
		}

		/// <summary>
		/// To the astronomy weather.
		/// </summary>
		/// <param name="astronomy">The astronomy.</param>
		/// <returns></returns>
		//public static AstronomyWeather ToAstronomyWeather(this Astronomy astronomy)
		//{
		//	if(astronomy == null)
		//	{
		//		return null;
		//	}
		//	var mp = astronomy.moon_phase;
		//	if(mp == null)
		//	{
		//		return null;
		//	}
		//	AstronomyWeather aw = new AstronomyWeather();
		//	var n = DateTime.Now;
		//	int h,m;
		//	if(int.TryParse(mp.sunrise?.hour, out h) && int.TryParse(mp.sunrise?.minute, out m))
		//	{
		//		aw.Sunrise = new DateTime(n.Year, n.Month, n.Day, h, m, 0);
		//	}
		//	if(int.TryParse(mp.sunset?.hour, out h) && int.TryParse(mp.sunset?.minute, out m))
		//	{
		//		aw.Sunset = new DateTime(n.Year, n.Month, n.Day, h, m, 0);
		//	}
		//	float f;
		//	if(float.TryParse(mp.percentIlluminated, out f))
		//	{
		//		aw.PercentIlluminated = f;
		//	}
		//	if(float.TryParse(mp.ageOfMoon, out f))
		//	{
		//		aw.AgeOfMoon = f;
		//	}
		//	return aw;
		//}

		private static AsyncLock iconCacheLock = new AsyncLock();

		public static String GetLocalIconFromWeb(this String url)
		{
			if(url == null)
			{
				return url;
			}

			UriBuilder builder = new UriBuilder(url);
			var file = Path.GetFileName(builder.Path);
			builder.Scheme = "ms-appx";
			builder.Host = "";
			builder.Path = $"///Assets/Icons/{file}";

			return builder.ToString();
		}

		public static String GetSmallerLocalIconFromWeb(this String url)
		{
			if (url == null)
			{
				return url;
			}

			UriBuilder builder = new UriBuilder(url);
			var file = Path.GetFileName(builder.Path);
			builder.Scheme = "ms-appx";
			builder.Host = "";
			builder.Path = $"///Assets/Icons/25/{file}";

			return builder.ToString();
		}
	}
}
