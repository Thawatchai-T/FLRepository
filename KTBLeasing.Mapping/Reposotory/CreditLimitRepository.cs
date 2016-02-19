using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using log4net;
using System.Reflection;
using NHibernate.Criterion;
using System.Collections;
using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICreditLimitRepository
    {
        List<CreditLimitApproval> GetApproval(int start, int limit);
        CreditLimitApproval GetApproval(long id);
        List<CreditLimitApproval> GetApproval(int start, int limit, List<FilterModel> filter);
        List<CreditLimitDetail> GetDetail(int start, int limit, long master_id);
        int CountApproval();
        int CountApproval(List<FilterModel> filter);
        int CountDetail(long master_id);
        long Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);
    }

    class CreditLimitRepository : NhRepository, ICreditLimitRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<CreditLimitApproval> GetApproval(int start, int limit)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitApproval>()
                        .Fetch(x => x.Customer).Eager
                        .Where(x => x.Active == true)
                        .OrderBy(x => x.Id).Asc
                        //.Skip(start).Take(limit)
                        .List<CreditLimitApproval>() as List<CreditLimitApproval>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public CreditLimitApproval GetApproval(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitApproval>()
                        .Fetch(x => x.Customer).Eager
                        .Where(x => x.Active == true && x.Id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        private Conjunction GetCriteriaApproval(List<FilterModel> filter)
        {
            Conjunction conj = new Conjunction();

            foreach (var item in filter)
            {
                switch (item.type)
                {
                    case "number":
                        if (item.property == "StartAmount")
                        {
                            conj.Add(Restrictions.Ge("CreditLimit", Convert.ToDecimal(item.value)));
                        }
                        else if (item.property == "EndAmount")
                        {
                            conj.Add(Restrictions.Le("CreditLimit", Convert.ToDecimal(item.value)));
                        }
                        else
                        {
                            conj.Add(Restrictions.Eq(item.property, Convert.ToInt32(item.value)));
                        }
                        break;
                    case "string":
                        if (item.property != "CustFullName")
                        {
                            conj.Add(Restrictions.Like(item.property, string.Format("%{0}%", item.value)));
                        }
                        break;
                    case "date":
                        if (item.property == "StartDate")
                        {
                            conj.Add(Restrictions.Ge("ApproveDate", Convert.ToDateTime(item.value)));
                        }
                        else if (item.property == "EndDate")
                        {
                            conj.Add(Restrictions.Le("ApproveDate", Convert.ToDateTime(item.value)));
                        }
                        break;
                }
            }

            return conj;
        }

        private Conjunction GetCriteriaCustomer(List<FilterModel> filter)
        {
            Conjunction conj = new Conjunction();

            foreach (var item in filter)
            {
                switch (item.type)
                {
                    case "string":
                        if (item.property == "CustFullName")
                        {
                            conj.Add(Restrictions.Like("Customer.NameTh", string.Format("%{0}%", item.value)));
                        }
                        break;
                }
            }

            return conj;
        }

        public List<CreditLimitApproval> GetApproval(int start, int limit, List<FilterModel> filter)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    Conjunction conjApproval = this.GetCriteriaApproval(filter);
                    Conjunction conjCustomer = this.GetCriteriaCustomer(filter);

                    var result = session.CreateCriteria<CreditLimitApproval>()
                        .Add(conjApproval.Add(Restrictions.Eq("Active", true)))
                        .Add(conjCustomer)
                        .CreateCriteria("Customer", "Customer", JoinType.LeftOuterJoin)
                        .SetFirstResult(start).SetMaxResults(limit)
                        .List<CreditLimitApproval>() as List<CreditLimitApproval>;

                    return result;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<CreditLimitDetail> GetDetail(int start, int limit, long master_id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitDetail>()
                        .Fetch(x => x.CreditLimitApproval).Eager
                        .Fetch(x => x.CreditLimitApproval.Customer).Eager
                        .Where(x => x.CreditLimitApproval.Id == master_id && x.Active == true)
                        .OrderBy(x => x.Id).Asc
                        .Skip(start).Take(limit)
                        .List<CreditLimitDetail>() as List<CreditLimitDetail>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public int CountApproval()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitApproval>()
                        .Where(x => x.Active == true)
                        .List<CreditLimitApproval>().Count();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public int CountApproval(List<FilterModel> filter)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    Conjunction conjApproval = this.GetCriteriaApproval(filter);
                    Conjunction conjCustomer = this.GetCriteriaCustomer(filter);

                    return session.CreateCriteria<CreditLimitApproval>()
                        .Add(conjApproval.Add(Restrictions.Eq("Active", true)))
                        .Add(conjCustomer)
                        .CreateCriteria("Customer", "Customer", JoinType.LeftOuterJoin)
                        .List<CreditLimitApproval>().Count();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public int CountDetail(long master_id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitDetail>()
                        .Where(x => x.CreditLimitApproval.Id == master_id && x.Active == true)
                        .List<CreditLimitDetail>().Count();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public long Insert<T>(T entity)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    var result = base.Insert<T>(entity);

                    long id = Convert.ToInt64(result);
                    return id;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public void Update<T>(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Update<T>(entity);
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.SaveOrUpdate<T>(entity);
            }
        }

        public void Delete<T>(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Delete<T>(entity);
            }
        }
    }
}
