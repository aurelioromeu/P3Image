using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteP3Image.Models.NHibernate;
using NHibernate;
using NHibernate.Linq;
using TesteP3Image.Models;
using Publico.Models;

namespace Publico.Controllers
{
    public class FormularioController : Controller
    {
        CamposRepository _camposRepository;

        public FormularioController()
        {
            _camposRepository = new CamposRepository();
        }

        //
        // GET: /Formulario/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario(int CategoriaId, int SubCategoriaId)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var model = new FormularioModel();
                var campos = session.Query<Campos>().ToList().Where(x => x.SubCategoriaId == SubCategoriaId);
                var subCategoria = session.Get<SubCategorias>(SubCategoriaId);
                model.Subcategoria = subCategoria;
                model.Categoria = session.Get<Categorias>(CategoriaId);
                model.Campos = campos.ToList();
                if (campos.Count() > 0)
                {
                    model.TemRegistros = true;
                }
                else
                {
                    model.TemRegistros = false;
                }
                return View(model);
            }
        }

    }
}
