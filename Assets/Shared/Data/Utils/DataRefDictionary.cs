﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data
{
    [JsonConverter(typeof(DataRefDictionaryConverter))]
    public class DataRefDictionary<K, V> : Dictionary<K, V> where K : DataBase
    {
    }
}