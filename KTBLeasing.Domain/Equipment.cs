using System;
using System.Text;
using System.Collections.Generic;
using KTBLeasing.Domain;


namespace KTBLeasing.FrontLeasing.Domain {

    public class Equipment : BaseDomain
    {
        public Equipment()
        {
            IndicationEquipment = new IndicationEquipment();
        }

        public virtual long Id { get; set; }
        public virtual long IndicationId { get; set; }
        public virtual string EquipmentName { get; set; }
        public virtual DateTime? EquipmentDate { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int Term { get; set; }
        public virtual int Deposit { get; set; }
        public virtual decimal DepositAmount { get; set; }
        public virtual int RV { get; set; }
        public virtual decimal RVAmount { get; set; }
        public virtual decimal IRRNet { get; set; }
        public virtual decimal IRRGross { get; set; }
        public virtual decimal AbnormalRental { get; set; }
        public virtual decimal Rental { get; set; }
        public virtual decimal TotalMA { get; set; }
        public virtual int Payment { get; set; }
        public virtual int AdvanceArrear { get; set; }
        public virtual int InsuranceBorne { get; set; }
        public virtual int ConditionLease { get; set; }
        public virtual int InsTerritory { get; set; }
        public virtual string InsRemark { get; set; }
        public virtual string OtherCondition { get; set; }
        public virtual int Result { get; set; }
        public virtual int ResultQuantity { get; set; }

        public virtual IndicationEquipment IndicationEquipment { get; set; }
    }
}
