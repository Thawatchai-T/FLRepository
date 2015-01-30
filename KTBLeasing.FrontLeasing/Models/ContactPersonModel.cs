using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class ContactPersonModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long TitleTh { get; set; }
        public long TitleEng { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public string FirstNameEng { get; set; }
        public string LastNameEng { get; set; }
        public string PositionTh { get; set; }
        public string PositionEng { get; set; }
        public string Department { get; set; }
        public string Remark { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public short Active { get; set; }

        public List<ContactPersonModel> Dummy()
        {
            List<ContactPersonModel> list = new List<ContactPersonModel>();
            for (int i = 0; i < 30; i++)
            {
                var en = new ContactPersonModel
                {
                    Id = i,
                    TitleTh = 46,
                    TitleEng = 110,
                    FirstNameTh = "ชาริล" + i,
                    LastNameTh = "ฉาบปูน" + i,
                    FirstNameEng = "Charil" + i,
                    LastNameEng = "Charpoon" + i,
                    PositionTh = "101 ก" + i,
                    PositionEng = "101 A" + i,
                    Remark = "Other",
                    Telephone = "0811233212",
                    Fax = "0811233212",
                    Email = "aa"+i+"@bb.cc",
                    Department = "IT",
                    Active = 1
                };
                list.Add(en);
            }
            return list;
        }

    }
}