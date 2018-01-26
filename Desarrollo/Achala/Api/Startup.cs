using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using Api.Config;
using Core.Formateadores;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(Api.Startup))]

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información acerca de cómo configurar su aplicación, visite http://go.microsoft.com/fwlink/?LinkID=316888

            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            Formateadores.Registrar(config);
            Filtros.Filtros.Registrar(config);


            app.UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(config);
        }
    }
}
