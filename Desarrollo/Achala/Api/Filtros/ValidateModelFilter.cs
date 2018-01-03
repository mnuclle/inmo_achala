using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace Api.Filtros
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (actionContext.ModelState.IsValid == false && actionContext.Request.Method != HttpMethod.Get)
            {
                var allErrors = new List<RespuestaError>();

                foreach (var key in actionContext.ModelState.Keys)
                {

                    foreach (var error in actionContext.ModelState[key].Errors)
                    {

                        var keyName = key;

                        if (actionContext.ActionArguments.Count == 1)
                        {
                            var nameVar = actionContext.ActionArguments.Keys.FirstOrDefault();
                            keyName = key.Replace(string.Format("{0}.", nameVar), "");
                        }

                        if (string.IsNullOrEmpty(error.ErrorMessage) && error.Exception == null || allErrors.Any(x => x.Origen == keyName && x.Titulo == error.ErrorMessage))
                            continue;

                        var respuestaError = new RespuestaError()
                        {
                            Origen = keyName,
                            Titulo = string.IsNullOrEmpty(error.ErrorMessage) ? "Error inesperado" : error.ErrorMessage,
                            Descripcion = error.Exception != null ? error.Exception.Message : string.Empty
                        };

                        allErrors.Add(respuestaError);
                    }
                }

                var respuesta = new Respuesta(allErrors);
                actionContext.Response = actionContext.Request.CreateResponse<object>(HttpStatusCode.BadRequest, respuesta);

            }
        }
    }

    public class RespuestaError
    {
        [JsonProperty(PropertyName = "origen")]
        public string Origen { get; set; }

        [JsonProperty(PropertyName = "titulo")]
        public string Titulo { get; set; }

        [JsonProperty(PropertyName = "descripcion",NullValueHandling = NullValueHandling.Ignore)]
        public string Descripcion { get; set; }
    }

    public class Respuesta
    {
        [JsonProperty(PropertyName = "codigo")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "resultado", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; private set; }

        [JsonProperty(PropertyName = "errores", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<RespuestaError> Errores { get; private set; }

        public Respuesta(int status, dynamic data)
        {
            Data = data;
            Status = status;
        }

        public Respuesta(IEnumerable<RespuestaError> errores)
        {
            Errores = errores;
        }

        private Respuesta()
        {
        }
    }


}