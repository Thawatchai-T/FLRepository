using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class PositionMap : ClassMap<Position> {
        
        public PositionMap() {
			Table("POSITION");
			LazyLoad();
			Id(x => x.Guid).GeneratedBy.Assigned().Column("GUID");
        }
    }
}
