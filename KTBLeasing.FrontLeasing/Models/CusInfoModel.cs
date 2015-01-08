using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class CusInfoModel
    {
        public int CustomerCode { get; set; }
        public int CustomerEngType { get; set; }
        public int CustomerThaiType { get; set; }
        public string CustomerEngName { get; set; }
        public string CustomerThaiName { get; set; }
        public int TypeCustomer { get; set; }
        public int ParentCompany { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string TaxNo { get; set; }
        public string Fax { get; set; }
        public int KTBIsicCode { get; set; }
        public int KTBCustType { get; set; }
        public string VAT { get; set; }
        public int IndustryCode { get; set; }
        public int NatureCust { get; set; }
        public int GroupCust { get; set; }
        public int TypeCust { get; set; }

        public List<CusInfoModel> Dummy()
        {
            List<CusInfoModel> list = new List<CusInfoModel>();
            for (int i = 0; i <= 30; i++)
            {
                var en = new CusInfoModel
                {
                    CustomerCode = i,
                    CustomerEngType = i,
                     CustomerThaiType = i,
                    CustomerEngName = "Company A"+i,
                    CustomerThaiName = "บริษัท ก"+i
                };
                list.Add(en);
            }
            return list;
        }
    }
}