using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace TesteP3Image.Models.NHibernate
{
    public class CamposRepository
    {
        public IList<Campos> ObterTodos()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Campos>().ToList();
            }
        }

        public Campos BuscarPorId(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.CreateCriteria<Campos>().Add(Restrictions.Eq("CampoId", id)).UniqueResult<Campos>();
            }
        }

        public int UltimaOrdem()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return (session.Query<Campos>().Select(x => x.Ordem).OrderByDescending(x => x).FirstOrDefault() + 1);
            }
        }

    }
}