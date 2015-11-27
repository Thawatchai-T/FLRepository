using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Commission : BaseDomain
    {
        public Commission()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long? Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string PayCompanyName { get; set; }
        public virtual decimal PayAmount { get; set; }
        public virtual string PayDetail { get; set; }
        public virtual decimal PayPaymentCondition { get; set; }
        public virtual string ReceiveCompanyName { get; set; }
        public virtual decimal ReceiveAmount { get; set; }
        public virtual string ReceiveDetail { get; set; }
        public virtual int ReceivePaymentCondition { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
