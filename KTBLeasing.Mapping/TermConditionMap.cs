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
            Table("AD_TERM_CONDITION");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.LeaseTerm).Column("LEASETERM");
            Map(x => x.PaymentId).Column("PAYMENTID");
            Map(x => x.TypeId).Column("TYPEID");
            Map(x => x.SyndicateSubLease).Column("SYNDICATESUBLEASE").Length(150);
            Map(x => x.AdvanceArrearId).Column("ADVANCEARREARID");
            Map(x => x.TypeFinanceId).Column("TYPEFINANCEID");
            Map(x => x.RateTypeId).Column("RATETYPEID");
            Map(x => x.SubsequenceDueDay).Column("SUBSEQUENCEDUEDAY");
            Map(x => x.PerUnitEqual).Column("PERUNITEQUAL");
            Map(x => x.AbnormalRental).Column("ABNORMALRENTAL");
            Map(x => x.ReceivedCompanyName).Column("RECEIVEDCOMPANYNAME").Length(150);
            Map(x => x.FinanceFeeAmount).Column("FINANCEFEEAMOUNT");
            Map(x => x.PercentEquipmentCost).Column("PERCENTEQUIPMENTCOST");
            Map(x => x.PercentEquipmentCostTypeId).Column("PERCENTEQUIPMENTCOSTTYPEID");
            Map(x => x.PaymentConditionId).Column("PAYMENTCONDITIONID");
            Map(x => x.FirstDuePerUnit).Column("FIRSTDUEPERUNIT");
            Map(x => x.SecondDuePerUnit).Column("SECONDDUEPERUNIT");
            Map(x => x.LastDuePerUnit).Column("LASTDUEPERUNIT");
            Map(x => x.NetRate).Column("NETRATE");
            Map(x => x.GrossRate).Column("GROSSRATE");
            Map(x => x.GrossRateAccount).Column("GROSSRATEACCOUNT");
            Map(x => x.AverageLife).Column("AVERAGELIFE");
            Map(x => x.RentalMA).Column("RENTALMA");
            Map(x => x.NumberPayment).Column("NUMBERPAYMENT");
            Map(x => x.FirstDueDate).Column("FIRSTDUEDATE").CustomSqlType("date");
            Map(x => x.LastDueDate).Column("LASTDUEDATE").CustomSqlType("date");
            Map(x => x.RVDueDate).Column("RVDUEDATE").CustomSqlType("date");
            Map(x => x.ResidualValuePerUnit).Column("RESIDUALVALUEPERUNIT");
            Map(x => x.RVDueDateOriginal).Column("RVDUEDATEORIGINAL").CustomSqlType("date");
            Map(x => x.PercentEQ).Column("PERCENTEQ");
            Map(x => x.TotalReceivablePerUnit).Column("TOTALRECEIVABLEPERUNIT");
            Map(x => x.TotalUnearnedPerUnit).Column("TOTALUNEARNEDPERUNIT");
        }
    }
}
