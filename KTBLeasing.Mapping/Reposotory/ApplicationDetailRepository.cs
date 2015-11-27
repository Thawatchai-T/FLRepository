using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using log4net;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IApplicationDetailRepository
    {
        int Count();
        int Count(string text);
        List<ApplicationDetail> Find(int start, int limit, string text);
        List<ApplicationDetail> GetAll();
        ApplicationDetail Get(long id);
        List<ApplicationDetail> GetAllWithOrderBy(string orderby);
        List<ApplicationDetail> GetAll(int start, int limit, long jobId);
        object Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        List<T> GetAll<T>(int start, int limit, long id, T entity);
        List<T> GetAll<T>(int start, int limit, long id, T entity, string Parent);
    }

    public class ApplicationDetailRepository : NhRepository, IApplicationDetailRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationDetail Get(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.Get<ApplicationDetail>(id);
            }
        }

        public List<ApplicationDetail> GetAll()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    //var list = session.QueryOver<ApplicationDetail>()
                    //    .Fetch(x => x.IndicationEquipment).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    //    .List<ApplicationDetail>() as List<ApplicationDetail>;
                    //return list;

                    var criteria = session.CreateCriteria("ApplicationDetail", "ApplicationDetail");
                    criteria.CreateAlias("ApplicationDetail.IndicationEquipment", "IndicationEquipment");
                    criteria.CreateAlias("IndicationEquipment.InformationIndication", "InformationIndication");
                    return criteria.List<ApplicationDetail>() as List<ApplicationDetail>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<ApplicationDetail> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<ApplicationDetail>(new ApplicationDetail(), orderby) as List<ApplicationDetail>;
        }

        /**
         * Hibernate Criteria Join with 2 Tables
         * ref: http://stackoverflow.com/questions/8726396/hibernate-criteria-join-with-3-tables
         * 
         */
        public List<T> GetAll<T>(int start, int limit, long id, T entity)// where T : class
        {
            string Alias = typeof(T).Name;
            string AliasJoin = string.Format("{0}.ApplicationDetail", Alias);
            using (var session = SessionFactory.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(T), Alias);
                criteria.CreateAlias(AliasJoin, "ApplicationDetail");
                criteria.CreateAlias("ApplicationDetail.Job", "Job");
                criteria.CreateAlias("Job.Customer", "Customer");
                criteria.CreateAlias("Job.MarketingOfficer", "MarketingOfficer");
                criteria.CreateAlias("MarketingOfficer.UsersAuthorize", "UsersAuthorize");

                criteria.CreateAlias("ApplicationDetail.IndicationEquipment", "IndicationEquipment");
                criteria.CreateAlias("IndicationEquipment.Job", "Job2");
                criteria.CreateAlias("Job2.Customer", "Customer2");
                criteria.CreateAlias("Job2.MarketingOfficer", "MarketingOfficer2");
                criteria.CreateAlias("MarketingOfficer2.UsersAuthorize", "UsersAuthorize2");

                criteria.CreateAlias("IndicationEquipment.InformationIndication", "InformationIndication");
                criteria.CreateAlias("InformationIndication.Job", "Job3");
                criteria.CreateAlias("Job3.Customer", "Customer3");
                criteria.CreateAlias("Job3.MarketingOfficer", "MarketingOfficer3");
                criteria.CreateAlias("MarketingOfficer3.UsersAuthorize", "UsersAuthorize3");

                criteria.CreateAlias("InformationIndication.VisitInformationDomain", "VisitInformationDomain");
                criteria.CreateAlias("VisitInformationDomain.Job", "Job4");
                criteria.CreateAlias("Job4.Customer", "Customer4");
                criteria.CreateAlias("Job4.MarketingOfficer", "MarketingOfficer4");
                criteria.CreateAlias("MarketingOfficer4.UsersAuthorize", "UsersAuthorize4");

                criteria.Add(Restrictions.Eq("ApplicationDetail.Id", id));
                var result = criteria.List<T>() as List<T>;
                return result;
            }
        }

        /**
         * Hibernate Criteria Join with 3 Tables
         */
        public List<T> GetAll<T>(int start, int limit, long id, T entity, string Parent)
        {
            string Alias = typeof(T).Name;
            string AliasJoin = string.Format("{0}.ApplicationDetail", Parent);
            string AliasJoin2 = string.Format("{0}." + Parent, Alias);
            using (var session = SessionFactory.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(T), Alias);
                criteria.CreateAlias(AliasJoin, "ApplicationDetail");
                criteria.CreateAlias(AliasJoin2, Parent);
                criteria.CreateAlias("ApplicationDetail.Job", "Job");
                criteria.CreateAlias("Job.Customer", "Customer");
                criteria.CreateAlias("Job.MarketingOfficer", "MarketingOfficer");
                criteria.CreateAlias("MarketingOfficer.UsersAuthorize", "UsersAuthorize");

                criteria.CreateAlias("ApplicationDetail.IndicationEquipment", "IndicationEquipment");
                criteria.CreateAlias("IndicationEquipment.Job", "Job2");
                criteria.CreateAlias("Job2.Customer", "Customer2");
                criteria.CreateAlias("Job2.MarketingOfficer", "MarketingOfficer2");
                criteria.CreateAlias("MarketingOfficer2.UsersAuthorize", "UsersAuthorize2");

                criteria.CreateAlias("IndicationEquipment.InformationIndication", "InformationIndication");
                criteria.CreateAlias("InformationIndication.Job", "Job3");
                criteria.CreateAlias("Job3.Customer", "Customer3");
                criteria.CreateAlias("Job3.MarketingOfficer", "MarketingOfficer3");
                criteria.CreateAlias("MarketingOfficer3.UsersAuthorize", "UsersAuthorize3");

                criteria.CreateAlias("InformationIndication.VisitInformationDomain", "VisitInformationDomain");
                criteria.CreateAlias("VisitInformationDomain.Job", "Job4");
                criteria.CreateAlias("Job4.Customer", "Customer4");
                criteria.CreateAlias("Job4.MarketingOfficer", "MarketingOfficer4");
                criteria.CreateAlias("MarketingOfficer4.UsersAuthorize", "UsersAuthorize4");

                criteria.Add(Restrictions.Eq("ApplicationDetail.Id", id));
                var result = criteria.List<T>() as List<T>;
                return result;
                criteria.Add(Restrictions.Eq(Parent + ".Id", id));
                return criteria.List<T>() as List<T>;
            }
        }

        #region "Back up"
        //public List<ApplicationDetailViewModel> GetAll(int start, int limit, long id)
        //{
        //    using (var session = SessionFactory.OpenSession())
        //    {
        //        //var result1 = session.QueryOver<WaiveDocument>()
        //        //    .Fetch(x => x.ApplicationDetail).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
        //        //    .List<WaiveDocument>();

        //        var resultApp = session.Get<ApplicationDetail>(id);
        //        var viewmodel = new ApplicationDetailViewModel(resultApp);
        //        var resultWaiveDocument = session.QueryOver<WaiveDocument>().Where(x => x.ApplicationDetail.Id == id).List<WaiveDocument>() as List<WaiveDocument>;
        //        var resultGuarantor = session.QueryOver<Guarantor>().Where(x => x.ApplicationDetail.Id == id).List<Guarantor>() as List<Guarantor>;
        //        var resultMethodPayment = session.QueryOver<MethodPayment>().Where(x => x.ApplicationDetail.Id == id).List<MethodPayment>() as List<MethodPayment>;
        //        var resultOptionEndLeaseTerm = session.QueryOver<OptionEndLeaseTerm>().Where(x => x.ApplicationDetail.Id == id).List<OptionEndLeaseTerm>() as List<OptionEndLeaseTerm>;
        //        var resultMaintenance = session.QueryOver<Maintenance>().Where(x => x.ApplicationDetail.Id == id).List<Maintenance>() as List<Maintenance>;
        //        var resultSeller = session.QueryOver<Seller>().Where(x => x.ApplicationDetail.Id == id).List<Seller>() as List<Seller>;
        //        var resultPurchaseOrder = session.QueryOver<PurchaseOrder>().Where(x => x.ApplicationDetail.Id == id).List<PurchaseOrder>() as List<PurchaseOrder>;
        //        var resultInsurance = session.QueryOver<Insurance>().Where(x => x.ApplicationDetail.Id == id).List<Insurance>() as List<Insurance>;
        //        var resultCommission = session.QueryOver<Commission>().Where(x => x.ApplicationDetail.Id == id).List<Commission>() as List<Commission>;
        //        var resultAnnualTax = session.QueryOver<AnnualTax>().Where(x => x.ApplicationDetail.Id == id).List<AnnualTax>() as List<AnnualTax>;
        //        var resultStampDuty = session.QueryOver<StampDuty>().Where(x => x.ApplicationDetail.Id == id).List<StampDuty>() as List<StampDuty>;
        //        var resultStipulateLoss = session.QueryOver<StipulateLoss>().Where(x => x.ApplicationDetail.Id == id).List<StipulateLoss>() as List<StipulateLoss>;
        //        var resultCollectionSchedule = session.QueryOver<CollectionSchedule>().Where(x => x.ApplicationDetail.Id == id).List<CollectionSchedule>() as List<CollectionSchedule>;
        //        var resultFunding = session.QueryOver<Funding>().Where(x => x.ApplicationDetail.Id == id).List<Funding>() as List<Funding>;
        //        var resultTermCondition = session.QueryOver<TermCondition>().Where(x => x.ApplicationDetail.Id == id).List<TermCondition>() as List<TermCondition>;
                
        //        viewmodel.WaiveDocument = resultWaiveDocument;
        //        viewmodel.MethodPayment = resultMethodPayment;
        //        viewmodel.Guarantor = resultGuarantor;
        //        viewmodel.OptionEndLeaseTerm = resultOptionEndLeaseTerm;
        //        viewmodel.Maintenance = resultMaintenance;
        //        //viewmodel.Seller = resultSeller;
        //        //viewmodel.PurchaseOrder = resultPurchaseOrder;
        //        viewmodel.Insurance = resultInsurance;
        //        viewmodel.Commission = resultCommission;
        //        //viewmodel.AnnualTax = resultAnnualTax;
        //        viewmodel.StampDuty = resultStampDuty;
        //        viewmodel.StipulateLoss = resultStipulateLoss;
        //        //viewmodel.CollectionSchedule = resultCollectionSchedule;
        //        viewmodel.Funding = resultFunding;
        //        viewmodel.TermCondition = resultTermCondition;

        //        List<ApplicationDetailViewModel> list = new List<ApplicationDetailViewModel>();
        //        list.Add(viewmodel);

        //        return list;
        //    }
        //}
        #endregion

        public List<ApplicationDetail> GetAll(int start, int limit, long jobId) 
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<ApplicationDetail>()
                        .Fetch(x => x.Job).Eager
                        .Fetch(x => x.Job.Customer).Eager
                        .Fetch(x => x.Job.MarketingOfficer).Eager
                        .Fetch(x => x.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.IndicationEquipment).Eager
                        .Fetch(x => x.IndicationEquipment.Job).Eager
                        .Fetch(x => x.IndicationEquipment.Job.Customer).Eager
                        .Fetch(x => x.IndicationEquipment.Job.MarketingOfficer).Eager
                        .Fetch(x => x.IndicationEquipment.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job.Customer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job.MarketingOfficer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.Customer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer).Eager
                        .Fetch(x => x.IndicationEquipment.InformationIndication.VisitInformationDomain.Job.MarketingOfficer.UsersAuthorize).Eager
                        .Where(x => x.Job.Id == jobId)
                        .OrderBy(x => x.Id).Asc
                        .Skip(start).Take(limit)
                        .List<ApplicationDetail>() as List<ApplicationDetail>;

                return result;
            }
        }

        public object Insert<T>(T entity)
        {
            try
            {
               return base.Insert<T>(entity);
            }
            catch (Exception ex)
            {
                return null;
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

            }
        }

        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<ApplicationDetail>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<ApplicationDetail> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<ApplicationDetail>().List<ApplicationDetail>() where x.ApplicationId.Contains(text) select x).Skip(start).Take(limit);
                //var result = session.QueryOver<ApplicationDetail>().List<ApplicationDetail>().Where(w => w.ApplicationDetailTh.Contains(text) || w.ApplicationDetailEng.Contains(text)).Skip(start).Take(limit);
                //session.Close();
                return result.ToList<ApplicationDetail>();

            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<ApplicationDetail>().List<ApplicationDetail>().Where(w => w.ApplicationId.Contains(text));
                session.Close();
                return result.ToList<ApplicationDetail>().Count;
            }
        }
    }
}
