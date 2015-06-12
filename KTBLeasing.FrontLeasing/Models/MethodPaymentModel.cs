using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class MethodPaymentModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public int MethodPayment { get; set; }
        public int BankCharges { get; set; }
        public decimal ChequeAmount { get; set; } 
    }
}
