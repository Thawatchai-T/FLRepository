using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTBLeasing.FrontLeasing.Models
{
    public class SignerModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long TitleTh { get; set; }
        public long TitleEng { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public string FirstNameEng { get; set; }
        public string LastNameEng { get; set; }
        public string AddressTh { get; set; }
        public string AddressEng { get; set; }
        public string PositionTh { get; set; }
        public string PositionEng { get; set; }
        public string Remark { get; set; }

        public long PassportType { get; set; }
        public string IdCardNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? IssuedDate { get; set; }
        public short Active { get; set; }


        public long SpouseTitleEng { get; set; }
        public long SpouseTitleTh { get; set; }
        public string SpouseFirstNameTh { get; set; }
        public string SpouseFirstNameEng { get; set; }
        public string SpouseLastNameTh { get; set; }
        public string SpouseLastNameEng { get; set; }
        public string SpouseAddressTh { get; set; }
        public string SpouseAddressEng { get; set; }
        public long SpouseSubDistrictId { get; set; }
        public long SubDistrictId { get; set; }

        public List<SignerModel> Dummy()
        {
            List<SignerModel> list = new List<SignerModel>();
            for (int i = 0; i <= 30; i++)
            {
                var en = new SignerModel
                {
                    Id = i,
                    TitleTh = 46,
                    TitleEng = 110,
                    FirstNameTh = "ชาริล" + i,
                    LastNameTh = "ฉาบปูน" + i,
                    FirstNameEng = "Charil" + i,
                    LastNameEng = "Charpoon" + i,
                    AddressTh = "101 ก" + i,
                    AddressEng = "101 A" + i
                };
                list.Add(en);
            }
            return list;
        }

    }
}