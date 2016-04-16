using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Sannel.House.WUnderground.WModels;

namespace Sannel.House.WUnderground.Tests
{
	[TestClass]
	public class WUndergroundExtensionsTests
	{
		[TestMethod]
		public void FCTTIME_ToDateTimeTests()
		{
			var fcttime = new FCTTIME();
			fcttime.pretty = "2:00 PM PDT on July 03, 2012";
			fcttime.hour = "14";
			fcttime.year = "2012";
			fcttime.mday = "3";
			fcttime.min = "23";
			fcttime.mon = "7";
			fcttime.ampm = "pm";
			var dt = fcttime.ToDateTime();
			Assert.AreEqual(14, dt.Hour);
			Assert.AreEqual(23, dt.Minute);
			Assert.AreEqual(2012, dt.Year);
			Assert.AreEqual(7, dt.Month);
			Assert.AreEqual(3, dt.Day);
			Assert.AreEqual("PM", dt.ToString("tt"));
		}
	}
}
