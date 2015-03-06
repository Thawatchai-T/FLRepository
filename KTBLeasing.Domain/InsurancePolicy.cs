using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class InsurancePolicy : BaseDomain
    {
        public InsurancePolicy()
        {
        }

        public virtual long Id { get; set; }
        public virtual string PolicyNo { get; set; }
        public virtual DateTime ReceiveDate { get; set; }
        public virtual DateTime PayDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual string ContactNo { get; set; } 
    }
}
