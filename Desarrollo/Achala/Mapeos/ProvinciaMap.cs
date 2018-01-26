using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Modelo;

namespace Mapeos
{
    class ProvinciaMap : ClassMap<Provincia>
    {
        public ProvinciaMap()
        {
            Table("PROVINCIAS");
            Id(x => x.Id).Column("ID_PROVINCIA").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("N_PROVINCIA").Nullable().Length(200);
        }
    }
}
