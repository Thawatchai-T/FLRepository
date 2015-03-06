using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class InsuranceModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public int InsuranceCompany { get; set; }
        public int PaymentCondition { get; set; }
        public string Equipment1 { get; set; }
        public int BorneBy1 { get; set; }
        public string Equipment2 { get; set; }
        public int BorneBy2 { get; set; }
        public string ExceptEquipment { get; set; }
        public string Remark { get; set; } 
    }
}
