using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class UserInTabRepository : NhRepository
    {
        public void Insert(UserInTab entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }

        }

        public List<UserInTab> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return   session.QueryOver<UserInTab>()
                    .Fetch(x => x.Role).Eager
                    .TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.Tab).Eager
                    .TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<UserInTab>() as List<UserInTab>;
            }
        }

        public List<UserInTab> Get(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return null;
                    //session.QueryOver<UserInTab>()
                    //.Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    //.Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    //.Where(x => x.Id == id)
                    //.List<UserInTab>() as List<UserInTab>;
            }
        }

        public List<UserInTab> GetAll(int start, int limit)
        {
            //using (var session = SessionFactory.OpenStatelessSession())
            //{
            //    var result = session.QueryOver<UserInTab>()
            //        .Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
            //        .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
            //        .Skip(start).Take(limit)
            //        .List<UserInTab>();
                    
            //    return result as List<UserInTab>;
            //}
            return null;
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<UserInTab>().RowCount();
                session.Close();
                return result;
            }
        }

        public List<UserInTab> Find(int start, int limit, string text)
        {
            //using (var session = SessionFactory.OpenSession())
            //{
            //    var result = (from x in session.QueryOver<UserInTab>()
            //                      .Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
            //                      .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
            //                      .Skip(start).Take(limit)
            //                      .List<UserInTab>() where x.UsersAuthorize.UserId.Contains(text) select x).Skip(start).Take(limit)
            //        ;
            //    session.Close();
            //    return result.ToList<UserInTab>();
                
            //}
            return null;
        }

        public int Count(string text)
        {
            //using (var session = SessionFactory.OpenSession())
            //{
            //    var result = (from x in session.QueryOver<UserInTab>().List<UserInTab>() where x.RoleId.Contains(text) select x);
            //    session.Close();
            //    return result.ToList<UserInTab>().Count;
            //}
            return 0;
        }
    }
}
