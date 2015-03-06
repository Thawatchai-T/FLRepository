using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class OptionEndLeaseTerm : BaseDomain
    {
        public OptionEndLeaseTerm()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual bool PurchaseOption { get; set; }
        public virtual int ResidualValue { get; set; }
        public virtual int ResidualValuePercent { get; set; }
        public virtual string Others { get; set; }
        public virtual bool Renewal { get; set; }
        public virtual int Term { get; set; }
        public virtual bool Rental { get; set; }
        public virtual decimal RentalTotal { get; set; }
        public virtual decimal RentalTotalBHT { get; set; }
        public virtual decimal ResidualValueTotal { get; set; }
        public virtual decimal ResidualValueTotalBHT { get; set; }
        public virtual decimal ResidualValuePercentEQ { get; set; }
        public virtual bool Return { get; set; }
        public virtual decimal GuaranteeBuyBackTotal { get; set; }
        public virtual decimal GuaranteeBuyBackTotalBHT { get; set; }
        public virtual decimal GuaranteeBuyBackPercentEQ { get; set; }
        public virtual string BuyerName { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
