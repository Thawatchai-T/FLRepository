using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using KTBLeasing.Domain;
using NHibernate.Transform;
using NHibernate.Criterion;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IVisitInformationRepository
    {
        bool Insert(VisitInformationDomain entity);
        bool Update(VisitInformationDomain entity);
        VisitInformationDomain GetBYID(long id);
        bool SaveOrUpdate(VisitInformationDomain entity);
        List<VisitInformationDomain> Get(int start, int limit);
        List<VisitInformationDomain> Get(int start, int limit, long jobId);
        List<VisitInformationDomain> Get(string text, int start, int limit);
    }

    public class VisitInformationRepository : NhRepository, IVisitInformationRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region insert update GetByID

        public VisitInformationDomain GetBYID(long id)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.Get<VisitInformationDomain>(id);

                return result;
            }
        }

        public List<VisitInformationDomain> Get(int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    var criteria = session.CreateCriteria("VisitInformationDomain", "VisitInformation");
                    criteria.CreateAlias("VisitInformation.Job", "Job");
                    criteria.CreateAlias("Job.Customer", "Customer");
                    criteria.CreateAlias("Job.MarketingOfficer", "MarketingOfficer");
                    criteria.CreateAlias("MarketingOfficer.UsersAuthorize", "UsersAuthorize");

                    return criteria.List<VisitInformationDomain>() as List<VisitInformationDomain>;
                }
                catch(Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public List<VisitInformationDomain> Get(int start, int limit, long jobId)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var criteria = session.CreateCriteria("VisitInformationDomain", "VisitInformation");
                criteria.CreateAlias("VisitInformation.Job", "Job");
                criteria.CreateAlias("Job.Customer", "Customer");
                criteria.CreateAlias("Job.MarketingOfficer", "MarketingOfficer");
                criteria.CreateAlias("MarketingOfficer.UsersAuthorize", "UsersAuthorize");

                return criteria.Add(Restrictions.Eq("Job.Id", jobId))
                    .AddOrder(Order.Asc("Id"))
                    .SetFirstResult(start).SetMaxResults(limit)
                    .List<VisitInformationDomain>() as List<VisitInformationDomain>;
            }
        }

        public List<VisitInformationDomain> Get(string text, int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var criteria = session.CreateCriteria<VisitInformationDomain>();
                return null;
            }
        }

        public bool Insert(VisitInformationDomain entity)
        {
            try
            {
                Insert<VisitInformationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
                throw;
            }
        }

        public bool Update(VisitInformationDomain entity)
        {
            try
            {
                Update<VisitInformationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool SaveOrUpdate(VisitInformationDomain entity)
        {
            try
            {
                SaveOrUpdate<VisitInformationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        #endregion

    }
}
