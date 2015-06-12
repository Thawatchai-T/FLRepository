using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class IndicationEquipmentModel
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public string IndicationId { get; set; }
        public string IndicationDate { get; set; }
        public int JobId { get; set; }
        public int InformationId { get; set; }
        public int RequestType { get; set; }
        public int ScheduleNo { get; set; }
        public int LeaseType { get; set; }
        public int CustomerId { get; set; }
        public string ContactPerson { get; set; }
        public string CustomerFax { get; set; }
        public int ThirdPartyId { get; set; }
        public string ThirdPartyContactPerson { get; set; }
        public string ThirdPartyContactPersonFax { get; set; }
        public int MarketingOfficer { get; set; }
        public string Currency { get; set; }
        public string ExchangeRate { get; set; }
        public decimal Rating { get; set; }
        public decimal ExposureRate { get; set; }
        public decimal ExposureLimit { get; set; }
        public string RatingDate { get; set; }
        public bool Approve { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UdpateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        
        public List<IndicationEquipmentModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<IndicationEquipmentModel> list = new List<IndicationEquipmentModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new IndicationEquipmentModel
                {
                    Id = i,
                    Year = DateTime.Now.Year,
                    IndicationId = "ID20140101",
                    IndicationDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    JobId = i,
                    InformationId = i,
                    RequestType = i,
                    ScheduleNo = i,
                    LeaseType = i,
                    CustomerId = i,
                    ContactPerson = "a" + i,
                    CustomerFax = "a" + i,
                    ThirdPartyId = i,
                    ThirdPartyContactPerson = "a" + i,
                    ThirdPartyContactPersonFax = "a" + i,
                    MarketingOfficer = i,
                    Currency = "a" + i,
                    ExchangeRate = "a" + i,
                    Rating = i,
                    ExposureRate = i,
                    ExposureLimit = i,
                    RatingDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    Approve = true,
                    CreateDate = DateTime.Now,
                    UdpateDate= null,
                    CreateBy= "phutip_pr",
                    UpdateBy= null
                };
                list.Add(en);
            }
            return list;
        }

    }
}