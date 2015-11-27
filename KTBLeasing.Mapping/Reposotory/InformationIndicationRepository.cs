 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
using KTBLeasing.FrontLeasing.Domain;
using NHibernate.Transform;
using NHibernate.Criterion;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IInformationIndicationRepository
    {
        List<InformationIndication> GetAll();
        InformationIndication Get(long id);
        List<InformationIndication> GetListApprove(int start, int limit);
        List<InformationIndication> Get(int start, int limit, long jobId);
        List<Approval> GetApproval(long id);
        List<RequestTransaction> GetRequestTransaction(long id);
        void Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);
    }
    public class InformationIndicationRepository : NhRepository, IInformationIndicationRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<InformationIndication> GetAll()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<InformationIndication>()
                        //.Fetch(x => x.Approval).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                        .List<InformationIndication>() as List<InformationIndication>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public InformationIndication Get(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.Get<InformationIndication>(id);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<InformationIndication> ListInformationIndication()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<InformationIndication>()
                    .Fetch(x => x.Job).Eager
                    .Fetch(x => x.Job.Customer).Eager
                    .Fetch(x => x.Job.MarketingOfficer).Eager
                    .Fetch(x => x.Job.MarketingOfficer.UsersAuthorize).Eager
                    .Fetch(x => x.VisitInformationDomain).Eager
                    .Fetch(x => x.VisitInformationDomain.Job).Eager
                    .Fetch(x => x.VisitInformationDomain.Job.Customer).Eager
                    .Fetch(x => x.VisitInformationDomain.Job.MarketingOfficer).Eager
                    .Fetch(x => x.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                    .OrderBy(x => x.Id).Asc
                    .List<InformationIndication>()
                    
                    as List<InformationIndication>;
            }
        }

        public List<InformationIndication> GetListApprove(int start, int limit)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    var result = session.QueryOver<InformationIndication>()
                        .Fetch(x => x.Job).Eager
                        .Fetch(x => x.Job.Customer).Eager
                        .Fetch(x => x.Job.MarketingOfficer).Eager
                        .Fetch(x => x.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.VisitInformationDomain).Eager
                        .Fetch(x => x.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.Approve == true)
                        .OrderBy(x => x.Id).Asc
                        .List<InformationIndication>() as List<InformationIndication>;

                    return result;

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<InformationIndication> Get(int start, int limit, long jobId)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    var result = session.QueryOver<InformationIndication>()
                        .Fetch(x => x.Job).Eager
                        .Fetch(x => x.Job.Customer).Eager
                        .Fetch(x => x.Job.MarketingOfficer).Eager
                        .Fetch(x => x.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.VisitInformationDomain).Eager
                        .Fetch(x => x.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.Job.Id == jobId)
                        .OrderBy(x => x.Id).Asc
                        .List<InformationIndication>() as List<InformationIndication>;

                    return result;

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<Approval> GetApproval(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    //return session.QueryOver<Approval>()
                    //    .Fetch(x => x.InformationIndication).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    //    .Where(x => x.InformationIndication.Id == id)
                    //    .List<Approval>() as List<Approval>;

                    return session.QueryOver<Approval>()
                        .Fetch(x => x.InformationIndication).Eager
                        .Fetch(x => x.InformationIndication.Job).Eager
                        .Fetch(x => x.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.InformationIndication.Id == id)
                        .OrderBy(x => x.Id).Asc
                        .List<Approval>() as List<Approval>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<RequestTransaction> GetRequestTransaction(long id)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<RequestTransaction>()
                        .Fetch(x => x.InformationIndication).Eager
                        .Fetch(x => x.InformationIndication.Job).Eager
                        .Fetch(x => x.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.InformationIndication.Id == id)
                        .OrderBy(x => x.Id).Asc
                        .List<RequestTransaction>() as List<RequestTransaction>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public void Insert<T>(T entity)
        {
            try
            {
                base.Insert<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void Update<T>(T entity)
        {
            try
            {
                base.Update<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            try
            {
                base.SaveOrUpdate<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void Delete<T>(T entity)
        {
            try
            {
                base.Delete<T>(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
