using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace TesteP3Image.Models.NHibernate
{
    public class CategoriasRepository
    {
        public IList<Categorias> ObterCategorias()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Categorias>().ToList();
            }
        }

        public Categorias BuscarPorId(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.CreateCriteria<Categorias>().Add(Restrictions.Eq("CategoriaId", id)).UniqueResult<Categorias>();
            }
        }

    }
}