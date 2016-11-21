using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Common;
using NUnit.Framework;
using System.Reflection;
using NUnitLite;

namespace Sannel.House.Web.Tests
{
	public class Program
	{
		public static int Main(string[] args)
		{
			int result = new AutoRun(typeof(Program).GetTypeInfo().Assembly)
				.Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);
			Console.ReadKey();

			return result;
		}
	}
}
