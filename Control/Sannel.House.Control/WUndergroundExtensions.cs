using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sannel.House.Control.Data.Models;
using Sannel.House.Control.Models;
using Sannel.House.Control.Models.WUnderground;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Sannel.House.Control
{
	public static class WUndergroundExtensions
	{
		public static async Task<CurrentWeather> GetCurrentConditionsAsync(this HttpClient client)
		{
			var set = AppSettings.Current;
			var result = await client.GetStringAsync(new Uri($"http://api.wunderground.com/api/{set.WUndergroundApiKey}/conditions/q/{set.WUndergroundState}/{set.WUndergroundCity}.json"));
			var d = JToken.Parse(result);
			var co = d["current_observation"];
			if (co != null)
			{
				return co.ToObject<CurrentWeather>();
			}

			return null;
		}

		public static async Task<Hourly10Day> GetHourly10Day(this HttpClient client)
		{
			var set = AppSettings.Current;
			var result = await client.GetStringAsync(new Uri($"http://api.wunderground.com/api/{set.WUndergroundApiKey}/hourly10day/q/{set.WUndergroundState}/{set.WUndergroundCity}.json"));
			try
			{
				return JsonConvert.DeserializeObject<Hourly10Day>(result);
			}
			catch
			{
				return null;
			}
		}
	}
}
