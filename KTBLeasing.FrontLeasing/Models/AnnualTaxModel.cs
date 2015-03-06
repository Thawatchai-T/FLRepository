using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class AnnualTaxModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public int BorneBy { get; set; }
        public int Yearly { get; set; }
        public decimal PerUnit { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public List<AnnualTaxModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<AnnualTaxModel> list = new List<AnnualTaxModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new AnnualTaxModel
                {
                    Id= 952,
                    AppId = 1,
                    BorneBy= 787,
                    Yearly= 244,
                    PerUnit= 710,
                    Quantity= 68,
                    Total= Convert.ToDecimal(696.1)
                };
                list.Add(en);
            }
            return list;
        }
    }
}