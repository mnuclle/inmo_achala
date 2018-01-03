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
            Map(x => x.TipoPropiedad).Column("ID_TIPO_PROPIEDAD").CustomType<TipoPropiedad>().Not.Nullable();
        }
    }
}
