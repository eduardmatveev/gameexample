using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data
{
    public class DataRefConverter : JsonConverter
    {
        private static bool _canRead = true;
        public override bool CanWrite => false;
        public override bool CanRead => _canRead;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType == JsonToken.String)
                return DataLibrary.DictionaryByType[objectType][JToken.Load(reader).ToString()];
            
            var jobj = JObject.Load(reader);
            _canRead = false;
            var obj = jobj.ToObject(objectType, serializer);
            _canRead = true;
            return obj;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataBase);
        }
    }
}