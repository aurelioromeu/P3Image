using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteP3Image.Controllers;
using TesteP3Image.Models;
using TesteP3Image.Models.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace TesteP3Image.Tests
{
    [TestClass]
    public class TesteAdmin
    {
        [TestMethod]
        public void TestarIndex()
        {
            var controller = new CategoriasController();
            var result = controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            
        }


        [TestMethod]
        public void TestarCriacaoCategoriaView()
        {
            CategoriasController controller = new CategoriasController();

            ViewResult result = controller.Inserir() as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void TestarCriacaoCategoria()
        {
            CategoriasRepository _repository;
            _repository = new CategoriasRepository();

            Categorias modelTeste = new Categorias();
            modelTeste.Descricao = "novaDescricao";

            CategoriasController controller = new CategoriasController();
            var result = controller.Inserir(modelTeste);
            // get the list of books

            IList<Categorias> listaCategorias = _repository.ObterCategorias();
            List<Categorias> teste = new List<Categorias>();
            foreach (Categorias item in listaCategorias)
            {
                teste.Add(item);
            }
            CollectionAssert.Contains(teste, modelTeste, "erro");

        }


        [TestMethod]
        public void TestarCriacaoCategoriaRedirect()
        {
            Categorias modelTeste = new Categorias();

            modelTeste.Descricao = "Teste de Descrição";

            CategoriasController controller = new CategoriasController();

            var result = controller.Inserir(modelTeste) as RedirectToRouteResult;

            var routeValue = result.RouteValues["action"];

            //Assert
            Assert.AreEqual(routeValue, "Index");
        }
    }
}
