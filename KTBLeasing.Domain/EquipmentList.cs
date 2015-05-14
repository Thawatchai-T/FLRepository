using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class EquipmentList : BaseDomain
    {
        public EquipmentList()
        {
            ApplicationDetail = new ApplicationDetail();
        }
        public virtual long Id { get; set; }
        public virtual long AppId { get; set; }
        public virtual long SellerId { get; set; }
        public virtual string SellerName { get; set; }
        public virtual int Quantity { get; set; }
        public virtual long EquipmentId { get; set; }
        public virtual string EquipmentName { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal Total { get; set; }
        public virtual decimal VAT { get; set; }
        public virtual decimal Net { get; set; }
        public virtual DateTime? ChequeDate { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
