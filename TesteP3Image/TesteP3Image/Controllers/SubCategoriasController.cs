using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using TesteP3Image.Models;
using TesteP3Image.Models.NHibernate;

namespace TesteP3Image.Controllers
{
    public class SubCategoriasController : Controller
    {
        CategoriasRepository _repository;

        public SubCategoriasController()
        {
            _repository = new CategoriasRepository();
        }

        public ActionResult Index()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var subCategorias = session.Query<SubCategorias>().ToList();
                foreach(var item in subCategorias)
                {
                    item.Categoria = _repository.BuscarPorId(item.CategoriaId);
                }
                return View(subCategorias);
            }
        }

        public ActionResult Detalhes(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var subCategoria = session.Get<SubCategorias>(id);
                subCategoria.Categoria = _repository.BuscarPorId(subCategoria.CategoriaId);
                return View(subCategoria);
            }
        }

        public ActionResult Inserir()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                IList<Categorias> listCat = _repository.ObterCategorias();

                var listaCategorias = (from u in listCat.AsEnumerable()
                                 select new SelectListItem
                                 {
                                     Text = u.Descricao,
                                     Value = u.CategoriaId.ToString()
                                 }).AsEnumerable();

                ViewBag.ListItems = listaCategorias;

                return View();    
            }
            
        }

        [HttpPost]
        public ActionResult Inserir(SubCategorias subCategoria)
        {
            ModelState.Remove("Categoria.Descricao");
            if (ModelState.IsValid)
            {
                subCategoria.CategoriaId = subCategoria.Categoria.CategoriaId;
                try
                {
                    using (ISession session = NHibernateSession.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Save(subCategoria);
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
            else
            {
                SubCategorias model = new SubCategorias();
                model.SubCategoriaId = subCategoria.Categoria.CategoriaId;

                IList<Categorias> listCat = _repository.ObterCategorias();

                var listaCategorias = (from u in listCat.AsEnumerable()
                                       select new SelectListItem
                                       {
                                           Text = u.Descricao,
                                           Value = u.CategoriaId.ToString()
                                       }).AsEnumerable();

                ViewBag.ListItems = listaCategorias;

                return View(model);
            }
        }

        public ActionResult Editar(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                IList<Categorias> listCat = _repository.ObterCategorias();

                var listaCategorias = (from u in listCat.AsEnumerable()
                                       select new SelectListItem
                                       {
                                           Text = u.Descricao,
                                           Value = u.CategoriaId.ToString()
                                       }).AsEnumerable();

                ViewBag.ListItems = listaCategorias;
                var subCategoria = session.Get<SubCategorias>(id);
                subCategoria.Categoria = _repository.BuscarPorId(subCategoria.CategoriaId);
                return View(subCategoria);
            }
        }

        [HttpPost]
        public ActionResult Editar(int id, SubCategorias subCategoria)
        {
            ModelState.Remove("Categoria.Descricao");
            if (ModelState.IsValid)
            {
                try
                {
                    using (ISession session = NHibernateSession.OpenSession())
                    {
                        var subCategoriaAtualizada = session.Get<SubCategorias>(id);

                        subCategoriaAtualizada.CategoriaId = subCategoria.Categoria.CategoriaId;
                        subCategoriaAtualizada.Descricao = subCategoria.Descricao;
                        subCategoriaAtualizada.SubCategoriaId = subCategoria.SubCategoriaId;

                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Save(subCategoriaAtualizada);
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
            else
            {
                SubCategorias model = new SubCategorias();
                subCategoria.SubCategoriaId = subCategoria.Categoria.CategoriaId;

                IList<Categorias> listCat = _repository.ObterCategorias();

                var listaCategorias = (from u in listCat.AsEnumerable()
                                       select new SelectListItem
                                       {
                                           Text = u.Descricao,
                                           Value = u.CategoriaId.ToString()
                                       }).AsEnumerable();

                ViewBag.ListItems = listaCategorias;

                return View(subCategoria);
            }
        }

        public ActionResult Excluir(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var subCategoria = session.Get<SubCategorias>(id);
                subCategoria.Categoria = _repository.BuscarPorId(subCategoria.CategoriaId);
                return View(subCategoria);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id, SubCategorias subCategoria)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var subCategoriaDeletar = session.Get<SubCategorias>(id);
                        session.Delete(subCategoriaDeletar);
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
