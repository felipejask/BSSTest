using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda
{
    public class Agenda<T> : IEventosCRUD<T> where T : class
    {
        public void Alterar(T entidade)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao alterar evento: " + ex.Message);
                    }
                }
            }
        }

        public IList<T> Consultar()
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                return (from c in session.Query<T>() select c).ToList();
            }
        }

        public void Excluir(T entidade)
        {
            using(ISession session = SessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao excluir evento: " + ex.Message);
                    }
                }
            }
        }

        public void Inserir(T entidade)
        {
            using (ISession session = SessionFactory.AbrirSession())
            { 
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Evento : " + ex.Message);
                    }
                }
            }
        }

        public T RetornarPorId(int Id)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                return session.Get<T>(Id);
            }
        }
    }
}