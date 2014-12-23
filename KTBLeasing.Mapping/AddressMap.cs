using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class AddressMap : ClassMap<Address> {
        
        public AddressMap() {
            Table("ADDRESS");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Sequence("SEQ_ADDRESS");
            References(x => x.Company).Column("COMPANY_ID");
            Map(x => x.AddressTh).Column("ADDRESS_TH");
            Map(x => x.AddressEng).Column("ADDRESS_ENG").Not.Nullable();
            Map(x => x.Zipcode).Column("ZIPCODE");
            Map(x => x.SubdistrictId).Column("SUBDISTRICT_ID");
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
            Map(x => x.Remark).Column("REMARK");
        }
        //old
        //public AddressMap() {
        //    Table("ADDRESS");
        //    LazyLoad();
        //    Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
        //    References(x => x.Company).Column("COMPANY_ID");
        //    References(x => x.MasterProvince).Column("PROVINCE_ID");
        //    Map(x => x.Addressval).Column("ADDRESS");
        //}
    }
}
