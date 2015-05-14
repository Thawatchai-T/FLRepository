using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IUsersAuthorizeRepository
    {
        void Insert(UsersAuthorize entity);
        List<UsersAuthorize> GetAll();
        List<UsersAuthorize> GetAll(int start, int limit);
        bool SaveOrUpdate(UsersAuthorize entity);
        bool Delete(long id);
        int Count();
        List<UsersAuthorize> Find(int start, int limit, string text);
        int Count(string text);
    }

    public class UsersAuthorizeRepository : NhRepository, IUsersAuthorizeRepository
    {
        public void Insert(UsersAuthorize entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }

        }

        public List<UsersAuthorize> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return   session.QueryOver<UsersAuthorize>().List<UsersAuthorize>() as List<UsersAuthorize>;
            }
        }

        public List<UsersAuthorize> GetAll(int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {
              var result = session.QueryOver<UsersAuthorize>().Skip(start).Take(limit);
              return result.List<UsersAuthorize>() as List<UsersAuthorize>;
            }
        }

        public bool SaveOrUpdate(UsersAuthorize entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    ts.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    ts.Dispose();
                    ts.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(long id)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    var sql = string.Format("update USERS_AUTHORIZE set active=0 where id = {0}", id);
                    session.CreateSQLQuery(sql).ExecuteUpdate();

                    ts.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    ts.Dispose();
                    ts.Rollback();
                    return false;
                }
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<UsersAuthorize>().RowCount();
                session.Close();
                return result;
            }
        }

        public List<UsersAuthorize> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<UsersAuthorize>().List<UsersAuthorize>() where x.UserId.Contains(text) select x).Skip(start).Take(limit);
                session.Close();
                return result.ToList<UsersAuthorize>();
                
            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<UsersAuthorize>().List<UsersAuthorize>() where x.UserId.Contains(text) select x);
                session.Close();
                return result.ToList<UsersAuthorize>().Count;
            }
        }
           
    }
}
