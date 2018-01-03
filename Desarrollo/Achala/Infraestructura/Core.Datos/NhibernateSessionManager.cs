using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentNHibernate.Cfg.Db;
using Mapeos;

namespace Core.Datos
{
    public class NhibernateSessionManager
    {
        private const string ConnectionStringName = "DB";

        // private static readonly ILog log;
        private static ISessionFactory _sessionFactory;

        static NhibernateSessionManager()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }


        public static string ConnectionString { get; private set; }



        public static ISession GetCurrentSession()
        {
            EnsureSessionFactoryHasBeenInitialized();

            if (HasCurrentlyBoundSession)
                return _sessionFactory.GetCurrentSession();

            var session = _sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;

            CurrentSessionContext.Bind(session);

            return session;
        }

        public static IStatelessSession CurrentStatelessSession()
        {
            EnsureSessionFactoryHasBeenInitialized();
            return _sessionFactory.OpenStatelessSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                EnsureSessionFactoryHasBeenInitialized();
                return _sessionFactory;
            }
        }

        public static void CloseSession()
        {
            if (_sessionFactory == null)
                return;

            if (HasCurrentlyBoundSession)
                CloseAndUnbindSessionInstance();
        }

        private static void CloseAndUnbindSessionInstance()
        {
            var session = CurrentSessionContext.Unbind(_sessionFactory);
            session.Close();
        }


        public static void ResetSessionFactory()
        {
            _sessionFactory = null;
        }

        private static bool HasCurrentlyBoundSession
        {
            get { return CurrentSessionContext.HasBind(_sessionFactory); }
        }


        private static void EnsureSessionFactoryHasBeenInitialized()
        {
            if (_sessionFactory == null)
                InitializeSessionFactory();
        }


        private static void InitializeSessionFactory()
        {
            if (HttpContext.Current != null)
                InitializeWebSessionContextSessionFactory();
            else
                InitializeThreadStaticSessionContextSessionFactory();
        }

        private static void InitializeThreadStaticSessionContextSessionFactory()
        {
            _sessionFactory = GetSessionFactory<ThreadStaticSessionContext>();

        }

        private static void InitializeWebSessionContextSessionFactory()
        {
            _sessionFactory = GetSessionFactory<WebSessionContext>();

        }

        private static ISessionFactory GetSessionFactory<T>() where T : ICurrentSessionContext
        {       


            var mysqlConfiguration = Fluently.Configure()
                .Database(MySQLConfiguration
                        .Standard
                        .ConnectionString(c => c.FromConnectionStringWithKey(ConnectionStringName)))
                 .CurrentSessionContext<T>()
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<InmuebleMap>());

            _sessionFactory = mysqlConfiguration.BuildSessionFactory();

            return _sessionFactory;
        }

    }

}
