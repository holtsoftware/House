using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Control.Http
{
	public class HttpRequest
	{
		public ContentType ContentType { get; internal set; }
		public string Path { get; internal set; }
		public HttpRequestType RequestType { get; internal set; }
	}
}
