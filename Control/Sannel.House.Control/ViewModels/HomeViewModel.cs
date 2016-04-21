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
using Sannel.House.Control.Data;
using Sannel.House.Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Web.Http;

namespace Sannel.House.Control.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public HomeViewModel(WeatherViewModel wvm, TemperatureViewModel temp)
		{
			Weather = wvm;
			Temperature = temp;
		}

		private WeatherViewModel weatherViewModel;
		public WeatherViewModel Weather
		{
			get
			{
				return weatherViewModel;
			}
			set
			{
				Set(ref weatherViewModel, value);
			}
		}

		private TemperatureViewModel temperatureViewModel;

		public TemperatureViewModel Temperature
		{
			get { return temperatureViewModel; }
			set { temperatureViewModel = value; }
		}

		//protected override async void OnInitialize()
		//{
		//	base.OnInitialize();
		//	//TimerViewModel.Current.HourTick += updateWeather;
		//	//TimerViewModel.Current.DayTick += dayTick;
		//	//await Task.Run(() =>
		//	//{
		//	//	using (Context context = new Context())
		//	//	{
		//	//		var w = context.CurrentWeather.OrderByDescending(i => i.CreatedDate).FirstOrDefault();
		//	//		updateCurrentConditions(w);
		//	//		HourlyWeather = context.HourlyWeather.Where(i => i.Hour > DateTime.Now).OrderBy(i => i.Hour).Take(4).ToList().Select(i => new HourlyItem(i)).ToList();
		//	//	}
		//	//});
		//}

		//private async void dayTick()
		//{
		//	var set = AppSettings.Current;
		//	if (!String.IsNullOrWhiteSpace(set.WUndergroundApiKey) && !string.IsNullOrWhiteSpace(set.WUndergroundCity) && !String.IsNullOrWhiteSpace(set.WUndergroundState))
		//	{
		//		try
		//		{
		//			Astronomy a;
		//			using (HttpClient client = new HttpClient())
		//			{
		//				a = await client.GetAstronomyAsync();
		//			}
		//			if(a != null)
		//			{
		//				var aw = a.ToAstronomyWeather();
		//				using (Context c = new Context())
		//				{
		//					c.AstronomyWeather.Add(aw);
		//					await c.SaveChangesAsync();
		//				}
		//			}
		//		}
		//		catch(Exception ex)
		//		{

		//		}
		//	}
		//}

		//private void updateAstronomy(AstronomyWeather aw)
		//{

		//}

		//public void updateWeather()
		//{
		//	Task.Run((Action)updateCurrentWeather);
		//}

		//public async void updateCurrentWeather()
		//{
		//	var set = AppSettings.Current;
		//	if (!String.IsNullOrWhiteSpace(set.WUndergroundApiKey) && !string.IsNullOrWhiteSpace(set.WUndergroundCity) && !String.IsNullOrWhiteSpace(set.WUndergroundState))
		//	{
		//		CurrentWeather weather = null;
		//		try
		//		{
		//			using (HttpClient client = new HttpClient())
		//			{
		//				weather = await client.GetCurrentConditionsAsync();
		//			}
		//		}
		//		catch(Exception ex)
		//		{

		//		}
		//		logCurrentWeather(weather);

		//		Hourly hourly = null;
		//		try
		//		{
		//			using (HttpClient client = new HttpClient())
		//			{
		//				hourly = await client.GetHourly();
		//			}
		//		}
		//		catch { }
		//		logHourly(hourly);

		//	}
		//}

		//private void logHourly(Hourly h10day)
		//{
		//	if(h10day != null)
		//	{
		//		using (Context context = new Context())
		//		{
		//			foreach(var i in h10day.hourly_forecast)
		//			{
		//				var id = new DateTime(int.Parse(i.FCTTIME.year), int.Parse(i.FCTTIME.mon), int.Parse(i.FCTTIME.mday), int.Parse(i.FCTTIME.hour), 0, 0);
		//				var hw = context.HourlyWeather.FirstOrDefault(j => j.Hour == id);
		//				if(hw == null)
		//				{
		//					hw = new HourlyWeather();
		//					hw.Hour = id;
		//					context.HourlyWeather.Add(hw);
		//				}
		//				hw.Condition = i.condition;
		//				hw.DewPointC = i.dewpoint.metric;
		//				hw.DewPointF = i.dewpoint.english;
		//				hw.fctcode = i.fctcode;
		//				hw.FeelsLikeC = i.dewpoint.metric;
		//				hw.FeelsLikeF = i.dewpoint.english;
		//				hw.HeatIndexC = i.heatindex.metric;
		//				hw.HeatIndexF = i.heatindex.english;
		//				hw.Humidity = i.humidity;
		//				hw.Icon = i.icon;
		//				hw.IconUrl = i.icon_url;
		//				hw.MSLPInches = i.mslp.english;
		//				hw.MSLPMetric = i.mslp.metric;
		//				hw.POP = i.pop;
		//				hw.QPFInches = i.qpf.english;
		//				hw.QPFMetric = i.qpf.metric;
		//				hw.Sky = i.sky;
		//				hw.SnowInches = i.qpf.english;
		//				hw.SnowMetric = i.qpf.metric;
		//				hw.TempC = i.temp.metric;
		//				hw.TempF = i.temp.english;
		//				hw.UVI = i.uvi;
		//				hw.WindChillC = i.windchill.metric;
		//				hw.WindChillF = i.windchill.english;
		//				hw.WindDirection = i.wdir.dir;
		//				hw.WindDirectionDegrees = i.wdir.degrees;
		//				hw.WindSpeedKPH = i.wspd.metric;
		//				hw.WindSpeedMPH = i.wspd.english;
		//				hw.WX = i.wx;
		//			}
		//			context.SaveChanges();

		//			HourlyWeather = context.HourlyWeather.Where(i => i.Hour > DateTime.Now).OrderBy(i => i.Hour).Take(4).ToList().Select(i => new HourlyItem(i)).ToList();
		//		}
		//	}
		//}

		//private void logCurrentWeather(CurrentWeather weather)
		//{
		//	if (weather != null)
		//	{
		//		using (Context context = new Context())
		//		{
		//			context.CurrentWeather.Add(weather);
		//			context.SaveChanges();
		//			var w = context.CurrentWeather.OrderByDescending(i=>i.CreatedDate).FirstOrDefault();
		//			updateCurrentConditions(w);
		//		}
		//	}
		//}

		//private void updateCurrentConditions(CurrentWeather weather)
		//{
		//	if(weather != null)
		//	{
		//		Weather = weather.Weather;
		//		TemperatureF = weather.TemperatureF;
		//		IconUrl = weather.IconUrl.GetLocalIconFromWeb();
		//	}
		//}

		////protected void updateWeather(CurrentWeather weather)
		////{
		////	if (weather != null)
		////	{
		////		Weather = weather.Weather;
		////		TemperatureF = weather.TemperatureF;
		////		IconUrl = weather.IconUrl;
		////	}
		////}


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
		//		Set(ref iconUrl, value);
		//	}
		//}


		//private String weather;

		///// <summary>
		///// Gets or sets Weather.
		///// </summary>
		///// <value>
		///// The Weather.
		///// </value>
		//public String Weather
		//{
		//	get { return weather; }
		//	set
		//	{
		//		Set(ref weather, value);
		//	}
		//}


		//private float temperatureF;

		///// <summary>
		///// Gets or sets TemperatureF.
		///// </summary>
		///// <value>
		///// The TemperatureF.
		///// </value>
		//public float TemperatureF
		//{
		//	get { return temperatureF; }
		//	set
		//	{
		//		Set(ref temperatureF, value);
		//	}
		//}


		//private IList<HourlyItem> hourlyWeather;

		///// <summary>
		///// Gets or sets HourlyWeather.
		///// </summary>
		///// <value>
		///// The HourlyWeather.
		///// </value>
		//public IList<HourlyItem> HourlyWeather
		//{
		//	get { return hourlyWeather; }
		//	set
		//	{
		//		Set(ref hourlyWeather, value);
		//	}
		//}
	}
}
