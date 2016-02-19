using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;
using log4net;
using System.Reflection;
using KTBLeasing.Domain.ViewCommonData;
using System.Data;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ICommonDataRepository
    {
        void Insert(CommonData entity);
        List<CommonData> Get();
        List<CommonData> Get(string Type);
        int Count();
        void SaveOrUpdate(CommonData entity);
        bool Delete(int entity);
        CommonData GetById(long id);
        List<EQP> GetEQP();
        List<AssetType> GetAssetType();

        bool Update(CommonData commonAddress);
        List<CommonData> GetCommonByNameEng(string nameeng);
        List<CommonData> GetSubCommonById(long id);
        List<Province> GetProvince();
        List<CommonCustomerDomain> GetCustomerInfoPopup(int start, int limit);
        int CountCommonCustomerPopup();
    }
    public class CommonDataRepository : NhRepository, ICommonDataRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Insert(CommonData entity)
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

        public List<CommonData> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var sql = string.Format("select name Nname, ID Id, PARENT_ID ParentId, level Levels, CONNECT_BY_ISLEAF leaf from COMMON_DATA where active = 1 connect by prior id = PARENT_ID start with parent_id = 0 ");
                var result = session.CreateSQLQuery(sql).List();

                Logger.Debug(sql);
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
            using (var ts = session.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    Logger.Error(ex);
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
                    var sql = string.Format("delete common_data where parent_id = {0}", entity.Id);
                    session.CreateSQLQuery(sql).ExecuteUpdate();
                    
                    ts.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    ts.Dispose();
                    Logger.Error(ex);
                        
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
                    Logger.Error(ex);
                    return false;
                }
            }
        }

        public CommonData GetById(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = session.QueryOver<CommonData>().Where(x => x.Id == id).List<CommonData>().FirstOrDefault<CommonData>();

                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public List<CommonData> GetSubCommonById(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = session.QueryOver<CommonData>()
                        .Where(x => x.Parent_Id == id)
                        .List<CommonData>() as List<CommonData>;

                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public bool Delete(int id)
        {
             var sql = string.Format("DELETE COMMON_DATA a WHERE EXISTS (SELECT * FROM (SELECT b.ID FROM COMMON_DATA b CONNECT BY prior b.id  = b.PARENT_ID START WITH b.Parent_id = {0} )tmp " +
                                    "WHERE tmp.id = a.id ) OR a.id = {1}", id, id);

            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                try
                {
                    session.CreateSQLQuery(sql).ExecuteUpdate();
                    ts.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    ts.Dispose();
                    Logger.Error(ex);
                    return false;
                }
            }
            
        }

        public List<CommonData> GetCommonByNameEng(string nameeng)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    var result = session.QueryOver<CommonData>().Where(x => x.Name_Eng == nameeng && x.Parent_Id != 0)
                        .List<CommonData>() as List<CommonData>;

                    return result;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }

        public List<Province> GetProvince()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<Province>().List();

                return result as List<Province>;
            }
        }

        #region CmonmonCustomerPopup [20150217] WOODY
        /// <summary>
        /// CommonCustomer popup in V_Customer_Popup
        /// </summary>
        /// <returns></returns>
        public List<CommonCustomerDomain> GetCustomerInfoPopup(int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            //using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<CommonCustomerDomain>().Skip(start).Take(limit).List();
                return result as List<CommonCustomerDomain>;
            }
        }

        public int CountCommonCustomerPopup()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<CommonCustomerDomain>().List();
                return result.Count;
            }
        }
        #endregion

        public List<EQP> GetEQP()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    var result = session.QueryOver<EQP>()
                        .OrderBy(x => x.IdSort).Asc
                        .List<EQP>() as List<EQP>;

                    return result;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }

        public List<AssetType> GetAssetType()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    var result = session.QueryOver<AssetType>()
                        .OrderBy(x => x.Id).Asc
                        .List<AssetType>() as List<AssetType>;

                    return result;
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return null;
                }
            }
        }
    }
}
