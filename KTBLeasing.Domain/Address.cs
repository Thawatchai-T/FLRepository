using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class Address {
        public virtual long Id { get; set; }
        public virtual Company Company { get; set; }
        public virtual MasterProvince MasterProvince { get; set; }
        public virtual string Addressval { get; set; }
    }
}
