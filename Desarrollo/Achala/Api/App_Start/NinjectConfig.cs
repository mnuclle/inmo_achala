using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using NHibernate;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using Servicios;
using Repositorios;
using Core.Datos;

namespace Api.Config
{
    public class NinjectConfig
    {

        public static StandardKernel CreateKernel()
        {
            var modules = new NinjectModule[] {
                new ModuloBaseDeDatos(),
                new ModuloServicios(),
                new ModuloRepositorios()
            };
            var kernel = new StandardKernel(modules);
            
            return kernel;
        }


        public class ModuloServicios : NinjectModule
        {
            public override void Load()
            {
                this.Bind(x =>
                {
                    x.FromAssemblyContaining<InmuebleServicio>()
                        .SelectAllClasses();
                });
            }
        }

        public class ModuloRepositorios : NinjectModule
        {
            public override void Load()
            {
                this.Bind(x =>
                {
                    x.FromAssemblyContaining<InmuebleRepositorio>()
                     .SelectAllClasses().InheritedFrom(typeof(IRepositorio<>))
                     .BindAllInterfaces();
                });
            }
        }

        public class ModuloBaseDeDatos : NinjectModule
        {
            public override void Load()
            {

                if (Kernel != null)
                {
                    Kernel.Bind<ISession>()
                        .ToMethod(x => NhibernateSessionManager.GetCurrentSession())
                        .InRequestScope()
                        .OnActivation(OpenTransaction)
                        .OnDeactivation(EndTransaction);

                   // Kernel.Bind<IStatelessSession>().ToMethod(x => NhibernateSessionManager.CurrentStatelessSession()).InRequestScope();
                }
            }

            private void EndTransaction(ISession session)
            {

                try
                {
                    if (session.Transaction.IsActive)
                    {
                        session.Transaction.Commit();
                    }
                }
                catch (ADOException ex)
                {
                    session.Dispose();
                }
            }


            private void OpenTransaction(ISession session)
            {
                session.BeginTransaction();

                HttpContext.Current.AddOnRequestCompleted((context) =>
                {
                    EndTransaction(session);
                });
            }
        }



    }
}