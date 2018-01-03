using Core;
using Modelo;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class InmuebleRepositorio : NhRepositorio<Inmueble>
    {
        public InmuebleRepositorio(ISession sesion) : base(sesion)
        {
        }


            
    }
}
