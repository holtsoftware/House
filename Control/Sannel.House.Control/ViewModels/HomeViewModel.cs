using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sannel.House.Control.Data;
using Sannel.House.Control.Data.Models;
using Sannel.House.Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Sannel.House.Control.ViewModels
{
	public class HomeViewModel : SubViewModel
	{

		protected override void OnInitialize()
		{
			base.OnInitialize();
			TimerViewModel.Current.HourTick += updateCurrentWeather;
		}

		public void updateCurrentWeather()
		{
			Task.Run(async () =>
			{
				var set = AppSettings.Current;
				if (!String.IsNullOrWhiteSpace(set.WUndergroundApiKey) && !string.IsNullOrWhiteSpace(set.WUndergroundCity) && !String.IsNullOrWhiteSpace(set.WUndergroundState))
				{
					CurrentWeather weather = null;
					try
					{
						using (HttpClient client = new HttpClient())
						{
							var result = await client.GetAsync($"http://api.wunderground.com/api/{set.WUndergroundApiKey}/conditions/q/{set.WUndergroundState}/{set.WUndergroundCity}.json");
							var data = await result.Content.ReadAsStringAsync();
							var d = JToken.Parse(data);
							var co = d["current_observation"];
							if (co != null)
							{
								weather = co.ToObject<CurrentWeather>();
							}
						}
					}
					catch(Exception ex)
					{

					}
					logCurrentWeather(weather);
				}
			});
		}

		private void logCurrentWeather(CurrentWeather weather)
		{
			if (weather != null)
			{
				using (Context context = new Context())
				{
					context.CurrentWeather.Add(weather);
					context.SaveChanges();
					var w = context.CurrentWeather.OrderByDescending(i=>i.CreatedDate).FirstOrDefault();
					updateWeather(w);
				}
			}
		}

		protected void updateWeather(CurrentWeather weather)
		{
			Weather = weather.Weather;
			TemperatureF = weather.TemperatureF;
			IconUrl = weather.IconUrl;
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
				Set(ref iconUrl, value);
			}
		}


		private String weather;

		/// <summary>
		/// Gets or sets Weather.
		/// </summary>
		/// <value>
		/// The Weather.
		/// </value>
		public String Weather
		{
			get { return weather; }
			set
			{
				Set(ref weather, value);
			}
		}


		private float temperatureF;

		/// <summary>
		/// Gets or sets TemperatureF.
		/// </summary>
		/// <value>
		/// The TemperatureF.
		/// </value>
		public float TemperatureF
		{
			get { return temperatureF; }
			set
			{
				Set(ref temperatureF, value);
			}
		}
	}
}
