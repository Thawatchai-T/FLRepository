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
        List<Restructure> Get(int start, int limit, string agrcode);
        Restructure GetRestructure(string agrcode, int SEQ);
        void Insert(Restructure entity);
        void Update(Restructure entity);
        void SaveOrUpdate(Restructure entity);
        int Count(string agrcode);
    }
    public class RestructureRepository : NhRepository, IRestructureRepository
    {
        public List<Restructure> Get(int start, int limit, string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Restructure>()
                    .Where(x => x.Agreement == agrcode)
                    //.Skip(start).Take(limit)
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

        public int Count(string agrcode)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Restructure>()
                    .Where(x => x.Agreement == agrcode)
                    .RowCount();
                session.Close();
                return result;
            }
        }
    }
}
