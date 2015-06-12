using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class MaintenanceModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string PayTo { get; set; }
        public int PaymentCondition { get; set; }
        public int Pattern { get; set; }
        public double FirstDue { get; set; }
        public double SecondDue { get; set; }
        public double LastDue { get; set; } 
    }
}
