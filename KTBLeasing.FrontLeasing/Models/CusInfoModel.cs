using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class CusInfoModel
    {
        public long CustomerId { get; set; }
        public long CustomerEngType { get; set; }
        public long CustomerThaiType { get; set; }
        public string CustomerEngName { get; set; }
        public string CustomerThaiName { get; set; }
        public long TypeCustomer { get; set; }
        public long ParentCompany { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string TaxNo { get; set; }
        public string Fax { get; set; }
        public long KTBIsicCode { get; set; }
        public long KTBCustType { get; set; }
        public long VAT { get; set; }
        public long IndustryCode { get; set; }
        public long NatureCust { get; set; }
        public long GroupCust { get; set; }
        public long TypeCust { get; set; }

        //public List<CusInfoModel> Dummy()
        //{
        //    List<CusInfoModel> list = new List<CusInfoModel>();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        var en = new CusInfoModel
        //        {
        //            CustomerId = i,
        //            CustomerEngType = i,
        //             CustomerThaiType = i,
        //            CustomerEngName = "Company A"+i,
        //            CustomerThaiName = "บริษัท ก"+i,
        //            TypeCustomer = 99,
        //            NatureCust = 67
        //        };
        //        list.Add(en);
        //    }
        //    return list;
        //}

        public long MarketingOfficer { get; set; }
    }
}