using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class CustomerMap : ClassMap<Customer> {
        
        public CustomerMap() {
			Table("CUSTOMER");
			LazyLoad();
			Id(x => x.Guid2).GeneratedBy.Assigned().Column("GUID2");
			Map(x => x.PositionId).Column("POSITION_ID").Not.Nullable();
			Map(x => x.PositionGuid).Column("POSITIONGUID").Not.Nullable();
        }
    }
}
