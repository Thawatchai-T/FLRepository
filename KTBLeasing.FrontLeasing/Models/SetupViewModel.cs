using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class SetupViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Name_Eng { get; set; }
        public int Parent_Id { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
    }
}