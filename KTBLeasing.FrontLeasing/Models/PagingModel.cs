using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class PagingModel<T>
    {
        public List<T> data { get; set; }
        public int total { get; set; }
    }
}