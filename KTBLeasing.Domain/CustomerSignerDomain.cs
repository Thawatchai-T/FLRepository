using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain
{
    public class CustomerSignerDomain
    {
        public virtual long Id { get; set; }
        public virtual long CustomerId { get; set; }
        public virtual long TitleTh { get; set; }
        public virtual long TitleEng { get; set; }
        public virtual string FirstNameTh { get; set; }
        public virtual string LastNameTh { get; set; }
        public virtual string FirstNameEng { get; set; }
        public virtual string LastNameEng { get; set; }
        public virtual string AddressTh { get; set; }
        public virtual string AddressEng { get; set; }
        public virtual string PositionTh { get; set; }
        public virtual string PositionEng { get; set; }
        public virtual string Remark { get; set; }

        public virtual long PassportType { get; set; }
        public virtual string IdCardNo { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual DateTime? IssuedDate { get; set; }
        public virtual short Active { get; set; }
        
       
        public virtual long SpouseTitleEng { get; set; }
        public virtual long SpouseTitleTh { get; set; }
        public virtual string SpouseFirstNameTh { get; set; }
        public virtual string SpouseFirstNameEng { get; set; }
        public virtual string SpouseLastNameTh { get; set; }
        public virtual string SpouseLastNameEng { get; set; }
        public virtual string SpouseAddressTh { get; set; }
        public virtual string SpouseAddressEng { get; set; }
        public virtual long SpouseSubDistrictId { get; set; }
        public virtual long SubDistrictId { get; set; }

    }
}
