using System;
using System.Text.RegularExpressions;

namespace BottleRocket.Json
{
	public class JsonDeserializer
	{
		// Declaration

		#region Constants

		private readonly Regex rxBoolean = new Regex(@"true|false|null", RegexOptions.Singleline);
		private readonly Regex rxKey = new Regex(@"(\w+\s*):", RegexOptions.Singleline);
		private readonly Regex rxMembers = new Regex(@"(\w+\s*:\w+\s*|\w+\s*:\s*{(?<={)(.+)(?=})}),*", RegexOptions.Singleline);
		private readonly Regex rxObject = new Regex(@"(?<={)(.+)(?=})", RegexOptions.Singleline);
		private readonly Regex rxString = new Regex(@"true|false|null", RegexOptions.Singleline);

		#endregion 
		
		// Constructors

		#region Constructors

		public JsonDeserializer()
		{

		}

		#endregion 

		// Implementation

		#region Deserialize

		public T Deserialize<T>(String json)
			where T : new()
		{
			T item = new T();
			JsonObject obj = this.DeserializeObject(json);

			if (obj.Properties.Count > 0)
			{

			}

			return item;
		}

		public JsonObject DeserializeObject(String json)
		{
			JsonObject obj = new JsonObject();


			return obj;
		}

		#endregion 
	}
}