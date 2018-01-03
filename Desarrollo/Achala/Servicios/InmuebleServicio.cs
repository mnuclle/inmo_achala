using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Repositorios;

namespace Servicios
{
    public class InmuebleServicio
    {

        private readonly InmuebleRepositorio _inmuebleRepositorio;


        public InmuebleServicio(InmuebleRepositorio inmuebleRepositorio)
        {
            this._inmuebleRepositorio = inmuebleRepositorio;
        }

        public void Guardar(Inmueble inmueble)
        {
            _inmuebleRepositorio.Guardar(inmueble);
        }

        public Inmueble ObtenerPorId(int id)
        {
            return _inmuebleRepositorio.ConsultarPorId(id);
        }
        
    }
}
