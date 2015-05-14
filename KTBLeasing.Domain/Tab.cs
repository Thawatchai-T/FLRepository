using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class Tab{
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual short Active { get; set; }
        public virtual string Createby { get; set; }
        public virtual DateTime? Createdate { get; set; }
        public virtual string Updateby { get; set; }
        public virtual DateTime? Updatedate { get; set; }
        public virtual string Widget { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
