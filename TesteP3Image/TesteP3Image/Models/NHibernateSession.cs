using System;
using System.Collections.Generic;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace TesteP3Image.Models
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\Configuration\hibernate.cfg.xml");
            //var configurationPath = "D:\\web\\TesteP3Image\\TesteP3Image\\TesteP3Image\\Models\\NHibernate\\Configuration\\hibernate.cfg.xml";
            configuration.Configure(configurationPath.ToString().Replace("Publico", "TesteP3Image"));
            //var categoriasConfigurationFile = "D:\\web\\TesteP3Image\\TesteP3Image\\TesteP3Image\\Models\\NHibernate\\Mappings\\Categorias.hbm.xml";
            var categoriasConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\Mappings\Categorias.hbm.xml");
            configuration.AddFile(categoriasConfigurationFile.ToString().Replace("Publico","TesteP3Image"));
            //var subCategoriasConfigurationFile = "D:\\web\\TesteP3Image\\TesteP3Image\\TesteP3Image\\Models\\NHibernate\\Mappings\\SubCategorias.hbm.xml";
            var subCategoriasConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\Mappings\SubCategorias.hbm.xml");
            configuration.AddFile(subCategoriasConfigurationFile.ToString().Replace("Publico", "TesteP3Image"));
            //var camposConfigurationFile = "D:\\web\\TesteP3Image\\TesteP3Image\\TesteP3Image\\Models\\NHibernate\\Mappings\\Campos.hbm.xml";
            var camposConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\Mappings\Campos.hbm.xml");
            configuration.AddFile(camposConfigurationFile.ToString().Replace("Publico", "TesteP3Image"));
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
