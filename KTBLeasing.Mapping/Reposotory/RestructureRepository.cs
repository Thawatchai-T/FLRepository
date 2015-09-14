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
        List<Restructure> Get(int start, int limit, int marketing_group);
        List<Restructure> Get(int start, int limit, int marketing_group, string agrcode);
        Restructure GetRestructure(string agrcode, int SEQ);
        void Insert(Restructure entity);
        void Update(Restructure entity);
        void SaveOrUpdate(Restructure entity);
        int Count(int marketing_group);
        int Count(int marketing_group, string agrcode);
    }
    public class RestructureRepository : NhRepository, IRestructureRepository
    {
        public List<Restructure> Get(int start, int limit, int marketing_group)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    //var result = session.QueryOver<Restructure>()
                    //    .OrderBy(x => x.SEQ).Asc
                    //    .Where(x => x.Status == "pending")
                    //    .Skip(start).Take(limit)
                    //    .List<Restructure>() as List<Restructure>;

                    var result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Status != "normal" && y.MarketingGroup == marketing_group
                                  select x)
                                  .ToList<Restructure>();

                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public List<Restructure> Get(int start, int limit, int marketing_group, string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                try
                {
                    var result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Agreement == agrcode && y.MarketingGroup == marketing_group
                                  select x)
                                  .ToList<Restructure>();

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

        public void Insert(Restructure entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Insert<Restructure>(entity);
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

        public int Count(int marketing_group)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = session.QueryOver<Restructure>()
                //    .Where(x => x.Status == "pending")
                //    .RowCount();
                //session.Close();
                //return result;

                var result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Status != "normal" && y.MarketingGroup == marketing_group
                              select x)
                              .Count();

                return result;
            }
        }

        public int Count(int marketing_group, string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Agreement == agrcode && y.MarketingGroup == marketing_group
                              select x)
                              .Count();

                return result;
            }
        }

        public string GetSQLReles(){
            try
            {
                string agrcode = "F01H40001517";
                int seq = 2;
                StringBuilder sb = new StringBuilder();
                var instResVat = (1*0.7);//replact instr

                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    var head = session.QueryOver<Restructure>().Where(Expression.Eq("Agreement",agrcode) && Expression.Eq("SEQ",seq)).List<Restructure>().FirstOrDefault();
                    var result = session.QueryOver<Installment>().Where(Expression.Eq("Agreement",agrcode) && Expression.Eq("SEQ",seq)).List<Installment>();

                    result.AsParallel().ForAll(x=>{
                        Object obj = new Object();
                        lock(obj){
                            var insvat = x.InstallmentTotal* Convert.ToDecimal(0.07);
                            var RestructureDate = Convert.ToDateTime(head.RestructureDate).ToString("yyyy-MM-dd");

                            sb.Append("UPDATE KEMADIST.PAYREL SET ");
                            sb.Append(string.Format("A.INSTALL = ROUND({0}, 2), ", x.InstallmentTotal));
                            sb.Append(string.Format("A.INST_VAT = ROUND({0}, 2), ", insvat));
                            sb.Append(string.Format("WHERE COM_ID = '1' AND COMCODE = 'AGRCODE', ", x.Agreement));
                            sb.Append(string.Format("AND DATE_EFF = {0} ", RestructureDate));
                            sb.Append(string.Format("AND DATEPAY = {0} ", RestructureDate));
                        
                        
                        }

                    
                    });

                }
                
       
       
       AND DATE_EFF = 3 AND COMCODE = DATEPAY = 4
                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
