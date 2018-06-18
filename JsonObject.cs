using System;
using System.Collections.Generic;

namespace BottleRocket.Json
{
	public class JsonObject
		: JsonValue
	{


		public List<JsonProperty> Properties { get; set; } = new List<JsonProperty>();

		public JsonValue this[String key]
		{
			get
			{
				foreach (JsonProperty property in this.Properties)
					if (property.Key == key)
						return property.Value;

				return null;
			}
			set
			{
				foreach (JsonProperty property in this.Properties)
					if (property.Key == key)
						property.Value = value;

				this.Properties.Add(new JsonProperty
				{
					Key = key,
					Value = value
				});
			}
		}

		public override String Serialize()
		{
			return this.Serialize(new JsonSerializerOptions());
		}

		public String Serialize(JsonSerializerOptions options)
		{
			String properties = "";

			foreach (JsonProperty property in this.Properties)
			{
				properties = properties + (properties.Length > 0 ? ", " : "") + property.Serialize(options);
			}

			return properties;
		}
	}
}
