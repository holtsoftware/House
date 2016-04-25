using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Sannel.House.Control.Http
{
	public class Rought404 : SyncBase
	{
		public override string Path
		{
			get
			{
				return "";
			}
		}

		public override void Request(HttpRequest request, HttpResponse response)
		{
			response.StatusCode = 404;
			var ot = response.Output = new StringBuilder();
			ot.AppendLine("<html>");
			ot.AppendLine("<head>");
			ot.AppendLine("\t<title>404 Not Found</title>");
			ot.AppendLine("</head>");
			ot.AppendLine("<body>");
			ot.AppendLine("\t<h1>404 Not Found</h1>");
			ot.AppendLine("</body>");
			ot.AppendLine("</html>");
		}
	}
}
