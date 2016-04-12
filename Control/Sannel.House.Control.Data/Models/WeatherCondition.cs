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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class WeatherCondition
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		public float DewPointCelsius { get; set; }
		public float DewPointFahrenheit { get; set; }
		public float FeelsLikeCelsius { get; set; }
		public float FeelsLikeFahrenheit { get; set; }
		public float HeatIndexCelsius { get; set; }
		public float HeatIndexFahrenheit { get; set; }
		public string Icon { get; set; }
		public string IconUrl { get; set; }
		public long LocalEpoch { get; set; }
		public DateTime LocalTime { get; set; }
		public float Precipitation1HourInches { get; set; }
		public float Precipitation1HourMetric { get; set; }
		public float PrecipitationTodayInches { get; set; }
		public float PrecipitationTodayMetric { get; set; }
		public float PresureInches { get; set; }
		public float PresureMillibar { get; set; }
		public string PresureTrending { get; set; }
		public float RelativeHumidity { get; set; }
		public string SolarRadiation { get; set; }
		public string StationId { get; set; }
		public float TempratureCelsius { get; set; }
		public float TempratureFahrenheit { get; set; }
		public float UV { get; set; }
		public float VisibilityMiles { get; set; }
		public float VisibilityKilometers { get; set; }
		public string Weather { get; set; }
		public float WindChillFahrenheit { get; set; }
		public float WindChillCelsius { get; set; }
		public float WindDegrees { get; set; }
		public string WindDirection { get; set; }
		public float WindGustMilesPerHour { get; set; }
		public float WindGustKilometersPerHour { get; set; }
		public float WindKilometerPerHour { get; set; }
		public float WindMilesPerHour { get; set; }
	}
}
