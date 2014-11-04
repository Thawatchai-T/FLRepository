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
			Id(x => x.RoleId).GeneratedBy.Assigned().Column("ROLE_ID");
			Map(x => x.Desc).Column("desc");
			Map(x => x.CreateBy).Column("CREATE_BY");
			Map(x => x.UpdateBy).Column("UPDATE_BY");
			Map(x => x.CreateDate).Column("CREATE_DATE");
			Map(x => x.UpdateDate).Column("UPDATE_DATE").Not.Nullable();
			Map(x => x.TabId).Column("TAB_ID").Not.Nullable();
        }
    }
}
