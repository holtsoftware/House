using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Sannel.House.Control.Models.WUnderground;
using Sannel.House.Control;

namespace Sannel.House.Control.Tests
{
	[TestClass]
	public class WUndergroundExtensionsTests
	{
		[TestMethod]
		public void FCTTIME_ToDateTimeTest()
		{
			var fcttime = new FCTTIME(); 
			fcttime.pretty = "11:13 PM PDT on July 03, 2012";
			var dt = fcttime.ToDateTime();
			Assert.AreEqual(11, dt.Hour);
			Assert.AreEqual(13, dt.Minute);
			Assert.AreEqual(7, dt.Month);
			Assert.AreEqual(3, dt.Day);
			Assert.AreEqual(2012, dt.Year);
			Assert.AreEqual("PM", dt.ToString("tt"));
		}
	}
}
