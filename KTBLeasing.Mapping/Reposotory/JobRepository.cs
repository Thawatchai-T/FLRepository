using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using System.Reflection;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IJobRepository
    {
        List<Job> Get(int start, int limit);
        void Insert(Job entity);
        void Update(Job entity);
        void SaveOrUpdate(Job entity);
        int Count();
    }
    public class JobRepository : NhRepository, IJobRepository
    {
        public List<Job> Get(int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {

                //return session.QueryOver<Job>()
                //    .Fetch(x => x.Customer).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                //    .Fetch(x => x.MarketingOfficer).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                //    //.OrderBy(x => x.Id).Asc
                //    //.Skip(start).Take(limit)
                //    .List<Job>() as List<Job>;

                var criteria = session.CreateCriteria("Job", "Job");
                criteria.CreateAlias("Job.Customer", "Customer");
                criteria.CreateAlias("Job.MarketingOfficer", "MarketingOfficer");
                criteria.CreateAlias("MarketingOfficer.UsersAuthorize", "UsersAuthorize");
                return criteria.List<Job>() as List<Job>;
            }
        }

        public void Insert(Job entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Insert<Job>(entity);
            }
        }

        public void Update(Job entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Update<Job>(entity);
            }
        }

        public void SaveOrUpdate(Job entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.SaveOrUpdate<Job>(entity);
            }
        }

        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Job>().List<Job>().Count();
            }
        }
    }
}
