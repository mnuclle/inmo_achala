using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.Filtros
{
    public class Filtros
    {
        public static void Registrar(HttpConfiguration config)
        {
            config.Filters.Add(new ValidateModelFilter());
            config.Filters.Add(new CamelCaseFilter());
        }

    }
}