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
        List<ApplicationDetailViewModel> GetAll(int start, int limit, long id);
        void Insert(ApplicationDetailViewModel entity);
        void Insert<T>(T entity);
        bool SaveOrUpdate(ApplicationDetailViewModel entity);
        void Update(ApplicationDetailViewModel entity);
        //void Update(ApplicationDetail entity);
        void Update<T>(T entity);
        List<T> GetAll<T>(int start, int limit, long id,T entity);
        List<T> GetAll<T>(int start, int limit, long id, T entity, string Parent);
    }

    public class ApplicationDetailRepository : NhRepository, IApplicationDetailRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(ApplicationDetailViewModel entity)
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
                    Logger.Error(e);
                    ts.Rollback();
                }
            }
        }

        public bool SaveOrUpdate(ApplicationDetailViewModel entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    ApplicationDetail objApplicationDetail = new ApplicationDetail();
                    objApplicationDetail = (ApplicationDetail)entity;

                    session.SaveOrUpdate(entity.ApplicationDetail[0]);
                    session.SaveOrUpdate(entity.WaiveDocument[0]);
                    session.SaveOrUpdate(entity.Guarantor[0]);
                    session.SaveOrUpdate(entity.MethodPayment[0]);
                    session.SaveOrUpdate(entity.OptionEndLeaseTerm[0]);
                    session.SaveOrUpdate(entity.Maintenance[0]);
                    //session.SaveOrUpdate(entity.Seller[0]);
                    //session.SaveOrUpdate(entity.PurchaseOrder[0]);
                    session.SaveOrUpdate(entity.Insurance[0]);
                    session.SaveOrUpdate(entity.Commission[0]);
                    //session.SaveOrUpdate(entity.AnnualTax[0]);
                    session.SaveOrUpdate(entity.StampDuty[0]);
                    session.SaveOrUpdate(entity.StipulateLoss[0]);
                    //session.SaveOrUpdate(entity.CollectionSchedule[0]);
                    session.SaveOrUpdate(entity.Funding[0]);
                    session.SaveOrUpdate(entity.TermCondition[0]);

                    ts.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    ts.Dispose();
                    ts.Rollback();
                    return false;
                }
            }
        }

        public ApplicationDetail Get(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.Get<ApplicationDetail>(id);
            }
        }

        public List<ApplicationDetail> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var list = session.QueryOver<ApplicationDetail>().List<ApplicationDetail>() as List<ApplicationDetail>;
                return list;

                //return this.ExecuteICriteria<ApplicationDetail>() as List<ApplicationDetail>;
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

        public List<T> GetAll<T>(int start, int limit, long id,T entity)
        {
            string Alias = typeof(T).Name;
            string AliasJoin = string.Format("{0}.ApplicationDetail", Alias);
            using (var session = SessionFactory.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(T), Alias);
                criteria.CreateAlias(AliasJoin, "ApplicationDetail");
                criteria.Add(Restrictions.Eq("ApplicationDetail.Id", id));
                return criteria.List<T>() as List<T>;
            }
        }

        /**
         * Hibernate Criteria Join with 3 Tables
         */
        public List<T> GetAll<T>(int start, int limit, long id, T entity,string Parent)
        {
            string Alias = typeof(T).Name;
            string AliasJoin = string.Format("{0}.ApplicationDetail", Parent);
            string AliasJoin2 = string.Format("{0}." + Parent, Alias);
            using (var session = SessionFactory.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(T), Alias);
                criteria.CreateAlias(AliasJoin, "ApplicationDetail");
                criteria.CreateAlias(AliasJoin2, Parent);
                criteria.Add(Restrictions.Eq(Parent + ".Id", id));
                return criteria.List<T>() as List<T>;
            }
        }

        public List<ApplicationDetailViewModel> GetAll(int start, int limit, long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result1 = session.QueryOver<WaiveDocument>()
                //    .Fetch(x => x.ApplicationDetail).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                //    .List<WaiveDocument>();

                var resultApp = session.Get<ApplicationDetail>(id);
                var viewmodel = new ApplicationDetailViewModel(resultApp);
                var resultWaiveDocument = session.QueryOver<WaiveDocument>().Where(x => x.ApplicationDetail.Id == id).List<WaiveDocument>() as List<WaiveDocument>;
                var resultGuarantor = session.QueryOver<Guarantor>().Where(x => x.ApplicationDetail.Id == id).List<Guarantor>() as List<Guarantor>;
                var resultMethodPayment = session.QueryOver<MethodPayment>().Where(x => x.ApplicationDetail.Id == id).List<MethodPayment>() as List<MethodPayment>;
                var resultOptionEndLeaseTerm = session.QueryOver<OptionEndLeaseTerm>().Where(x => x.ApplicationDetail.Id == id).List<OptionEndLeaseTerm>() as List<OptionEndLeaseTerm>;
                var resultMaintenance = session.QueryOver<Maintenance>().Where(x => x.ApplicationDetail.Id == id).List<Maintenance>() as List<Maintenance>;
                var resultSeller = session.QueryOver<Seller>().Where(x => x.ApplicationDetail.Id == id).List<Seller>() as List<Seller>;
                var resultPurchaseOrder = session.QueryOver<PurchaseOrder>().Where(x => x.ApplicationDetail.Id == id).List<PurchaseOrder>() as List<PurchaseOrder>;
                var resultInsurance = session.QueryOver<Insurance>().Where(x => x.ApplicationDetail.Id == id).List<Insurance>() as List<Insurance>;
                var resultCommission = session.QueryOver<Commission>().Where(x => x.ApplicationDetail.Id == id).List<Commission>() as List<Commission>;
                var resultAnnualTax = session.QueryOver<AnnualTax>().Where(x => x.ApplicationDetail.Id == id).List<AnnualTax>() as List<AnnualTax>;
                var resultStampDuty = session.QueryOver<StampDuty>().Where(x => x.ApplicationDetail.Id == id).List<StampDuty>() as List<StampDuty>;
                var resultStipulateLoss = session.QueryOver<StipulateLoss>().Where(x => x.ApplicationDetail.Id == id).List<StipulateLoss>() as List<StipulateLoss>;
                var resultCollectionSchedule = session.QueryOver<CollectionSchedule>().Where(x => x.ApplicationDetail.Id == id).List<CollectionSchedule>() as List<CollectionSchedule>;
                var resultFunding = session.QueryOver<Funding>().Where(x => x.ApplicationDetail.Id == id).List<Funding>() as List<Funding>;
                var resultTermCondition = session.QueryOver<TermCondition>().Where(x => x.ApplicationDetail.Id == id).List<TermCondition>() as List<TermCondition>;
                
                viewmodel.WaiveDocument = resultWaiveDocument;
                viewmodel.MethodPayment = resultMethodPayment;
                viewmodel.Guarantor = resultGuarantor;
                viewmodel.OptionEndLeaseTerm = resultOptionEndLeaseTerm;
                viewmodel.Maintenance = resultMaintenance;
                //viewmodel.Seller = resultSeller;
                //viewmodel.PurchaseOrder = resultPurchaseOrder;
                viewmodel.Insurance = resultInsurance;
                viewmodel.Commission = resultCommission;
                //viewmodel.AnnualTax = resultAnnualTax;
                viewmodel.StampDuty = resultStampDuty;
                viewmodel.StipulateLoss = resultStipulateLoss;
                //viewmodel.CollectionSchedule = resultCollectionSchedule;
                viewmodel.Funding = resultFunding;
                viewmodel.TermCondition = resultTermCondition;

                List<ApplicationDetailViewModel> list = new List<ApplicationDetailViewModel>();
                list.Add(viewmodel);

                return list;
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

            }
        }

        public void Update(ApplicationDetailViewModel entity)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    ApplicationDetail newobj = new ApplicationDetail();
                    newobj = entity.ApplicationDetail[0];
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(newobj);
                    Logger.Error("woody " + str);



                    this.Update(newobj);
                    //this.Update(entity.WaiveDocument[0]);
                    //this.Update(entity.Guarantor[0]);
                    //this.Update(entity.MethodPayment[0]);
                    //this.Update(entity.OptionEndLeaseTerm[0]);
                    //this.Update(entity.Maintenance[0]);
                    //this.Update(entity.Seller[0]);
                    //this.Update(entity.PurchaseOrder[0]);
                    //this.Update(entity.Insurance[0]);
                    //this.Update(entity.Commission[0]);
                    //this.Update(entity.AnnualTax[0]);
                    //this.Update(entity.StampDuty[0]);
                    //this.Update(entity.StipulateLoss[0]);
                    //this.Update(entity.CollectionSchedule[0]);
                    //this.Update(entity.Funding[0]);
                    //this.Update(entity.TermCondition[0]);
                    ts.Commit();
                    //return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    //return false;
                }
            }
        }


        public void Update(ApplicationDetail entity)
        {
            //using (var session = SessionFactory.OpenStatelessSession())
            //using (var ts = session.BeginTransaction())
            //{
                try
                {
                    this.Insert<ApplicationDetail>(entity);
               //     ts.Commit();
                    //return true;
                }
                catch (Exception ex)
                {
             //       ts.Rollback();
                    //return false;
                }
           // }
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
