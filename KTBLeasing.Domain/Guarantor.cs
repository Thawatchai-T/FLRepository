using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Guarantor : BaseDomain
    {
        public Guarantor()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long? Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int ConditionLease { get; set; }
        public virtual string BGNo { get; set; }
        public virtual DateTime? BGReceivedDate { get; set; }
        public virtual DateTime? ConfirmPrintedDate { get; set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual int Bank { get; set; }
        public virtual string Branch { get; set; }
        public virtual decimal BGAmount { get; set; }
        public virtual DateTime? BGDate { get; set; }
        public virtual DateTime? PeriodFrom { get; set; }
        public virtual DateTime? PeriodTo { get; set; }
        public virtual string BuyerName { get; set; }
        public virtual decimal RSAAmount { get; set; }
        public virtual DateTime? EquipmentSalesPrintedDate { get; set; }
        public virtual string Signer1EquipmentSales { get; set; }
        public virtual string Signer2EquipmentSales { get; set; }
        public virtual string WithnessEquipmentSales { get; set; }
        public virtual string AddressEquipmentSales { get; set; }
        public virtual int Collateral { get; set; }
        public virtual string CollateralDetail { get; set; }
        public virtual string AdditionalCondition { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
