using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Domain
{
    public class FilterModel
    {
        public string property { get; set; }
        public string value { get; set; }
        public bool exactMatch { get; set; }
        public string type { get; set; }
    }
}