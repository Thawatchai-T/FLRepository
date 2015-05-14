using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using NHibernate.Transform;
using NHibernate.Criterion;


namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IUserInfomationRepository
    {
        int Count();
        int Count(string text);
        //System.Collections.Generic.List<KTBLeasing.Domain.UserInformation> Find(int start, int limit, string text);
        List<UserInformationView> Find(string text, string property, int start, int limit);
        System.Collections.Generic.List<KTBLeasing.Domain.UserInformation> GetAll();
        System.Collections.Generic.List<KTBLeasing.Domain.UserInformation> GetAll(int start, int limit);
        System.Collections.Generic.List<KTBLeasing.Domain.UserInformation> GetAllWithOrderBy(string orderby);
        void Insert(KTBLeasing.Domain.UserInformation entity);
        void SaveOrUpdate(KTBLeasing.Domain.UserInformation entity);
        void Update(UserInformation entity);
        void Save(UserInformation entity);

        UserInformation Get(string userid);

        List<UserInformationView> GetAllView();
    }

    class UserInfomationRepository : NhRepository, IUserInfomationRepository
    {
        
        public void Insert(UserInformation entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }

        }

        public void SaveOrUpdate(UserInformation entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);
                ts.Commit();
            }

        }

        public List<UserInformation> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<UserInformation>()
                    .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<UserInformation>() as List<UserInformation>;
                //return this.ExecuteICriteria<UserInformation>() as List<UserInformation>;
            }
        }

        public List<UserInformationView> GetAllView()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<UserInformationView>()
                    .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.TitleNameEng).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.TitleNameTh).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.MarketingGroup).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.Position).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.DepartmentCode).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .List<UserInformationView>() as List<UserInformationView>;
                return result;
                //return this.ExecuteICriteria<UserInformation>() as List<UserInformation>;
            }
        }

        public List<UserInformation> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<UserInformation>(new UserInformation(), orderby) as List<UserInformation>;
        }

        public List<UserInformation> GetAll(int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<UserInformation>().Skip(start).Take(limit);
                return result.List<UserInformation>() as List<UserInformation>;
            }
        }

        public int Count()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<UserInformation>().RowCount();
                session.Close();
                return result;
            }
        }

        //find searech
        public List<UserInformationView> Find(string text, string property, int start, int limit)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = (from x in session.QueryOver<Address>().List<Address>() where x.AddressTh.Contains(text) select x).Skip(start).Take(limit);
                List<UserInformationView> result = null;
                switch (property)
                {
                    case "UserId":
                        //result = session.QueryOver<UserInformation>().Where(x => x.UsersAuthorize.UserId.ToLower().Contains(text.ToLower())).Skip(start).Take(limit).List<UserInformation>() as List<UserInformation>;
                        result = session.QueryOver<UserInformationView>()
                                .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.TitleNameEng).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.TitleNameTh).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.MarketingGroup).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.Position).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.DepartmentCode).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Where(Restrictions.Like("UsersAuthorize.UserId", text, MatchMode.Anywhere).IgnoreCase())
                                .Skip(start).Take(limit)
                                .List<UserInformationView>() as List<UserInformationView>;
                        
                        break;
                    case "FirstNameTh":

                        //result = session.QueryOver<UserInformation>()
                        //    .Where(x => x.FirstNameTh.ToLower().Contains(text.ToLower()) ||
                        //        x.LastNameTh.ToLower().Contains(text.ToLower()) ||
                        //        x.FirstNameEng.ToLower().Contains(text.ToLower()) ||
                        //        x.LastNameEng.ToLower().Contains(text.ToLower()))
                        //    .Skip(start).Take(limit)
                        //    .List<UserInformation>() as List<UserInformation>;
                        result = session.QueryOver<UserInformationView>()
                                .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.TitleNameEng).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.TitleNameTh).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.MarketingGroup).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.Position).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                                .Fetch(x => x.DepartmentCode).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                            .Where(Restrictions.Like("FirstNameTh", text, MatchMode.Anywhere).IgnoreCase() ||
                            Restrictions.Like("LastNameTh", text, MatchMode.Anywhere).IgnoreCase() ||
                            Restrictions.Like("FirstNameEng", text, MatchMode.Anywhere).IgnoreCase() ||
                            Restrictions.Like("LastNameEng", text, MatchMode.Anywhere).IgnoreCase())
                            .Skip(start).Take(limit)
                            .List<UserInformationView>() as List<UserInformationView>;
                        break;
                }
                session.Close();
                return result;
            }
        }

        public int Count(string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = session.QueryOver<UserInformation>().List<UserInformation>().Where(w => w.AddressTh.Contains(text) || w.AddressEng.Contains(text));
                session.Close();
                return 0; // result.ToList<UserInformation>().Count;
            }
        }

        public UserInformation Get(string userid)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.QueryOver<UserInformation>().Where(x => x.UsersAuthorize.UserId == userid).List<UserInformation>(); //session.CreateCriteria(typeof(UserInformation)).Add(Expression.Eq( "UserId", userid )).List<UserInformation>();
                   
                return result.FirstOrDefault(); // result.ToList<UserInformation>().Count;
            }
        }

        public void Update(UserInformation entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Update(entity);
                ts.Commit();
            }
        }

        public void Save(UserInformation entity)
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                session.Save(entity);
                ts.Commit();
            }
        }
    }
}
