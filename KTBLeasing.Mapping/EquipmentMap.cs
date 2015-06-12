using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class EquipmentMap : ClassMap<Equipment>
    {
        public EquipmentMap()
        {
            Table("JOB_ID_EQUIPMENT");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.IndicationEquipment).Column("INDICATION_ID");
            Map(x => x.EquipmentName).Column("EQUIPMENT_NAME").Length(128);
            Map(x => x.EquipmentDate).Column("EQUIPMENT_DATE").CustomSqlType("date");
            Map(x => x.Quantity).Column("QUANTITY");
            Map(x => x.Cost).Column("COST");
            Map(x => x.Term).Column("TERM");
            Map(x => x.Deposit).Column("DEPOSIT");
            Map(x => x.DepositAmount).Column("DEPOSIT_AMOUNT");
            Map(x => x.RV).Column("RV");
            Map(x => x.RVAmount).Column("RV_AMOUNT");
            Map(x => x.IRRNet).Column("IRR_NET");
            Map(x => x.IRRGross).Column("IRR_GROSS");
            Map(x => x.AbnormalRental).Column("ABNORMAL_RENTAL");
            Map(x => x.Rental).Column("RENTAL");
            Map(x => x.TotalMA).Column("TOTAL_MA");
            Map(x => x.Payment).Column("PAYMENT");
            Map(x => x.AdvanceArrear).Column("ADVANCE_ARREAR");
            Map(x => x.InsuranceBorne).Column("INSURANCE_BORNE");
            Map(x => x.ConditionLease).Column("CONDITION_LEASE");
            Map(x => x.InsTerritory).Column("INS_TERRITORY");
            Map(x => x.InsRemark).Column("INS_REMARK").Length(256);
            Map(x => x.OtherCondition).Column("OTHER_CONDITION").Length(256);
            Map(x => x.Result).Column("RESULT");
            Map(x => x.ResultQuantity).Column("RESULT_QUANTITY");
            Map(x => x.CreateDate).Column("CREATE_DATE").CustomSqlType("date");
            Map(x => x.CreateBy).Column("CREATE_BY").Length(32);
            Map(x => x.UpdateDate).Column("UPDATE_DATE").CustomSqlType("date");
            Map(x => x.UpdateBy).Column("UPDATE_BY").Length(32);
        }
    }
}
