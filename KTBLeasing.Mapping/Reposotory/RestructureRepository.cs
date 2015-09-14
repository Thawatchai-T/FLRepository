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
        List<Restructure> Get(int start, int limit, int marketing_group, string agrcode);
        Restructure GetRestructure(string agrcode, int SEQ);
        long Insert(Restructure entity);
        void Update(Restructure entity);
        void SaveOrUpdate(Restructure entity);
        int Count(string user_id, string user_group, int marketing_group);
        int Count(int marketing_group, string agrcode);
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
                                  where x.Status != "normal" && y.MarketingGroup == marketing_group && x.CreateBy == user_id
                                  select x)
                                  .Skip(start).Take(limit)
                                  .ToList<Restructure>();
                    }else {
                        result = (from x in session.QueryOver<Restructure>().List()
                                  join y in session.QueryOver<UserInformation>().List()
                                    on x.CreateBy equals y.UsersAuthorize.UserId
                                  where x.Status != "pending" && y.MarketingGroup == marketing_group && x.CreateBy == user_id
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
                                  .Skip(start).Take(limit)
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
                              where x.Status != "normal" && y.MarketingGroup == marketing_group && x.CreateBy == user_id
                              select x)
                              .Count();
                }
                else
                {
                    result = (from x in session.QueryOver<Restructure>().List()
                              join y in session.QueryOver<UserInformation>().List()
                                on x.CreateBy equals y.UsersAuthorize.UserId
                              where x.Status != "pending" && y.MarketingGroup == marketing_group && x.CreateBy == user_id
                              select x)
                             .Count();
                }

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
    }
}
