using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Background : BaseDomain
    {
        public Background()
        {
            InformationIndication = new InformationIndication();
        }

        public virtual long Id { get; set; }
        public virtual long InformationId { get; set; }
        public virtual string Business { get; set; }
        public virtual DateTime? Establishment { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual DateTime? RatingDate { get; set; }
        public virtual string RatingDetail { get; set; }
        public virtual decimal RegisterCapital { get; set; }
        public virtual string RegisterCapitalDetail { get; set; }
        public virtual decimal Sales { get; set; }
        public virtual DateTime? SalesDate { get; set; }
        public virtual string SalesDetail { get; set; }
        public virtual decimal ProfitLoss { get; set; }
        public virtual DateTime? ProfitLossDate { get; set; }
        public virtual string ProfitLossDetail { get; set; }
        public virtual decimal ShareholderEquity { get; set; }
        public virtual DateTime? ShareholderEquityDate { get; set; }
        public virtual string ShareholderEquityDetail { get; set; }
        public virtual decimal OutstandingAmount { get; set; }
        public virtual DateTime? OutstandingAmountDate { get; set; }
        public virtual decimal ExposureLimit { get; set; }
        public virtual DateTime? ExposureLimitDate { get; set; }
        public virtual int Committed { get; set; }

        public virtual InformationIndication InformationIndication { get; set; }
    }
}
