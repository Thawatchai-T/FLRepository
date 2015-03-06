using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class InsurancePolicyModel
    {
        public long Id { get; set; }
        public string PolicyNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public string ContactNo { get; set; } 

        public List<InsurancePolicyModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<InsurancePolicyModel> list = new List<InsurancePolicyModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new InsurancePolicyModel
                {
                   Id= 393,
                    PolicyNo= "omnis",
                   ReceiveDate = DateTime.Now,
                   PayDate = DateTime.Now,
                    Amount= Convert.ToDecimal(966.71),
                    Rate= Convert.ToDecimal(819.27),
                    ContactNo= "a"+i
                };
                list.Add(en);
            }
            return list;
        }
    }
}