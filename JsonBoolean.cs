using System;
using System.Text.RegularExpressions;

namespace BottleRocket.Json
{
	public class JsonBoolean
		: JsonValue
	{
		public static Regex Regex = new Regex(@"^(true|false)$", RegexOptions.Singleline);

		public Boolean Value { get; set; } = false;

		public override String Serialize()
		{
			return this.Value.ToString().ToLower();
		}
	}
}
