using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteP3Image.Controllers
{
    public class PublicaController : Controller
    {
        //
        // GET: /Publica/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario(int id)
        {
            return View();
        }

        //
        // GET: /Publica/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Publica/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Publica/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Publica/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Publica/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Publica/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Publica/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
