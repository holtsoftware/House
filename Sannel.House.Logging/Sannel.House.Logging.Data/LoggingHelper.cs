using Newtonsoft.Json;
using Sannel.House.Logging.Data;
using Sannel.House.Logging.Interface;
using Sannel.House.Logging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Logging.Data
{
	public sealed class LoggingHelper : IDisposable
	{
		public void Dispose()
		{
			dbContext?.Dispose();
		}

		private IDbContext dbContext;

		public LoggingHelper()
		{
			dbContext = new LoggingContext();
		}

		public LoggingHelper(IDbContext context)
		{
			dbContext = context;
		}

		public bool LogEntry(String logType, String message)
		{
			if(logType == null)
			{
				throw new ArgumentNullException(nameof(logType));
			}

			if(message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			try
			{
				switch (logType)
				{
					case nameof(ApplicationLogEntry):
						var result = JsonConvert.DeserializeObject<ApplicationLogEntry>(message);
						result.Id = Guid.NewGuid();
						result.EntryDateTime = DateTime.Now;
						result.Synced = false;
						dbContext.ApplicationLogEntries.Add(result);
						dbContext.SaveChanges();
						return true;
				}
			}
			catch (JsonSerializationException)
			{
			}

			return false;
		}
	}
}
