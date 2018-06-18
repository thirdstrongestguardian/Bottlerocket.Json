using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BottleRocket.Json
{
	public class JsonArray
		: JsonValue
	{
		public static Regex Regex = new Regex(@"^\[.*\]$", RegexOptions.Singleline);

		public List<JsonValue> Values { get; set; } = new List<JsonValue>();

		public JsonValue this[Int32 index]
		{
			get
			{
				return this.Values[index];
			}
			set
			{
				this.Values[index] = value;
			}
		}

		public JsonArray()
		{

		}

		public JsonArray(Int32 length)
		{
			this.Values = new List<JsonValue>(length);
		}

		public void Add(JsonValue item)
		{
			this.Values.Add(item);
		}

		public void Remove(JsonValue item)
		{
			this.Values.Remove(item);
		}

		public override String Serialize()
		{
			String values = "";

			foreach (JsonValue value in this.Values)
			{
				values = values + (values.Length > 0 ? ", " : "") + value.Serialize();
			}

			return "[" + values + "]";
		}
	}
}
