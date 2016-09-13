using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base
{
	public class GenerationAttribute : Attribute
	{
		public GenerationAttribute()
		{
		}

		public bool Ignore { get; set; }
	}
}
