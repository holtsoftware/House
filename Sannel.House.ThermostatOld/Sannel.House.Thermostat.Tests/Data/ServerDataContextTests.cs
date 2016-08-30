using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Sannel.House.Thermostat.Base.Interfaces;
using Sannel.House.Thermostat.Base.Enums;
using Sannel.House.Thermostat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Tests.Data
{
	[TestClass]
	public class ServerDataContextTests
	{
		[TestMethod]
		public async Task LoginAsyncTest()
		{
			var appSettings = new StubIAppSettings().ServerUrl_Get(() => "InvalidUrl");
			IServerSource server = new ServerDataContext(appSettings);
			var result = await server.LoginAsync("", "");
			Assert.AreEqual(LoginStatus.InvalidServerUrl, result);

			appSettings.ServerUrl_Get(() => "http://localhost:54321");
			result = await server.LoginAsync("", "");
			Assert.AreEqual(LoginStatus.UnableToConnectToServer, result);

			appSettings.ServerUrl_Get(() => "http://localhost:5000");
			result = await server.LoginAsync("test123@test.com", "test");
			Assert.AreEqual(LoginStatus.ErrorAuthenticating, result);

			result = await server.LoginAsync("test@test.com", "testtest");
			Assert.AreEqual(LoginStatus.Success, result);
			Assert.IsTrue(server.IsAuthenticated);
		}

		[TestMethod]
		public async Task GetDevicesAsyncTest()
		{
			var appSettings = new StubIAppSettings().ServerUrl_Get(() => "http://localhost:5000");
			IServerSource server = new ServerDataContext(appSettings);
			bool thrown = false;
			try
			{
				await server.GetDevicesAsync();
			}
			catch (UnauthorizedAccessException)
			{
				thrown = true;
			}
			Assert.IsTrue(thrown);

			await server.LoginAsync("test2@test.com", "testtest"); // login does not have access to devices

			var results = await server.GetDevicesAsync();
			Assert.IsNull(results); // we dont have access to devices this should be null

			await server.LoginAsync("test@test.com", "testtest"); // login does have access to devices
			results = await server.GetDevicesAsync();
			Assert.IsNotNull(results);
			Assert.IsTrue(results.Count > 0);
		}
	}
}
