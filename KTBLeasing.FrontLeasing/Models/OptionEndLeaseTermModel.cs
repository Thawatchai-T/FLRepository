using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class OptionEndLeaseTermModel
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public bool PurchaseOption { get; set; }
        public int ResidualValue { get; set; }
        public int ResidualValuePercent { get; set; }
        public string Others { get; set; }
        public bool Renewal { get; set; }
        public int Term { get; set; }
        public bool Rental { get; set; }
        public decimal RentalTotal { get; set; }
        public decimal RentalTotalBHT { get; set; }
        public decimal ResidualValueTotal { get; set; }
        public decimal ResidualValueTotalBHT { get; set; }
        public decimal ResidualValuePercentEQ { get; set; }
        public bool Return { get; set; }
        public decimal GuaranteeBuyBackTotal { get; set; }
        public decimal GuaranteeBuyBackTotalBHT { get; set; }
        public decimal GuaranteeBuyBackPercentEQ { get; set; }
        public string BuyerName { get; set; } 
    }
}
