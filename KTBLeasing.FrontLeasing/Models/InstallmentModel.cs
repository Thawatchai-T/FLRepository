using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class InstallmentModel
    {
        public long Id { get; set; }
        public string Agreement { get; set; }
        public int SEQ { get; set; }
        public int InstallNo { get; set; }
        public DateTime? InstallmentDate { get; set; }
        public decimal InstallmentBeforeVAT { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
        public decimal Principle { get; set; }
        public decimal Interest { get; set; }
        public decimal OS_PR { get; set; }
    }
}