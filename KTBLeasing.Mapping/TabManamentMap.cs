using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class TabManamentMap : ClassMap<TabManament> {
        
        public TabManamentMap() {
			Table("TAB_MANAMENT");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
			Map(x => x.Name).Column("NAME").Not.Nullable();
			Map(x => x.Active).Column("ACTIVE").Not.Nullable();
			Map(x => x.Createby).Column("CREATEBY");
			Map(x => x.Createdate).Column("CREATEDATE");
			Map(x => x.Updateby).Column("UPDATEBY");
			Map(x => x.Updatedate).Column("UPDATEDATE");
        }
    }
}
