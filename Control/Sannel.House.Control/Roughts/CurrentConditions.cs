using Sannel.House.Control.Data;
using Sannel.House.Control.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Roughts
{
	public class CurrentConditions : IRought
	{
		public string Path
		{
			get
			{
				return "/currentconditions";
			}
		}

		public void Request(HttpRequest request, HttpResponse response)
		{
			response.ContentType = ContentType.Html;
			response.StatusCode = 200;
			var ou = response.Output = new StringBuilder();
			ou.AppendLine("<html><head>");
			using (var context = new SqliteContext())
			{
				var current = context.WeatherConditions.OrderByDescending(i => i.CreatedDate).FirstOrDefault();
				ou.AppendLine($"<title>Conditions as of {current.LocalTime}</title>");
				ou.AppendLine("</head><body>");
				ou.AppendLine($"<img src='{current.IconUrl}' /><br />");
				ou.AppendLine($"{current.Weather}<br />");
				ou.AppendLine($"{current.TempratureFahrenheit}<br />");
				ou.AppendLine("</body></html>");

			}
		}
	}
}
