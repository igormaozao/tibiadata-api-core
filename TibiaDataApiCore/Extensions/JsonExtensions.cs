using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TibiaDataApiCore.Extensions {
    public static class JsonExtensions {

        static JsonSerializerSettings jsonSettings = new JsonSerializerSettings() {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true } }
        };

        public static T Deserialize<T>(this string data) {
            return JsonConvert.DeserializeObject<T>(data, jsonSettings);
        }
    }
}
