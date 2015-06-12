using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class LeadModel
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public int LeadId { get; set; }
        public string Status { get; set; }
        public string RequestDate { get; set; }
        public int MarketingCode { get; set; }
        public int Method { get; set; }
        public int CustomerId { get; set; }
        public int TypeCustomer { get; set; }
        public int TitleNameTh { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int SubDistrict { get; set; }
        public int ContactPersonTitleNameTh { get; set; }
        public string ContactPersonFirstNameTh { get; set; }
        public string ContactPersonLastNameTh { get; set; }
        public int Position { get; set; }
        public string Business { get; set; }
        public string Establishment { get; set; }
        public int SourceInformation { get; set; }
        public string Remark { get; set; }
        public string FinancialPolicy { get; set; }
        public int TypeEQP { get; set; }
        public decimal EQPAmount { get; set; }
        public string PlanSchedule { get; set; }
        public int Result { get; set; }
        public string OtherComment { get; set; }
        
        public List<LeadModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<LeadModel> list = new List<LeadModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new LeadModel
                {
                    Id = i,
                    Year = DateTime.Now.Year,
                    LeadId = i,
                    Status = "LD20150101",
                    RequestDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    MarketingCode = i,
                    Method = i,
                    CustomerId = i,
                    TypeCustomer = i,
                    TitleNameTh = i,
                    FirstNameTh = "a" + i,
                    LastNameTh = "a" + i,
                    Address = "a" + i,
                    Telephone = "a" + i,
                    Fax = "a" + i,
                    Email = "a" + i,
                    SubDistrict = i,
                    ContactPersonTitleNameTh = i,
                    ContactPersonFirstNameTh = "a" + i,
                    ContactPersonLastNameTh = "a" + i,
                    Position = i,
                    Business = "a" + i,
                    Establishment = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    SourceInformation = i,
                    Remark = "a" + i,
                    FinancialPolicy = "a" + i,
                    TypeEQP = i,
                    EQPAmount = i,
                    PlanSchedule = "a" + i,
                    Result = i,
                    OtherComment = "a" + i
                };
                list.Add(en);
            }
            return list;
        }

    }
}