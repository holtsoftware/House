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
		}
	}
}
