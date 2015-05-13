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
    public interface ISellerRepository
    {
        int Count();
        int Count(string text);
        List<Seller> Find(int start, int limit, string text);
        List<Seller> GetAll();
        List<Seller> GetAllWithOrderBy(string orderby);
        List<Seller> GetAll(int start, int limit, long id);
        void Insert(Seller entity);
        void SaveOrUpdate(Seller entity);
        void Delete(long id);
    }

    public class SellerRepository : NhRepository, ISellerRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(Seller entity)
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

        public void SaveOrUpdate(Seller entity)
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

        public List<Seller> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Seller>().List<Seller>() as List<Seller>;

                //return this.ExecuteICriteria<Seller>() as List<Seller>;
            }
        }

        public List<Seller> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<Seller>(new Seller(), orderby) as List<Seller>;
        }
        
        public List<Seller> GetAll(int start, int limit, long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var list = session.QueryOver<Seller>().Where(x => x.ApplicationDetail.Id == id)
                    .Fetch(x => x.ApplicationDetail).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<Seller>() as List<Seller>;

                return list;
            }
        }

        //public bool Insert(Seller entity)
        //{
        //    using (var session = SessionFactory.OpenStatelessSession())
        //    using (var ts = session.BeginTransaction())
        //    {
        //        try
        //        {
        //            //insert list of obj
        //            //session.Insert(entity.WaiveDocument);

        //            ts.Commit();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            ts.Rollback();
        //            return false;
        //        }
        //    }
        //}
             
        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Seller>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<Seller> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = (from x in session.QueryOver<Seller>().List<Seller>() where x.EquipmentName.Contains(text) select x).Skip(start).Take(limit);
                //var result = session.QueryOver<Seller>().List<Seller>().Where(w => w.SellerTh.Contains(text) || w.SellerEng.Contains(text)).Skip(start).Take(limit);
                //session.Close();
                //return result.ToList<Seller>();
                return null;
            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = session.QueryOver<Seller>().List<Seller>().Where(w => w.EquipmentName.Contains(text));
                //session.Close();
                //return result.ToList<Seller>().Count;
                return 0;
            }
        }
    }
}
