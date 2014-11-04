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
			Id(x => x.UserId).GeneratedBy.Assigned().Column("USER_ID");
			Map(x => x.Active).Column("ACTIVE");
			Map(x => x.DepCode).Column("DEP_CODE");
        }
    }
}
