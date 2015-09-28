using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using System.Reflection;
using NHibernate.Criterion;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IRestructureRepository
    {
        List<Restructure> Get(int start, int limit, string user_id, string user_group, int marketing_group);
        List<Restructure> Get(int start, int limit, string user_id, string user_group, int marketing_group, string agrcode);
        Restructure GetRestructure(string agrcode, int SEQ);
        long Insert(Restructure entity);
        void Update(Restructure entity);
        void SaveOrUpdate(Restructure entity);
        int Count(string user_id, string user_group, int marketing_group);
        int Count(string user_id, string user_group, int marketing_group, string agrcode);
        //string GetSQLRelease(long id);
        List<string> GetSQLRelease(long id);
    }
    public class RestructureRepository : NhRepository, IRestructureRepository
    {
        public List<Restructure> Get(int start, int limit, string user_id, string user_group, int marketing_group)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = new List<Restructure>();

                    if (user_group == "head_marketing")
                    {
                            
                            result = (from x in session.QueryOver<Restructure>().List()
                                      join y in session.QueryOver<UserInformation>().List()
                                        on x.CreateBy equals y.UsersAuthorize.UserId
                                      where x.Status != "normal" //&& y.MarketingGroup == marketing_group
                                      select x)
                                      .Skip(start).Take(limit)
                                      .ToList<Restructure>();
                    }
                    else if (user_group == "marketing")
                    {
                        result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                  on x.CreateBy equals y.UsersAuthorize.UserId
                                  where y.MarketingGroup == marketing_group && x.CreateBy == user_id
                                  select x)
                                .Skip(start).Take(limit)
                                .ToList<Restructure>();
                    }
                    else
                    {
                        result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Status != "normal"
                                  select x)
                                      .Skip(start).Take(limit)
                                      .ToList<Restructure>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public List<Restructure> Get(int start, int limit, string user_id, string user_group, int marketing_group, string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = new List<Restructure>();

                    if (user_group == "head_marketing")
                    {
                        result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Agreement == agrcode //&& y.MarketingGroup == marketing_group 
                                  select x)
                                  .Skip(start).Take(limit)
                                  .ToList<Restructure>();
                    }
                    else if (user_group == "marketing")
                    {
                        result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Agreement == agrcode && y.MarketingGroup == marketing_group && x.CreateBy == user_id
                                  select x)
                                  .Skip(start).Take(limit)
                                  .ToList<Restructure>();
                    }
                    else
                    {
                        result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Status != "normal" && x.Agreement == agrcode
                                  select x)
                                  .Skip(start).Take(limit)
                                  .ToList<Restructure>();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public Restructure GetRestructure(string agrcode, int SEQ)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Restructure>()
                    .Where(x => x.Agreement == agrcode && x.SEQ == SEQ)
                    .List<Restructure>().FirstOrDefault<Restructure>();

            }
        }

        public long Insert(Restructure entity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    var result = Session.Insert(entity);
                    tran.Commit();
                    long id = Convert.ToInt64(result);
                    return id;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.Error(ex);
                    return 0;
                    //throw;
                }
            }
        }

        public void Update(Restructure entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Update<Restructure>(entity);
            }
        }

        public void SaveOrUpdate(Restructure entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.SaveOrUpdate<Restructure>(entity);
            }
        }

        public int Count(string user_id, string user_group, int marketing_group)
        {
            using (var session = SessionFactory.OpenSession())
            {
                int result = 0;
                if (user_group == "head_marketing")
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Status != "normal" //&& y.MarketingGroup == marketing_group
                              select x)
                              .Count();
                }
                else if (user_group == "marketing")
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where y.MarketingGroup == marketing_group && x.CreateBy == user_id
                              select x)
                             .Count();
                }
                else
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Status != "normal"
                              select x)
                             .Count();
                }

                return result;
            }
        }

        public int Count(string user_id, string user_group, int marketing_group, string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                int result = 0;
                if (user_group == "head_marketing")
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Agreement == agrcode //&& y.MarketingGroup == marketing_group
                              select x)
                              .Count();
                }
                else if (user_group == "marketing")
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Agreement == agrcode && y.MarketingGroup == marketing_group && x.CreateBy == user_id
                              select x)
                              .Count();
                }
                else
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Status != "normal" && x.Agreement == agrcode
                              select x)
                              .Count();
                }

                return result;
            }
        }

        //[2015.914] Add by Woody. Gen file sql update db2
        private string GetSQLReleaseStr(long id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
               
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    var head = session.QueryOver<Restructure>().Where(Expression.Eq("Id",id)).List<Restructure>().FirstOrDefault();
                    var result = session.QueryOver<Installment>().Where(Expression.Eq("Res_Id", id)).OrderBy(x=>x.InstallNo).Asc().List<Installment>();

                    foreach(var item in result){

                        if (item.InstallNo == 0) continue;
                        var insvat = item.Installment_Total * Convert.ToDecimal(0.07);
                        var RestructureDate = Convert.ToDateTime(head.RestructureDate).ToString("yyyy-MM-dd");
                        string InstallmentDate = Convert.ToDateTime(item.InstallmentDate).ToString("yyyy-MM-dd");
                        //[20150928] Add by Woody. Request By P'Tu Fix cast not sum penalty
                        var interest = item.Interest + item.Penalty;
                        
                        sb.Append(string.Format("-- InstallNo: {0} -------------------------------------------------------------------------\n",item.InstallNo));    
                        sb.Append("UPDATE PAYREL SET ");
                        sb.Append(string.Format("INSTALL = ROUND({0}, 2), ", item.Installment_Total));
                        sb.Append(string.Format("INST_VAT = ROUND({0}, 2) ", insvat));
                        sb.Append(string.Format("WHERE COM_ID = '1' AND COMCODE = '1' AND AGRCODE = '{0}' ", item.Agreement));
                        sb.Append(string.Format("AND DATE_EFF = '{0}' ", RestructureDate));
                        sb.Append(string.Format("AND DATEPAY = '{0}' ;", InstallmentDate));
                            
                        sb.Append("\n---------------------------------------------------------------------------\n");
                        //[20150928] Updat by Woody. Request By P'Tu Fix cast not sum penalty
                        //sb.Append(string.Format("UPDATE INC_FREL SET INCOME = ROUND({0}, 2) ",item.Interest));
                        sb.Append(string.Format("UPDATE INC_FREL SET INCOME = ROUND({0}, 2) ", interest));
                        sb.Append(string.Format("WHERE COM_ID= '1' AND COMCODE = '1' AND AGRCODE = '{0}' ", item.Agreement));
                        sb.Append(string.Format("AND DATE_EFF = '{0}' AND DATEINC = '{1}' ;", RestructureDate, InstallmentDate));

                        sb.Append("\n---------------------------------------------------------------------------\n");
                        //[20150928] Updat by Woody. Request By P'Tu Fix cast not sum penalty
                        //sb.Append(string.Format("UPDATE INC_NREL SET INCOME = ROUND({0}, 2) ",item.Interest));
                        sb.Append(string.Format("UPDATE INC_NREL SET INCOME = ROUND({0}, 2) ", interest));
                        sb.Append(string.Format("WHERE COM_ID= '1' AND COMCODE = '1' AND AGRCODE = '{0}' ", item.Agreement));
                        sb.Append(string.Format("AND DATE_EFF = '{0}' AND DATEINC = '{1}' ;", RestructureDate, InstallmentDate));
                        sb.Append("\n");

                    }

                }
                return sb.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public List<string> GetSQLRelease(long id)
        {
            try
            {
                List<string> lsql = new List<string>();
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    var head = session.QueryOver<Restructure>().Where(Expression.Eq("Id", id)).List<Restructure>().FirstOrDefault();
                    var result = session.QueryOver<Installment>().Where(Expression.Eq("Res_Id", id)).OrderBy(x => x.InstallNo).Asc().List<Installment>();

                    foreach (var item in result)
                    {

                        if (item.InstallNo == 0) continue;
                        var insvat = item.Installment_Total * Convert.ToDecimal(0.07);
                        var RestructureDate = Convert.ToDateTime(head.RestructureDate).ToString("yyyy-MM-dd");
                        string InstallmentDate = Convert.ToDateTime(item.InstallmentDate).ToString("yyyy-MM-dd");
                        StringBuilder sb = new StringBuilder();
                        StringBuilder sb1 = new StringBuilder();
                        StringBuilder sb2 = new StringBuilder();
                        //sb.Append(string.Format("-- InstallNo: {0} -------------------------------------------------------------------------\n", item.InstallNo));
                        sb.Append("UPDATE PAYREL SET ");
                        sb.Append(string.Format("INSTALL = ROUND({0}, 2), ", item.Installment_Total));
                        sb.Append(string.Format("INST_VAT = ROUND({0}, 2) ", insvat));
                        sb.Append(string.Format("WHERE COM_ID = '1' AND COMCODE = '1' AND AGRCODE = '{0}' ", item.Agreement));
                        sb.Append(string.Format("AND DATE_EFF = '{0}' ", RestructureDate));
                        sb.Append(string.Format("AND DATEPAY = '{0}' ;", InstallmentDate));
                        
                        //sb1.Append("\n---------------------------------------------------------------------------\n");
                        sb1.Append(string.Format("UPDATE INC_FREL SET INCOME = ROUND({0}, 2) ", item.Interest));
                        sb1.Append(string.Format("WHERE COM_ID= '1' AND COMCODE = '1' AND AGRCODE = '{0}' ", item.Agreement));
                        sb1.Append(string.Format("AND DATE_EFF = '{0}' AND DATEINC = '{1}' ;", RestructureDate, InstallmentDate));

                        //sb1.Append("\n---------------------------------------------------------------------------\n");
                        sb2.Append(string.Format("UPDATE INC_NREL SET INCOME = ROUND({0}, 2) ", item.Interest));
                        sb2.Append(string.Format("WHERE COM_ID= '1' AND COMCODE = '1' AND AGRCODE = '{0}' ", item.Agreement));
                        sb2.Append(string.Format("AND DATE_EFF = '{0}' AND DATEINC = '{1}' ;", RestructureDate, InstallmentDate));
                        lsql.Add(sb.ToString());
                        lsql.Add(sb1.ToString());
                        lsql.Add(sb2.ToString());
                    }

                }
                
                return lsql;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
