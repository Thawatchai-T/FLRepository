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
    public interface IEquipmentDetailRepository
    {
        int Count();
        List<EquipmentDetail> GetAll();
        List<EquipmentDetail> GetAllWithOrderBy(string orderby);
        List<EquipmentDetail> GetAll(int start, int limit, long id);
        void Insert(EquipmentDetail entity);
        void SaveOrUpdate(EquipmentDetail entity);
    }

    public class EquipmentDetailRepository : NhRepository, IEquipmentDetailRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(EquipmentDetail entity)
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

        public void SaveOrUpdate(EquipmentDetail entity)
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

        public List<EquipmentDetail> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<EquipmentDetail>().List<EquipmentDetail>() as List<EquipmentDetail>;

                //return this.ExecuteICriteria<EquipmentDetail>() as List<EquipmentDetail>;
            }
        }

        public List<EquipmentDetail> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<EquipmentDetail>(new EquipmentDetail(), orderby) as List<EquipmentDetail>;
        }
        
        public List<EquipmentDetail> GetAll(int start, int limit, long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var list = session.QueryOver<EquipmentDetail>().Where(x => x.EquipmentList.Id == id)
                    .Fetch(x => x.EquipmentList).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<EquipmentDetail>() as List<EquipmentDetail>;

                return list;
            }
        }

        //public bool Insert(EquipmentDetail entity)
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
                var result = session.QueryOver<EquipmentDetail>().RowCount();
                session.Close();
                return result;
            }
        }
    }
}
