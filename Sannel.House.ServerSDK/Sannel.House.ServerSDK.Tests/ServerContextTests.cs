using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sannel.House.ServerSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

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
			var create = new StubICreateHelper();
			var serverContext = new ServerContext(sett, create);
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
		public async Task GetTemperatureEntryAsyncTest()
		{
			var item = new StubITemperatureEntry();
			Guid id = Guid.Empty;
			item.Id_Get(() => id);
			item.Id_Set((v) => id = v);
			int deviceId = 0;
			item.DeviceId_Get(() => deviceId);
			item.DeviceId_Set((v) => deviceId = v);
			double temperatureCelsius = 0;
			item.TemperatureCelsius_Get(() => temperatureCelsius);
			item.TemperatureCelsius_Set((v) => temperatureCelsius = v);
			double humidity = 0;
			item.Humidity_Get(() => humidity);
			item.Humidity_Set((v) => humidity = v);
			double pressure = 0;
			item.Pressure_Get(() => pressure);
			item.Pressure_Set((v) => pressure = v);
			DateTimeOffset createDateTime = DateTimeOffset.MinValue;
			item.CreatedDateTime_Get(() => createDateTime);
			item.CreatedDateTime_Set((v) => createDateTime = v);

			var sett = new StubIServerSettings();
			sett.ServerUri_Get(() => null);
			var create = new StubICreateHelper();
			create.CreateTemperatureEntry(() => item);
			var client = new StubIHttpClient();

			var serverContext = new ServerContext(sett, create, client);

			var key = Guid.NewGuid();
			var result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(TemperatureEntryStatus.ServerUriNotSet, result.Status);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.AreEqual(Guid.Empty, result.Key);

			sett.ServerUri_Get(() => new Uri("/Cheader", UriKind.Relative));

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(TemperatureEntryStatus.NotLoggedIn, result.Status);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.AreEqual(Guid.Empty, result.Key);

			sett.ServerUri_Get(() => new Uri("http://test"));
			client.PostAsync((uri, dict) =>
			{
				return Task.Run(() =>
				{
					return new HttpClientResult()
					{
						StatusCode = Windows.Web.Http.HttpStatusCode.Ok,
						Content = ""
					};
				}).AsAsyncOperation();
			});
			client.GetCookieValue((u, name) =>
			{
				return "value";
			});
			await serverContext.LoginAsync("test", "test");
			sett.ServerUri_Get(() => new Uri("/Cheader", UriKind.Relative));

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(TemperatureEntryStatus.ServerUriIsNotValid, result.Status);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.AreEqual(Guid.Empty, result.Key);

			key = Guid.NewGuid();
			sett.ServerUri_Get(() => new Uri("http://test"));
			Exception expectedException = null;
			bool methodHit = false;
			client.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					Assert.AreEqual(new Uri($"http://test/api/TemperatureEntry/{key}"), uri);
					expectedException = new COMException("Message1", -2147012867);
					throw expectedException;
					return new HttpClientResult();
				}).AsAsyncOperation();
			});

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(TemperatureEntryStatus.UnableToConnectToServer, result.Status);
			Assert.AreEqual(key, result.Key);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.AreEqual(expectedException, result.Exception);

			methodHit = false;
			client.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new COMException("Message2");
					throw expectedException;
					return new HttpClientResult();
				}).AsAsyncOperation();
			});

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(TemperatureEntryStatus.Exception, result.Status);
			Assert.AreEqual(key, result.Key);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.AreEqual(expectedException, result.Exception);

			methodHit = false;
			client.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new Exception("Message3");
					throw expectedException;
					return new HttpClientResult();
				}).AsAsyncOperation();
			});

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(TemperatureEntryStatus.Exception, result.Status);
			Assert.AreEqual(key, result.Key);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.AreEqual(expectedException, result.Exception);
			
			methodHit = false;
			client.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{
						StatusCode = Windows.Web.Http.HttpStatusCode.Unauthorized,
						Content = "{test: 'cheese'"
					};
				}).AsAsyncOperation();
			});

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(TemperatureEntryStatus.Error, result.Status);
			Assert.AreEqual(key, result.Key);
			Assert.IsNull(result.Data, "Data should be null");
			
			methodHit = false;
			client.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{
						StatusCode = Windows.Web.Http.HttpStatusCode.Ok,
						Content = "{test: 'cheese'"
					};
				}).AsAsyncOperation();
			});

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(TemperatureEntryStatus.Exception, result.Status);
			Assert.AreEqual(key, result.Key);
			Assert.IsNull(result.Data, "Data should be null");
			Assert.IsInstanceOfType(result.Exception, typeof(Newtonsoft.Json.JsonReaderException));

			var exp = new StubITemperatureEntry();
			exp.CreatedDateTime_Get(() => DateTimeOffset.Parse(DateTimeOffset.Now.ToString()));
			exp.Id_Get(() => key);
			exp.DeviceId_Get(() => 2);
			exp.TemperatureCelsius_Get(() => 4.5);
			exp.Humidity_Get(() => 1.2);
			exp.Pressure_Get(() => 3.5);
			ITemperatureEntry expected = exp;

			var jobj = new JObject();
			jobj.Add(new JProperty(nameof(expected.Id), expected.Id));
			jobj.Add(new JProperty(nameof(expected.DeviceId), expected.DeviceId));
			jobj.Add(new JProperty(nameof(expected.TemperatureCelsius), expected.TemperatureCelsius));
			jobj.Add(new JProperty(nameof(expected.Humidity), expected.Humidity));
			jobj.Add(new JProperty(nameof(expected.Pressure), expected.Pressure));
			jobj.Add(new JProperty(nameof(expected.CreatedDateTime), expected.CreatedDateTime.ToString()));

			methodHit = false;
			client.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{
						StatusCode = Windows.Web.Http.HttpStatusCode.Ok,
						Content = jobj.ToString()
					};
				}).AsAsyncOperation();
			});

			result = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(TemperatureEntryStatus.Success, result.Status);
			Assert.AreEqual(key, result.Key);
			Assert.IsNull(result.Exception, "Exception should be null");
			Assert.IsNotNull(result.Data, "Data should not be null");
			var actual = result.Data;
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.DeviceId, actual.DeviceId);
			Assert.AreEqual(expected.TemperatureCelsius, actual.TemperatureCelsius);
			Assert.AreEqual(expected.Humidity, actual.Humidity);
			Assert.AreEqual(expected.Pressure, actual.Pressure);
			Assert.AreEqual(expected.CreatedDateTime, actual.CreatedDateTime);
		}
	}
}
