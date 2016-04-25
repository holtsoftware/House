using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Http
{
	public class Error500 : SyncBase
	{
		private Exception ex;
		public Error500(Exception ex)
		{
			this.ex = ex;
		}

		public override string Path
		{
			get
			{
				return "";
			}
		}

		public override void Request(HttpRequest request, HttpResponse response)
		{
			response.StatusCode = 500;
			var sb = response.Output = new StringBuilder();
			sb.AppendLine("<html>");
			sb.AppendLine("<head><title>Server Error</title></head>");
			sb.AppendLine("<body>");
			sb.AppendLine("\t<h1>Server Error</h1>");
			if(ex != null)
			{
				sb.AppendLine("<pre style=\"background: cyan\">");
				sb.AppendLine(ex.ToString());
				sb.AppendLine("</pre>");
			}
			sb.AppendLine("</body></html>");
		}
	}
}
