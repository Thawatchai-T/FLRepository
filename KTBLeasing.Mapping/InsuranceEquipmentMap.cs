using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class InsuranceEquipmentMap : ClassMap<InsuranceEquipment>
    {
        public InsuranceEquipmentMap()
        {
            Table("AD_INSURANCE_EQUIPMENT");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.Insurance).Column("INSURANCE_ID");
            Map(x => x.EquipmentType).Column("EQUIPMENT_TYPE");
            Map(x => x.Chassis).Column("CHASSIS");
            Map(x => x.Licens).Column("LICENS").Length(20);
            Map(x => x.StartDate).Column("START_DATE").CustomSqlType("date");
            Map(x => x.EndDate).Column("END_DATE").CustomSqlType("date");
            Map(x => x.Rate).Column("RATE");
            Map(x => x.SumInsured).Column("SUM_INSURED");
            Map(x => x.Premium).Column("PREMIUM");
            Map(x => x.Territory).Column("TERRITORY");
            Map(x => x.Deductible).Column("DEDUCTIBLE");
            Map(x => x.PaymentInsRate).Column("PAYMENT_INS_RATE").Length(100);
            Map(x => x.Minimum).Column("MINIMUM");
            Map(x => x.ActualPremium).Column("ACTUAL_PREMIUM");
            Map(x => x.StampDuty).Column("STAMP_DUTY");
            Map(x => x.Discount).Column("DISCOUNT");
            Map(x => x.NetPremium).Column("NET_PREMIUM");
            Map(x => x.PaidPream).Column("PAID_PREAM");
            Map(x => x.PolicyNo).Column("POLICY_NO").Length(20);
            Map(x => x.ReceivedDate).Column("RECEIVED_DATE").CustomSqlType("date");
            Map(x => x.PayDate).Column("PAY_DATE").CustomSqlType("date");
            Map(x => x.Remark).Column("REMARK").Length(255);
        }
    }
}
