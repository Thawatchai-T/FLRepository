using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class ProvinceMap : ClassMap<Province>
    {
        public ProvinceMap()
        {
            Table("V_PROVINCE");
            ReadOnly();
			LazyLoad();
            //Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Id(x => x.SubdistrictId).GeneratedBy.Assigned().Column("SUBDISTRICT_ID");
            Map(x => x.ProvinceId).Column("PROVINCE_ID").Not.Nullable();
			Map(x => x.DistrictId).Column("DISTRICT_ID").Not.Nullable();
            Map(x => x.ProvinceName).Column("PROVINCE_NAME").Not.Nullable();
			Map(x => x.SubdistrictName).Column("SUBDISTRICT_NAME").Not.Nullable();
			Map(x => x.DistrictName).Column("DISTRICT_ANME").Not.Nullable();
            Map(x => x.Zipcode).Column("ZIPCODE").Not.Nullable();
        }
    }
}
