using Sannel.House.Control.Data;
using Sannel.House.Control.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Roughts
{
	public class CurrentConditions : SyncBase
	{
		public override string Path
		{
			get
			{
				return "currentconditions";
			}
		}

		public override void Request(HttpRequest request, HttpResponse response)
		{
			response.ContentType = ContentType.Html;
			response.StatusCode = 200;
			var ou = response.Output = new StringBuilder();
			ou.AppendLine("<html><head>");
			ou.AppendLine("<link type='text/css' href='/css/default.css' rel='stylesheet' />");
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
