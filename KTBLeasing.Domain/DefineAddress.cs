using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class DefineAddress : BaseDomain
    {
        public DefineAddress()
        {
            ApplicationDetail = new ApplicationDetail();
        }

        public virtual long Id { get; set; }
        public virtual string AppId { get; set; }
        public virtual string Agreement { get; set; }
        public virtual string ScheduleAcceptanceReceipt { get; set; }
        public virtual string ContactSheetTaxInvoice { get; set; }
        public virtual string TaxBranch { get; set; }
        public virtual int AddressPurchaseOrder { get; set; }
        public virtual string Remark { get; set; } 

        public virtual ApplicationDetail ApplicationDetail { get; set; }
    }
}
