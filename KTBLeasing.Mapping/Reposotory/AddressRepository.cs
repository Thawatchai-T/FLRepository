using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.Domain;
using log4net;
using System.Reflection;
using NHibernate.Criterion;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public interface IAddressRepository
    {
        long Insert<T>(T entity);
        void Update<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        List<Address> GetAll();
        List<Address> GetAllWithOrderBy(string orderby);
        List<Address> GetAll(int start, int limit, int custid);
        int Count();
        List<Address> Find(int start, int limit, string text);
        int Count(string text);
    }
    public class AddressRepository : NhRepository, IAddressRepository
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public long Insert<T>(T entity)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                {
                    var result = base.Insert<T>(entity);

                    long id = Convert.ToInt64(result);
                    return id;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public void Update<T>(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.Update<T>(entity);
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                base.SaveOrUpdate<T>(entity);
            }
        }

        public List<Address> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.QueryOver<Address>()
                    .Where(x => x.Active == true)
                    .List<Address>() as List<Address>;
            }
        }

        public List<Address> GetAllWithOrderBy(string orderby)
        {
            return this.ExecuteICriteriaOrderBy<Address>(new Address(), orderby) as List<Address>;
        }

        //public List<Address> GetAll(int start, int limit)
        //{
        //    using (var session = SessionFactory.OpenSession())
        //    {
        //        var result = session.QueryOver<Address>().Skip(start).Take(limit);
        //        return result.List<Address>() as List<Address>;
        //    }
        //}
        /// <summary>
        /// [20150113] Thawatchai.t 
        /// Get Addresss view tab customer
        ///  
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        //public List<AddressViewModel> GetAll(int start, int limit,int custid)
        //{
        //    using (var session = SessionFactory.OpenSession())
        //    {
        //        var tProvince= session.CreateCriteria<Address>();
        //        var rProvince = tProvince.Add(Restrictions.Eq("CustomerId", (long)custid)).List<Address>();

        //        if (rProvince.Count == 0) return new List<AddressViewModel>();
        //        else
        //        {
        //            var result2 = session.QueryOver<Province>()
        //                              .WhereRestrictionOn(val => val.SubdistrictId)
        //                              .IsIn(rProvince.Select(x=>x.SubdistrictId).ToArray())
        //                              .List<Province>();
                    
        //            var result = (from x in rProvince
        //                          join y in result2 
        //                          on x.SubdistrictId equals y.SubdistrictId
        //                          select (new AddressViewModel
        //                          {
        //                              AddressEng = x.AddressEng,
        //                              AddressTh = x.AddressTh,
        //                              CompanyId = x.CustomerId,
        //                              DistrictId = y.DistrictId,
        //                              DistrictName = y.DistrictName,
        //                              Id = x.Id,
        //                              ProvinceId = y.ProvinceId,
        //                              ProvinceName = y.ProvinceName,
        //                              Remark = x.Remark,
        //                              SubdistrictId = y.SubdistrictId,
        //                              SubdistrictName = y.SubdistrictName,
        //                              Zipcode = y.Zipcode,
        //                              DisplayProvince = string.Format("{0} {1} {2} {3}", y.ProvinceName, y.DistrictName, y.SubdistrictName, y.Zipcode),
        //                              AddressType = x.AddressType,
        //                              Active = x.Active

        //                          })
        //                         ).Skip(start).Take(limit).ToList<AddressViewModel>();

        //            return result as List<AddressViewModel>;
        //        }
                
        //    }
        //}
        public List<Address> GetAll(int start, int limit, int custid)
        {
            try{
                using (var session = SessionFactory.OpenSession())
                {
                    //var tProvince = session.CreateCriteria<Address>();
                    //var rProvince = tProvince.Add(Restrictions.Eq("CustomerId", (long)custid)).List<Address>();

                    //if (rProvince.Count == 0) return new List<Address>();
                    //else
                    //{
                        //var result2 = session.QueryOver<Province>()
                        //                  .WhereRestrictionOn(val => val.SubdistrictId)
                        //                  .IsIn(rProvince.Select(x => x.SubdistrictId).ToArray())
                        //                  .List<Province>();

                        //var result = (from x in rProvince
                        //              join y in result2
                        //              on x.SubdistrictId equals y.SubdistrictId
                        //              select (new Address
                        //              {
                        //                  AddressEng = x.AddressEng,
                        //                  AddressTh = x.AddressTh,
                        //                  CompanyId = x.CustomerId,
                        //                  DistrictId = y.DistrictId,
                        //                  DistrictName = y.DistrictName,
                        //                  Id = x.Id,
                        //                  ProvinceId = y.ProvinceId,
                        //                  ProvinceName = y.ProvinceName,
                        //                  Remark = x.Remark,
                        //                  SubdistrictId = y.SubdistrictId,
                        //                  SubdistrictName = y.SubdistrictName,
                        //                  Zipcode = y.Zipcode,
                        //                  DisplayProvince = string.Format("{0} {1} {2} {3}", y.ProvinceName, y.DistrictName, y.SubdistrictName, y.Zipcode),
                        //                  AddressType = x.AddressType,
                        //                  Active = x.Active

                        //              })
                        //             ).Skip(start).Take(limit).ToList<Address>();
                        var result = session.QueryOver<Address>()
                                .Fetch(x => x.Customer).Eager
                                .Where(x => x.Customer.Id == custid && x.Active == true)
                                .List<Address>() as List<Address>;

                        return result;
                    //}
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
                var result = session.QueryOver<Address>()
                    .Where(x => x.Active == true)
                    .RowCount();
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
