using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Maintenance : BaseDomain
    {
        public Maintenance()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string PayTo { get; set; }
        public virtual int PaymentCondition { get; set; }
        public virtual int Pattern { get; set; }
        public virtual decimal FirstDue { get; set; }
        public virtual decimal SecondDue { get; set; }
        public virtual decimal LastDue { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
