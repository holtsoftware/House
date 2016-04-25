using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

		public Dictionary<String, String> Headers { get; internal set; } = new Dictionary<String, String>();
		public string RootPath { get; internal set; }
		public string Data { get; internal set; }

		internal void AddHeader(string line)
		{
			if(line != null)
			{
				var parts = line.Split(':');
				if(parts.Length > 1)
				{
					Headers[parts[0]] = parts[1];
				}
			}
		}
	}
}
