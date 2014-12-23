using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Address : BaseDomain
    {
        public Address()
        {
            if (Company == null) this.Company = new Company();
        }
        public virtual long Id { get; set; }
        public virtual Company Company { get; set; }
        public virtual string AddressTh { get; set; }
        public virtual string AddressEng { get; set; }
        public virtual int? Zipcode { get; set; }
        public virtual int SubdistrictId { get; set; }
        public virtual string Remark { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        //public virtual string UpdateDate { get; set; }
        //public virtual string CreateBy { get; set; }
        //public virtual string UpdateBy { get; set; }
        
    }
}
