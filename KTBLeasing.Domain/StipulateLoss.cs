using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class StipulateLoss : BaseDomain
    {
        public StipulateLoss()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual decimal CommencementLeasePerUnit { get; set; }
        public virtual decimal CommencementLeaseTotal { get; set; }
        public virtual int MonthlyDiminishingAmountFrom { get; set; }
        public virtual int MonthlyDiminishingAmountTo { get; set; }
        public virtual decimal MonthlyDiminishingPerUnit { get; set; }
        public virtual decimal MonthlyDiminishingTotal { get; set; }
        public virtual int MonthlyDiminishingAmountFrom2 { get; set; }
        public virtual int MonthlyDiminishingAmountTo2 { get; set; }
        public virtual decimal MonthlyDiminishingPerUnit2 { get; set; }
        public virtual decimal MonthlyDiminishingTotal2 { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
