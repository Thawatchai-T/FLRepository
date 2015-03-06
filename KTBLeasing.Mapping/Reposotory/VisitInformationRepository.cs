using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IVisitInformationRepository
    {
        bool Insert(VisitInformationDomain entity);

        bool Update(VisitInformationDomain entity);

        VisitInformationDomain GetBYID(long id);

        bool SaveOrUpdate(VisitInformationDomain entity);

        List<VisitInformationDomain> Get(int start, int limit);

        List<VisitInformationDomain> Get(string text, int start, int limit);
    }

    public class VisitInformationRepository : NhRepository, IVisitInformationRepository
    {

        #region insert update GetByID

        public bool Insert(VisitInformationDomain entity)
        {
            try
            {
                Insert<VisitInformationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool Update(VisitInformationDomain entity)
        {
            try
            {
                Update<VisitInformationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }


        public VisitInformationDomain GetBYID(long id)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.Get<VisitInformationDomain>(id);
                return result;
            }
        }

        public bool SaveOrUpdate(VisitInformationDomain entity)
        {
            try
            {
                SaveOrUpdate<VisitInformationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public List<VisitInformationDomain> Get(int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var reslut = session.QueryOver<VisitInformationDomain>().Skip(start).Take(limit).List<VisitInformationDomain>();
                return reslut as List<VisitInformationDomain>;
            }
        }

        public List<VisitInformationDomain> Get(string text, int start, int limit)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var criteria = session.CreateCriteria<VisitInformationDomain>();
                //criteria.Add(Ret
                return null;
            }
        }

        #endregion

    }
}
