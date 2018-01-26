using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using FluentNHibernate.Mapping;

namespace Mapeos
{
    public class DepartamentoMap : ClassMap<Departamento>
    {
        public DepartamentoMap()
        {
            Table("DEPARTAMENTOS");
            Id(x => x.Id).Column("ID_DEPARTAMENTO").GeneratedBy.Identity();
            Map(x => x.Nombre).Column("N_DEPARTAMENTO").Nullable().Length(200);
            References<Provincia>(x => x.Provincia).Column("ID_PROVINCIA").Nullable().Not.LazyLoad();
        }
    }
}
