using System;
using System.Text.RegularExpressions;

namespace MoonStorm.Json
{
	public class JsonNumber
		: JsonValue
	{
		public static Regex Regex = new Regex(@"^\d+\.?\d*$", RegexOptions.Singleline);

		public Double Value { get; set; } = 0;

		public override String Serialize()
		{
			return this.Value.ToString();
		}
	}
}
