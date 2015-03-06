using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class ThirdPartyModel
    {
        public int Id { get; set; }
        public string ThirdPartyCode { get; set; }
        public string PersonType { get; set; }
        public string TitleNameEn { get; set; }
        public string NameEn { get; set; }
        public string TitleNameTh { get; set; }
        public string NameTh { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Tag { get; set; }
        public string Vat { get; set; }
        public int PaymentMethod { get; set; }
        public string Bank1 { get; set; }
        public string Branch1 { get; set; }
        public string AccountType1 { get; set; }
        public string AccountNo1 { get; set; }
        public string Bank2 { get; set; }
        public string Branch2 { get; set; }
        public string AccountType2 { get; set; }
        public string AccountNo2 { get; set; }
        public string BankChargeBy { get; set; }
        public int PaymentCondition { get; set; }
        public string OtherRemark { get; set; }
        public string Status { get; set; }

        public List<ThirdPartyModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<ThirdPartyModel> list = new List<ThirdPartyModel>();
            for (int i = 0; i < 30; i++)
            {
                var en = new ThirdPartyModel
                {
                    Id= i,
                    ThirdPartyCode= "TP" + i,
                    PersonType= "quia",
                    TitleNameEn= "consequatur",
                    NameEn= "iusto",
                    TitleNameTh= "Et Ratione Voluptatibus Provident Impedit",
                    NameTh= "et",
                    Telephone= "qui",
                    Fax= "nam",
                    Email= "elane@twinte.gov",
                    HomePage= "esse",
                    Tag= "dolores",
                    Vat= "dolore",
                    PaymentMethod= 875,
                    Bank1= "doloribus",
                    Branch1= "corrupti",
                    AccountType1= "veniam",
                    AccountNo1= "aut",
                    Bank2= "consectetur",
                    Branch2= "temporibus",
                    AccountType2= "nulla",
                    AccountNo2= "qui",
                    BankChargeBy= "exercitationem",
                    PaymentCondition= 649,
                    OtherRemark= "et",
                    Status= "voluptatem"
                };
                list.Add(en);
            }
            return list;
        }
    }
}