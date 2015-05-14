using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Role 
    {
        //public Role() { }
        public virtual long Id { get; set; }
        public virtual string RoleName { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual bool Active { get; set; }
        
    }
}
