using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class RoleMap : ClassMap<Role> {
        
        public RoleMap() {
			Table("ROLE");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("ID");
			Map(x => x.RoleName).Column("ROLE_NAME").Not.Nullable();
			Map(x => x.Createdate).Column("CREATEDATE").Not.Nullable();
			Map(x => x.Createby).Column("CREATEBY").Not.Nullable();
			Map(x => x.Updatedate).Column("UPDATEDATE").Not.Nullable();
			Map(x => x.Updateby).Column("UPDATEBY").Not.Nullable();
        }
    }
}
