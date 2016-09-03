using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.Common.Tests
{
	public interface ITest1
	{
	}
	public interface ITest2
	{
	}
	
	public interface ITest3
	{
	}

	public interface ITest4
	{
		ITest3 Test3
		{
			get;
		}
	}
}
