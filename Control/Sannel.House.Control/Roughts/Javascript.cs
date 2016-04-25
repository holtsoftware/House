using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sannel.House.Control.Http;

namespace Sannel.House.Control.Roughts
{
	public class Javascript : StaticContent
	{
		public override ContentType ContentType
		{
			get
			{
				return ContentType.Javascript;
			}
		}

		public override string Path
		{
			get
			{
				return "js";
			}
		}
	}
}
