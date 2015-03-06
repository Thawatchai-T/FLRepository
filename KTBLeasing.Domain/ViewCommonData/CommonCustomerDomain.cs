using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain.ViewCommonData
{
    public class CommonCustomerDomain
    {
        public virtual long CustomerCode { get; set; }
        public virtual string TitleNameTh { get; set; }
        public virtual string NameTh { get; set; }
        public virtual string NameEng { get; set; }
        public virtual long MarketingOfficer { get; set; }
        public virtual long TypeCustomer { get; set; }
        public virtual string AddressTh { get; set; }
        public virtual string ProvinceName { get; set; }
        public virtual string DistrictName { get; set; }
        public virtual string SubdistrictName { get; set; }
        public virtual string SubdistrictId { get; set; }
        public virtual long Zipcode { get; set; }
        public virtual long ContactTitleTh { get; set; }
        public virtual string ContactPersonFirstName { get; set; }
        public virtual string ContactPersonLastName { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual string Email { get; set; }
        public virtual string PositionTh { get; set; }
    }
}
