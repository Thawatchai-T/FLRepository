using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class UserInRoleRepository : NhRepository
    {
        public void Insert(UserInRole entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }

        }

        public List<UserInRole> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return   session.QueryOver<UserInRole>().List<UserInRole>() as List<UserInRole>;
            }
        }

        public List<UserInRole> GetAll(int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<UserInRole>()
                    .Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Skip(start).Take(limit)
                    .List<UserInRole>();
                    
                return result as List<UserInRole>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<UserInRole>().RowCount();
                session.Close();
                return result;
            }
        }

        public List<UserInRole> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<UserInRole>()
                                  .Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                  .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                  .Skip(start).Take(limit)
                                  .List<UserInRole>() where x.UsersAuthorize.UserId.Contains(text) select x).Skip(start).Take(limit)
                    ;
                session.Close();
                return result.ToList<UserInRole>();
                
            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<UserInRole>().List<UserInRole>() where x.UsersAuthorize.UserId.Contains(text) select x);
                session.Close();
                return result.ToList<UserInRole>().Count;
            }
        }
    }
}
