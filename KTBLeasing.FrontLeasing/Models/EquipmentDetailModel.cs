using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace KTBLeasing.FrontLeasing.Models
{
    public class EquipmentDetailModel
    {
        public long Id { get; set; }

        public long EquipmentListId { get; set; }
        public int SubType { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public string CC { get; set; }
        public string SerialNo { get; set; }
        public string FrameChassisSerialNo { get; set; }
        public string FLNo { get; set; }
        public DateTime DateInvoice { get; set; }
        public DateTime DueDate { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string Color { get; set; }
        public string LicenseNo { get; set; }
        public decimal PriceCar { get; set; }
        public bool Book { get; set; }
        public int BookBy { get; set; }
        public DateTime BookReceivedDate { get; set; }
        public DateTime BookReturnDate { get; set; }
        public string PowNo { get; set; }
        public bool SpareKey { get; set; }
        public int SpareBy { get; set; }
        public DateTime SpareReceivedDate { get; set; }
        public DateTime SpareReturnDate { get; set; }
        public string Remark { get; set; }

        public List<EquipmentDetailModel> Dummy()
        {
            CultureInfo eng = new CultureInfo("en-US");

            List<EquipmentDetailModel> list = new List<EquipmentDetailModel>();
            for (int i = 0; i < 1; i++)
            {
                var en = new EquipmentDetailModel
                {
                    Id= 118,
                    EquipmentListId= 465,
                    SubType= 857,
                    Brand= 390,
                    Model= "qui",
                    CC= "120",
                    SerialNo= "3325882457",
                    FrameChassisSerialNo = "AR356906768X",
                    FLNo= "AR3569065",
                    DateInvoice= DateTime.Now,
                    DueDate = DateTime.Now,
                    ChassisNo= "CS4R37",
                    EngineNo= "MX13566642",
                    Color= "Green",
                    LicenseNo= "LC2745582",
                    PriceCar = Convert.ToDecimal(5815962.91),
                    Book= true,
                    BookBy = 92,
                    BookReceivedDate = DateTime.Now,
                    BookReturnDate = DateTime.Now,
                    PowNo= "",
                    SpareKey= true,
                    SpareBy = 92,
                    SpareReceivedDate = DateTime.Now,
                    SpareReturnDate = DateTime.Now,
                    Remark= ""
                };
                list.Add(en);
            }
            return list;
        }
    }
}