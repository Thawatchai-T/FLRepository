using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Com.Ktbl.Database.DB2.Domain;

namespace Com.Ktbl.Database.DB2.Repository
{
    public class Repository
    {
        //private OleDbConnection _DbConn {get;set;}
        public DbAuth DbAuth { get; set; }
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

        public List<AgrCodeDomain> GetAgrCodeAll(string text)
        {
            try
            {
                //select COM_ID, AGRCODE, CUSCODE from AGRREL group by COM_ID, AGRCODE, CUSCODE;
                string sqlCommand = "select COM_ID ComId, AGRCODE AgrCode, CUSCODE CusCode from AGRREL where AgrCode like '%" + text + "%' group by COM_ID, AGRCODE, CUSCODE";
                this.DbAuth.GetOleDBConnetion();
                var dt = this.DbAuth.ExecuteQueryWithSQL(sqlCommand);
                var list = Db2Linq.ConvertToList<AgrCodeDomain>(dt);
                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<AgrCodeDomain> GetCuscodeWithAgrCode(string agrcode)
        {
            try
            {
                //select COM_ID, AGRCODE, CUSCODE from AGRREL group by COM_ID, AGRCODE, CUSCODE;
                string sqlCommand = string.Format("select COM_ID ComId, AGRCODE AgrCode, CUSCODE CusCode from AGRREL where com_id ='{0}' and AGRCODE ='{1}' group by COM_ID, AGRCODE, CUSCODE", "1", agrcode);
                var dt = DbAuth.ExecuteQueryWithSQL(sqlCommand);
                var list = Db2Linq.ConvertToList<AgrCodeDomain>(dt);
                
                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<CustomerDomain> GetCustomerName()
        {
            try
            {
                string sql = "select com_id ComId,ENTCODE CusCode, name_t NameTh,name_e NameEng, title_T TitleTh, title_e TitleEng FROM ENTREL group by com_id,ENTCODE,name_t,name_e,title_T,title_e";
                var dt = DbAuth.ExecuteQueryWithSQL(sql);
                var list = Db2Linq.ConvertToList<CustomerDomain>(dt);
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public List<CustomerDomain> GetCustomerNameWithCusCode(string cuscode)
        {
            try
            {
                string sql = string.Format("select com_id ComId,ENTCODE CusCode, name_t NameTh,name_e NameEng, title_T TitleTh, title_e TitleEng FROM ENTREL where com_id='{0}' and ENTCODE ='{1}' group by com_id,ENTCODE,name_t,name_e,title_T,title_e", "1", cuscode);
                var dt = DbAuth.ExecuteQueryWithSQL(sql);
                var list = Db2Linq.ConvertToList<CustomerDomain>(dt);
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
