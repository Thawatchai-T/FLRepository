using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    class AddressRepository : NhRepository
    {
        
        public void Insert(Address entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }

        }

        public List<Address> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                //return session.QueryOver<Address>().List<Address>() as List<Address>;
                return this.ExecuteICriteria<Address>() as List<Address>;
            }
        }

        public List<Address> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<Address>(new Address(), orderby) as List<Address>;
        }

        public List<Address> GetAll(int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Address>().Skip(start).Take(limit);
                return result.List<Address>() as List<Address>;
            }
        }

        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Address>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<Address> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = (from x in session.QueryOver<Address>().List<Address>() where x.AddressTh.Contains(text) select x).Skip(start).Take(limit);
                var result = session.QueryOver<Address>().List<Address>().Where(w => w.AddressTh.Contains(text) || w.AddressEng.Contains(text)).Skip(start).Take(limit);
                session.Close();
                return result.ToList<Address>();

            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<Address>().List<Address>().Where(w => w.AddressTh.Contains(text) || w.AddressEng.Contains(text));
                session.Close();
                return result.ToList<Address>().Count;
            }
        }
    }
}
