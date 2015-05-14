using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IRoleRepository
    {
        bool Delete(int id);
        
        bool Insert(Role entity);
        List<Role> Get();
        int Count();

        Role GetById(int id);

        bool Update(Role model);
    }
    public class RoleRepository : NhRepository, IRoleRepository
    {
        public object Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Role entity)
        {
            try
            {
                this.Insert<Role>(entity);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                
            }
        }

        public List<Role> Get()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Role>().List<Role>() as List<Role>;
            }
        }

        public Role GetById(int id)
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var ts = session.BeginTransaction())
                {
                    var result = session.QueryOver<Role>().Where(x => x.Id == id).List<Role>().FirstOrDefault<Role>();
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
                
            }
            
        }

        public bool Update(Role model)
        {
            try
            {
                this.Update<Role>(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<Role>().RowCount();
                session.Close();
                return result;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using(var session = SessionFactory.OpenStatelessSession())
                using (var ts = session.BeginTransaction())
                {
                    //session.CreateSQLQuery();
                    return true;

                }
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
