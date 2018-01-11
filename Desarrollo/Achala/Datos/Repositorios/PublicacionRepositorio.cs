using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Modelo;
using NHibernate;

namespace Repositorios
{
    public class PublicacionRepositorio : NhRepositorio<Publicacion>
    {
        public PublicacionRepositorio(ISession sesion) : base(sesion)
        {
        }

    }
}
