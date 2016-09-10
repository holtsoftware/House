using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House.ServerSDK
{
	internal static class LocalExtensions
	{
		public static JObject ToJObject(this ITemperatureSetting setting)
		{
			if(setting == null)
			{
				return new JObject();
			}

			var obj = new JObject();
			obj.Add(new JProperty(nameof(setting.Id), setting.Id));
			obj.Add
		}
	}
}
