using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using TesteP3Image.Models;

namespace TesteP3Image.Controllers
{
    public class CategoriasController : Controller
    {

        public ActionResult Index()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var categorias = session.Query<Categorias>().ToList();
                return View(categorias);
            }
        }

        public ActionResult Detalhes(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var categoria = session.Get<Categorias>(id);
                return View(categoria);
            }
        }

        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Categorias categoria)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(categoria);
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

        public ActionResult Editar(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var categoria = session.Get<Categorias>(id);
                return View(categoria);
            }

        }

        [HttpPost]
        public ActionResult Editar(int id, Categorias categoria)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var categoriaAtualizada = session.Get<Categorias>(id);

                    categoriaAtualizada.CategoriaId = categoria.CategoriaId;
                    categoriaAtualizada.Descricao = categoria.Descricao;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(categoriaAtualizada);
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

        public ActionResult Excluir(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var categoria = session.Get<Categorias>(id);
                return View(categoria);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id, Categorias categoria)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var categoriaDeletar = session.Get<Categorias>(id);
                        session.Delete(categoriaDeletar);
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
    }
}
