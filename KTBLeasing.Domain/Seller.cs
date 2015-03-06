using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Seller : BaseDomain
    {
        public Seller()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string SellerName { get; set; }
        public virtual string Address { get; set; }
        public virtual string Signer1 { get; set; }
        public virtual string Signer2 { get; set; }
        public virtual string Title1 { get; set; }
        public virtual string Title2 { get; set; }
        public virtual int PaymentCondition { get; set; }
        public virtual int PaymentMethod { get; set; }
        public virtual int BankNo { get; set; }
        public virtual string BankName { get; set; }
        public virtual string Branch { get; set; }
        public virtual string AccountType { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string BankChargeBy { get; set; }
        public virtual string Remark { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
