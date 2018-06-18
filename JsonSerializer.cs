using System;
using System.Reflection;
using System.Text.RegularExpressions;
using BottleRocket;

namespace BottleRocket.Json
{
	public class JsonSerializer
	{
		// Declaration

		#region Constructors

		public JsonSerializer()
		{
			
		}

		#endregion Constructors

		// Implementation

		#region Is/Has

		private Boolean HasIgnoreAttribute(PropertyInfo property)
		{
			JsonIgnoreAttribute[] attrs;
			attrs = (JsonIgnoreAttribute[])property.GetCustomAttributes(typeof(JsonIgnoreAttribute), false);
			return attrs.Length > 0;
		}

		#endregion Is/Has

		#region Serialize

		public String Serialize(Object obj, JsonSerializerOptions options)
		{
			return this.SerializeObject(obj).Serialize(options);
		}

		public JsonObject SerializeEnum(Enum e)
		{
			JsonObject json = new JsonObject();

			String description = e.GetDescription();
			String name = e.GetName();
			Int32 position = e.GetPosition();
			String value = e.GetValue();

			if (description != null) json["Description"] = new JsonString { Value = description };
			else json["Description"] = new JsonNull();

			if (name != null) json["Name"] = new JsonString { Value = name };
			else json["Name"] = new JsonNull();

			if (position > 0) json["Position"] = new JsonNumber { Value = position };
			else json["Position"] = new JsonNull();

			if (value != null) json["Value"] = new JsonString { Value = value };
			else json["Value"] = new JsonNull();

			return json;
		}

		public JsonObject SerializeObject(Object obj)
		{
			JsonObject json = new JsonObject();

			PropertyInfo[] properties = obj.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
				if (property != null && !this.HasIgnoreAttribute(property))
					this.SerializeProperty(property, obj);

			return json;
		}

		public JsonProperty SerializeProperty(PropertyInfo property, Object obj)
		{
			JsonValue json;
			String key = property.Name;
			Object value = property.GetValue(obj);

			if (value == null)
			{
				json = new JsonNull();
			}
			else if (property.GetType().IsEnum)
			{
				json = this.SerializeEnum((Enum)value);
			}
			else if (property.PropertyType.Name == "Currency")
			{
				json = new JsonString { Value = ((Currency)value).ToString() };
			}
			else if (property.PropertyType.Name == "Percent")
			{
				json = new JsonString { Value = ((Percent)value).ToString() };
			}
			else
			{
				json = this.SerializeObject(value);
			}

			return new JsonProperty
			{
				Key = key,
				Value = json
			};
		}

		#endregion Serialize
	}
}
