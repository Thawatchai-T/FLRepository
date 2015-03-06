using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.AdoNet.Util;
using NHibernate.Criterion;
using log4net;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl
{
    public class NhRepository : IDisposable
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        ~NhRepository()
        {
            Dispose(false);
        }

        public NhRepository()
        {
            
        }

        private ISessionFactory _sessionFactory = null;
        public static string NHibernateGeneratedSQL { get; set; }
        public static int QueryCounter { get; set; }
        public static string FormatSQL()
        {
            BasicFormatter formatter = new BasicFormatter();
            return formatter.Format(NHibernateGeneratedSQL.ToUpper());
        }

        public ISessionFactory SessionFactory
        {
            protected get { return _sessionFactory; }
            set { _sessionFactory = value; }
        }

        public IList<T> ExecuteICriteria<T>()
        {
            //using (ITransaction transaction = Session.BeginTransaction())
            using (var Session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof(T)).List<T>();
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    throw;
                }
            }
        }

        public void Update<T>(T enity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.Update(enity);
                    tran.Commit();
                }
                catch (Exception executeICriteria)
                {
                    tran.Rollback();
                    Logger.Error(executeICriteria);
                    throw executeICriteria;

                }
            }
        }

        public void Insert<T>(T entity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.Insert(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.Error(ex);
                    throw;
                }
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            using (var Session = SessionFactory.OpenSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.Error(ex);
                }
                

            }

        }

        public void Delete<T>(T entity)
        {
            using (var Session = SessionFactory.OpenSession())
            using (var ts = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    Logger.Error(ex);
                    throw;
                }
            }
        }

        public IList<T> ExecuteICriteriaOrderBy<T>(T entity, string orderBy)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof(T))
                    .AddOrder(Order.Asc(orderBy))
                    .List<T>();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Logger.Error(ex);
                    throw;
                }
            }
        }
    }
}
