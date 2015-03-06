using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class GuarantorModel
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string ConditionLease { get; set; }
        public string BGNo { get; set; }
        public string BGReceivedDate { get; set; }
        public string ConfirmPrintedDate { get; set; }
        public string ReturnDate { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public double BGAmount { get; set; }
        public string BGDate { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }
        public string BuyerName { get; set; }
        public double RSAAmount { get; set; }
        public string EquipmentSalesPrintedDate { get; set; }
        public double Signer1EquipmentSales { get; set; }
        public double Signer2EquipmentSales { get; set; }
        public double WithnessEquipmentSales { get; set; }
        public double AddressEquipmentSales { get; set; }
        public int Collateral { get; set; }
        public string CollateralDetail { get; set; }
        public string AdditionalCondition { get; set; } 
    }
}
