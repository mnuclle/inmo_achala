using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Modelo
{
    public class Publicacion : Entidad
    {
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual TipoOperacion TipoOperacion { get; set; }
        public virtual double Precio { get; set; }
        public virtual DateTime FechaPublicacion { get; set; }
        public virtual DateTime FechaBaja { get; set; }
        public virtual EstadoPublicacion EstadoPublicacion { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public virtual int Prioridad { get; set; }
    }
}
