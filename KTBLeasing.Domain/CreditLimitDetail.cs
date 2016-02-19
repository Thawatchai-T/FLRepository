using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class CreditLimitDetail : BaseDomain
    {
        public CreditLimitDetail()
        {
            CreditLimitApproval = new CreditLimitApproval();
        }

        public virtual long Id { get; set; }
        public virtual string AssetType { get; set; }
        public virtual int MainAsset { get; set; }
        public virtual int SubAsset { get; set; }
        public virtual int DetailAsset { get; set; }
        public virtual int Marketable { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal LimitAmount { get; set; }
        public virtual int DownHireInsurance { get; set; }
        public virtual decimal DownRate { get; set; }
        public virtual decimal ScrapValue { get; set; }
        public virtual decimal ScrapPercent { get; set; }
        public virtual decimal FlatRate { get; set; }
        public virtual decimal EffectiveRate { get; set; }
        public virtual decimal KTBMLR { get; set; }
        public virtual int Term { get; set; }
        public virtual int TermStyle { get; set; }
        public virtual int MethodPayment { get; set; }
        public virtual int ChequeCondition { get; set; }
        public virtual int Guarantor { get; set; }
        public virtual int Insurance { get; set; }
        public virtual int InsuranceBy { get; set; }
        public virtual int RegisterCapital { get; set; }
        public virtual int RegisterCapitalBy { get; set; }
        public virtual int RegisterCapitalAgency { get; set; }
        public virtual string OtherCondition { get; set; }
        public virtual bool Active { get; set; }
        public virtual int TypeLeasing { get; set; }
        public virtual long CreditLimitId { get; set; }

        public virtual CreditLimitApproval CreditLimitApproval { get; set; }
    }
}
