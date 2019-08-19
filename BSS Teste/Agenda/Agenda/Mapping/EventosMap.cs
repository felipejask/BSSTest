using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using Agenda.Models;

namespace Agenda.Mapping
{
    public class EventosMap : ClassMap<Eventos>
    {
        public EventosMap()
        {
            Id(x => x.Id);
            Map(x => x.DataCriacao)
                .Not.Nullable();
            Map(x => x.DataEntrega)
                .Not.Nullable();
            Map(x => x.Titulo)
                .Not.Nullable();
            Map(x => x.Descricao);
            Map(x => x.FlagPronto)
                .Not.Nullable();
            Table("eventos");
        }
    }
}