using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class PurchaseOrder : BaseDomain
    {
        public PurchaseOrder()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual string PONo { get; set; }
        public virtual DateTime PODate { get; set; }
        public virtual int SellerId { get; set; }
        public virtual string QuotationNo1 { get; set; }
        public virtual DateTime QuotationDate1 { get; set; }
        public virtual string QuotationNo2 { get; set; }
        public virtual DateTime QuotationDate2 { get; set; }
        public virtual int POType { get; set; }
        public virtual string SignerName { get; set; }
        public virtual string RefPO { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
