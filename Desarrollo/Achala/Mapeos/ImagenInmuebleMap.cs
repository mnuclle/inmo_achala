using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Modelo;

namespace Mapeos
{
    public class ImagenInmuebleMap : ClassMap<ImagenInmueble>
    {
        public ImagenInmuebleMap()
        {
            Table("IMAGENES_X_INMUEBLE");
            Id(x => x.Id).Column("ID_IMAGEN_X_INMUEBLE").GeneratedBy.Identity();
            Map(x => x.Path).Column("PATH").Nullable().Length(500);
            References(x => x.Inmueble).Column("ID_INMUEBLE").Not.Nullable();
        }
    }
}
