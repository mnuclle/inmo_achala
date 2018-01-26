using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using FluentNHibernate.Mapping;

namespace Mapeos
{
    public class BarrioMap : ClassMap<Barrio>
    {
        public BarrioMap()
        {
            Table("BARRIOS");
            Id(x => x.Id).Column("ID_BARRIO").GeneratedBy.Identity().UnsavedValue(0);
            Map(x => x.Nombre).Column("N_BARRIO").Nullable().Length(200);
            References<Localidad>(x => x.Localidad).Column("ID_LOCALIDAD").Nullable().Not.LazyLoad();
        }
    }
}
