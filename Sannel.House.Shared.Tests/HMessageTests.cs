using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Sannel.House.Shared.Tests
{
	[TestClass]
	public class HMessageTests
	{
		[TestMethod]
		public void ParseTest()
		{
			var v = HMessage.Parse(new byte[]
			{
				0,//Length
				1,// Type of message (Temperature)
				0,// ID << 8 from ushort
				1,// ID from ushort
				72, // arg1 (above the .)
				11 // arg2 (decimal & 255)
			});
		}
	}
}
