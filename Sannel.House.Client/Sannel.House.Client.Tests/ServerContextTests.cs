using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Sannel.House.Client.Interfaces;
using Sannel.House.Client.Data;
using Sannel.Helpers;
using Sannel.House.Client.Exceptions;
using System.Collections.Generic;

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
			bool thrown = false;
			try
			{
				await context.GetRolesAsync();
			}
			catch(NotLoggedInException)
			{
				thrown = true;
			}
			Assert.IsTrue(thrown, "Exception was not thrown");

			String authValue = "cheese";
			settings.AuthzCookieValue_Set((a) => authValue = a);
			settings.AuthzCookieValue_Get(() => authValue);

			IList<String> actual = null;
			thrown = false;
			try
			{
				actual = await context.GetRolesAsync();
			}
			catch(NotLoggedInException)
			{
				thrown = true;
			}

			Assert.IsTrue(thrown);

			await context.LoginAsync("test@test.com", "testtest");
			actual = await context.GetRolesAsync();
			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Count > 0);
			Assert.IsTrue(actual.Contains("Controller"));
		}

		[TestMethod]
		public async Task LoginAsyncTest()
		{
			StubISettings settings = new StubISettings();
			String authValue = null;
			settings.AuthzCookieValue_Get(() => authValue);
			settings.AuthzCookieValue_Set((v) => authValue = v);
			IServerContext context = new ServerContext(settings);

			settings.ServerUrl_Get(() => new Uri("http://localhost:1/"));

			bool thrown = false;
			try
			{
				await context.LoginAsync("test@test.com", "testtest");
			}
			catch(ServerException se)
			{
				thrown = true;
				Assert.AreEqual(503, se.StatusCode);
			}

			Assert.IsTrue(thrown);


			settings.ServerUrl_Get(() => new Uri("http://localhost:5000/"));

			thrown = false;
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
			Assert.AreEqual(false, result.Item1);
			result = await context.LoginAsync("test@test.com", "testtest");
			Assert.AreEqual(true, result.Item1);
			Assert.AreEqual("Test User", result.Item2);

			Assert.IsNotNull(authValue);
			Assert.IsFalse(String.IsNullOrWhiteSpace(authValue));
		}
	}
}
