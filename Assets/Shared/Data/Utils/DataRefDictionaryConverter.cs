﻿using System;
 using System.Collections;
 using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data
{
    public class DataRefDictionaryConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jobj = JObject.Load(reader);
            var keyType = objectType.GenericTypeArguments[0];
            var valueType = objectType.GenericTypeArguments[1];
            var instance = (IDictionary)Activator.CreateInstance(objectType);
            foreach (var pair in jobj)
            {
                var key = DataLibrary.DictionaryByType[keyType][pair.Key];
                var value = pair.Value.ToObject(valueType);
                instance.Add(key, value);
            }
            return instance;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataBase);
        }
    }
}