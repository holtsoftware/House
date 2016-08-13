using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Exceptions
{
	public class ServerException : Exception
	{
		public int StatusCode { get; set; }
		public ServerException(string message, int statusCode) : base(message)
		{
			StatusCode = statusCode;
		}

		public ServerException(string message, int statusCode, Exception innerException) : base(message, innerException)
		{
			StatusCode = statusCode;
		}
	}
}
