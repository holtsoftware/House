using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Sannel.House.Control.Http
{
	public class HttpResponse
	{
		public int StatusCode { get; set; } = 200;
		public ContentType ContentType { get; set; }
		public StringBuilder Output { get; set; }
	}
}
