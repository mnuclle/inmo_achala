using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Repositorios;

namespace Servicios
{
    public class BarrioServicio
    {
        private readonly BarrioRepositorio _barrioRepositorio;

        public BarrioServicio(BarrioRepositorio barrioRepositorio)
        {
            this._barrioRepositorio = barrioRepositorio;
        }

        public Barrio ObtenerPorId(int id)
        {
            if (id > 0)
            {
                return _barrioRepositorio.ConsultarPorId(id);
            }
            else
            {
                return null;
            }
        }
    }
}
