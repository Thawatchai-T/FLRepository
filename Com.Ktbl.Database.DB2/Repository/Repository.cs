using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Com.Ktbl.Database.DB2.Domain;
using System.Reflection;
using log4net;

namespace Com.Ktbl.Database.DB2.Repository
{
    public class Repository
    {
        //private OleDbConnection _DbConn {get;set;}
        public DbAuth DbAuth { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
       
        public Repository()
        {
        }

        public Repository(string _Provider, string _Password, string _UserID, string _DATABASE,string _SERVER)
        {
            DbAuth = (this.DbAuth == null) ? new DbAuth() : DbAuth;
            DbAuth._Provider = _Provider;
            DbAuth._DATABASE = _DATABASE;
            DbAuth._Password = _Password;
            DbAuth._SERVER = _SERVER;
            DbAuth._UserID = _UserID;
        }

        public List<AgrCodeDomain> GetAgrCodeAll()
        {
            try
            {
                //select COM_ID, AGRCODE, CUSCODE from AGRREL group by COM_ID, AGRCODE, CUSCODE;
                string sqlCommand = "select COM_ID ComId, AGRCODE AgrCode, CUSCODE CusCode from AGRREL where com_id = '1' and comcode = '1' and reason <> 1  and reason <> 2  and reason <> 7 group by COM_ID, AGRCODE, CUSCODE with ur";
                this.DbAuth.GetOleDBConnetion();
                var dt = this.DbAuth.ExecuteQueryWithSQL(sqlCommand);
                var list = Db2Linq.ConvertToList<AgrCodeDomain>(dt);
                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }

        }

        public List<AgrCodeDomain> GetSearchAgrCode(string agrcode)
        {
            try
            {
                //select COM_ID, AGRCODE, CUSCODE from AGRREL group by COM_ID, AGRCODE, CUSCODE;
                string sqlCommand = string.Format("select COM_ID ComId, AGRCODE AgrCode, CUSCODE CusCode from AGRREL where reason in (1,2,7) and com_id ='{0}' and AGRCODE like'%{1}%' group by COM_ID, AGRCODE, CUSCODE with ur", "1", agrcode);
                var dt = DbAuth.ExecuteQueryWithSQL(sqlCommand);
                var list = Db2Linq.ConvertToList<AgrCodeDomain>(dt);
                
                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }

        }

        public List<CustomerDomain> GetCustomerName()
        {
            try
            {
                string sql = "select com_id ComId,ENTCODE CusCode, name_t NameTh,name_e NameEng, title_T TitleTh, title_e TitleEng FROM ENTREL group by com_id,ENTCODE,name_t,name_e,title_T,title_e with ur";
                var dt = DbAuth.ExecuteQueryWithSQL(sql);
                var list = Db2Linq.ConvertToList<CustomerDomain>(dt);
                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
            
        }

        public List<CustomerDomain> GetCustomerNameWithCusCode(string cuscode)
        {
            try
            {
                string sql = string.Format("select com_id ComId,ENTCODE CusCode, name_t NameTh,name_e NameEng, title_T TitleTh, title_e TitleEng FROM ENTREL where com_id='{0}' and ENTCODE ='{1}' group by com_id,ENTCODE,name_t,name_e,title_T,title_e with ur", "1", cuscode);
                var dt = DbAuth.ExecuteQueryWithSQL(sql);
                var list = Db2Linq.ConvertToList<CustomerDomain>(dt);
                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }

        }

        public bool UpdateRelease(List<string> lsql)
        {
            try
            {
                var dt = DbAuth.ExecuteTransaction(lsql);
                //var list = Db2Linq.ConvertToList<CustomerDomain>(dt);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
