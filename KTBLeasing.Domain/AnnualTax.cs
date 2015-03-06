using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class AnnualTax : BaseDomain
    {
        public AnnualTax()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual int BorneBy { get; set; }
        public virtual int Yearly { get; set; }
        public virtual decimal PerUnit { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Total { get; set; }

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
