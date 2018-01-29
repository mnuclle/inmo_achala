using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ImagenInmuebleRepositorio _imagenInmuebleRepositorio;

        public InmuebleServicio(InmuebleRepositorio inmuebleRepositorio, ImagenInmuebleRepositorio imagenInmuebleRepositorio)
        {
            this._inmuebleRepositorio = inmuebleRepositorio;
            this._imagenInmuebleRepositorio = imagenInmuebleRepositorio;
        }

        public void Guardar(Inmueble inmueble)
        {
            _inmuebleRepositorio.Guardar(inmueble);
            if (inmueble.Imagenes != null)
            {
                foreach (var imagen in inmueble.Imagenes)
                {
                    imagen.Inmueble = inmueble;
                    _imagenInmuebleRepositorio.Guardar(imagen);
                }
            }
        }

        public Inmueble ObtenerPorId(int id)
        {
            return _inmuebleRepositorio.ConsultarPorId(id);
        }

        public void Eliminar(Inmueble inmueble)
        {
            _inmuebleRepositorio.Eliminar(inmueble);
        }

        public IList<Inmueble> ObtenerTodos()
        {
            return _inmuebleRepositorio.ObtenerTodas();
        }
        
    }
}
