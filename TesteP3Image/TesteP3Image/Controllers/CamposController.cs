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
    public class CamposController : Controller
    {
        CamposRepository _camposRepository;

        public CamposController()
        {
            _camposRepository = new CamposRepository();
        }

        public ActionResult Index(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var campos = session.Query<Campos>().ToList().Where(x => x.SubCategoriaId == id);
                foreach (var item in campos)
                {
                    item.TipoTxt = Enum.GetName(typeof(TiposEnum), item.Tipo);
                }
                var subCat = session.Get<SubCategorias>(id);
                SubCatCampos retorno = new SubCatCampos();
                retorno.listaCampos = campos.ToList();
                retorno.SubCategoria = subCat;
                return View(retorno);
            }
        }

        public ActionResult Detalhes(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var campo = session.Get<Campos>(id);
                campo.SubCategoria = session.Get<SubCategorias>(campo.SubCategoriaId);
                campo.TipoTxt = Enum.GetName(typeof(TiposEnum), campo.Tipo);
                return View(campo);
            }
        }

        public ActionResult Inserir(int id)
        {
            Campos model = new Campos();
            model.SubCategoriaId = id;

            model.TipoItens = Enum.GetValues(typeof(TiposEnum)).Cast<TiposEnum>().Select(o => new SelectListItem
            {
                Text = o.ToString(),
                Value = ((int)o).ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Inserir(Campos campo)
        {
            if (campo.Tipo == 1 || campo.Tipo == 2)
            {
                ModelState.Remove("Lista");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (ISession session = NHibernateSession.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            campo.Ordem = _camposRepository.UltimaOrdem();

                            session.Save(campo);
                            transaction.Commit();
                        }
                    }
                    return RedirectToAction("Index", new { id = campo.SubCategoriaId });
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                Campos model = new Campos();
                model.SubCategoriaId = campo.SubCategoriaId;

                model.TipoItens = Enum.GetValues(typeof(TiposEnum)).Cast<TiposEnum>().Select(o => new SelectListItem
                {
                    Text = o.ToString(),
                    Value = ((int)o).ToString()
                }).ToList();

                return View(model);
            }
        }

        public ActionResult Editar(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var campo = session.Get<Campos>(id);

                campo.TipoItens = Enum.GetValues(typeof(TiposEnum)).Cast<TiposEnum>().Select(o => new SelectListItem
                {
                    Text = o.ToString(),
                    Value = ((int)o).ToString()
                }).ToList();

                return View(campo);
            }

        }

        [HttpPost]
        public ActionResult Editar(int id, Campos campo)
        {
            if (campo.Tipo == 1 || campo.Tipo == 2)
            {
                ModelState.Remove("Lista");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (ISession session = NHibernateSession.OpenSession())
                    {
                        var campoAtualizado = session.Get<Campos>(id);

                        campoAtualizado.CampoId = campo.CampoId;
                        campoAtualizado.Descricao = campo.Descricao;
                        campoAtualizado.Lista = campo.Lista;
                        campoAtualizado.Ordem = campo.Ordem;
                        campoAtualizado.Tipo = campo.Tipo;
                        campoAtualizado.SubCategoriaId = campo.SubCategoriaId;

                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Save(campoAtualizado);
                            transaction.Commit();
                        }
                    }
                    return RedirectToAction("Index", new { id = campo.SubCategoriaId });
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                //Campos model = new Campos();
                //model.SubCategoriaId = campo.SubCategoriaId;


                campo.TipoItens = Enum.GetValues(typeof(TiposEnum)).Cast<TiposEnum>().Select(o => new SelectListItem
                {
                    Text = o.ToString(),
                    Value = ((int)o).ToString()
                }).ToList();

                return View(campo);
            }
        }

        public ActionResult Excluir(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var campo = session.Get<Campos>(id);
                return View(campo);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id, Campos campo)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var campoDeletar = session.Get<Campos>(id);
                        session.Delete(campoDeletar);
                        transaction.Commit();
                        return RedirectToAction("Index", new { id = campoDeletar.SubCategoriaId });
                    }
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
