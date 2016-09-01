using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace Sannel.House
{
	public static class Extensions
	{
		public static T GetValue<T>(this ValueSet valueSet, String key)
		{
			if(valueSet == null)
			{
				return default(T);
			}

			if(key == null)
			{
				return default(T);
			}

			if(valueSet.ContainsKey(key))
			{
				Object obj = valueSet[key];
				if(obj is T)
				{
					return (T)obj;
				}
			}

			return default(T);
		}
	}
}
