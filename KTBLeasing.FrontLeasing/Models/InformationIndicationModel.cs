using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class InformationIndicationModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RequestDate { get; set; }
        public string PrimaryJob { get; set; }
        public long IndustryCode { get; set; }
        public long MarketingCode { get; set; }
        public int Year { get; set; }
        public string InfoId { get; set; }
        public int LeadId { get; set; }
        public int Nationality { get; set; }
        public int CustomerId { get; set; }
        public int TypeCustomer { get; set; }
        public int GroupCust { get; set; }
        public int TitleNameTh { get; set; }
        public int FirstNameTh { get; set; }
        public int LastNameTh { get; set; }
        public int TypeBusiness { get; set; }
        public string Address { get; set; }
        public int SubDistrict { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public BackgroundModel Business { get; set; }
        public int TypeFinance { get; set; }
        public string SubLesseeSyndicated { get; set; }
        public string UsedEquipment { get; set; }
        public string SpecialProgram { get; set; }
        public string EQPYear { get; set; }
        public string ProgramName { get; set; }
        public string Currency { get; set; }
        public string ExchangeRate { get; set; }
        public int SourceInformation { get; set; }
        public string Remark { get; set; }
        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    var t = obj as InformationIndicationModel;
        //    if (t == null) return false;
        //    if (Business.Id == t.Business.Id)
        //        return true;

        //    return false;
        //}
        //public override int GetHashCode()
        //{
        //    int hash = GetType().GetHashCode();
        //    hash = (hash * 397) ^ Business.Id.GetHashCode();

        //    return hash;
        //}
        public List<InformationIndicationModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<InformationIndicationModel> list = new List<InformationIndicationModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new InformationIndicationModel
                {
                    Id = i,
                    Name = "IF20150101",
                    RequestDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    PrimaryJob = "a" + i,
                    IndustryCode = i,
                    MarketingCode = i,
                    Year = DateTime.Now.Year,
                    InfoId = "IF20150101",
                    LeadId = i,
                    Nationality = i,
                    CustomerId = i,
                    TypeCustomer = i,
                    GroupCust = i,
                    TitleNameTh = i,
                    FirstNameTh = i,
                    LastNameTh = i,
                    TypeBusiness = i,
                    Address = "a" + i,
                    SubDistrict = i,
                    Telephone = "a" + i,
                    Fax = "a" + i,
                    Email = "a" + i,
                    TypeFinance = i,
                    SubLesseeSyndicated = "a" + i,
                    UsedEquipment = "a" + i,
                    SpecialProgram = "a" + i,
                    EQPYear = "a" + i,
                    ProgramName = "a" + i,
                    Currency = "a" + i,
                    ExchangeRate = "a" + i,
                    SourceInformation = i,
                    Remark = "a" + i
                };

                en.Business = new BackgroundModel
                {
                    Id = i,
                    Business = "a" + i,
                    Establishment = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    Rating = i,
                    RatingDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    RatingDetail = i,
                    RegisterCapital = i,
                    RegisterCapitalDetail = "a" + i,
                    Sales = i,
                    SalesDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    SalesDetail = "a" + i,
                    ProfitLoss = i,
                    ProfitLossDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    ProfitLossDetail = "a" + i,
                    ShareholderEquity = i,
                    ShareholderEquityDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    ShareholderEquityDetail = "a" + i,
                    OutstandingAmount = i,
                    OutstandingAmountDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    ExposureLimit = i,
                    ExposureLimitDate = DateTime.Now.ToString("MM/dd/yyyy", eng),
                    Committed = i
                };
                list.Add(en);
            }
            return list;
        }

    }
}