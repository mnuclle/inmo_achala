using System.Collections.Generic;
using System.Web.Http;
using Core.Formateadores.MultipartData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Formatting = System.Xml.Formatting;

namespace Core.Formateadores
{
    public class Formateadores
    {
        public static void Registrar(HttpConfiguration config)
        {

            //var defaultSettings = new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //    Converters = new List<JsonConverter>
            //            {
                           
            //            }
            //};

            //JsonConvert.DefaultSettings = () => { return defaultSettings; };

            //config.Formatters.JsonFormatter
            //    .SerializerSettings = defaultSettings;

            config.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter());
        }
    }
}
