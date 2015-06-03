using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class GuarantorMap : ClassMap<Guarantor>
    {
        public GuarantorMap()
        {
            Table("JOB_AD_GUARANTOR");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.ConditionLease).Column("CONDITION_LEASE");
            Map(x => x.BGNo).Column("BG_NO").Length(20);
            Map(x => x.BGReceivedDate).Column("BG_RECEIVED_DATE").CustomSqlType("date");
            Map(x => x.ConfirmPrintedDate).Column("CONFIRM_PRINTED_DATE").CustomSqlType("date");
            Map(x => x.ReturnDate).Column("RETURN_DATE").CustomSqlType("date");
            Map(x => x.Bank).Column("BANK");
            Map(x => x.Branch).Column("BRANCH").Length(100);
            Map(x => x.BGAmount).Column("BG_AMOUNT");
            Map(x => x.BGDate).Column("BG_DATE").CustomSqlType("date");
            Map(x => x.PeriodFrom).Column("PERIOD_FROM").CustomSqlType("date");
            Map(x => x.PeriodTo).Column("PERIOD_TO").CustomSqlType("date");
            Map(x => x.BuyerName).Column("BUYER_NAME").Length(100);
            Map(x => x.RSAAmount).Column("RSA_AMOUNT");
            Map(x => x.EquipmentSalesPrintedDate).Column("EQUIPMENT_SALES_PRINTED_DATE").CustomSqlType("date");
            Map(x => x.Signer1EquipmentSales).Column("SIGNER1_EQUIPMENT_SALES").Length(100);
            Map(x => x.Signer2EquipmentSales).Column("SIGNER2_EQUIPMENT_SALES").Length(100);
            Map(x => x.WithnessEquipmentSales).Column("WITHNESS_EQUIPMENT_SALES").Length(100);
            Map(x => x.AddressEquipmentSales).Column("ADDRESS_EQUIPMENT_SALES").Length(255);
            Map(x => x.Collateral).Column("COLLATERAL");
            Map(x => x.CollateralDetail).Column("COLLATERAL_DETAIL").Length(150);
            Map(x => x.AdditionalCondition).Column("ADDITIONAL_CONDITION").Length(150);
        }
    }
}
