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
    }
}
 