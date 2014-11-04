using System;
using System.Text;
using System.Collections.Generic;


namespace KTBLeasing.FrontLeasing.Domain {
    
    public class Company {
        public Company() { }
        public virtual long Id { get; set; }
        public virtual long? CompanyTypeId { get; set; }
    }
}
