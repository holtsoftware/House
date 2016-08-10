using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Data;
using Sannel.Helpers;
using Sannel.House.Client.Exceptions;

namespace Sannel.House.Client.Tests
{
	[TestClass]
	public class ServerContextTests
	{

		[TestMethod]
		public async Task GetRolesAsyncTest()
		{
			StubISettings settings = new StubISettings();
			settings.ServerUrl_Get(() => new Uri("http://localhost:5000/"));
			settings.AuthzCookieValue_Get(() => null);
			IServerContext context = new ServerContext(settings);
			AssertHelpers.ThrowsException<NotLoggedInException>(() => { var data = context.GetRolesAsync().Result; });
		}

		[TestMethod]
		public async Task LoginAsyncTest()
		{
			StubISettings settings = new StubISettings();
			settings.ServerUrl_Get(() => new Uri("http://localhost:5000/"));
			String authValue = null;
			settings.AuthzCookieValue_Get(() => authValue);
			settings.AuthzCookieValue_Set((v) => authValue = v);
			IServerContext context = new ServerContext(settings);

			bool thrown = false;
			try
			{
				await context.LoginAsync(null, "");
			}
			catch(ArgumentNullException ane)
			{
				thrown = true;
				Assert.AreEqual("username", ane.ParamName);
			}
			Assert.IsTrue(thrown, "Exception not thrown");

			thrown = false;
			try
			{
				await context.LoginAsync("test@test.com", null);
			}
			catch(ArgumentNullException ane)
			{
				Assert.AreEqual("password", ane.ParamName);
				thrown = true;
			}

			Assert.IsTrue(thrown, "Exception not thrown");

			var result = await context.LoginAsync("notreal@test.com", "not known");
			Assert.AreEqual(false, result);
			result = await context.LoginAsync("test@test.com", "testtest");
			Assert.AreEqual(true, result);

			Assert.IsNotNull(authValue);
			Assert.IsFalse(String.IsNullOrWhiteSpace(authValue));
		}
	}
}
