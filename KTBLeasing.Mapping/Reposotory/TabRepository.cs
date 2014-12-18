using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;


namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ITabRepository
    {
        void Insert(Tab entity);
        List<Tab> Get();
        int Count();
    }
    public class TabRepository : NhRepository, ITabRepository
    {
        public void Insert(Tab entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }

        public List<Tab> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Tab>().List<Tab>() as List<Tab>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Tab>().RowCount();
                session.Close();
                return result;
            }
        }
    }
}
