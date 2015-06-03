using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Transform;
using KTBLeasing.Domain;
using log4net;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICustomerSignerRepository
    {
        void Insert(CustomerSignerDomain entity);
        void Update(CustomerSignerDomain entity);
        bool SaveOrUpdate(CustomerSignerDomain entity);
        List<CustomerSignerDomain> GetAll(int start, int limit);
        List<CustomerSignerDomain> GetAll(int p, int start, int limit);
    }
    public class CustomerSignerRepository : NhRepository, ICustomerSignerRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(CustomerSignerDomain entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    ts.Rollback();
                    Logger.Error(e);
                }
            }
        }

        public void Update(CustomerSignerDomain entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    ts.Rollback();
                    Logger.Error(e);
                }
            }
        }

        public bool SaveOrUpdate(CustomerSignerDomain entity)
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
                    ts.Rollback();
                    Logger.Error(e);
                    return false;
                }
            }
        }

        public List<CustomerSignerDomain> GetAll(int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = session.QueryOver<CustomerSignerDomain>().Skip(start).Take(limit).List<CustomerSignerDomain>();
                    return result as List<CustomerSignerDomain>;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }

        public List<CustomerSignerDomain> GetAll(int custId, int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = session.QueryOver<CustomerSignerDomain>().Where(x => x.CustomerId == custId).Skip(start).Take(limit).List<CustomerSignerDomain>();
                    return result as List<CustomerSignerDomain>;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }
    }
}
