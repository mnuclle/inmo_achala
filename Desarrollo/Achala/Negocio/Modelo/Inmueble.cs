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
        public virtual EstadoInmueble EstadoInmueble { get; set; }
        public virtual DateTime FechaBaja { get; set; }
        public virtual DateTime FechaAlta { get; set; }
        public virtual DateTime FechaModificacion { get; set; }
        public virtual List<ImagenInmueble> Imagenes { get; set; }
        public virtual UbicacionDepartamento? UbicacionDepartamento { get; set; }
        public virtual string AEstrenar { get; set; }
        public virtual TipoEmprendimiento? TipoEmprendimiento { get; set; }
    }
}
