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
    public interface IEquipmentListRepository
    {
        int Count();
        int Count(string text);
        List<EquipmentList> Find(int start, int limit, string text);
        List<EquipmentList> GetAll();
        List<EquipmentList> GetAllWithOrderBy(string orderby);
        List<EquipmentList> GetAll(int start, int limit, long id);
        void Insert(EquipmentList entity);
        void Update(EquipmentList entity);
        void Delete(long id);
        void SaveOrUpdate(EquipmentList entity);
    }

    public class EquipmentListRepository : NhRepository, IEquipmentListRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(EquipmentList entity)
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

        public void Update(EquipmentList entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    ts.Rollback();
                }
            }
        }

        public void SaveOrUpdate(EquipmentList entity)
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
                    session.Delete(id);
                    ts.Commit();
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
            }
        }

        public List<EquipmentList> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<EquipmentList>().List<EquipmentList>() as List<EquipmentList>;

                //return this.ExecuteICriteria<EquipmentList>() as List<EquipmentList>;
            }
        }

        public List<EquipmentList> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<EquipmentList>(new EquipmentList(), orderby) as List<EquipmentList>;
        }
        
        public List<EquipmentList> GetAll(int start, int limit, long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var list = session.QueryOver<EquipmentList>().Where(x => x.ApplicationDetail.Id == id)
                    .Fetch(x => x.ApplicationDetail).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<EquipmentList>() as List<EquipmentList>;

                return list;
            }
        }
             
        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<EquipmentList>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<EquipmentList> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<EquipmentList>().List<EquipmentList>() where x.EquipmentName.Contains(text) select x).Skip(start).Take(limit);
                //var result = session.QueryOver<EquipmentList>().List<EquipmentList>().Where(w => w.EquipmentListTh.Contains(text) || w.EquipmentListEng.Contains(text)).Skip(start).Take(limit);
                //session.Close();
                return result.ToList<EquipmentList>();

            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<EquipmentList>().List<EquipmentList>().Where(w => w.EquipmentName.Contains(text));
                session.Close();
                return result.ToList<EquipmentList>().Count;
            }
        }
    }
}
