using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Sannel.House.ServerSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK.Tests
{
	[TestClass]
	public class ServerContextTests
	{
		[TestMethod]
		public async Task LoginAsyncTest()
		{
			var sett = new StubIServerSettings();
			sett.ServerUri_Get(() => null);
			var serverContext = new ServerContext(sett);
			var result = await serverContext.LoginAsync(null, null);
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.ServerUriNotSet, result.Status);
			Assert.AreEqual("Server Uri is not set", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5020/"));
			result = await serverContext.LoginAsync(null, null);
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.UsernameIsNull, result.Status);
			Assert.AreEqual("Username cannot be null", result.Message);

			result = await serverContext.LoginAsync("test@test.com", null);
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.PasswordIsNull, result.Status);
			Assert.AreEqual("Password cannot be null", result.Message);

			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.UnableToConnectToServer, result.Status);
			Assert.AreEqual("Unable to connect to server", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtst");
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.Error, result.Status);
			Assert.AreEqual("Error Authenticating", result.Message);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.IsNotNull(result);
			Assert.AreEqual(LoginStatus.Success, result.Status);
			Assert.IsNotNull(result.Message);
		}

		[TestMethod]
		public async Task PostTemperatureEntryAsyncTest()
		{
			var sett = new StubIServerSettings();
			sett.ServerUri_Get(() => null);
			var serverContext = new ServerContext(sett);
			var entry = new StubITemperatureEntry();
			var result = await serverContext.PostTemperatureEntryAsync(entry);
			Assert.AreEqual(TemperatureEntryStatus.ServerUriNotSet, result.Status);
			Assert.AreEqual(Guid.Empty, result.Id);
			Assert.AreEqual(entry, result.Entry);

			sett.ServerUri_Get(() => new Uri("http://localtest.me:5000/"));

			result = await serverContext.PostTemperatureEntryAsync(entry);
			Assert.AreEqual(TemperatureEntryStatus.NotLoggedIn, result.Status);
			Assert.AreEqual(Guid.Empty, result.Id);
			Assert.AreEqual(entry, result.Entry);

			await serverContext.LoginAsync("test@test.com", "testtest");

			sett.ServerUri_Get(() => new Uri("http://localtest.me:5020"));

			Guid id = Guid.Empty;
			entry.Id_Get(() => id);
			entry.Id_Set((value) => id = value);
			entry.DeviceId_Get(() => 1);
			entry.CreatedDateTime_Get(() => DateTimeOffset.Now);
			entry.Humidity_Get(() => 2);
			entry.Pressure_Get(() => 3);
			entry.TemperatureCelsius_Get(() => 22);

			result = await serverContext.PostTemperatureEntryAsync(entry);
			Assert.AreEqual(TemperatureEntryStatus.UnableToConnectToServer, result.Status);
			Assert.AreEqual(Guid.Empty, result.Id);
			Assert.AreEqual(entry, result.Entry);

			sett.ServerUri_Get(() => new Uri("http://localtest.me:5000"));


			result = await serverContext.PostTemperatureEntryAsync(entry);
			Assert.AreEqual(TemperatureEntryStatus.Success, result.Status);
			Assert.AreNotEqual(Guid.Empty, result.Id);
			Assert.AreEqual(entry, result.Entry);

			var actual = id = Guid.NewGuid();
			result = await serverContext.PostTemperatureEntryAsync(entry);
			Assert.AreEqual(TemperatureEntryStatus.Success, result.Status);
			Assert.AreEqual(actual, result.Id);
			Assert.AreEqual(entry, result.Entry);


		}
	}
}
