using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IRoleRepository
    {
        void Insert(Role entity);
        List<Role> Get();
        int Count();
    }
    public class RoleRepository : NhRepository, IRoleRepository
    {
        public void Insert(Role entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }

        public List<Role> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Role>().List<Role>() as List<Role>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<Role>().RowCount();
                session.Close();
                return result;
            }
        }
    }
}
