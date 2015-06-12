using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class DefineAddressModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string Agreement { get; set; }
        public string ScheduleAcceptanceReceipt { get; set; }
        public string ContactSheetTaxInvoice { get; set; }
        public string TaxBranch { get; set; }
        public int AddressPurchaseOrder { get; set; }
        public string Remark { get; set; } 

        public List<DefineAddressModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<DefineAddressModel> list = new List<DefineAddressModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new DefineAddressModel
                {
                    Id= 260,
                    AppId = 1,
                    Agreement= "labore",
                    ScheduleAcceptanceReceipt= "aut",
                    ContactSheetTaxInvoice= "possimus",
                    TaxBranch= "aliquam",
                    AddressPurchaseOrder= 336,
                    Remark= "quos"
                };
                list.Add(en);
            }
            return list;
        }
    }
}