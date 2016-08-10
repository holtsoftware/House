using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Client.Exceptions
{
	public class NotLoggedInException : Exception
	{
		public NotLoggedInException(string message) : base(message)
		{
		}

		public NotLoggedInException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
