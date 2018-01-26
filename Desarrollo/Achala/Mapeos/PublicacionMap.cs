using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using FluentNHibernate.Mapping;

namespace Mapeos
{
    public class PublicacionMap : ClassMap<Publicacion> 
    {
        public PublicacionMap()
        {
            Table("PUBLICACIONES");
            Id(x => x.Id).Column("ID_PUBLICACION").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("N_PUBLICACION").Not.Nullable().Length(200);
            Map(x => x.Descripcion).Column("DESCRIPCION_PUBLICACION").Nullable().Length(5000);
            Map(x => x.TipoOperacion).Column("ID_TIPO_OPERACION").CustomType<TipoOperacion>().Not.Nullable().Length(2);
            Map(x => x.Precio).Column("PRECIO").Nullable().Length(10);
            Map(x => x.FechaPublicacion).Column("FEC_PUBLICACION").Not.Nullable();
            Map(x => x.FechaBaja).Column("FEC_BAJA").Nullable();
            Map(x => x.EstadoPublicacion).Column("ID_ESTADO_PUBLICACION").CustomType<EstadoPublicacion>().Not.Nullable().Length(2);
            References<Inmueble>(x => x.Inmueble).Column("ID_INMUEBLE").Not.Nullable().Not.LazyLoad();
            Map(x => x.Prioridad).Column("PRIORIDAD").Not.Nullable().Length(2);
            Map(x => x.FechaModificacion).Column("FEC_MODIF").Not.Nullable();
        }
    }
}
