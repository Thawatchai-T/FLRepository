using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class BG : BaseDomain
    {
        public BG()
        {
        }

        public virtual long Id { get; set; }
        public virtual string BGNo { get; set; }
        public virtual DateTime ReceiveDate { get; set; }
        public virtual DateTime BGDate { get; set; }
        public virtual string Bank { get; set; }
        public virtual string Branch { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string ContactNo { get; set; }
    }
}
