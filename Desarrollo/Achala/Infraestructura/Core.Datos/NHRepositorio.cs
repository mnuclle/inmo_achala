using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace Core
{
    public abstract class NhRepositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : Entidad
    {
        public ISession Sesion { get; private set; }

        protected NhRepositorio(ISession sesion)
        {
            Sesion = sesion;
        }

        public TEntidad ConsultarPorId(int id)
        {
            return Sesion.Get<TEntidad>(id);
        }

        public void Guardar(TEntidad entidad)
        {
            Sesion.SaveOrUpdate(entidad);
        }

        public void Eliminar(TEntidad entidad)
        {
            Sesion.SaveOrUpdate(entidad);
        }

        public IList<TEntidad> ObtenerTodas()
        {
            return Sesion.Query<TEntidad>().ToList();
        }
    }
}
