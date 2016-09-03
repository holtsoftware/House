using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Common.Tests
{
	[TestClass]
	public class ExtensionsTests
	{
		[TestMethod]
		public void GetValueTest()
		{
			IDictionary<String, String> d = new Dictionary<String, String>();
			d["Test1"] = "Test";
			Assert.AreEqual("Test", d.GetValue("Test1"));
			Assert.AreEqual(null, d.GetValue("Test2"));
		}

		[TestMethod]
		public void FahrenheitToCelsiusTest()
		{
			double d = 32;
			var c = d.FahrenheitToCelsius();
			Assert.AreEqual(0, c);
		}

		[TestMethod]
		public void CelsiusToFahrenheitTest()
		{
			double d = 0;
			var f = d.CelsiusToFahrenheit();
			Assert.AreEqual(32, f);
		}
	}
}
