using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class Contract {
        public virtual long Id { get; set; }
        public virtual Company Company { get; set; }
    }
}
