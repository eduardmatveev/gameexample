using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Data
{
    public static class DataLibrary
    {
        static DataLibrary()
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => p.BaseType == typeof(DataBase)))
            {
                DictionaryByType.Add(type, new Dictionary<string, DataBase>());
                InsertByStringType.Add(type.Name.Replace("Data", ""), jobj =>
                {
                    var data = (DataBase)jobj.ToObject(type);
                    DictionaryByType[type].Add(data.Name, data);
                });
            }
        }

        internal static readonly Dictionary<Type, Dictionary<string, DataBase>> DictionaryByType = new Dictionary<Type, Dictionary<string, DataBase>>();
        private static readonly Dictionary<string, Action<JObject>> InsertByStringType = new Dictionary<string, Action<JObject>>();

        public static void Insert(string text)
        {
            foreach (var token in JArray.Parse(text).Children())
            {
                if (token is JObject jobj && InsertByStringType.TryGetValue(jobj.GetValue("Type").ToString(), out var insert))
                    insert(jobj);
            }
        }
    }
}