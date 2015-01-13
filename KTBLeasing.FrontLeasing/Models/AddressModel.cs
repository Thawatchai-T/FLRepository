using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string AddressEng { get; set; }
        public string AddressTh { get; set; }
        public int SubdistrictId { get; set; }
        public int Zipcode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Remark { get; set; }
        public int AddressType { get; set; }
        public bool Active { get; set; }

    }
}