using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class InsuranceEquipment : BaseDomain
    {
        public InsuranceEquipment()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string EquipmentType { get; set; }
        public virtual int Chassis { get; set; }
        public virtual string Licens { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual decimal SumInsured { get; set; }
        public virtual decimal Premium { get; set; }
        public virtual int Territory { get; set; }
        public virtual decimal Deductible { get; set; }
        public virtual string PaymentInsRate { get; set; }
        public virtual decimal Minimum { get; set; }
        public virtual decimal ActualPremium { get; set; }
        public virtual decimal StampDuty { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual decimal NetPremium { get; set; }
        public virtual decimal PaidPream { get; set; }
        public virtual string PolicyNo { get; set; }
        public virtual DateTime? ReceivedDate { get; set; }
        public virtual DateTime? PayDate { get; set; }
        public virtual string Remark { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
