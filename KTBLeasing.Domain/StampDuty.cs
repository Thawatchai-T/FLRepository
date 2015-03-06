using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class StampDuty : BaseDomain
    {
        public StampDuty()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int BorneBy { get; set; }
        public virtual decimal Amount { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
