using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class MethodPayment : BaseDomain
    {
        public MethodPayment()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int MethodPayments { get; set; }
        public virtual int BankCharges { get; set; }
        public virtual decimal ChequeAmount { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
