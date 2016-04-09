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
using Windows.Web.Http;
using WinRTXamlToolkit.Async;
using WinRTXamlToolkit.IO.Extensions;

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

		private static AsyncLock iconCacheLock = new AsyncLock();

		public static async Task<String> GetCachedIconAsync(this String url)
		{
			if(url == null)
			{
				return url;
			}

			Uri u = new Uri(url);
			var path = u.GetComponents(UriComponents.Path, UriFormat.SafeUnescaped);
			var folder = await ApplicationData.Current.LocalCacheFolder.CreateFolderAsync("WUndergroundIcons", CreationCollisionOption.OpenIfExists);
			var fileName = Path.GetFileName(path);
			if(!await folder.ContainsFileAsync(fileName))
			{
				using (await iconCacheLock.LockAsync())
				{
					if (!await folder.ContainsFileAsync(fileName))
					{
						UriBuilder builder = new UriBuilder(u);
						builder.Path = $"/i/c/k/{fileName}";
						using (var client = new HttpClient())
						{
							var iconStream = await client.GetBufferAsync(builder.Uri);
							var fi = await folder.CreateFileAsync(fileName);
							using (var fstream = await fi.OpenAsync(FileAccessMode.ReadWrite))
							{
								await fstream.WriteAsync(iconStream);
							}
						}
					}
				}
			}

			var file = await folder.GetFileAsync(fileName);
			return file.Path;
		}
	}
}
