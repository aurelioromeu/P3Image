using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;

namespace TesteP3Image.Models.NHibernate
{
    public class SubCategoriasRepository
    {
        public IList<SubCategorias> ObterSubCategorias()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<SubCategorias>().ToList();
            }
        }

    }
}