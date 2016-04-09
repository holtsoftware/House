using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Data.Models
{
	public class HourlyWeather
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();

		public DateTime Hour { get; set; }
		public String TempF { get; set; }
		public String TempC { get; set; }
		public String DewPointF { get; set; }
		public String DewPointC { get; set; }
		public String Condition { get; set; }
		public String Icon { get; set; }
		public String IconUrl { get; set; }
		public String fctcode { get; set; }
		public String Sky { get; set; }
		public String WindSpeedMPH { get; set; }
		public String WindSpeedKPH { get; set; }
		public String WindDirection { get; set; }
		public String WindDirectionDegrees { get; set; }
		public String WX { get; set; }
		public String UVI { get; set; }
		public String Humidity { get; set; }
		public String WindChillF { get; set; }
		public String WindChillC { get; set; }
		public String HeatIndexF { get; set; }
		public String HeatIndexC { get; set; }
		public String FeelsLikeF { get; set; }
		public String FeelsLikeC { get; set; }
		public String QPFInches { get; set; }
		public String QPFMetric { get; set; }
		public String SnowInches { get; set; }
		public String SnowMetric { get; set; }
		public String POP { get; set; }
		public String MSLPInches { get; set; }
		public String MSLPMetric { get; set; }
	}
}
