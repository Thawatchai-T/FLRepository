using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class StipulateLossModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public decimal CommencementLeasePerUnit { get; set; }
        public decimal CommencementLeaseTotal { get; set; }
        public int MonthlyDiminishingAmountFrom { get; set; }
        public int MonthlyDiminishingAmountTo { get; set; }
        public decimal MonthlyDiminishingPerUnit { get; set; }
        public decimal MonthlyDiminishingTotal { get; set; }
        public int MonthlyDiminishingAmountFrom2 { get; set; }
        public int MonthlyDiminishingAmountTo2 { get; set; }
        public decimal MonthlyDiminishingPerUnit2 { get; set; }
        public decimal MonthlyDiminishingTotal2 { get; set; }
    }
}
