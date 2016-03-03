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
using KTBLeasing.FrontLeasing.Domain.ViewModel;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICreditLimitRepository
    {
        List<CreditLimitMasterView> GetApproval(int start, int limit);
        CreditLimitApproval GetApproval(long id);
        List<CreditLimitMasterView> GetApproval(int start, int limit, List<FilterModel> filter);
        List<CreditLimitDetail> GetDetail(int start, int limit, long master_id);
        List<CreditLimitCustomerView> GetCustomer(int start, int limit, long id);
        List<CreditLimitGuarantorView> GetGuarantor(int start, int limit, long id);

        List<CreditLimitMasterView> findDupCustomerInRange(long customer_id, long limit_type, DateTime start_date, DateTime end_date);

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

        public List<CreditLimitMasterView> GetApproval(int start, int limit)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitMasterView>()
                        //.Fetch(x => x.CreditLimitCustomer).Eager
                        //.Fetch(x => x.CreditLimitCustomer[0].Customer).Eager
                        //.Where(x => x.Active == true)
                        .OrderBy(x => x.Id).Desc
                        .OrderBy(x => x.SEQ).Asc
                        .Skip(start).Take(limit)
                        .List<CreditLimitMasterView>() as List<CreditLimitMasterView>;
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
                        .Fetch(x => x.CreditLimitCustomer).Eager
                        //.Fetch(x => x.CreditLimitCustomer[0].Customer).Eager
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

        private Conjunction GetCriteriaParameter(List<FilterModel> filter)
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
                        else if (item.property == "Id")
                        {
                            conj.Add(Restrictions.Eq(item.property, Convert.ToInt64(item.value)));
                        }
                        else
                        {
                            conj.Add(Restrictions.Eq(item.property, Convert.ToInt32(item.value)));
                        }
                        break;
                    case "string":
                            conj.Add(Restrictions.Like(item.property, string.Format("%{0}%", item.value)));
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

        public List<CreditLimitMasterView> GetApproval(int start, int limit, List<FilterModel> filter)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    Conjunction conj = this.GetCriteriaParameter(filter);

                    var result = session.QueryOver<CreditLimitMasterView>()
                        .And(Restrictions.Conjunction().Add(conj))
                        .OrderBy(x => x.Id).Desc
                        .OrderBy(x => x.SEQ).Asc
                        .Skip(start).Take(limit)
                        .List<CreditLimitMasterView>() as List<CreditLimitMasterView>;
                    

                    return result;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<CreditLimitMasterView> findDupCustomerInRange(long customer_id, long limit_type, DateTime start_date, DateTime end_date)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    var result = session.QueryOver<CreditLimitMasterView>()
                        .Where(x => x.CustomerId == customer_id)
                        .And(x => x.TypeCreditLimit == limit_type)
                        .And(Restrictions.Conjunction().Add(Restrictions.Ge("StartLimitDate", start_date)).Add(Restrictions.Le("EndLimitDate", end_date)))
                        .List<CreditLimitMasterView>() as List<CreditLimitMasterView>;

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
                        .Fetch(x => x.CreditLimitApproval.CreditLimitCustomer).Eager
                        //.Fetch(x => x.CreditLimitApproval.CreditLimitCustomer[0].Customer).Eager
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

        public List<CreditLimitCustomerView> GetCustomer(int start, int limit, long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitCustomerView>()
                        //.Fetch(x => x.CreditLimitApproval).Eager
                        .Fetch(x => x.Customer).Eager
                        .Where(x => x.CreditLimitApprovalId == id)
                        .OrderBy(x => x.CreditLimitApprovalId).Asc
                        .OrderBy(x => x.CustomerId).Asc
                        .Skip(start).Take(limit)
                        .List<CreditLimitCustomerView>() as List<CreditLimitCustomerView>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<CreditLimitGuarantorView> GetGuarantor(int start, int limit, long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<CreditLimitGuarantorView>()
                        //.Fetch(x => x.CreditLimitApproval).Eager
                        .Fetch(x => x.Customer).Eager
                        .Where(x => x.CreditLimitDetilId == id)
                        .OrderBy(x => x.CreditLimitDetilId).Asc
                        .OrderBy(x => x.CustomerId).Asc
                        .Skip(start).Take(limit)
                        .List<CreditLimitGuarantorView>() as List<CreditLimitGuarantorView>;
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
                    return session.QueryOver<CreditLimitMasterView>()
                        .Where(x => x.Active == true)
                        .List<CreditLimitMasterView>().Count();
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
                    Conjunction conj = this.GetCriteriaParameter(filter);

                    return session.QueryOver<CreditLimitMasterView>()
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
