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


		#region TemperatureEntry
		[TestMethod]
		public async Task GetTemperatureEntryAsyncTest()
		{
			Guid _Id = Guid.Empty;
			Int32 _DeviceId = 0;
			Double _TemperatureCelsius = 0;
			Double _Humidity = 0;
			Double _Pressure = 0;
			DateTimeOffset _CreatedDateTime = DateTimeOffset.MinValue;
			// Setup Stub
			var stub = new StubITemperatureEntry();
			stub.Id_Get(() => _Id);
			stub.Id_Set((v) => _Id = v);
			stub.DeviceId_Get(() => _DeviceId);
			stub.DeviceId_Set((v) => _DeviceId = v);
			stub.TemperatureCelsius_Get(() => _TemperatureCelsius);
			stub.TemperatureCelsius_Set((v) => _TemperatureCelsius = v);
			stub.Humidity_Get(() => _Humidity);
			stub.Humidity_Set((v) => _Humidity = v);
			stub.Pressure_Get(() => _Pressure);
			stub.Pressure_Set((v) => _Pressure = v);
			stub.CreatedDateTime_Get(() => _CreatedDateTime);
			stub.CreatedDateTime_Set((v) => _CreatedDateTime = v);
			// create helper
			var create = new StubICreateHelper();
			create.CreateTemperatureEntry(() => stub);
			// settings 
			var settings = new StubIServerSettings();
			settings.ServerUri_Get(() => null);
			// Http Client
			var httpClient = new StubIHttpClient();
			// Server 
			var serverContext = new ServerContext(settings, create, httpClient);
			Guid key = Guid.NewGuid();
			// leading
			var results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriNotSet, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(Guid.Empty, results.Key);
			// login exception
			settings.ServerUri_Get(() => new Uri("http://test"));
			httpClient.PostAsync((uri, d) =>
			{
				return Task.Run(() =>
				{
					return new HttpClientResult { StatusCode = HttpStatusCode.Ok, Content = "" };
				}

				).AsAsyncOperation();
			}

			);
			httpClient.GetCookieValue((u, name) => "Value");
			await serverContext.LoginAsync("user", "pass");
			settings.ServerUri_Get(() => new Uri("/cheese", UriKind.Relative));
			// invalid uri
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.AreEqual(RequestStatus.ServerUriIsNotValid, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(Guid.Empty, results.Key);
			// Unable to connect to server
			key = Guid.NewGuid();
			settings.ServerUri_Get(() => new Uri("http://test"));
			Exception expectedException = null;
			bool methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					Assert.AreEqual(new Uri($"http://test/api/TemperatureEntry/{key}"), uri);
					expectedException = new COMException("Message1", -2147012867);
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.UnableToConnectToServer, results.Status);
			Assert.IsNull(results.Data, "Data should not be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// COMException 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new COMException("Message2");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Exception 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					expectedException = new Exception("Message3");
					throw expectedException;
					return new HttpClientResult();
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Exception, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.AreEqual(expectedException, results.Exception);
			// Unauthorized 
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult()
					{ StatusCode = HttpStatusCode.Unauthorized, Content = "{Test: 'cheese'" };
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Error, results.Status);
			Assert.IsNull(results.Data, "Data should be null");
			Assert.AreEqual(key, results.Key);
			Assert.IsInstanceOfType(results.Exception, typeof(JsonReaderException));
			// Success Test
			var exp = new StubITemperatureEntry();
			exp.Id_Get(() => key);
			exp.DeviceId_Get(() => 180);
			exp.TemperatureCelsius_Get(() => 0.39166543138756671);
			exp.Humidity_Get(() => 0.7764159984776825);
			exp.Pressure_Get(() => 0.36414104437648365);
			exp.CreatedDateTime_Get(() => new DateTimeOffset(1987, 10, 8, 10, 49, 23, TimeSpan.FromHours(-6)));
			ITemperatureEntry expected = exp;
			var jobj = new JObject();
			jobj.Add(new JProperty(nameof(expected.Id), expected.Id));
			jobj.Add(new JProperty(nameof(expected.DeviceId), expected.DeviceId));
			jobj.Add(new JProperty(nameof(expected.TemperatureCelsius), expected.TemperatureCelsius));
			jobj.Add(new JProperty(nameof(expected.Humidity), expected.Humidity));
			jobj.Add(new JProperty(nameof(expected.Pressure), expected.Pressure));
			jobj.Add(new JProperty(nameof(expected.CreatedDateTime), expected.CreatedDateTime));
			methodHit = false;
			httpClient.GetAsync((uri) =>
			{
				return Task.Run(() =>
				{
					methodHit = true;
					return new HttpClientResult { StatusCode = HttpStatusCode.Ok, Content = jobj.ToString() };
				}

				).AsAsyncOperation();
			}

			);
			results = await serverContext.GetTemperatureEntryAsync(key);
			Assert.IsTrue(methodHit, "Method not called");
			Assert.AreEqual(RequestStatus.Success, results.Status);
			Assert.AreEqual(key, results.Key);
			Assert.IsNull(results.Exception, "Exception should be null");
			Assert.IsNotNull(results.Data, "Data should not be null");
			var actual = results.Data;
			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.DeviceId, actual.DeviceId);
			Assert.AreEqual(expected.TemperatureCelsius, actual.TemperatureCelsius);
			Assert.AreEqual(expected.Humidity, actual.Humidity);
			Assert.AreEqual(expected.Pressure, actual.Pressure);
			Assert.AreEqual(expected.CreatedDateTime, actual.CreatedDateTime);
		}
		#endregion
	}
}
