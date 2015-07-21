using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KTBLeasing.FrontLeasing.Domain;

namespace KTBLeasing.FrontLeasing.Models
{
    public class JobModel
    {
        public List<Job> data { get; set; }
        public int total { get; set; }
    }
}