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
    public interface IPurchaseOrderRepository
    {
        int Count();
        int Count(string text);
        List<PurchaseOrder> Find(int start, int limit, string text);
        List<PurchaseOrder> GetAll();
        List<PurchaseOrder> GetAllWithOrderBy(string orderby);
        List<PurchaseOrder> GetAll(int start, int limit, long id);
        void Insert(PurchaseOrder entity);
        void SaveOrUpdate(PurchaseOrder entity);
        void Delete(long id);
    }

    public class PurchaseOrderRepository : NhRepository, IPurchaseOrderRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(PurchaseOrder entity)
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

        public void SaveOrUpdate(PurchaseOrder entity)
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

        public void Delete(long id)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(id);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }

        public List<PurchaseOrder> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<PurchaseOrder>().List<PurchaseOrder>() as List<PurchaseOrder>;

                //return this.ExecuteICriteria<PurchaseOrder>() as List<PurchaseOrder>;
            }
        }

        public List<PurchaseOrder> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<PurchaseOrder>(new PurchaseOrder(), orderby) as List<PurchaseOrder>;
        }
        
        public List<PurchaseOrder> GetAll(int start, int limit, long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var list = session.QueryOver<PurchaseOrder>().Where(x => x.ApplicationDetail.Id == id)
                    .Fetch(x => x.ApplicationDetail).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<PurchaseOrder>() as List<PurchaseOrder>;

                return list;
            }
        }
 
        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<PurchaseOrder>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<PurchaseOrder> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = (from x in session.QueryOver<PurchaseOrder>().List<PurchaseOrder>() where x.EquipmentName.Contains(text) select x).Skip(start).Take(limit);
                //var result = session.QueryOver<PurchaseOrder>().List<PurchaseOrder>().Where(w => w.PurchaseOrderTh.Contains(text) || w.PurchaseOrderEng.Contains(text)).Skip(start).Take(limit);
                //session.Close();
                //return result.ToList<PurchaseOrder>();
                return null;
            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = session.QueryOver<PurchaseOrder>().List<PurchaseOrder>().Where(w => w.EquipmentName.Contains(text));
                //session.Close();
                //return result.ToList<PurchaseOrder>().Count;
                return 0;
            }
        }
    }
}
