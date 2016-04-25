using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Control.Http;
using Sannel.House.Control.Data;
using Sannel.House.Control.HttpHelpers;
using Newtonsoft.Json;

namespace Sannel.House.Control.Roughts.Authenticated
{
	public class Devices : DBAuthenticated
	{
		public override string Path
		{
			get
			{
				return "devices";
			}
		}
		public override async Task AuthenticatedRequestAsync(HttpRequest request, HttpResponse response)
		{
			switch (request.RequestType)
			{
				case HttpRequestType.GET:
					if (String.Compare(request.Path, "/devices/addnew", true) == 0)
					{
						await addNew(request, response);
					}
					else
					{
						await listDevicesAsync(request, response);
					}
					break;
			}
		}

		private async Task addNew(HttpRequest request, HttpResponse response, String errors = null)
		{
			response.StatusCode = 200;
			var sb = response.Output = new StringBuilder();
			sb.AppendLine("<html>");
			writeHeader(sb, "Devices");
			sb.AppendLine("<body>");
			sb.AppendLine("<a href='/devices'>Back to list</a><br />");
			sb.AppendLine("<form method='post'>");
			sb.AppendLine("<label for='shortId'>Short Id</label><br />");
			using (var context = new SqliteContext())
			{
				await Task.Run(() =>
				{
					sb.AppendLine($"<input name='shortId' type='text' value='{context.StoredDevices.Max(i => i.ShortId) + 1}' /><br />");
				});
			}
			sb.AppendLine("<label for='name'>Name</label><br />");
			sb.AppendLine("<input name='name' type='text' value='' /><br />");
			sb.AppendLine("<button type='submit'>Save</button>");
			sb.AppendLine("</form>");
			sb.AppendLine("</body></html>");
		}

		private void writeHeader(StringBuilder builder, String title)
		{
			builder.AppendLine("<head>");
			builder.AppendLine($"\t<title>{title}</title>");
			builder.AppendLine("<link type='text/css' href='/css/default.css' rel='stylesheet' />");
			builder.AppendLine("</head>");
		}

		private async Task listDevicesAsync(HttpRequest request, HttpResponse response)
		{
			response.StatusCode = 200;
			var sb = response.Output = new StringBuilder();
			sb.AppendLine("<html>");
			writeHeader(sb, "Devices");
			sb.AppendLine("<body>");
			sb.AppendLine("<table>");
			sb.AppendLine("<thead><tr><th>Long Device Id</th><th>Short Device Id</th><th>Name</th></tr></thead>");
			sb.AppendLine("<tbody data-bind='foreach: Items'>");
			using (var context = new SqliteContext())
			{
				await Task.Run(() =>
				{
					foreach (var item in context.StoredDevices.OrderBy(i => i.ShortId))
					{
						sb.AppendLine("\t<tr>");
						sb.AppendLine($"\t\t<td>{item.Id}</td>");
						sb.AppendLine($"\t\t<td>{item.ShortId}</td>");
						sb.AppendLine($"\t\t<td>{item.Name}</td>");
						sb.AppendLine("\t</tr>");
					}
				});
			}
			sb.AppendLine("</tbody>");
			sb.AppendLine("</table>");
			sb.AppendLine("<a href='/devices/addnew'>Add New</a>");
			sb.AppendLine("</body>");
			sb.AppendLine("</html>");
		}

	}
}
