using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class GuarantorListModel
    {
        public long Id { get; set; }
        public long GuarantorId { get; set; }
        public bool GuarantorType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Signer1 { get; set; }
        public string Signer2 { get; set; }
        public string Person1 { get; set; }
        public string Position { get; set; }
        public string PersonAddress { get; set; }
        public string ConsentSpouse { get; set; }
        public string SpouseAddress { get; set; } 

        public List<GuarantorListModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<GuarantorListModel> list = new List<GuarantorListModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new GuarantorListModel
                {
                    Id = 167,
                    GuarantorId = 737,
                    GuarantorType = true,
                    Name = "fugit",
                    Address = "1757 Northview Plaza",
                    Signer1 = "officia",
                    Signer2 = "iste",
                    Person1 = "architecto",
                    Position = "iusto",
                    PersonAddress = "296 Reindahl Center",
                    ConsentSpouse = "hic",
                    SpouseAddress = "76 International Alley"
                };
                list.Add(en);
            }
            return list;
        }
    }
}