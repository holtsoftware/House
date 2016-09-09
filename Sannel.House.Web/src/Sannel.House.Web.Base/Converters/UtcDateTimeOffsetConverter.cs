using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sannel.House.Web.Base.Converters
{
	public class UtcDateTimeOffsetConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is DateTime)
			{
				var date = (DateTime)value;
				base.WriteJson(writer, date.ToUniversalTime(), serializer);
				value = date.ToUniversalTime();
			}
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			object value = base.ReadJson(reader, objectType, existingValue, serializer);
			if (value is DateTime)
			{
				var date = (DateTime)value;
				value = date.ToLocalTime();
			}
			return value;
		}
	}
	//And apply it on the property you want using the JsonConverter attribute:

	//[JsonConverter(typeof(UtcDateTimeOffsetConverter))]
	//public DateTimeOffset Date { get; set; }
}
