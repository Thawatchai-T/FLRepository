using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class TermConditionMap : ClassMap<TermCondition>
    {
        public TermConditionMap()
        {
            Table("JOB_AD_TERM_CONDITION");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.LeaseTerm).Column("LEASE_TERM");
            Map(x => x.PaymentId).Column("PAYMENT_ID");
            Map(x => x.TypeId).Column("TYPE_ID");
            Map(x => x.SyndicateSubLease).Column("SYNDICATE_SUBLEASE").Length(150);
            Map(x => x.AdvanceArrearId).Column("ADVANCE_ARREAR_ID");
            Map(x => x.TypeFinanceId).Column("TYPE_FINANCE_ID");
            Map(x => x.RateTypeId).Column("RATE_TYPE_ID");
            Map(x => x.SubsequenceDueDay).Column("SUBSEQUENCE_DUE_DAY");
            Map(x => x.Irregular).Column("IRREGULAR");
            Map(x => x.PerUnitEqual).Column("PER_UNIT_EQUAL");
            Map(x => x.AbnormalRental).Column("ABNORMAL_RENTAL");
            Map(x => x.ReceivedCompanyName).Column("RECEIVED_COMPANY_NAME").Length(150);
            Map(x => x.FinanceFeeAmount).Column("FINANCE_FEE_AMOUNT");
            Map(x => x.PercentEquipmentCost).Column("PERCENT_EQUIPMENT_COST");
            Map(x => x.PercentEquipmentCostTypeId).Column("PERCENT_EQUIPMENT_COST_TYPE_ID");
            Map(x => x.PaymentConditionId).Column("PAYMENT_CONDITION_ID");
            Map(x => x.FirstDuePerUnit).Column("FIRST_DUE_PER_UNIT");
            Map(x => x.SecondDuePerUnit).Column("SECOND_DUE_PER_UNIT");
            Map(x => x.LastDuePerUnit).Column("LAST_DUE_PER_UNIT");
            Map(x => x.NetRate).Column("NET_RATE");
            Map(x => x.GrossRate).Column("GROSS_RATE");
            Map(x => x.GrossRateAccount).Column("GROSS_RATE_ACCOUNT");
            Map(x => x.AverageLife).Column("AVERAGE_LIFE");
            Map(x => x.RentalMA).Column("RENTAL_MA");
            Map(x => x.NumberPayment).Column("NUMBER_PAYMENT");
            Map(x => x.FirstDueDate).Column("FIRST_DUE_DATE").CustomSqlType("date");
            Map(x => x.LastDueDate).Column("LAST_DUE_DATE").CustomSqlType("date");
            Map(x => x.RVDueDate).Column("RV_DUE_DATE").CustomSqlType("date");
            Map(x => x.ResidualValuePerUnit).Column("RESIDUAL_VALUE_PER_UNIT");
            Map(x => x.RVDueDateOriginal).Column("RVDUE_DATE_ORIGINAL").CustomSqlType("date");
            Map(x => x.PercentEQ).Column("PERCENT_EQ");
            Map(x => x.TotalReceivablePerUnit).Column("TOTAL_RECEIVABLE_PER_UNIT");
            Map(x => x.TotalUnearnedPerUnit).Column("TOTAL_UNEARNED_PER_UNIT");
        }
    }
}
