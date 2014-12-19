using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTBLeasing.FrontLeasing.Domain;
using System.Collections;
using NHibernate.Transform;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl.Reposotory
{
    public class ComboboxRepository : NhRepository
    {
        public List<Province> GetProvince()
        {
            using (var session = SessionFactory.OpenSession())
            using (var ts = session.BeginTransaction())
            {
                var result = session.QueryOver<Province>().List();
                result.Select(x => new { x.ProvinceId, x.ProvinceName }).GroupBy(x => new { x.ProvinceId, x.ProvinceName });
                //result.Select(x => new { x.DistrictId, x.DistrictName }).GroupBy(x => new { x.DistrictId, x.DistrictName }).AsEnumerable();
                //result.Select(x => new { x.SubdistrictId, x.SubdistrictName, x.Zipcode }).GroupBy(x => new { x.SubdistrictId, x.SubdistrictName, x.Zipcode }).AsEnumerable();
                
                return result as List<Province>;
            }
        }

        public int Count()
        {
            using(var session = SessionFactory.OpenSession())
            {
                var result =  session.QueryOver<CommonData>().RowCount();
                session.Close();
                return result;
            }
        }
    }
}
