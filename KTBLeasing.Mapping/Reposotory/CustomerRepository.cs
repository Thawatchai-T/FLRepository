using System;
using System.Collections.Generic;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Domain;
using NHibernate.Criterion;
using KTBLeasing.Domain.ViewCommonData;


namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICustomerRepository
    {
        bool Insert(Customer entity);
        bool Update(Customer entity);
        bool SaveOrUpdate(Customer entity);
        Customer GetById(int id);
        List<Customer> GetAll();
        List<Customer> GetWihtPage(int start, int limit);
        List<Customer> Find(int start, int limit, string text, int type);
    }
    public class CustomerRepository : NhRepository, ICustomerRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public bool Insert(Customer entity)
        {
            try
            {
                this.Insert<Customer>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }

        public bool Update(Customer entity)
        {
            try
            {
                this.Update<Customer>(entity);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
            
        }

        public bool SaveOrUpdate(Customer entity)
        {
            try
            {
                //this.SaveOrUpdate<Customer>(entity);
                var result = this.GetById((int)entity.Id);
                if (result != null)
                {
                    this.Update(entity);
                }
                else
                {
                    this.Insert(entity);
                }

                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
        }

        public Customer GetById(int id)
        {
            using(var session = SessionFactory.OpenStatelessSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    var result = session.Get<Customer>(id);
                    //var result = session.QueryOver<Customer>().List().Where(x => x.Id == id);
                    //var result1 = session.CreateCriteria(typeof(Customer));
                    //result1.Add(
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public List<Customer> GetAll()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    return session.QueryOver<Customer>().List<Customer>() as List<Customer>;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public List<Customer> GetWihtPage(int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    var result = session.QueryOver<Customer>().Skip(start).Take(limit).List<Customer>() as List<Customer>;

                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
            
        }

        public List<Customer> Find(int start, int limit, string text,int type)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = session.QueryOver<Customer>().Where(
                //    Restrictions.Like("NameTh", text) ||
                //    Restrictions.Like("NameEng", text)
                //    ).List<Customer>().Skip(start).Take(limit);
                var criteria = session.CreateCriteria(typeof(Customer));
                switch (type)
                {
                    case 0:
                        int value;
                        if(int.TryParse(text,out value)){
                        criteria.Add(Expression.Eq("Id", value));
                        }
                        break;
                    case 1:
                        criteria.Add(Expression.Like("NameEng", text));
                        break;
                    case 2:
                        criteria.Add(Expression.Like("NameTh", text));
                        break;
                }
                
                session.Close();
                return criteria.List<Customer>() as List<Customer>;

            }
        }


    }
}
