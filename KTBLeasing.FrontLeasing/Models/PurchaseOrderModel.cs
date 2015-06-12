using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class PurchaseOrderModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string PONo { get; set; }
        public DateTime PODate { get; set; }
        public int SellerId { get; set; }
        public string QuotationNo1 { get; set; }
        public DateTime QuotationDate1 { get; set; }
        public string QuotationNo2 { get; set; }
        public DateTime QuotationDate2 { get; set; }
        public int POType { get; set; }
        public string SignerName { get; set; }
        public string RefPO { get; set; } 

        public List<PurchaseOrderModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<PurchaseOrderModel> list = new List<PurchaseOrderModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new PurchaseOrderModel
                {
                    Id= 264,
                    AppId= 1,
                    PONo= "expedita",
                    PODate = DateTime.Now,
                    SellerId= 778,
                    QuotationNo1= "est",
                    QuotationDate1 = DateTime.Now,
                    QuotationNo2= "esse",
                    QuotationDate2 = DateTime.Now,
                    POType= 551,
                    SignerName= "et",
                    RefPO= "aperiam"
                };
                list.Add(en);
            }
            return list;
        }
    }
}