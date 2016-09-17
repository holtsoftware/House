using NUnit.Framework;
using Sannel.House.Web.Base.Interfaces;
using Sannel.House.Web.Base.Models;
using Sannel.House.Web.Controllers.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Tests
{
	[TestFixture]
	public class TemperatureSettingsControllerTests : TestBase
	{
		private void AreEqual(TemperatureSetting expected, TemperatureSetting actual, String name="")
		{
			Assert.IsNotNull(actual);
			Assert.AreEqual(expected.Id, actual.Id, $"Id of {name} does not match");
			Assert.AreEqual(expected.HeatTemperatureC, actual.HeatTemperatureC, $"HeatTemperatureC of {name} does not match");
			Assert.AreEqual(expected.CoolTemperatureC, actual.CoolTemperatureC, $"CoolTemperatureC of {name} does not match");
			Assert.AreEqual(expected.DayOfWeek, actual.DayOfWeek, $"DayOfWeek of {name} does not match");
			Assert.AreEqual(expected.StartTime, actual.StartTime, $"StartTime of {name} does not match");
			Assert.AreEqual(expected.EndTime, actual.EndTime, $"EndTime of {name} does not match");
			Assert.AreEqual(expected.StartTime, actual.StartTime, $"StartTime of {name} does not match");
			Assert.AreEqual(expected.EndTime, actual.EndTime, $"EndTime of {name} does not match");
		}

		[Test]
		public void GetTest()
		{
			using(IDataContext context = new Mocks.MockDataContext())
			{
				#region Test Items
				int temp = 1;
				var today = new DateTime(2016, 8, 3, 2, 4, 1);
				var previousTwo = today.AddDays(-2);
				var previous = today.AddDays(-1);
				var tomorrow = today.AddDays(1);
				var twoDays = today.AddDays(2);
				var threeDays = today.AddDays(3);
				// defaults only one should be returned from the query.
				var ts_1 = new TemperatureSetting();
				ts_1.HeatTemperatureC = temp++;
				ts_1.CoolTemperatureC = temp++;
				ts_1.DateCreated = DateTime.Now.AddDays(-20);
				ts_1.DateModified = DateTime.Now;
				context.TemperatureSettings.Add(ts_1);
				var ts_2 = new TemperatureSetting();
				ts_2.HeatTemperatureC = temp++;
				ts_2.CoolTemperatureC = temp++;
				ts_2.DateCreated = ts_2.DateModified = DateTime.Now.AddDays(-5);
				context.TemperatureSettings.Add(ts_2);
				context.SaveChanges();

				// Items that are day of the week 
				// 2 days ago
				var ts_3 = new TemperatureSetting();
				ts_3.HeatTemperatureC = temp++;
				ts_3.CoolTemperatureC = temp++;
				ts_3.DayOfWeek = previousTwo.DayOfWeek;
				context.TemperatureSettings.Add(ts_3);
				//yesterday
				var ts_4 = new TemperatureSetting();
				ts_4.HeatTemperatureC = temp++;
				ts_4.CoolTemperatureC = temp++;
				ts_4.DayOfWeek = previous.DayOfWeek;
				ts_4.StartTime = new DateTime(1, 1, 1, 12, 0, 0);
				ts_4.EndTime = new DateTime(1, 1, 1, 12, 10, 0);
				context.TemperatureSettings.Add(ts_4);

				var ts_5 = new TemperatureSetting();
				ts_5.HeatTemperatureC = temp++;
				ts_5.CoolTemperatureC = temp++;
				ts_5.DayOfWeek = previous.DayOfWeek;
				context.TemperatureSettings.Add(ts_5);

				var ts_6 = new TemperatureSetting();
				ts_6.HeatTemperatureC = temp++;
				ts_6.CoolTemperatureC = temp++;
				ts_6.DayOfWeek = previous.DayOfWeek;
				ts_6.StartTime = new DateTime(1, 1, 1, 0, 0, 0);
				context.TemperatureSettings.Add(ts_6);
				// today
				var ts_7 = new TemperatureSetting();
				ts_7.HeatTemperatureC = temp++;
				ts_7.CoolTemperatureC = temp++;
				ts_7.DayOfWeek = today.DayOfWeek;
				context.TemperatureSettings.Add(ts_7);

				var ts_8 = new TemperatureSetting();
				ts_8.HeatTemperatureC = temp++;
				ts_8.CoolTemperatureC = temp++;
				ts_8.DayOfWeek = today.DayOfWeek;
				ts_8.StartTime = new DateTime(1, 1, 1, 8, 45, 0);
				context.TemperatureSettings.Add(ts_8);

				var ts_9 = new TemperatureSetting();
				ts_9.HeatTemperatureC = temp++;
				ts_9.CoolTemperatureC = temp++;
				ts_9.DayOfWeek = today.DayOfWeek;
				ts_9.StartTime = new DateTime(1, 1, 1, 8, 46, 0);
				context.TemperatureSettings.Add(ts_9);
				// tomorrow
				var ts_10 = new TemperatureSetting();
				ts_10.HeatTemperatureC = temp++;
				ts_10.CoolTemperatureC = temp++;
				ts_10.DayOfWeek = tomorrow.DayOfWeek;
				ts_10.StartTime = new DateTime(1, 1, 1, 13, 13, 0);
				context.TemperatureSettings.Add(ts_10);

				var ts_11 = new TemperatureSetting();
				ts_11.HeatTemperatureC = temp++;
				ts_11.CoolTemperatureC = temp++;
				ts_11.DayOfWeek = tomorrow.DayOfWeek;
				ts_11.StartTime = new DateTime(1, 1, 1, 13, 12, 0);
				context.TemperatureSettings.Add(ts_11);

				var ts_12 = new TemperatureSetting();
				ts_12.HeatTemperatureC = temp++;
				ts_12.CoolTemperatureC = temp++;
				ts_12.DayOfWeek = tomorrow.DayOfWeek;
				context.TemperatureSettings.Add(ts_12);

				// two days 
				var ts_13 = new TemperatureSetting();
				ts_13.HeatTemperatureC = temp++;
				ts_13.CoolTemperatureC = temp++;
				ts_13.DayOfWeek = twoDays.DayOfWeek;
				context.TemperatureSettings.Add(ts_13);

				// three days (should not be returned)
				var ts_14 = new TemperatureSetting();
				ts_14.HeatTemperatureC = temp++;
				ts_14.CoolTemperatureC = temp++;
				ts_14.DayOfWeek = threeDays.DayOfWeek;
				context.TemperatureSettings.Add(ts_14);

				// spacific dates


				context.SaveChanges();

				#endregion

				using (var controller = new TemperatureSettingsController(context))
				{
					var results = controller.Get(today).ToList();
					Assert.IsNotNull(results);
					Assert.IsTrue(results.Count > 0);

					var actual = results[0];
					//AreEqual(ts_1, actual);

					//// ts_3 is not expected to be returned.

					//actual = results[1]; // expected to be ts_5;
					//AreEqual(ts_5, actual);

					//actual = results[2]; // expected to be ts_6;
					//AreEqual(ts_6, actual);

					//actual = results[3]; // expected to be ts_4
					//AreEqual(ts_4, actual);

					//actual = results[4]; // expected to be ts_7;
					//AreEqual(ts_7, actual);

					//actual = results[5]; // expected to be ts_8;
					//AreEqual(ts_8, actual);

					//actual = results[6]; // expected to be ts_9;
					//AreEqual(ts_9, actual);

					//actual = results[7]; // expected to be ts_12;
					//AreEqual(ts_12, actual);

					//actual = results[8]; // exptected to be ts_11;
					//AreEqual(ts_11, actual);

					//actual = results[9]; // expected to be ts_10;
					//AreEqual(ts_10, actual);

					//actual = results[10]; // expected to be ts_13;
					//AreEqual(ts_13, actual);
				}
			}
		}
	}
}
