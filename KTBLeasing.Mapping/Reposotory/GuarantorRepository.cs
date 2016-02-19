using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using log4net;
using System.Reflection;
using NHibernate.Criterion;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IGuarantorRepository
    {
        List<GuarantorModel> GetList(int start, int limit);
        List<GuarantorModel> GetList(int start, int limit, long cl_id);
        int Count();
        int Count(long cl_id);
        void Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);
    }

    class GuarantorRepository : NhRepository, IGuarantorRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<GuarantorModel> GetList(int start, int limit)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<GuarantorModel>()
                        .Where(x => x.Active == true)
                        .OrderBy(x => x.Id).Asc
                        .Skip(start).Take(limit)
                        .List<GuarantorModel>() as List<GuarantorModel>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<GuarantorModel> GetList(int start, int limit, long cl_id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<GuarantorModel>()
                        .Where(x => x.CreditLimitId == cl_id && x.Active == true)
                        .OrderBy(x => x.Id).Asc
                        .Skip(start).Take(limit)
                        .List<GuarantorModel>() as List<GuarantorModel>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public int Count()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<GuarantorModel>()
                        .Where(x => x.Active == true)
                        .List<GuarantorModel>().Count();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public int Count(long cl_id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<GuarantorModel>()
                        .Where(x => x.CreditLimitId == cl_id && x.Active == true)
                        .List<GuarantorModel>().Count();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public void Insert<T>(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Insert<T>(entity);
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
