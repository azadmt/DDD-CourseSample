using Newtonsoft.Json;

namespace Framework.Core
{
    public class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
