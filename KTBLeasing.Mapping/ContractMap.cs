using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class ContractMap : ClassMap<Contract> {
        
        public ContractMap() {
			Table("CONTRACT");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
			References(x => x.Company).Column("COMPANY_ID");
        }
    }
}
