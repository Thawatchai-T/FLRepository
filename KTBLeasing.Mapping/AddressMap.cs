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
            Id(x => x.Id, "ID").GeneratedBy.Increment(); 
            Map(x => x.CustomerId).Column("CUSTOMER_ID"); 
            Map(x => x.AddressTh).Column("ADDRESS_TH");
            Map(x => x.AddressEng).Column("ADDRESS_ENG");
            Map(x => x.SubdistrictId).Column("SUBDISTRICT_ID");
            Map(x => x.Zipcode).Column("ZIPCODE"); 
            Map(x => x.Remark).Column("REMARK");
            Map(x => x.AddressType).Column("ADDRESS_TYPE");
            Map(x => x.Active).Column("ACTIVE"); 
            Map(x => x.CreateDate).Column("CREATE_DATE");
            Map(x => x.UpdateDate).Column("UPDATE_DATE");
            Map(x => x.CreateBy).Column("CREATE_BY");
            Map(x => x.UpdateBy).Column("UPDATE_BY");
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
