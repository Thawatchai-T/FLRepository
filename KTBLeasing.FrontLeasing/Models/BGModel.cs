using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class BGModel
    {
        public long Id { get; set; }
        public string BGNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime BGDate { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public decimal Amount { get; set; }
        public string ContactNo { get; set; }
    }
}
