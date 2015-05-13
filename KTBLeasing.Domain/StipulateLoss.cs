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
        public virtual decimal CLPerUnit { get; set; }
        public virtual decimal CLTotal { get; set; }
        public virtual int MDAmountFrom { get; set; }
        public virtual int MDAmountTo { get; set; }
        public virtual decimal MDPerUnit { get; set; }
        public virtual decimal MDTotal { get; set; }
        public virtual int MDAmountFrom2 { get; set; }
        public virtual int MDAmountTo2 { get; set; }
        public virtual decimal MDPerUnit2 { get; set; }
        public virtual decimal MDTotal2 { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
