using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class EquipmentListModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public long SellerId { get; set; }
        public string SellerName { get; set; }
        public int Quantity { get; set; }
        public long EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public decimal VAT { get; set; }
        public decimal Net { get; set; }
        public DateTime ChequeDate { get; set; } 

        public List<EquipmentListModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<EquipmentListModel> list = new List<EquipmentListModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new EquipmentListModel
                {
                    Id= 129,
                    SellerId= 202,
                    SellerName = "METRO SYSTEMS CORPORATION PUBLIC CO., LTD.",
                    Quantity= 946,
                    EquipmentId= 981,
                    EquipmentName = "Blue Coat Network Equipment",
                    UnitPrice = Convert.ToDecimal(5815962.91),
                    Total = Convert.ToDecimal(5815962.91),
                    VAT = Convert.ToDecimal(407117.00),
                    Net= Convert.ToDecimal(85.16),
                    ChequeDate = DateTime.Now
                };
                list.Add(en);
            }
            return list;
        }
    }
}