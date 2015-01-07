using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{

    public interface IUserInRoleRepository
    {
        void Insert(UserInRole entity);
        List<UserInRole> GetAll();
        List<UserInRole> Get(long id);
        List<UserInRole> GetAll(int start, int limit);
        int Count();
        List<UserInRole> Find(int start, int limit, string text);
        int Count(string text);
        bool SaveOrUpdate(UserInRole entity);
        bool Delete(UserInRole entity);
    }
    public class UserInRoleRepository : NhRepository, IUserInRoleRepository
    {
        public void Insert(UserInRole entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
               var obj =  session.Save(entity);
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

        public List<UserInRole> Get(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<UserInRole>()
                    .Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Where(x => x.Id == id)
                    .List<UserInRole>() as List<UserInRole>;
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

        public bool SaveOrUpdate(UserInRole entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return true;
                }
            }
        }

        public bool Delete(UserInRole entity)
        {
            try
            {
                this.Delete<UserInRole>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
