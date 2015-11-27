using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Funding : BaseDomain
    {
        public Funding()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long? Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int Source { get; set; }
        public virtual decimal NetRate { get; set; }
        public virtual decimal FundingCost { get; set; }
        public virtual decimal Spread { get; set; }
        public virtual decimal ProfitFromSpread { get; set; }
        public virtual decimal CreditNetRate { get; set; }
        public virtual decimal CreditSpread { get; set; }
        public virtual decimal CreditProfit { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
