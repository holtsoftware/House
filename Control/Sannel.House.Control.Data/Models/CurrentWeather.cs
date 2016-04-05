using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class CurrentWeather
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		public DateTime CreatedDate { get; set; } = DateTime.Now;

		[JsonProperty("station_id")]
		public String StationId { get; set; }

		[JsonProperty("observation_time_rfc822")]
		public DateTime ObservationTime { get; set; }

		[JsonProperty("observation_epoch")]
		public long ObservationEpoch { get; set; }
		[JsonProperty("local_time_rfc822")]
		public DateTime LocalTime { get; set; }
		[JsonProperty("local_epoch")]
		public long LocalEpoch { get; set; }
		[JsonProperty("local_tz_long")]
		public String LocalTimeZone { get; set; }
		[JsonProperty("local_tz_offset")]
		public String LocalTimeZoneOffset { get; set; }
		[JsonProperty("weather")]
		public String Weather { get; set; }
		[JsonProperty("temperature_string")]
		public String TemperatureString { get; set; }
		[JsonProperty("temp_f")]
		public float TemperatureF { get; set; }
		[JsonProperty("temp_c")]
		public float TemperatureC { get; set; }
		[JsonProperty("relative_humidity")]
		public String RelativeHumidity { get; set; }
		[JsonProperty("wind_string")]
		public String WindString { get; set; }
		[JsonProperty("icon_url")]
		public String IconUrl { get; set; }
		//"wind_dir":"SW",
		//"wind_degrees":227,
		//"wind_mph":2.7,
		//"wind_gust_mph":"4.9",
		//"wind_kph":4.3,
		//"wind_gust_kph":"7.9",
		//"pressure_mb":"1020",
		//"pressure_in":"30.12",
		//"pressure_trend":"-",
		//"dewpoint_string":"30 F (-1 C)",
		//"dewpoint_f":30,
		//"dewpoint_c":-1,
		//"heat_index_string":"NA",
		//"heat_index_f":"NA",
		//"heat_index_c":"NA",
		//"windchill_string":"NA",
		//"windchill_f":"NA",
		//"windchill_c":"NA",
		//"feelslike_string":"68.2 F (20.1 C)",
		//"feelslike_f":"68.2",
		//"feelslike_c":"20.1",
		//"visibility_mi":"10.0",
		//"visibility_km":"16.1",
		//"solarradiation":"170",
		//"UV":"1.0","precip_1hr_string":"0.00 in ( 0 mm)",
		//"precip_1hr_in":"0.00",
		//"precip_1hr_metric":" 0",
		//"precip_today_string":"0.00 in (0 mm)",
		//"precip_today_in":"0.00",
		//"precip_today_metric":"0",
		//"icon":"cloudy",
		//"forecast_url":"http://www.wunderground.com/US/UT/West_Jordan.html",
		//"history_url":"http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KUTWESTJ25",
		//"ob_url":"http://www.wunderground.com/cgi-bin/findweather/getForecast?query=40.614223,-111.962837",
		//"nowcast":""
	}
}
