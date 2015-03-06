using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using KTBLeasing.FrontLeasing.Domain;
using KTBLeasing.FrontLeasing;

namespace KTBLeasing.FrontLeasing.Mapping.Orcl {


    public class StipulateLossMap : ClassMap<StipulateLoss>
    {
        public StipulateLossMap()
        {
            Table("AD_STIPULATE_LOSS");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            References(x => x.ApplicationDetail).Column("APP_ID");
            Map(x => x.CommencementLeasePerUnit).Column("CL_PER_UNIT");
            Map(x => x.CommencementLeaseTotal).Column("CL_TOTAL");
            Map(x => x.MonthlyDiminishingAmountFrom).Column("MD_AMOUNT_FROM");
            Map(x => x.MonthlyDiminishingAmountTo).Column("MD_AMOUNT_TO");
            Map(x => x.MonthlyDiminishingPerUnit).Column("MD_PER_UNIT");
            Map(x => x.MonthlyDiminishingTotal).Column("MD_TOTAL");
            Map(x => x.MonthlyDiminishingAmountFrom2).Column("MD_AMOUNT_FROM_2");
            Map(x => x.MonthlyDiminishingAmountTo2).Column("MD_AMOUNT_TO_2");
            Map(x => x.MonthlyDiminishingPerUnit2).Column("MD_PER_UNIT_2");
            Map(x => x.MonthlyDiminishingTotal2).Column("MD_TOTAL_2");
        }
    }
}
