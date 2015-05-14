using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain; 

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {
    
    
    public class UsersAuthorizeMap : ClassMap<UsersAuthorize> {
        
        public UsersAuthorizeMap() {
			Table("USERS_AUTHORIZE");
			LazyLoad();
            Id(x => x.UserId).Column("USER_ID").GeneratedBy.Assigned();
            Map(x => x.Id).Column("ID").Unique();
			Map(x => x.Active).Column("ACTIVE");
			Map(x => x.DepCode).Column("DEP_CODE");
        }
    }
}
