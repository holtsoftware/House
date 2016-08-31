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
			Assert.IsFalse(result.Key);
			Assert.AreEqual("Server Uri is not set", result.Value);

			sett.ServerUri_Get(() => new Uri("http://localhost:5020/"));
			result = await serverContext.LoginAsync(null, null);
			Assert.IsNotNull(result);
			Assert.IsFalse(result.Key);
			Assert.AreEqual("Username cannot be null", result.Value);

			result = await serverContext.LoginAsync("test@test.com", null);
			Assert.IsNotNull(result);
			Assert.IsFalse(result.Key);
			Assert.AreEqual("Password cannot be null", result.Value);

			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.IsNotNull(result);
			Assert.IsFalse(result.Key);
			Assert.AreEqual("Unable to connect to server", result.Value);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtst");
			Assert.IsNotNull(result);
			Assert.IsFalse(result.Key);
			Assert.AreEqual("Error Authenticating", result.Value);

			sett.ServerUri_Get(() => new Uri("http://localhost:5000/"));
			result = await serverContext.LoginAsync("test@test.com", "testtest");
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Key);
			Assert.IsNotNull(result.Value);
		}
	}
}
