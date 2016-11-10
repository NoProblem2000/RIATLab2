using System.Text;
using Newtonsoft.Json;

namespace RIATLab2
{
        public class JsonSerializer:ISerializer
        {
            public bool CanSerialize(string serializeFormat)
            {
                return serializeFormat == "Json";
            }

            public string Serialize<T>(T obj)
            {
                return JsonConvert.SerializeObject(obj);
            }

            public T Deserialize<T>(string serializedObj)
            {
                return JsonConvert.DeserializeObject<T>(serializedObj);
            }
        }
   }
