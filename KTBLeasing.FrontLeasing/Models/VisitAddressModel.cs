using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class VisitAddressModel : AddressModel
    {
        public string Bussiness { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string SourceInfomation { get; set; }

    }
}