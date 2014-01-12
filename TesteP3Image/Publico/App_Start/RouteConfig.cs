using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Publico
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{CategoriaId}/{SubCategoriaId}",
                defaults: new { controller = "Formulario", action = "Formulario", CategoriaId = 1, SubCategoriaId = 1 }
            );
        }
    }
}