using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class RestructureModel
    {
        public long Id { get; set; }
        public string Agreement { get; set; }
        public int SEQ { get; set; }
        public DateTime? RestructureDate { get; set; }
        public decimal EffectiveRate { get; set; }
    }
}