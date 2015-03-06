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
			//LazyLoad();
            //Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Id(x => x.SubdistrictId).GeneratedBy.Assigned().Column("SUBDISTRICT_ID");
            //Map(x => x.SubdistrictId).Column("SUBDISTRICT_ID");
            Map(x => x.ProvinceId).Column("PROVINCE_ID");
			Map(x => x.DistrictId).Column("DISTRICT_ID");
            Map(x => x.ProvinceName).Column("PROVINCE_NAME");
			Map(x => x.SubdistrictName).Column("SUBDISTRICT_NAME");
			Map(x => x.DistrictName).Column("DISTRICT_ANME");
            Map(x => x.Zipcode).Column("ZIPCODE");
        }
    }
}
