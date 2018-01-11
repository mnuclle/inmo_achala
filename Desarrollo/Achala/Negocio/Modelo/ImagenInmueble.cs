using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Modelo
{
    public class ImagenInmueble : Entidad
    {
        public virtual string Path { get; set; }
        public virtual Inmueble Inmueble { get; set; }
    }
}
