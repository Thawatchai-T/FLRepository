using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class StampDutyModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public int BorneBy { get; set; }
        public decimal Amount { get; set; }
    }
}
