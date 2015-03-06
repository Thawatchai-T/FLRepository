using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class CommissionModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string PayCompanyName { get; set; }
        public double PayAmount { get; set; }
        public string PayDetail { get; set; }
        public double PayPaymentCondition { get; set; }
        public string ReceiveCompanyName { get; set; }
        public double ReceiveAmount { get; set; }
        public string ReceiveDetail { get; set; }
        public int ReceivePaymentCondition { get; set; } 
    }
}
