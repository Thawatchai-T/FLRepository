using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class EquipmentDetail : BaseDomain
    {
        public EquipmentDetail()
        {
            EquipmentList = new EquipmentList();
        }

        public virtual long Id { get; set; }
        public virtual long EquipmentListId { get; set; }
        public virtual int SubType { get; set; }
        public virtual int Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string CC { get; set; }
        public virtual string SerialNo { get; set; }
        public virtual string FrameChassisSerialNo { get; set; }
        public virtual string FLNo { get; set; }
        public virtual DateTime? DateInvoice { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual string ChassisNo { get; set; }
        public virtual string EngineNo { get; set; }
        public virtual string Color { get; set; }
        public virtual string LicenseNo { get; set; }
        public virtual decimal PriceCar { get; set; }
        public virtual bool Book { get; set; }
        public virtual int BookBy { get; set; }
        public virtual DateTime? BookReceivedDate { get; set; }
        public virtual DateTime? BookReturnDate { get; set; }
        public virtual string PowNo { get; set; }
        public virtual bool SpareKey { get; set; }
        public virtual int SpareBy { get; set; }
        public virtual DateTime? SpareReceivedDate { get; set; }
        public virtual DateTime? SpareReturnDate { get; set; }
        public virtual string Remark { get; set; }

        

        public virtual EquipmentList EquipmentList { get; set; }
    }
}
