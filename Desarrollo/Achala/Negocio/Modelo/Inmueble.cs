using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public class Inmueble : Entidad
    {
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int SuperficieCubierta { get; set; }
        public virtual int SuperficieTerreno { get; set; }
        public virtual int SuperficieTotal { get; set; }
        public virtual int CantidadBaños { get; set; }
        public virtual int CantidadAmbientes { get; set; }
        public virtual int CantidadDormitorios { get; set; }
        public virtual int Antiguedad { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual TipoPropiedad TipoPropiedad { get; set; }
    }
}
