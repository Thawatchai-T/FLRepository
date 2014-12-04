using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class CommonAddressRepository : NhRepository
    {
        public void Insert(CommonAddress entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }

        public List<CommonAddress> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<CommonAddress>().Skip(0).Take(1000).List<CommonAddress>() as List<CommonAddress>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<CommonAddress>().RowCount();
                session.Close();
                return result;
            }
        }
    }
}
