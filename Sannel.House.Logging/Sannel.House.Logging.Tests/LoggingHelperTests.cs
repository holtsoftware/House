using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Sannel.House.Logging.Background;
using Sannel.House.Logging.Data;
using Sannel.House.Logging.Models;
using Sannel.House.Logging.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Logging.Tests
{
	[TestClass]
	public class LoggingHelperTests
	{
		[TestMethod]
		public void LogEntryTest()
		{
			using (var dbContext = new DbContextMock())
			{
				using(var logHelper = new LoggingHelper(dbContext))
				{
					Assert.ThrowsException<ArgumentNullException>(() => logHelper.LogEntry(null, ""));
					Assert.ThrowsException<ArgumentNullException>(() => logHelper.LogEntry("test", null));

					var results = logHelper.LogEntry("test", "{}");
					Assert.IsFalse(results, "LogType of test should return false");
					results = logHelper.LogEntry(nameof(ApplicationLogEntry), "{");
					Assert.IsFalse(results, "Invalid json for message should return false");
					results = logHelper.LogEntry(nameof(ApplicationLogEntry), @"{
	""DeviceId"": -2,
	""ApplicationId"": ""LoggingTest"",
	""Message"": ""This is the test message"",
	""Exception"": ""Exception Message""
}");
					Assert.IsTrue(results, "Entry was not logged correctly");
					var firstItem = dbContext.ApplicationLogEntries.FirstOrDefault();
					Assert.IsNotNull(firstItem, "Entry not added");
					Assert.AreNotEqual(Guid.Empty, firstItem.Id);
					Assert.AreEqual(-2, firstItem.DeviceId);
					Assert.AreEqual("LoggingTest", firstItem.ApplicationId);
					Assert.AreEqual("This is the test message", firstItem.Message);
					Assert.AreEqual("Exception Message", firstItem.Exception);
					Assert.AreNotEqual(default(DateTime), firstItem.EntryDateTime);
					Assert.IsFalse(firstItem.Synced, "Synced should be false");
				}
			}
		}

		[TestCleanup]
		public void CleanUp()
		{
			using(var dbContext = new DbContextMock())
			{
				dbContext.ApplicationLogEntries.RemoveRange(dbContext.ApplicationLogEntries);
				dbContext.SaveChanges();
			}
		}
	}
}
