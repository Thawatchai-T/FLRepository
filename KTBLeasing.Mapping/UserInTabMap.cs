using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class UserInTabMap : ClassMap<UserInTab> {
        
        public UserInTabMap() {
			Table("USER_IN_TAB");
			LazyLoad();
            /**[20141127] Thawatchai.T Edit Mapping to CompositedId and fix column desc to Description **/
			//Id(x => x.RoleId).GeneratedBy.Assigned().Column("ROLE_ID");
            CompositeId().KeyProperty(x => x.RoleId, "ROLE_ID")
                         .KeyProperty(x => x.TabId, "TAB_ID");
            References(x => x.Role).Column("ROLE_ID");
            References(x => x.Tab).Column("TAB_ID");
            Map(x => x.Description).Column("DESCRIPTION");
			Map(x => x.CreateBy).Column("CREATE_BY");
			Map(x => x.UpdateBy).Column("UPDATE_BY");
			Map(x => x.CreateDate).Column("CREATE_DATE");
			Map(x => x.UpdateDate).Column("UPDATE_DATE").Not.Nullable();

			//Map(x => x.TabId).Column("TAB_ID").Not.Nullable();
        }
    }
}
