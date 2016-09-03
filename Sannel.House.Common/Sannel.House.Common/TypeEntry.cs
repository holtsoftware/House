using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House
{
	internal class TypeEntry
	{
		public CreateType CreateType { get; set; }
		public Type Type { get; set; }

		public Func<SimpleContainer, Object> Handler
		{
			get;set;
		}

	}
}
