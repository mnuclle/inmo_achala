using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Modelo
{
    public class Localidad : Entidad
    {
        public virtual string Nombre { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}
