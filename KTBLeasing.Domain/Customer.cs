using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Customer : BaseDomain
    {
        public Customer() 
        {
        }

        public virtual long Id { get; set; }
        public virtual long? PositionId { get; set; }
        public virtual long? Positionguid { get; set; }
        public virtual long TypeCustomer { get; set; }
        public virtual long IndustryCode { get; set; }
        public virtual long NatureCust { get; set; }
        public virtual long TypeCust { get; set; }
        public virtual long TitleCustNameEng { get; set; }
        public virtual long TitleCustNameTh { get; set; }
        public virtual long TsicCode { get; set; }
        public virtual long CustType { get; set; }
        public virtual string NameTh { get; set; }
        public virtual string NameEng { get; set; }
        public virtual long ParentId { get; set; }
        public virtual long VsAreaProvince { get; set; }
        public virtual long VsAreaIndEstate { get; set; }
        public virtual string TaxNo { get; set; }
        public virtual long Vat { get; set; }
        public virtual long MarketingOfficer { get; set; }
        public virtual string Remark { get; set; }
        public virtual short? Active { get; set; }
        public virtual long GroupCust { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual long KTBCustType { get; set; }
        public virtual string Email { get; set; }
    }
}
