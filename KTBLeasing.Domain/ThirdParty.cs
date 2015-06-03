using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class ThirdParty : BaseDomain
    {
        public ThirdParty()
        {
        }

        public virtual long Id { get; set; }
        public virtual string ThirdPartyCode { get; set; }
        public virtual int PersonType { get; set; }
        public virtual int TitleNameEn { get; set; }
        public virtual string NameEn { get; set; }
        public virtual int TitleNameTh { get; set; }
        public virtual string NameTh { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string HomePage { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual decimal Vat { get; set; }
        public virtual int PaymentMethod { get; set; }
        public virtual int Bank1 { get; set; }
        public virtual string Branch1 { get; set; }
        public virtual int AccountType1 { get; set; }
        public virtual string AccountNo1 { get; set; }
        public virtual int Bank2 { get; set; }
        public virtual string Branch2 { get; set; }
        public virtual int AccountType2 { get; set; }
        public virtual string AccountNo2 { get; set; }
        public virtual int BankChargeBy { get; set; }
        public virtual int PaymentCondition { get; set; }
        public virtual string OtherRemark { get; set; }
        public virtual int Status { get; set; }
        public virtual string AddressEng1 { get; set; }
        public virtual string AddressTh1 { get; set; }
        public virtual string AddressEng2 { get; set; }
        public virtual string AddressTh2 { get; set; }
    }
}
