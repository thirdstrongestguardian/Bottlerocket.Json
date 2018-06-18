using System;

namespace BottleRocket.Json
{
	public static class JsonConvert
	{
		// Declaration

		#region Private Members

		private static JsonDeserializer Deserializer = new JsonDeserializer();

		private static JsonSerializer Serializer = new JsonSerializer();

		#endregion 

		// Implementation

		#region Deserialize

		public static T Deserialize<T>(String json) where T : new()
		{
			return Deserializer.Deserialize<T>(json);
		}

		#endregion 

		#region Serialize

		public static String Serialize(Object obj, JsonSerializerOptions options)
		{
			return Serializer.Serialize(obj, options);
		}

		#endregion 
	}
}