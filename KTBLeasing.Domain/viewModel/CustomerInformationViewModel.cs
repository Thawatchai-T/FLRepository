using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTBLeasing.Domain.ViewModel
{
    public class CustomerInformationViewModel
    {
        public int CustomerCode { get; set; }
        public string TitleName { get; set; }
        public string NameEng { get; set; }
        public string NameThai { get; set; }
        public string MarketingOfficer { get; set; }
        public string Address { get; set; }
        public string Business { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }

    }
}
