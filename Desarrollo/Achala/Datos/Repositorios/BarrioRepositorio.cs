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
    public class BarrioRepositorio : NhRepositorio<Barrio>
    {
        public BarrioRepositorio(ISession sesion) : base(sesion)
        {
        }
    }
}
