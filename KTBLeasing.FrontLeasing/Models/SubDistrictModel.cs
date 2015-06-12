using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class SubDistrictModel
    {
        public int SubDistrictId { get; set; }
        public int DistrictId { get; set; }
        public string SubDistrictName { get; set; }
        public int ZipCode { get; set; }
    }
}