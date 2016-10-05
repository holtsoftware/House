using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.House
{
#if _SERVERSDK_
	internal static class Extensions
#else
	public static class Extensions
#endif
	{
		/// <summary>
		/// Gets the value associated with the <typeparamref name="TKey"/> and returns it
		/// If <typeparamref name="TKey"/> is not found returns the default of <typeparamref name="TValue" />
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="dict">The dictionary.</param>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
		{
			if (dict == null)
			{
				return default(TValue);
			}

			if (key == null)
			{
				return default(TValue);
			}

			if (dict.ContainsKey(key))
			{
				Object obj = dict[key];
				if (obj is TValue)
				{
					return (TValue)obj;
				}
			}

			return default(TValue);
		}

		/// <summary>
		/// Celsiuses to fahrenheit.
		/// </summary>
		/// <param name="celsius">The celsius.</param>
		/// <returns></returns>
		public static double CelsiusToFahrenheit(this double celsius)
		{
			return (celsius * 9) / 5 + 32;
		}

		/// <summary>
		/// Fahrenheits to celsius.
		/// </summary>
		/// <param name="fahrenheit">The fahrenheit.</param>
		/// <returns></returns>
		public static double FahrenheitToCelsius(this double fahrenheit)
		{
			return (fahrenheit - 32) * (5 / 9);
		}

		public static DateTimeOffset? ToDateTimeOffset(this String item)
		{
			if(item == null)
			{
				return null;
			}

			var toParse = item.Replace("T", " ").Replace("Z", " ");
			DateTimeOffset dto;
			if(DateTimeOffset.TryParse(toParse, out dto))
			{
				return dto;
			}
			return null;
		}

		public static T GetPropertyValue<T>(this JObject token, String name)
		{
			if(typeof(T) == typeof(DateTimeOffset))
			{

			}
			var prop = token.Property(name);

			if(prop == null)
			{
				return default(T);
			}

			if(prop.Value == null)
			{
				return default(T);
			}

			return prop.Value.Value<T>();
		}
	}
}
