using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class MasterProvinceMap : ClassMap<MasterProvince> {
        
        public MasterProvinceMap() {
			Table("MASTER_PROVINCE");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
			Map(x => x.Name).Column("NAME");
        }
    }
}
