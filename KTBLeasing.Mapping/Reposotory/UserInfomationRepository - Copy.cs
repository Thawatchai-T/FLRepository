using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using NHibernate.SqlCommand;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    class UserInfomationRepository : NhRepository
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

        public List<UserInformation> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                //return session.QueryOver<UserInformation>().List<UserInformation>() as List<Address>;
                return this.ExecuteICriteria<UserInformation>() as List<UserInformation>;
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
        public List<UserInformation> Find(int start, int limit, string text)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //var result = (from x in session.QueryOver<Address>().List<Address>() where x.AddressTh.Contains(text) select x).Skip(start).Take(limit);
                //var result = session.QueryOver<UserInformation>().List<UserInformation>().Where(w => w.AddressTh.Contains(text) || w.AddressEng.Contains(text)).Skip(start).Take(limit);
                
                session.Close();
                return null;//result.ToList<UserInformation>();

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

        //use for grid view in main tab
        public List<object> GetGridView()
        {
            using (var session = SessionFactory.OpenSession())
            {
             //   var query = session.QueryOver<UserInformation>().f
               //var query = session.CreateCriteria<UserInformation>("u")
               //.CreateCriteria("u.title_th", JoinType.InnerJoin)
               //.Add(Restrictions.Eq("locationID", ""));
                /*
                    FROM USER_INFORMATION A
                LEFT OUTER JOIN v_deparment_code b
                ON a.deparment_code = b.id
                 * 
                LEFT OUTER JOIN v_marketing_code c
                ON a.marketing_code = c.id
                 * 
                LEFT OUTER JOIN v_title_eng d
                ON a.title_name_eng = d.id
                 * 
                LEFT OUTER JOIN v_title_th e
                ON a.title_name_th = e.id
                 * 
                LEFT OUTER JOIN v_position f
                ON a.position = f.id 
                 * 
                LEFT OUTER JOIN v_marketing_group g
                ON a.marketing_group = g.id
                ;
                 */
                //return session.QueryOver<UserInRole>()
                //    .Fetch(x => x.Role).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                //    .Fetch(x => x.UsersAuthorize).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                //    .Where(x => x.Id == id)
                //    .List<UserInRole>() as List<UserInRole>;

                var result = session.QueryOver<UserInformation>()
                    .Fetch(x => x.LastNameEng).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.LastNameTh).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.MarketingCode).Eager.TransformUsing(new DistinctRootEntityResultTransformer())
                    .Fetch(x => x.Position).Eager.TransformUsing(new DistinctRootEntityResultTransformer()).List<UserInformation>();

                    
                              
                    //from a in session.Query<UserInformation>()
                    //         join b in session.Query<DeparmentCode>()
                    //         on 
                             //equals dw.Id.WorldName
                             //where dw.Id.Imei == imei
                             //select w;
                //return result as List<object>;
                             return null;
            }
            
        }


    }
}
