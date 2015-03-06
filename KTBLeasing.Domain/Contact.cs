using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Contact : BaseDomain
    {
        public Contact()
        {
            //if (this.Company == null) Company = new Company();
        }
        public virtual long Id { get; set; }
        //public virtual Company Company { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual decimal TitleEng { get; set; }
        public virtual decimal TitleTh { get; set; }
        public virtual string FirstNameEng { get; set; }
        public virtual string LastNameEng { get; set; }
        public virtual string FirstNameTh { get; set; }
        public virtual string LastNameTh { get; set; }
        public virtual string PositionEng { get; set; }
        public virtual string PositionTh { get; set; }
        public virtual string Department { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Email { get; set; }
        public virtual short Active { get; set; }
        public virtual string AddressTh { get; set; }
    }
}
