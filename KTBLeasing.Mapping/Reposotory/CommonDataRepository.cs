using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICommonDataRepository
    {
        void Insert(CommonData entity);
        List<CommonData> Get();
        List<CommonData> Get(string Type);
        int Count();
        void SaveOrUpdate(CommonData entity);
        bool Delete(CommonData entity);

        bool Update(CommonData commonAddress);
    }
    public class CommonDataRepository : NhRepository, ICommonDataRepository
    {
        public void Insert(CommonData entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }

        public List<CommonData> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var sql = string.Format("select name Nname, ID Id, PARENT_ID ParentId, level Levels, CONNECT_BY_ISLEAF leaf from COMMON_DATA where active = 1 connect by prior id = PARENT_ID start with parent_id = 0 ");
                var result = session.CreateSQLQuery(sql).List();

                return result as List<CommonData>;
            }
        }

        //public List<CommonData> Get(string Type)
        //{
        //    using (var session = SessionFactory.OpenSession())
        //    {
        //        Type = "Address";
        //        var sql = string.Format("select name Nname, ID Id, PARENT_ID ParentId, level Levels, CONNECT_BY_ISLEAF leaf from COMMON_DATA where active = 1 connect by prior id = PARENT_ID start with name = '{0}' ", Type.ToLower());
        //        var result = session.CreateSQLQuery(sql).List();

        //        return result as List<CommonData>;
        //        //return session.QueryOver<CommonData>().List<CommonData>() as List<CommonData>;
        //    }
        //}

        public List<CommonData> Get(string Type)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = session.CreateSQLQuery(string.Format("SELECT  " +
                //                                                "  ID AS Id, " +
                //                                                "  PARENT_ID AS Parent_id, " +
                //                                                "  level AS Levels, " +
                //                                                "  name Name, CONNECT_BY_ISLEAF AS ISLEAF " +
                //                                                "FROM COMMON_DATA " +
                //                                                "  CONNECT BY prior id = PARENT_ID " +
                //                                                "  START WITH name_eng     = '{0}' ", CommonType));
                var result = session.CreateSQLQuery(string.Format("SELECT  " +
                                                                "  ID AS Id, " +
                                                                "  PARENT_ID AS Parent_id, " +
                                                                "  level AS Levels, " +
                                                                "  name Name, CONNECT_BY_ISLEAF AS ISLEAF, " +
                                                                "  name_eng Name_Eng " +
                                                                "FROM COMMON_DATA " +
                                                                "  CONNECT BY prior id = PARENT_ID " +
                                                                "  START WITH Parent_id     = 0 ", Type));

                return result.SetResultTransformer(Transformers.AliasToBeanConstructor(typeof(CommonData).GetConstructors().First())).List<CommonData>() as List<CommonData>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<CommonData>().RowCount();
                session.Close();
                return result;
            }
        }

        public void SaveOrUpdate(CommonData entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                }
            }
        }

        public bool Delete(CommonData entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    //session.CreateQuery("DELETE FROM COMMON_DATA WHERE ID = :ID")
                    //    .SetParameter(0, entity.Id)
                    //    .ExecuteUpdate();
                    //session.Delete(entity);
                    var sql = string.Format("delete common_data where id = {0}", entity.Id);
                    session.CreateSQLQuery(sql).ExecuteUpdate();
                    ts.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    ts.Dispose();
                    return false;
                }
            }
        }

        public bool Update(CommonData commonAddress)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.Update(commonAddress);
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
    }
}
