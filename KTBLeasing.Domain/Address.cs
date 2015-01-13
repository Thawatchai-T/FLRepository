using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Address : BaseDomain
    {
        public Address()
        {
            //if (Customer == null) Customer = new Customer();
        }
        public virtual long Id { get; set; }
        public virtual string AddressTh { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual string AddressEng { get; set; }
        public virtual long Zipcode { get; set; }
        public virtual long SubdistrictId { get; set; }
        public virtual string Remark { get; set; }
        public virtual long AddressType { get; set; }
        public virtual short? Active { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        //public virtual string UpdateDate { get; set; }
        //public virtual string CreateBy { get; set; }
        //public virtual string UpdateBy { get; set; }
        
    }
}
