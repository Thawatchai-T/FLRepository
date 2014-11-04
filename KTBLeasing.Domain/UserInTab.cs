using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class UserInTab {
        public virtual long RoleId { get; set; }
        public virtual string Desc { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual string UpdateDate { get; set; }
        public virtual long TabId { get; set; }
    }
}
