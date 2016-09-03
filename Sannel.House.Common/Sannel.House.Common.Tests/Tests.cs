using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Common.Tests
{
	public class Test1 : ITest1
	{
		public Test1()
		{
		}
	}

	public class Test2 : ITest2
	{
	}

	public class Test3 : ITest3
	{
	}

	public class Test4 : ITest4
	{
		private ITest3 test3;
		public Test4(ITest3 obj)
		{
			test3 = obj;
		}

		public ITest3 Test3
		{
			get
			{
				return test3;
			}
		}
	}
}
