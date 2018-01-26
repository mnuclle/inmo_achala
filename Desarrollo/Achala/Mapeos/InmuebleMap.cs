using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Modelo;

namespace Mapeos
{
   public class InmuebleMap : ClassMap<Inmueble>
    {

        public InmuebleMap()
        {
            Table("INMUEBLES");
            Id(x => x.Id).Column("ID_INMUEBLE").GeneratedBy.Identity();
            Map(x => x.Antiguedad).Column("ANTIGUEDAD").Nullable().Length(3);
            Map(x => x.CantidadAmbientes).Column("CANTIDAD_AMBIENTES").Nullable().Length(2);
            Map(x => x.CantidadBaños).Column("CANTIDAD_BANIOS").Nullable().Length(2);
            Map(x => x.CantidadDormitorios).Column("CANTIDAD_DORMITORIOS").Nullable().Length(2);
            Map(x => x.Descripcion).Column("DESCRIPCION").Nullable().Length(1000);
            Map(x => x.Nombre).Column("N_INMUEBLE").Not.Nullable().Length(200);
            Map(x => x.SuperficieCubierta).Column("SUPERFICIE_CUBIERTA").Nullable().Length(5);
            Map(x => x.SuperficieTerreno).Column("SUPERFICIE_TERRENO").Nullable().Length(5);
            Map(x => x.SuperficieTotal).Column("SUPERFICIE_TOTAL").Nullable().Length(6);
            References<Domicilio>(x => x.Domicilio).Column("ID_DOMICILIO").Not.Nullable().Not.LazyLoad().Cascade.SaveUpdate();
            Map(x => x.TipoPropiedad).Column("ID_TIPO_PROPIEDAD").CustomType<TipoPropiedad>().Nullable();
            Map(x => x.EstadoInmueble).Column("ID_ESTADO_INMUEBLE").CustomType<EstadoInmueble>().Not.Nullable();
            Map(x => x.FechaBaja).Column("FEC_BAJA").Nullable();
            Map(x => x.FechaAlta).Column("FEC_ALTA").Not.Nullable();
            Map(x => x.FechaModificacion).Column("FEC_MODIF").Not.Nullable();
            Map(x => x.UbicacionDepartamento).Column("ID_UBICACION_DEPARTAMENTO").CustomType<UbicacionDepartamento>().Nullable();
            Map(x => x.AEstrenar).Column("A_ESTRENAR").Nullable();
            Map(x => x.TipoEmprendimiento).Column("ID_TIPO_EMPRENDIMIENTO").CustomType<TipoEmprendimiento>().Nullable();
            HasMany(x => x.Imagenes).KeyColumn("ID_IMAGEN_INMUEBLE");
        }
    }
}
