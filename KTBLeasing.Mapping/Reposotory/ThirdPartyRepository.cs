using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using KTBLeasing.FrontLeasing.Domain;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IThirdPartyRepository
    {
        List<ThirdParty> GetAll();
        bool Insert(ThirdParty entity);
        bool Update(ThirdParty entity);
        bool SaveOrUpdate(ThirdParty entity);
        //List<ThirdParty> GetByPage(int custId, int start, int limit);
    }

    public class ThirdPartyRepository : NhRepository, IThirdPartyRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public List<ThirdParty> GetAll()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<ThirdParty>().List<ThirdParty>() as List<ThirdParty>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public bool Insert(ThirdParty entity)
        {
            try
            {
                base.Insert<ThirdParty>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }

        public bool Update(ThirdParty entity)
        {
            try
            {
                base.Update<ThirdParty>(entity);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }

        }

        public bool SaveOrUpdate(ThirdParty entity)
        {
            try
            {
                base.SaveOrUpdate<ThirdParty>(entity);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
        }

        //public List<ThirdParty> GetByPage(int custId, int start, int limit)
        //{
        //    using (var session = SessionFactory.OpenStatelessSession())
        //    using (var ts = session.BeginTransaction())
        //    {
        //        var result = session.QueryOver<ThirdParty>()
        //                    .Where(x => x.CustomerId == custId)
        //                    .Skip(start).Take(limit).List<ThirdParty>();
        //        return result as List<ThirdParty>;
        //    }
        //}

    }
}
