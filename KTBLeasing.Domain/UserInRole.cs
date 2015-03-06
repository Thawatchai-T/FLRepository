using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class UserInRole {
        public UserInRole()
        {
            this.Role = new Role();
            this.UsersAuthorize = new UsersAuthorize();
        }
        public virtual long Id { get; set; }
        public virtual Role Role { get; set; }
        public virtual UsersAuthorize UsersAuthorize { get; set; }

    }
}
