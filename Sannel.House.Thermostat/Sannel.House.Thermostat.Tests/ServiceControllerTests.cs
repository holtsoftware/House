using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Sannel.House.Thermostat.Buisness;
using Sannel.House.Thermostat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Thermostat.Tests
{
	[TestClass]
	public class ServiceControllerTests
	{
		[TestMethod]
		public async Task SetConfigurationAsyncTest()
		{
			Uri serverUri = null;
			String username = null;
			String password = null;
			var appSettings = new StubIAppSettings();
			appSettings.ServerUri_Set((s) => serverUri = s);
			appSettings.ServerUri_Get(() => serverUri);
			appSettings.Username_Get(() => username);
			appSettings.Username_Set((u) => username = u);
			appSettings.Password_Get(() => password);
			appSettings.Password_Set((p) => password = p);

			var controller = new ServiceController(appSettings);
			var result = await controller.SetConfigurationAsync(null, null, null);
			Assert.IsFalse(result.Item1);
			Assert.AreEqual("ServerUri cannot be null", result.Item2);

			result = await controller.SetConfigurationAsync(new Uri("http://test"), null, null);
			Assert.IsFalse(result.Item1);
			Assert.AreEqual("Username cannot be null", result.Item2);

			result = await controller.SetConfigurationAsync(new Uri("http://test"), "test", null);
			Assert.IsFalse(result.Item1);
			Assert.AreEqual("Password cannot be null", result.Item2);

			result = await controller.SetConfigurationAsync(new Uri("http://test"), "test", "passwordTest");
			Assert.IsFalse(result.Item1);
			Assert.AreEqual("Error verifying with server", result.Item2);
			Assert.AreEqual(new Uri("http://test"), serverUri);
			Assert.AreEqual("test", username);
			Assert.AreEqual("passwordTest", password);

			var expectedUri = new Uri("http://localhost:5000/");
			var expectedUsername = "test@test.com";
			var expectedPassword = "testtest";

			result = await controller.SetConfigurationAsync(expectedUri, expectedUsername, expectedPassword);
			Assert.IsTrue(result.Item1);
			Assert.AreEqual("Success", result.Item2);
			Assert.AreEqual(expectedUri, serverUri);
			Assert.AreEqual(expectedUsername, username);
			Assert.AreEqual(expectedPassword, password);
		}

		[TestMethod]
		public async Task GetConfigurationAsyncTest()
		{
			Uri serverUri = new Uri("http://localtest.me");
			String username = "test@test.com";
			var appSettings = new StubIAppSettings();
			appSettings.ServerUri_Get(() => serverUri);
			appSettings.Username_Get(() => username);

			var controller = new ServiceController(appSettings);
			var results = await controller.GetConfigurationAsync();
			Assert.AreEqual(serverUri, results.Item1);
			Assert.AreEqual(username, results.Item2);
		}
	}
}
