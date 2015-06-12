using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class CollectionScheduleModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string CollectionDate { get; set; }
        public string Collection { get; set; }
        public decimal Principal { get; set; }
        public decimal Receivable { get; set; } 
    }
}
