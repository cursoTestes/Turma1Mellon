using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SistemaVendas.model;

namespace SistemaVendas.nhibernate.orm
{
    public class VendaVendedorMap : ClassMap<VendaVendedor>
    {
        public VendaVendedorMap()
        {
            Id(x => x.IdVendaVendedor).GeneratedBy.Identity();
            Map(x => x.IdVendedor);
            Map(x => x.IdVenda);
            Map(x => x.ValorParticipacao);
        }
    }
}
