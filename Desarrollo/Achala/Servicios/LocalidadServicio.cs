using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Repositorios;

namespace Servicios
{
    public class LocalidadServicio
    {
        private readonly LocalidadRepositorio _localidadRepositorio;

        public LocalidadServicio(LocalidadRepositorio localidadRepositorio)
        {
            this._localidadRepositorio = localidadRepositorio;
        }

        public Localidad ObtenerPorId(int id)
        {
            if (id > 0)
            {
                return _localidadRepositorio.ConsultarPorId(id);
            }
            else
            {
                return null;
            }

        }
    }
}
