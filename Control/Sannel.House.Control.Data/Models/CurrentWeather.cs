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
		[JsonProperty("wind_dir")]
		public String WindDirection { get; set; }
		[JsonProperty("wind_degrees")]
		public String WindDegrees { get; set; }
		[JsonProperty("wind_mph")]
		public String WindMPH { get; set; }

		[JsonProperty("wind_gust_mph")]
		public String WindGustMPH { get; set; }
		[JsonProperty("wind_kph")]
		public String WindKPH { get; set; }
		[JsonProperty("wind_gust_kph")]
		public String WindGustKPH { get; set; }
		[JsonProperty("pressure_mb")]
		public String PressureMB { get; set; }
		[JsonProperty("pressure_in")]
		public String PressureIN { get; set; }
		[JsonProperty("pressure_trend")]
		public String PressureTrend { get; set; }
		[JsonProperty("dewpoint_f")]
		public float DewPointF { get; set; }
		[JsonProperty("dewpoint_c")]
		public float DewPointC { get; set; }
		[JsonProperty("heat_index_f")]
		public String HeatIndexF { get; set; }
		[JsonProperty("heat_index_c")]
		public String HeatIndexC { get; set; }
		[JsonProperty("windchill_f")]
		public String WindChillF { get; set; }
		[JsonProperty("windchill_c")]
		public String WindChillC { get; set; }
		[JsonProperty("feelslike_f")]
		public String FeelsLikeF { get; set; }
		[JsonProperty("feelslike_c")]
		public String FeelsLikeC { get; set; }
		[JsonProperty("visibility_mi")]
		public String VisibilityMiles { get; set; }
		[JsonProperty("visibility_km")]
		public String VisibilityKilometer { get; set; }
		[JsonProperty("solarradiation")]
		public String SolarRadiation { get; set; }
		[JsonProperty("UV")]
		public String UV { get; set; }
		[JsonProperty("precip_1hr_in")]
		public String PrecipitationPerHourInches { get; set; }
		[JsonProperty("precip_1hr_metric")]
		public String PrecipitationPerHourMetric { get; set; }
		[JsonProperty("precip_today_in")]
		public String PrecipitationTodayInches { get; set; }
		[JsonProperty("precip_today_metric")]
		public String PrecipitationTodayMetric { get; set; }
		[JsonProperty("icon")]
		public String Icon { get; set; }
		[JsonProperty("history_url")]
		public String HistoryUrl { get; set; }
		[JsonProperty("nowcast")]
		public String NowCast { get; set; }
	}
}
