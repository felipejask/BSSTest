using Agenda.Models;
using Agenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace Agenda.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        public ActionResult Index()
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                var eventos = session.Query<Eventos>().ToList();
                return View(eventos);
            }
        }

        private int Eventos()
        {
            throw new NotImplementedException();
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                var eventos = session.Get<Eventos>(id);

                return View(eventos);
            }
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        public ActionResult Create(Eventos eventos)
        {
            try
            {
                using (ISession session = SessionFactory.AbrirSession())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Save(eventos);
                        transacao.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                var eventos = session.Get<Eventos>(id);
                return View(eventos);
            }
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Eventos eventos)
        {
            try
            {
                using (ISession session = SessionFactory.AbrirSession())
                {
                    var eventosAlterado = session.Get<Eventos>(id);

                    eventosAlterado.DataCriacao = Convert.ToDateTime(eventos.DataCriacao);
                    eventosAlterado.DataEntrega = Convert.ToDateTime(eventos.DataEntrega);
                    eventosAlterado.Titulo = eventos.Titulo;
                    eventosAlterado.Descricao = eventos.Descricao;
                    eventosAlterado.FlagPronto = eventos.FlagPronto;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(eventosAlterado);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = SessionFactory.AbrirSession())
            {
                var eventos = session.Get<Eventos>(id);
                return View(eventos);
            }
        }

        // POST: Eventos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Eventos eventos)
        {
            try
            {
                using (ISession session = SessionFactory.AbrirSession())
                {
                    using (ITransaction transacao = session.BeginTransaction())
                    {
                        session.Delete(eventos);
                        transacao.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
