using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Barrio : Entidad
    {
        public virtual string Nombre { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
