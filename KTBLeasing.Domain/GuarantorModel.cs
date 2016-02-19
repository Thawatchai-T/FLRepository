using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class GuarantorModel : BaseDomain
    {
        public GuarantorModel()
        {
        }

        //public virtual long Id { get; set; }
        //public virtual long AppNo { get; set; }
        //public virtual int KtbCollTypeDesc { get; set; }
        //public virtual int KtbCollSubTypeDesc { get; set; }
        //public virtual int BotCollTypeDesc { get; set; }
        //public virtual int BotCollSubTypeDesc { get; set; }
        //public virtual int CollateralNo { get; set; }
        //public virtual int CollFlagCode { get; set; }
        //public virtual string IsExisting { get; set; }
        //public virtual string CifNo { get; set; }
        //public virtual string TaxId { get; set; }
        //public virtual string CitizenId { get; set; }
        //public virtual bool IsFlLimit { get; set; }
        //public virtual bool IsNonCrm { get; set; }
        //public virtual bool IsReqApprove { get; set; }
        //public virtual string GuarantorName { get; set; }
        //public virtual int GuarantorTitleName { get; set; }
        //public virtual bool Active { get; set; }

        public virtual long Id { get; set; }
        public virtual long? PositionId { get; set; }
        public virtual long? Positionguid { get; set; }
        public virtual long TypeCustomer { get; set; }
        public virtual long IndustryCode { get; set; }
        public virtual long NatureCust { get; set; }
        public virtual long TypeCust { get; set; }
        public virtual long TitleCustNameEng { get; set; }
        public virtual long TitleCustNameTh { get; set; }
        public virtual string TsicCode { get; set; }
        public virtual long CustType { get; set; }
        public virtual string FirstNameTh { get; set; }
        public virtual string LastNameTh { get; set; }
        public virtual string FirstNameEng { get; set; }
        public virtual string LastNameEng { get; set; }
        public virtual long ParentId { get; set; }
        public virtual long VsAreaProvince { get; set; }
        public virtual long VsAreaIndEstate { get; set; }
        public virtual string TaxNo { get; set; }
        public virtual long Vat { get; set; }
        public virtual long MarketingOfficer { get; set; }
        public virtual string Remark { get; set; }
        public virtual bool Active { get; set; }
        public virtual long GroupCust { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual long KTBCustType { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime IdIssueDate { get; set; }
        public virtual DateTime IdExpireDate { get; set; }
        public virtual string OwnerBranch { get; set; }
        public virtual string Contact { get; set; }
        public virtual long VAT_Registration { get; set; }
        public virtual decimal CreditLimit { get; set; }
        public virtual long CreditLimitId { get; set; }
    }
}
