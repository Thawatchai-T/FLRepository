using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class EquipmentModel
    {
        public long Id { get; set; }
        public string Equipment { get; set; }
        public string EquipmentDate { get; set; }
        public double Quantity { get; set; }
        public double CostBHT { get; set; }
        public double CostCurrency { get; set; }
        public int Term { get; set; }
        public int Deposit { get; set; }
        public double DepositAmount { get; set; }
        public int RV { get; set; }
        public double RVAmount { get; set; }
        public double IRRNet { get; set; }
        public double IRRGross { get; set; }
        public double AbnormalRental { get; set; }
        public double Rental { get; set; }
        public double TotalMA { get; set; }
        public int Payment { get; set; }
        public int AdvanceArrear { get; set; }
        public int InsuranceBorne { get; set; }
        public int ConditionLease { get; set; }
        public int InsTerritory { get; set; }
        public string InsRemark { get; set; }
        public string OtherCondition { get; set; }
        public int Result { get; set; }
        public string ResultQuantity { get; set; }
        
        public List<EquipmentModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<EquipmentModel> list = new List<EquipmentModel>();
            for (int i = 0; i < 30; i++)
            {
                var en = new EquipmentModel
                {
                    Id = i,
                    Equipment = "a" + i,
                    EquipmentDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    Quantity = i,
                    CostBHT = i,
                    CostCurrency = i,
                    Term = i,
                    Deposit = i,
                    DepositAmount = i,
                    RV = i,
                    RVAmount = i,
                    IRRNet = i,
                    IRRGross = i,
                    AbnormalRental = i,
                    Rental = i,
                    TotalMA = i,
                    Payment = i,
                    AdvanceArrear = i,
                    InsuranceBorne = i,
                    ConditionLease = i,
                    InsTerritory = i,
                    InsRemark = "a" + i,
                    OtherCondition = "a" + i,
                    Result = i,
                    ResultQuantity = "a" + i,
                };
                list.Add(en);
            }
            return list;
        }

    }
}