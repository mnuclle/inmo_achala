using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Modelo;

namespace Mapeos
{
    public class DomicilioMap : ClassMap<Domicilio>
    {
        public DomicilioMap()
        {
            Table("DOMICILIOS");
            Id(x => x.Id).Column("ID_DOMICILIO").GeneratedBy.Identity();
            Map(x => x.Calle).Column("CALLE").Nullable().Length(200);
            Map(x => x.Altura).Column("ALTURA").Nullable().Length(6);
            Map(x => x.Piso).Column("PISO").Nullable().Length(4);
            Map(x => x.Departamento).Column("DEPARTAMENTO").Nullable().Length(100);
            Map(x => x.Torre).Column("TORRE").Nullable().Length(100);
            Map(x => x.Manzana).Column("MANZANA").Nullable().Length(100);
            Map(x => x.Lote).Column("LOTE").Nullable().Length(100);
            Map(x => x.Latitud).Column("LATITUD").Nullable().Length(50);
            Map(x => x.Longitud).Column("LONGITUD").Nullable().Length(50);
            References<Barrio>(x => x.Barrio).Column("ID_BARRIO").Nullable();
            References<Localidad>(x => x.Localidad).Column("ID_LOCALIDAD").Nullable();
            Map(x => x.TipoBarrio).Column("ID_TIPO_BARRIO").CustomType<TipoBarrio>().Nullable();
        }
    }
}
