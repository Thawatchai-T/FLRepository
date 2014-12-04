using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class CommonAddress {
        public virtual long Id { get; set; }
        public virtual int Parent_Id { get; set; }
        public virtual int Levels { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsLeaf { get; set; }
    }
}
