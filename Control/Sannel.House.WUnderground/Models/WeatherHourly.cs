using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.WUnderground.Models
{
	public class WeatherHourly
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		public DateTime Date { get; internal set; }
		public float DewPointCelsius { get; internal set; }
		public float DewPointFahrenheit { get; internal set; }
		public float FeelsLikeCelsius { get; internal set; }
		public float FeelsLikeFahrenheit { get; internal set; }
		public float HeatIndexCelsius { get; internal set; }
		public float HeatIndexFahrenheit { get; internal set; }
		public float Humidity { get; internal set; }
		public string IconUrl { get; internal set; }
		public string Icon { get; internal set; }
		public float MSLPMetric { get; internal set; }
		public float MSLPEnglish { get; internal set; }
		public float ProbabilityOfPrecipitation { get; internal set; }
		public float QuantitativePrecipitationForecastEnglish { get; internal set; }
		public float QuantitativePrecipitationForecastMetric { get; internal set; }
		public float Sky { get; internal set; }
		public float SnowMillimeter { get; internal set; }
		public float SnowInches { get; internal set; }
		public float TemperatureCelsius { get; internal set; }
		public float TemperatureFahrenheit { get; internal set; }
		public float UVIndex { get; internal set; }
		public float WindDirectionDegrees { get; internal set; }
		public string WindDirection { get; internal set; }
		public float WindChillCelsius { get; internal set; }
		public float WindChillFahrenheit { get; internal set; }
		public float WindSpeedMPH { get; internal set; }
		public float WindSpeedKPH { get; internal set; }
		public string WX { get; internal set; }
	}
}
