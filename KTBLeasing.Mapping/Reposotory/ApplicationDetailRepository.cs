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
        List<ApplicationDetail> GetAllWithOrderBy(string orderby);
        List<ApplicationDetailViewModel> GetAll(int start, int limit, long id);
        void Insert(ApplicationDetail entity);
        void SaveOrUpdate(ApplicationDetail entity);
    }

    public class ApplicationDetailRepository : NhRepository, IApplicationDetailRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(ApplicationDetail entity)
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

        public void SaveOrUpdate(ApplicationDetail entity)
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
                    Logger.Error(e);
                }
            }
        }

        public List<ApplicationDetail> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<ApplicationDetail>().List<ApplicationDetail>() as List<ApplicationDetail>;

                //return this.ExecuteICriteria<ApplicationDetail>() as List<ApplicationDetail>;
            }
        }

        public List<ApplicationDetail> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<ApplicationDetail>(new ApplicationDetail(), orderby) as List<ApplicationDetail>;
        }
        
        #region WaiveDocument
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
                //viewmodel.WaiveDocument = resultWaiveDocument[0];
                //viewmodel.Guarantor = resultGuarantor[0];

                List<ApplicationDetailViewModel> list = new List<ApplicationDetailViewModel>();
                list.Add(viewmodel);

                return list;
            }
        }

        public bool Insert(ApplicationDetailViewModel entity)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    //insert list of obj
                    //session.Insert(entity.WaiveDocument);

                    ts.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    return false;
                }
            }
        }
             
        #endregion

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
