using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Transform;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICustomerSignerRepository
    {
        void Insert(CustomerSignerDomain entity);
        void Update(CustomerSignerDomain entity);
        void SaveOrUpdate(CustomerSignerDomain entity);
        List<CustomerSignerDomain> GetAll();
    }
    public class CustomerSignerRepository : NhRepository, ICustomerSignerRepository
    {
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
                }
            }
        }

        public void SaveOrUpdate(CustomerSignerDomain entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    ts.Rollback();
                }
            }
        }

        public List<CustomerSignerDomain> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = session.QueryOver<CustomerSignerDomain>().List<CustomerSignerDomain>();
                    return result as List<CustomerSignerDomain>;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
