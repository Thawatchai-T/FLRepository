using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.FrontLeasing.Models
{
    public class WaiveDocumentModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string Document { get; set; }
        public string Reason { get; set; } 
    }
}
