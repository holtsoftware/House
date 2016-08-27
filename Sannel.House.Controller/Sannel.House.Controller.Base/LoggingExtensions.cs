using Sannel.House.Logging.Models;
using Sannel.House.Logging.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Controller
{
	public static class LoggingExtensions
	{
		public const String APPLICATION_ID = "Sannel.House.Controller";
		public const int DEVICE_ID = 1;

		public static Task<bool> LogMessageAsync(this LoggingManager manager, String message)
		{
			if(manager == null)
			{
				throw new ArgumentNullException(nameof(manager));
			}

			ApplicationLogEntry entry = new ApplicationLogEntry();
			entry.ApplicationId = APPLICATION_ID;
			entry.DeviceId = DEVICE_ID;
			entry.Message = message;
			return manager.LogApplicationEntry(entry);
		}
	}
}
