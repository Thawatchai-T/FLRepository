using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class TermCondition : BaseDomain
    {
        public TermCondition()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int LeaseTerm { get; set; }
        public virtual int PaymentId { get; set; }
        public virtual int TypeId { get; set; }
        public virtual string SyndicateSubLease { get; set; }
        public virtual int AdvanceArrearId { get; set; }
        public virtual int TypeFinanceId { get; set; }
        public virtual int RateTypeId { get; set; }
        public virtual int SubsequenceDueDay { get; set; }
        public virtual bool Irregular { get; set; }
        public virtual bool PerUnitEqual { get; set; }
        public virtual bool AbnormalRental { get; set; }
        public virtual string ReceivedCompanyName { get; set; }
        public virtual decimal FinanceFeeAmount { get; set; }
        public virtual decimal PercentEquipmentCost { get; set; }
        public virtual int PercentEquipmentCostTypeId { get; set; }
        public virtual int PaymentConditionId { get; set; }
        public virtual decimal FirstDuePerUnit { get; set; }
        public virtual decimal SecondDuePerUnit { get; set; }
        public virtual decimal LastDuePerUnit { get; set; }
        public virtual decimal NetRate { get; set; }
        public virtual decimal GrossRate { get; set; }
        public virtual decimal GrossRateAccount { get; set; }
        public virtual decimal AverageLife { get; set; }
        public virtual decimal RentalMA { get; set; }
        public virtual decimal NumberPayment { get; set; }
        public virtual DateTime FirstDueDate { get; set; }
        public virtual DateTime LastDueDate { get; set; }
        public virtual DateTime RVDueDate { get; set; }
        public virtual decimal ResidualValuePerUnit { get; set; }
        public virtual DateTime RVDueDateOriginal { get; set; }
        public virtual decimal PercentEQ { get; set; }
        public virtual decimal TotalReceivablePerUnit { get; set; }
        public virtual decimal TotalUnearnedPerUnit { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
