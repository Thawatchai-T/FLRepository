using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class InsuranceEquipmentModel
    {
        public long Id { get; set; }
        public long InsuranceId { get; set; }
        public string EquipmentType { get; set; }
        public int Chassis { get; set; }
        public string Licens { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Rate { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Premium { get; set; }
        public int Territory { get; set; }
        public decimal Deductible { get; set; }
        public string PaymentInsRate { get; set; }
        public decimal Minimum { get; set; }
        public decimal ActualPremium { get; set; }
        public decimal StampDuty { get; set; }
        public decimal Discount { get; set; }
        public decimal NetPremium { get; set; }
        public decimal PaidPream { get; set; }
        public string PolicyNo { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime PayDate { get; set; }
        public string Remark { get; set; } 

        public List<InsuranceEquipmentModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<InsuranceEquipmentModel> list = new List<InsuranceEquipmentModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new InsuranceEquipmentModel
                {
                    Id= i,
                    InsuranceId= 264,
                    EquipmentType= "beatae",
                    Chassis= 478,
                    Licens= "rerum",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Rate= Convert.ToDecimal(123.51),
                    SumInsured = Convert.ToDecimal(123.51),
                    Premium = Convert.ToDecimal(123.51),
                    Territory= 397,
                    Deductible = Convert.ToDecimal(123.51),
                    PaymentInsRate= "voluptas",
                    Minimum = Convert.ToDecimal(123.51),
                    ActualPremium = Convert.ToDecimal(123.51),
                    StampDuty = Convert.ToDecimal(123.51),
                    Discount = Convert.ToDecimal(123.51),
                    NetPremium = Convert.ToDecimal(123.51),
                    PaidPream = Convert.ToDecimal(123.51),
                    PolicyNo= "veniam",
                    ReceivedDate = DateTime.Now,
                    PayDate = DateTime.Now,
                    Remark= "nesciunt"
                };
                list.Add(en);
            }
            return list;
        }
    }
}