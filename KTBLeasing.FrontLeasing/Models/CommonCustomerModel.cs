using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class CommonCustomerModel
    {
        public long CustomerCode { get; set; }
        public string TitleNameTh { get; set; }
        public string NameTh { get; set; }
        public string NameEng { get; set; }
        public long MarketingOfficer { get; set; }
        public long TypeCustomer { get; set; }
        public string AddressTh { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string SubdistrictId { get; set; }
        public long Zipcode { get; set; }
        public long ContactTitleTh { get; set; }
        public string ContactPersonFirstName { get; set; }
        public string ContactPersonLastName { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string PositionTh { get; set; }
    }
}