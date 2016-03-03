using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain.ViewModel {

    public class CreditLimitMasterView : BaseDomain
    {
        public CreditLimitMasterView()
        {
        }

        public virtual long Id { get; set; }
        public virtual int TypeCreditLimit { get; set; }
        public virtual int MarketingGroup { get; set; }
        public virtual int Branch { get; set; }
        public virtual DateTime ApproveDate { get; set; }
        public virtual int CustType { get; set; }
        public virtual int TypeLeasing { get; set; }
        public virtual int TypeProductHP { get; set; }
        public virtual int TypeProductLease { get; set; }
        public virtual decimal CreditLimit { get; set; }
        public virtual decimal Total { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual int AssetAmount { get; set; }
        public virtual int Limit { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime StartLimitDate { get; set; }
        public virtual DateTime EndLimitDate { get; set; }
        public virtual decimal LimitHPAmount { get; set; }
        public virtual decimal LimitLeaseAmount { get; set; }

        public virtual long CustomerId { get; set; }
        public virtual string FullNameTh { get; set; }
        public virtual int SEQ { get; set; }
    }
}
