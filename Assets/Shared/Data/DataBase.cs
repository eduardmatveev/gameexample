using Newtonsoft.Json;

namespace Data
{
    [JsonConverter(typeof(DataRefConverter))]
    public abstract class DataBase
    {
        public string Type;
        public string Name;
    }
}