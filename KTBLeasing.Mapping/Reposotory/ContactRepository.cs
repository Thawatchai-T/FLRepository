using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using KTBLeasing.FrontLeasing.Domain;
using System.Reflection;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IContactRepository
    {
        bool Insert(Contact entity);
        bool Update(Contact entity);
        bool SaveOrUpdate(Contact entity);
        List<Contact> GetByPage(int custId, int start, int limit);
    }

    public class ContactRepository : NhRepository, IContactRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool Insert(Contact entity)
        {
            try
            {
                this.Insert<Contact>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }

        public bool Update(Contact entity)
        {
            try
            {
                this.Update<Contact>(entity);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }

        }

        public bool SaveOrUpdate(Contact entity)
        {
            try
            {
                this.SaveOrUpdate<Contact>(entity);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return false;
            }
        }

        public List<Contact> GetByPage(int custId, int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<Contact>()
                            .Where(x => x.CustomerId == custId)
                            .Skip(start).Take(limit).List<Contact>();
                return result as List<Contact>;
            }
        }

    }
}
