using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Repositorios;

namespace Servicios
{
    public class ImagenInmuebleServicio
    {
        private readonly ImagenInmuebleRepositorio _imagenInmuebleRepositorio;

        public ImagenInmuebleServicio(ImagenInmuebleRepositorio imagenInmuebleRepositorio)
        {
            this._imagenInmuebleRepositorio = imagenInmuebleRepositorio;
        }
        
    }
}
