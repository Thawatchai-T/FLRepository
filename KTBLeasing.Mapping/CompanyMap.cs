using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class CompanyMap : ClassMap<Company> {
        
        public CompanyMap() {
			Table("COMPANY");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
			Map(x => x.CompanyTypeId).Column("COMPANY_TYPE_ID");
        }
    }
}
