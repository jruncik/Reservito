using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TV.TiskarnaVosahlo.Models
{
    public class JsonSerializer<T> where T : class
    {
        static JsonSerializer()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new JavaScriptDateTimeConverter());
            _serializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public string Serialize(T objectToSerialize)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    _serializer.Serialize(writer, objectToSerialize);
                }
                return sw.ToString();
            }
        }

        public T Deserialize(string jsonDefinition)
        {
            return JsonConvert.DeserializeObject(jsonDefinition) as T;
        }

        private static JsonSerializer _serializer;
    }
}