using System;
using System.Text.RegularExpressions;

namespace BottleRocket.Json
{
	public class JsonProperty
	{
		public static Regex Regex = new Regex(@"^\w+\s*:\s*[""\w]+ $", RegexOptions.Singleline);

		public String Key { get; set; }
		public JsonValue Value { get; set; }

		public String Serialize(JsonSerializerOptions options)
		{
			String key = this.Key;
			if (options.Behavior == JsonSerializerBehavior.CamelCase && key.Length > 0)
			{
				key = key[0].ToString().ToLower() + (key.Length > 1 ? key.Substring(1) : "");
			}
			
			return key + ":" + this.Value.Serialize();
		}
	}
}
