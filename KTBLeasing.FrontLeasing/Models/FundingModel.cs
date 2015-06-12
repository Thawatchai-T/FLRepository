using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class FundingModel
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public int Source { get; set; }
        public decimal NetRate { get; set; }
        public decimal FundingCost { get; set; }
        public decimal Spread { get; set; }
        public decimal ProfitFromSpread { get; set; }
        public decimal CreditNetRate { get; set; }
        public decimal CreditSpread { get; set; }
        public decimal CreditProfit { get; set; }
    }
}
