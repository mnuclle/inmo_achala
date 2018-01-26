using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Domicilio : Entidad
    {
        public virtual string Calle { get; set; }
        public virtual int Altura { get; set; }
        public virtual int Piso { get; set; }
        public virtual string Departamento { get; set; }
        public virtual string Torre { get; set; }
        public virtual string Manzana { get; set; }
        public virtual string Lote { get; set; }
        public virtual string Latitud { get; set; }
        public virtual string Longitud { get; set; }
        public virtual Barrio Barrio { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual TipoBarrio? TipoBarrio { get; set; }
    }
}
