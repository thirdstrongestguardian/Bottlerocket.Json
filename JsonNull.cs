using System;
using System.Text.RegularExpressions;

namespace MoonStorm.Json
{
	public class JsonNull
		: JsonValue
	{
		public static Regex Regex = new Regex(@"^null$", RegexOptions.Singleline);

		public override String Serialize()
		{
			return "null";
		}
	}
}
