using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface ITabRepository
    {
        void Insert(Tab entity);

        List<Tab> Get();

        int Count();

        List<RoleInTabsDomain> GetTabBYRoleID(long roleId);

        int CountRoleInTab();
    }

    public class TabRepository : NhRepository, ITabRepository
    {
        public void Insert(Tab entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }

        public List<Tab> Get()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    return session.QueryOver<Tab>().List<Tab>() as List<Tab>;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Tab>().RowCount();
                session.Close();
                return result;
            }
        }

        #region Table 

        /**
         * [20150324] add by  Woody 
         * add repository RoleInTab 
         */
        public List<RoleInTabsDomain> GetTabBYRoleID(long roleId)
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                {
                    var result = session.QueryOver<RoleInTabsDomain>()
                       .Fetch(x => x.Roles).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                       .Fetch(x => x.TabManament).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                       .Where(x => x.Roles.Id == roleId)
                       .List<RoleInTabsDomain>();
                    return result as List<RoleInTabsDomain>;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return new List<RoleInTabsDomain>();
            }
        }

        public int CountRoleInTab()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                using (var ts = session.BeginTransaction())
                {
                    return session.QueryOver<RoleInTabsDomain>().RowCount();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        /**
         * [21150327] Add by Woody 
         */
        public int GetTabInRoleByUserId()
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var ts = session.BeginTransaction())
                {
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return 0;
        }

        #endregion

    }
}
