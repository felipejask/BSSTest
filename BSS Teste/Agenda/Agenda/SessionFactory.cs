using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agenda.Models;
using NHibernate.Tool.hbm2ddl;

namespace Agenda
{
    public class SessionFactory
    {
        public static ISession CriarSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                                                    .Database(PostgreSQLConfiguration.PostgreSQL82
                                                            .ConnectionString("Server=localhost; Port=5432; User Id=postgres; Password=1234; Database=Agenda")
                                                            .ShowSql())
                                                    .Mappings(m =>
                                                                m.FluentMappings
                                                                .AddFromAssemblyOf<Eventos>())
                                                    .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                                                .Create(false, false))
                                                    .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public static ISession AbrirSession()
        {
            return CriarSession();
        }
    }
}