using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class SellerModel
    {
        public long Id { get; set; }
        public long AppId { get; set; }
        public string SellerName { get; set; }
        public string Address { get; set; }
        public string Signer1 { get; set; }
        public string Signer2 { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public int PaymentCondition { get; set; }
        public int PaymentMethod { get; set; }
        public int BankNo { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
        public string BankChargeBy { get; set; }
        public string Remark { get; set; } 

        public List<SellerModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<SellerModel> list = new List<SellerModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new SellerModel
                {
                   Id= 51,
                   AppId = 1,
                    SellerName= "consequatur",
                    Address= "qui",
                    Signer1= "quibusdam",
                    Signer2= "ipsa",
                    Title1= "sed",
                    Title2= "rerum",
                    PaymentCondition= 34,
                    PaymentMethod= 42,
                    BankNo= 4,
                    BankName= "sapiente",
                    Branch= "et",
                    AccountType= "quidem",
                    AccountNo= "excepturi",
                    BankChargeBy= "quasi",
                    Remark= "odio"
                };
                list.Add(en);
            }
            return list;
        }
    }
}