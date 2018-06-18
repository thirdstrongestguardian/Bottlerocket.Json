using System;
using System.Text.RegularExpressions;

namespace BottleRocket.Json
{
	public class JsonString
		: JsonValue
	{
		public static Regex Regex = new Regex(@"^"".*""$", RegexOptions.Singleline);

		public String Value { get; set; }

		public override String Serialize()
		{
			String value = this.Value;

			value = value.Replace("\"", "\\\"");
			value = value.Replace("\\", "\\\\");
			value = value.Replace("/", "\\/");
			value = value.Replace("\b", "\\\b");
			value = value.Replace("\f", "\\\f");
			value = value.Replace("\n", "\\\n");
			value = value.Replace("\r", "\\\r");
			value = value.Replace("\t", "\\\t");

			return value;
		}
	}
}
