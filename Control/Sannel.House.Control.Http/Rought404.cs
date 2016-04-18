using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Sannel.House.Control.Http
{
	public class Rought404 : IRought
	{
		public string Path
		{
			get
			{
				return "";
			}
		}

		public void Request(HttpRequest request, HttpResponse response)
		{
			response.StatusCode = 404;
			using (DataWriter dw = new DataWriter())
			{
				dw.WriteString("<html>\n");
				dw.WriteString("<head>\n");
				dw.WriteString("\t<title>404 Not Found\n");
				dw.WriteString("</head>\n");
				dw.WriteString("<body>\n");
				dw.WriteString("\t<h1>404 Not Found</h1>\n");
				dw.WriteString("</body>\n");
				dw.WriteString("</html>\n");
				response.Output = dw.DetachBuffer();
			}
		}
	}
}
