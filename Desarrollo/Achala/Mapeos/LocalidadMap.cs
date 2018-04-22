using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using FluentNHibernate.Mapping;

namespace Mapeos
{
    public class LocalidadMap : ClassMap<Localidad>
    {
        public LocalidadMap()
        {
            Table("LOCALIDADES");
            Id(x => x.Id).Column("ID_LOCALIDAD").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Nombre).Column("N_LOCALIDAD").Nullable().Length(200);
            References<Departamento>(x => x.Departamento).Column("ID_DEPARTAMENTO").Nullable().Not.LazyLoad();
        }
    }

}
