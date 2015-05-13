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
        List<Restructure> Get(string agrcode);
        Restructure GetRestructure(string agrcode, int SEQ);
        void Insert(Restructure entity);
        void Update(Restructure entity);
        void SaveOrUpdate(Restructure entity);
    }
    public class RestructureRepository : NhRepository, IRestructureRepository
    {
        public List<Restructure> Get(string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Restructure>()
                    .Where(x => x.Agreement == agrcode)
                    .List<Restructure>()
                    
                    as List<Restructure>;
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
    }
}
