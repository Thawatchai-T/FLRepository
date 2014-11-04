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
			Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
			References(x => x.Company).Column("COMPANY_ID");
			References(x => x.MasterProvince).Column("PROVINCE_ID");
			Map(x => x.Addressval).Column("ADDRESS");
        }
    }
}
