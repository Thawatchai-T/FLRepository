using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;
using Com.Ktbl.Database.DB2.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class ARCard : BaseDomain
    {
        public ARCard()
        {
            //CustomerDomain = new CustomerDomain();
        }

        public virtual string Agreement { get; set; }
        public virtual string Customer { get; set; }
        public virtual DateTime? RestructureDate { get; set; }
        public virtual decimal OS_PR { get; set; }
        public virtual decimal FlatRate { get; set; }
        public virtual int Day { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal UnpaidVAT { get; set; }
        public virtual decimal Penalty { get; set; }
        public virtual decimal DebitNote { get; set; }
        public virtual decimal NewFlatRate { get; set; }
        public virtual DateTime? NewFirstDueDate { get; set; }
        public virtual int SubsequentDueDay { get; set; }
        public virtual int NewTerm { get; set; }
        public virtual CustomerDomain Customers { get; set; }
    }
}
