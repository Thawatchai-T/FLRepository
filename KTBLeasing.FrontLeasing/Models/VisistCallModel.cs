using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class VisistCallModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string MarketingOfficer { get; set; }
        public string Status { get; set; }
        public int RefNo { get; set; }
        public string CreateBy { get; set; }
        public DateTime CrateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Md5 { get; set; }
        public string CustomerName { get; set; }

        //object 
        public AddressModel Address { get; set; }
        public ContactPersonModel ContactPerson { get; set; }
        public FinancialPolicyModel FinalcialProlicy { get; set; }

        public List<VisistCallModel> GenDummyData()
        {
            List<VisistCallModel> list = new List<VisistCallModel>();

            for (int i = 0; i < 10; i++)
            {
                var en = new VisistCallModel { 
                            Id = i,
                            CustomerId = i,
                            MarketingOfficer = "marketing_"+i,
                            RefNo =  10000025+i,
                            CustomerName = "CustomerName_"+i,
                            CreateDate = DateTime.Now
                            };

                list.Add(en);
            }
            return list;
        }

        public FinancialPolicyModel FinalcialPolicyFunction(string fl)
        {
            var finalcialpolicy = new FinancialPolicyModel();
            finalcialpolicy.Cash = (fl.Substring(0,1).Equals("1"))?true:false;
            finalcialpolicy.Loan = (fl.Substring(1, 1).Equals("1")) ? true : false;
            finalcialpolicy.Lease = (fl.Substring(2, 1).Equals("1")) ? true : false;
            finalcialpolicy.HirePurchase = (fl.Substring(3, 1).Equals("1")) ? true : false;
            finalcialpolicy.LoadAffiliated = (fl.Substring(4, 1).Equals("1")) ? true : false;
            finalcialpolicy.Other = (fl.Substring(5, 1).Equals("1")) ? true : false;

            return finalcialpolicy;
        }

        public AddressModel AddressFunction(int id)
        {
            return new AddressModel();
        }

        
    }
}
 